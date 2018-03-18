using System;
using System.Collections.Generic;
using System.Text;
using System.DirectoryServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using FileManager.Common;

namespace FileManager.Bll
{
    ///
    ///活动目录辅助类。封装一系列活动目录操作相关的方法。
    ///
    public sealed class ADHelper
    {
        ///
        ///域名
        /// 
        public static string DomainName = "MyDomain";
        ///
        /// LDAP 地址
        ///
        public static string LDAPDomain = "DC=MyDomain,DC=local";
        ///
        /// LDAP绑定路径
        ///
        public static string ADPath = "LDAP://brooks.mydomain.local";
        ///
        ///登录帐号
        ///
        public static string ADUser = "Administrator";
        ///
        ///登录密码
        ///
        public static string ADPassword = "password";
        ///
        ///扮演类实例
        ///
        private static IdentityImpersonation impersonate = new IdentityImpersonation(ADUser, ADPassword, DomainName);


        #region  对外公开方法

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dominName"></param>
        /// <param name="adminName"></param>
        /// <param name="adminPwd"></param>
        public static void SetADValue(string dominName, string adminName, string adminPwd)
        {
            ADHelper.DomainName = dominName;
            ADHelper.ADPath = "LDAP://" + dominName; ;
            ADHelper.LDAPDomain = "DC=" + dominName + ",DC=local";
            ADHelper.ADUser = adminName;
            ADHelper.ADPassword = adminPwd;
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="commonName"></param>
        /// <param name="sAMAccountName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool AddNewUser(string commonName, string sAMAccountName, string password)
        {
            try
            {
                DirectoryEntry retObj = CreateNewUser(commonName, sAMAccountName, password);
                if (retObj != null)
                {
                    List<string> groups = new List<string>() { "Administrators" };
                    foreach (var item in groups)
                    {
                        UserAddToGroup(sAMAccountName, item);
                    }
                }

                return retObj != null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                return false;
            }
        }

        private static bool UserAddToGroup(string userName, string groupName)
        {
            try
            {
                AddUserToGroup(userName, groupName);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                return false;
            }
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="sAMAccountName"></param>
        /// <returns></returns>
        public static bool UserExists(string sAMAccountName)
        {
            try
            {
                DirectoryEntry retObj = GetDirectoryEntryByAccount(sAMAccountName);
                return retObj != null;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("Error", ex.Message + "\r\n" + ex.StackTrace);
                return true;
            }
        }
        #endregion

        ///
        ///用户登录验证结果
        ///
        public enum LoginResult
        {
            ///
            ///正常登录
            ///
            LOGIN_USER_OK = 0,
            ///
            ///用户不存在
            ///
            LOGIN_USER_DOESNT_EXIST,
            ///
            ///用户帐号被禁用
            ///
            LOGIN_USER_ACCOUNT_INACTIVE,
            ///
            ///用户密码不正确
            ///
            LOGIN_USER_PASSWORD_INCORRECT
        }

        ///
        ///用户属性定义标志
        ///
        public enum ADS_USER_FLAG_ENUM
        {
            ///
            ///登录脚本标志。如果通过 ADSI LDAP 进行读或写操作时，该标志失效。如果通过 ADSI WINNT，该标志为只读。
            ///
            ADS_UF_SCRIPT = 0X0001,
            ///
            ///用户帐号禁用标志
            ///
            ADS_UF_ACCOUNTDISABLE = 0X0002,
            ///
            ///主文件夹标志
            ///
            ADS_UF_HOMEDIR_REQUIRED = 0X0008,
            ///
            ///过期标志
            ///
            ADS_UF_LOCKOUT = 0X0010,
            ///
            ///用户密码不是必须的
            ///
            ADS_UF_PASSWD_NOTREQD = 0X0020,
            ///
            ///密码不能更改标志
            ///
            ADS_UF_PASSWD_CANT_CHANGE = 0X0040,
            ///
            ///使用可逆的加密保存密码
            ///
            ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080,
            ///
            ///本地帐号标志
            ///
            ADS_UF_TEMP_DUPLICATE_ACCOUNT = 0X0100,
            ///
            ///普通用户的默认帐号类型
            ///
            ADS_UF_NORMAL_ACCOUNT = 0X0200,
            ///
            ///跨域的信任帐号标志
            ///
            ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = 0X0800,
            ///
            ///工作站信任帐号标志
            ///
            ADS_UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
            ///
            ///服务器信任帐号标志
            ///
            ADS_UF_SERVER_TRUST_ACCOUNT = 0X2000,
            ///
            ///密码永不过期标志
            ///
            ADS_UF_DONT_EXPIRE_PASSWD = 0X10000,
            ///
            /// MNS 帐号标志
            ///
            ADS_UF_MNS_LOGON_ACCOUNT = 0X20000,
            ///
            ///交互式登录必须使用智能卡
            ///
            ADS_UF_SMARTCARD_REQUIRED = 0X40000,
            ///
            ///当设置该标志时，服务帐号（用户或计算机帐号）将通过 Kerberos 委托信任
            ///
            ADS_UF_TRUSTED_FOR_DELEGATION = 0X80000,
            ///
            ///当设置该标志时，即使服务帐号是通过 Kerberos 委托信任的，敏感帐号不能被委托
            ///
            ADS_UF_NOT_DELEGATED = 0X100000,
            ///
            ///此帐号需要 DES 加密类型
            ///
            ADS_UF_USE_DES_KEY_ONLY = 0X200000,
            ///
            ///不要进行 Kerberos 预身份验证
            ///
            ADS_UF_DONT_REQUIRE_PREAUTH = 0X4000000,
            ///
            ///用户密码过期标志
            ///
            ADS_UF_PASSWORD_EXPIRED = 0X800000,
            ///
            ///用户帐号可委托标志
            ///
            ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0X1000000
        }

        public ADHelper()
        {
            //
        }

        #region GetDirectoryObject

        ///
        ///获得DirectoryEntry对象实例,以管理员登陆AD
        ///
        ///
        private static DirectoryEntry GetDirectoryObject()
        {
            DirectoryEntry entry = new DirectoryEntry(ADPath, ADUser, ADPassword, AuthenticationTypes.Secure);
            return entry;
        }

        ///
        ///根据指定用户名和密码获得相应DirectoryEntry实体
        ///
        ///
        ///
        ///
        private static DirectoryEntry GetDirectoryObject(string userName, string password)
        {
            DirectoryEntry entry = new DirectoryEntry(ADPath, userName, password, AuthenticationTypes.None);
            return entry;
        }

        ///
        /// i.e. /CN=Users,DC=creditsights, DC=cyberelves, DC=Com
        ///
        ///
        ///
        private static DirectoryEntry GetDirectoryObject(string domainReference)
        {
            DirectoryEntry entry = new DirectoryEntry(ADPath + domainReference, ADUser, ADPassword, AuthenticationTypes.Secure);
            return entry;
        }

        ///
        ///获得以UserName,Password创建的DirectoryEntry
        ///
        ///
        ///
        ///
        ///
        private static DirectoryEntry GetDirectoryObject(string domainReference, string userName, string password)
        {
            DirectoryEntry entry = new DirectoryEntry(ADPath + domainReference, userName, password, AuthenticationTypes.Secure);
            return entry;
        }

        #endregion

        #region GetDirectoryEntry

        /// <summary>
        /// 根据用户公共名称取得用户的 对象
        /// </summary>
        /// <param name="commonName">用户公共名称</param>
        /// <returns>如果找到该用户，则返回用户的 对象；否则返回 null</returns>
        public static DirectoryEntry GetDirectoryEntry(string commonName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(cn=" + commonName + "))";
            deSearch.SearchScope = SearchScope.Subtree;

            try
            {
                SearchResult result = deSearch.FindOne();
                de = new DirectoryEntry(result.Path);
                return de;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户公共名称和密码取得用户的
        /// </summary>
        /// <param name="commonName">用户公共名称</param>
        /// <param name="password">用户密码</param>
        /// <returns>如果找到该用户，则返回用户的 对象；否则返回 null</returns>
        public static DirectoryEntry GetDirectoryEntry(string commonName, string password)
        {
            DirectoryEntry de = GetDirectoryObject(commonName, password);
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(cn=" + commonName + "))";
            deSearch.SearchScope = SearchScope.Subtree;

            try
            {
                SearchResult result = deSearch.FindOne();
                de = new DirectoryEntry(result.Path);
                return de;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户帐号称取得用户的 对象
        /// </summary>
        /// <param name="sAMAccountName">用户帐号名</param>
        /// <returns>如果找到该用户，则返回用户的 对象；否则返回 null</returns>
        public static DirectoryEntry GetDirectoryEntryByAccount(string sAMAccountName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(sAMAccountName=" + sAMAccountName + "))";
            deSearch.SearchScope = SearchScope.Subtree;

            try
            {
                SearchResult result = deSearch.FindOne();
                de = new DirectoryEntry(result.Path);
                return de;
            }
            catch
            {

                return null;
            }
        }

        /// <summary>
        /// 根据用户帐号和密码取得用户的 对象
        /// </summary>
        /// <param name="sAMAccountName">用户帐号名</param>
        /// <param name="password">用户密码</param>
        /// <returns>如果找到该用户，则返回用户的 对象；否则返回 null</returns>
        public static DirectoryEntry GetDirectoryEntryByAccount(string sAMAccountName, string password)
        {
            DirectoryEntry de = GetDirectoryEntryByAccount(sAMAccountName);
            if (de != null)
            {
                string commonName = de.Properties["cn"][0].ToString();

                if (GetDirectoryEntry(commonName, password) != null)
                    return GetDirectoryEntry(commonName, password);
                else
                    return null;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据组名取得用户组的 对象
        /// </summary>
        /// <param name="groupName">组名</param>
        /// <returns></returns>
        public static DirectoryEntry GetDirectoryEntryOfGroup(string groupName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(objectClass=group)(cn=" + groupName + "))";
            deSearch.SearchScope = SearchScope.Subtree;

            try
            {
                SearchResult result = deSearch.FindOne();
                de = new DirectoryEntry(result.Path);
                return de;
            }
            catch
            {
                return null;
            }
        }

        #endregion

        #region GetProperty

        ///
        ///获得指定 指定属性名对应的值
        ///
        ///
        ///
        ///属性名称 
        ///属性值
        public static string GetProperty(DirectoryEntry de, string propertyName)
        {
            if (de.Properties.Contains(propertyName))
            {
                return de.Properties[propertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        ///
        ///获得指定搜索结果 中指定属性名对应的值
        ///
        ///
        ///
        ///属性名称 
        ///属性值
        public static string GetProperty(SearchResult searchResult, string propertyName)
        {
            if (searchResult.Properties.Contains(propertyName))
            {
                return searchResult.Properties[propertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        #endregion

        ///
        ///设置指定 的属性值
        ///
        ///
        ///
        ///属性名称 
        ///
        ///属性值 
        public static void SetProperty(DirectoryEntry de, string propertyName, string propertyValue)
        {
            if (propertyValue != string.Empty || propertyValue != "" || propertyValue != null)
            {
                if (de.Properties.Contains(propertyName))
                {
                    de.Properties[propertyName][0] = propertyValue;
                }
                else
                {
                    de.Properties[propertyName].Add(propertyValue);
                }
            }
        }

        ///
        ///创建新的用户
        ///
        ///
        ///DN 位置。例如：OU=共享平台 或 CN=Users 
        ///
        ///公共名称 
        ///
        ///帐号 

        ///
        ///密码 
        ///
        public static DirectoryEntry CreateNewUser(string ldapDN, string commonName, string sAMAccountName, string password)
        {
            DirectoryEntry entry = GetDirectoryObject();
            DirectoryEntry subEntry = entry.Children.Find(ldapDN);
            DirectoryEntry deUser = subEntry.Children.Add("CN=" + commonName, "user");
            deUser.Properties["sAMAccountName"].Value = sAMAccountName;
            deUser.CommitChanges();
            ADHelper.EnableUser(commonName);
            ADHelper.SetPassword(commonName, password);
            deUser.Close();
            return deUser;
        }

        ///
        ///创建新的用户。默认创建在 Users 单元下。
        ///
        ///
        ///公共名称 
        ///
        ///帐号 
        ///
        ///密码 
        ///
        public static DirectoryEntry CreateNewUser(string commonName, string sAMAccountName, string password)
        {
            return CreateNewUser("CN=Users", commonName, sAMAccountName, password);
        }

        ///
        ///判断指定公共名称的用户是否存在
        ///
        ///
        ///用户公共名称 
        ///如果存在，返回 true；否则返回 false
        public static bool IsUserExists(string commonName)
        {
            DirectoryEntry de = GetDirectoryObject();
            DirectorySearcher deSearch = new DirectorySearcher(de);
            deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(cn=" + commonName + "))";       // LDAP 查询串
            SearchResultCollection results = deSearch.FindAll();

            if (results.Count == 0)
                return false;
            else
                return true;
        }

        ///
        ///判断用户帐号是否激活
        ///
        ///
        ///用户帐号属性控制器 
        ///如果用户帐号已经激活，返回 true；否则返回 false
        public static bool IsAccountActive(int userAccountControl)
        {
            int userAccountControl_Disabled = Convert.ToInt32(ADS_USER_FLAG_ENUM.ADS_UF_ACCOUNTDISABLE);
            int flagExists = userAccountControl & userAccountControl_Disabled;

            if (flagExists > 0)
                return false;
            else
                return true;
        }

        ///
        ///判断用户与密码是否足够以满足身份验证进而登录
        ///
        ///
        ///用户公共名称 
        ///
        ///密码 
        ///如能可正常登录，则返回 true；否则返回 false
        public static LoginResult Login(string commonName, string password)
        {
            DirectoryEntry de = GetDirectoryEntry(commonName);

            if (de != null)
            {
                // 必须在判断用户密码正确前，对帐号激活属性进行判断；否则将出现异常。
                int userAccountControl = Convert.ToInt32(de.Properties["userAccountControl"][0]);
                de.Close();

                if (!IsAccountActive(userAccountControl))
                    return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;

                if (GetDirectoryEntry(commonName, password) != null)
                    return LoginResult.LOGIN_USER_OK;
                else
                    return LoginResult.LOGIN_USER_PASSWORD_INCORRECT;
            }
            else
            {
                return LoginResult.LOGIN_USER_DOESNT_EXIST;
            }
        }

        ///
        ///判断用户帐号与密码是否足够以满足身份验证进而登录
        ///
        ///
        ///用户帐号 
        ///
        ///密码 
        ///如能可正常登录，则返回 true；否则返回 false
        public static LoginResult LoginByAccount(string sAMAccountName, string password)
        {
            DirectoryEntry de = GetDirectoryEntryByAccount(sAMAccountName);

            if (de != null)
            {
                // 必须在判断用户密码正确前，对帐号激活属性进行判断；否则将出现异常。
                int userAccountControl = Convert.ToInt32(de.Properties["userAccountControl"][0]);
                de.Close();

                if (!IsAccountActive(userAccountControl))
                    return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;

                if (GetDirectoryEntryByAccount(sAMAccountName, password) != null)
                    return LoginResult.LOGIN_USER_OK;
                else
                    return LoginResult.LOGIN_USER_PASSWORD_INCORRECT;
            }
            else
            {
                return LoginResult.LOGIN_USER_DOESNT_EXIST;
            }
        }

        ///
        ///设置用户密码，管理员可以通过它来修改指定用户的密码。
        ///
        ///
        ///用户公共名称 
        ///
        ///用户新密码 
        public static void SetPassword(string commonName, string newPassword)
        {
            DirectoryEntry de = GetDirectoryEntry(commonName);

            // 模拟超级管理员，以达到有权限修改用户密码
            impersonate.BeginImpersonate();
            de.Invoke("SetPassword", new object[] { newPassword });
            impersonate.StopImpersonate();

            de.Close();
        }

        ///
        ///设置帐号密码，管理员可以通过它来修改指定帐号的密码。
        ///
        ///
        ///用户帐号 
        ///
        ///用户新密码 
        public static void SetPasswordByAccount(string sAMAccountName, string newPassword)
        {
            DirectoryEntry de = GetDirectoryEntryByAccount(sAMAccountName);

            // 模拟超级管理员，以达到有权限修改用户密码
            IdentityImpersonation impersonate = new IdentityImpersonation(ADUser, ADPassword, DomainName);
            impersonate.BeginImpersonate();
            de.Invoke("SetPassword", new object[] { newPassword });
            impersonate.StopImpersonate();

            de.Close();
        }

        ///
        ///修改用户密码
        ///
        ///
        ///用户公共名称 
        ///
        ///旧密码 
        ///
        ///新密码 
        public static void ChangeUserPassword(string commonName, string oldPassword, string newPassword)
        {
            // to-do: 需要解决密码策略问题
            DirectoryEntry oUser = GetDirectoryEntry(commonName);
            oUser.Invoke("ChangePassword", new Object[] { oldPassword, newPassword });
            oUser.Close();
        }

        ///
        ///启用指定公共名称的用户
        ///
        ///
        ///用户公共名称 
        public static void EnableUser(string commonName)
        {
            EnableUser(GetDirectoryEntry(commonName));
        }

        ///
        ///启用指定 的用户
        ///
        ///
        public static void EnableUser(DirectoryEntry de)
        {
            impersonate.BeginImpersonate();
            de.Properties["userAccountControl"][0] = ADHelper.ADS_USER_FLAG_ENUM.ADS_UF_NORMAL_ACCOUNT | ADHelper.ADS_USER_FLAG_ENUM.ADS_UF_DONT_EXPIRE_PASSWD;
            de.CommitChanges();
            impersonate.StopImpersonate();
            de.Close();
        }

        ///
        ///禁用指定公共名称的用户
        ///
        ///
        ///用户公共名称 
        public static void DisableUser(string commonName)
        {
            DisableUser(GetDirectoryEntry(commonName));
        }

        ///
        ///禁用指定 的用户
        ///
        ///
        public static void DisableUser(DirectoryEntry de)
        {
            impersonate.BeginImpersonate();
            de.Properties["userAccountControl"][0] = ADHelper.ADS_USER_FLAG_ENUM.ADS_UF_NORMAL_ACCOUNT | ADHelper.ADS_USER_FLAG_ENUM.ADS_UF_DONT_EXPIRE_PASSWD | ADHelper.ADS_USER_FLAG_ENUM.ADS_UF_ACCOUNTDISABLE;
            de.CommitChanges();
            impersonate.StopImpersonate();
            de.Close();
        }

        ///
        ///将指定的用户添加到指定的组中。默认为 Users 下的组和用户。
        ///
        ///
        ///用户公共名称 
        ///
        ///组名 
        public static void AddUserToGroup(string userCommonName, string groupName)
        {
            DirectoryEntry oGroup = GetDirectoryEntryOfGroup(groupName);
            DirectoryEntry oUser = GetDirectoryEntry(userCommonName);

            impersonate.BeginImpersonate();
            oGroup.Properties["member"].Add(oUser.Properties["distinguishedName"].Value);
            oGroup.CommitChanges();
            impersonate.StopImpersonate();

            oGroup.Close();
            oUser.Close();
        }

        ///
        ///将用户从指定组中移除。默认为 Users 下的组和用户。
        ///
        ///
        ///用户公共名称 
        ///
        ///组名 
        public static void RemoveUserFromGroup(string userCommonName, string groupName)
        {
            DirectoryEntry oGroup = GetDirectoryEntryOfGroup(groupName);
            DirectoryEntry oUser = GetDirectoryEntry(userCommonName);

            impersonate.BeginImpersonate();
            oGroup.Properties["member"].Remove(oUser.Properties["distinguishedName"].Value);
            oGroup.CommitChanges();
            impersonate.StopImpersonate();

            oGroup.Close();
            oUser.Close();
        }

    }

    ///
    ///用户模拟角色类。实现在程序段内进行用户角色模拟。
    ///
    public class IdentityImpersonation
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(String lpszUsername, String lpszDomain, String lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public extern static bool DuplicateToken(IntPtr ExistingTokenHandle, int SECURITY_IMPERSONATION_LEVEL, ref IntPtr DuplicateTokenHandle);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public extern static bool CloseHandle(IntPtr handle);

        // 要模拟的用户的用户名、密码、域(机器名)
        private String _sImperUsername;
        private String _sImperPassword;
        private String _sImperDomain;
        // 记录模拟上下文
        private WindowsImpersonationContext _imperContext;
        private IntPtr _adminToken;
        private IntPtr _dupeToken;
        // 是否已停止模拟
        private Boolean _bClosed;


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="impersonationUsername">所要模拟的用户的用户名</param>
        /// <param name="impersonationPassword">所要模拟的用户的密码</param>
        /// <param name="impersonationDomain">所要模拟的用户所在的域</param>
        public IdentityImpersonation(String impersonationUsername, String impersonationPassword, String impersonationDomain)
        {
            _sImperUsername = impersonationUsername;
            _sImperPassword = impersonationPassword;
            _sImperDomain = impersonationDomain;

            _adminToken = IntPtr.Zero;
            _dupeToken = IntPtr.Zero;
            _bClosed = true;
        }

        ///
        ///析构函数
        ///
        ~IdentityImpersonation()
        {
            if (!_bClosed)
            {
                StopImpersonate();
            }
        }

        ///
        ///开始身份角色模拟。
        ///
        ///
        public Boolean BeginImpersonate()
        {
            Boolean bLogined = LogonUser(_sImperUsername, _sImperDomain, _sImperPassword, 2, 0, ref _adminToken);

            if (!bLogined)
            {
                return false;
            }

            Boolean bDuped = DuplicateToken(_adminToken, 2, ref _dupeToken);

            if (!bDuped)
            {
                return false;
            }

            WindowsIdentity fakeId = new WindowsIdentity(_dupeToken);
            _imperContext = fakeId.Impersonate();

            _bClosed = false;

            return true;
        }

        ///
        ///停止身分角色模拟。
        ///
        public void StopImpersonate()
        {
            if (_imperContext != null)
            {
                _imperContext.Undo();
            }
            CloseHandle(_dupeToken);
            CloseHandle(_adminToken);
            _bClosed = true;
        }
    }
}

/////=====================================================

/////简单的应用

/////[WebMethod]
//  public string IsAuthenticated(string UserID,string Password)
//  {
//            string _path = "LDAP://" + adm + "/DC=lamda,DC=com,DC=cn";//"LDAP://172.75.200.1/DC=名字,DC=com,DC=cn";
//   string _filterAttribute=null;

//   DirectoryEntry entry = new DirectoryEntry(_path,UserID,Password);

//   try
//   {
//    //Bind to the native AdsObject to force authentication.
//    DirectorySearcher search = new DirectorySearcher(entry);
//    search.Filter = "(SAMAccountName=" + UserID + ")";
//    SearchResult result = search.FindOne();

//    if(null == result)
//    {
//     _filterAttribute="登录失败: 未知的用户名或错误密码.";
//    }
//    else
//    {
//     _filterAttribute="true";
//    }

//   }
//   catch (Exception ex)
//   {
////    if(ex.Message.StartsWith("该服务器不可操作")) 
////    {
////     string mail = ADO.GetConnString("mail");
////     entry.Path = "LDAP://"+mail+"/OU=名字,DC=it2004,DC=gree,DC=com,DC=cn";
////     try
////     { 
////      DirectorySearcher search = new DirectorySearcher(entry);
////      search.Filter = "(SAMAccountName=" + UserID + ")";
////      SearchResult result = search.FindOne();
////
////      if(null == result)
////      {
////       _filterAttribute="登录失败: 未知的用户名或错误密码.";
////      }
////      else
////      {
////       _filterAttribute="true";
////      }
////      return _filterAttribute;
////   
////     }
////     catch (Exception ex1)
////     {
////      return ex1.Message;
////     }
////     
////    }
////    else
//     return ex.Message;
//   }
//   return _filterAttribute;
//  }
//  [WebMethod]
//  public string[] LDAPMessage(string UserID)
//  {
//   string _path = "LDAP://"+adm+"/DC=it2004,DC=名字,DC=com,DC=cn";
//   string[] _filterAttribute=new string[5];
//   string[] msg = {"samaccountname","displayname","department","company"};

//   DirectoryEntry entry = new DirectoryEntry(_path,"180037","790813");


//   try
//   { 


//    Object obj = entry.NativeObject;

//    DirectorySearcher search = new DirectorySearcher(entry);
//    search.Filter = "(SAMAccountName=" + UserID + ")";
//    SearchResult result = search.FindOne();


//    if(null == result)
//    {
//     _filterAttribute[0]="登录失败: 未知的用户名或错误密码.";
//    }
//    else
//    {
//     _filterAttribute[0]="true";  
//     for(int propertyCounter = 1; propertyCounter < 5; propertyCounter++)
//     {

//      if(propertyCounter==4 &&  result.Properties[msg[propertyCounter-1]][0]==null)
//       break;
//      _filterAttribute[propertyCounter]=result.Properties[msg[propertyCounter-1]][0].ToString();

//     }
//    }

//   }
//   catch (Exception ex)
//   {
//    //_filterAttribute[0]=ex.Message;
//   }
//   return _filterAttribute;
//  }
//  [WebMethod]
//  public string[] AllMembers() 
//  {

//   string[] msg;
//   string _path = "LDAP://名字";

//   DirectoryEntry entry = new DirectoryEntry(_path,"180037","790813");


//   //Bind to the native AdsObject to force authentication.
//   Object obj = entry.NativeObject;

//   System.DirectoryServices.DirectorySearcher mySearcher = new System.DirectoryServices.DirectorySearcher(entry);
//   mySearcher.Filter = "(SAMAccountName=180037)";
//   msg=new string[mySearcher.FindAll().Count];
//   int i=0;
//   foreach(System.DirectoryServices.SearchResult result in mySearcher.FindAll()) 
//   {
//    msg[i++]=result.Path;
//   }
//   return msg;
//  }
//}

