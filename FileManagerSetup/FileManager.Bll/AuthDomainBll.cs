using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Security.Principal;
using FileManager.BLL;

namespace FileManager.Bll
{
    public class AuthDomainBll
    {

        public bool AuthDomainUser(string domain, string username, string passwd)
        {
            const int LOGON32_LOGON_INTERACTIVE = 2; //通过网络验证账户合法性
            const int LOGON32_PROVIDER_DEFAULT = 0; //使用默认的Windows 2000/NT NTLM验证方
            IntPtr tokenHandle = new IntPtr(0);
            tokenHandle = IntPtr.Zero;

            if (string.IsNullOrEmpty(domain))
            {
                domain = "TELINGA01";
            }
            bool checkok = LogonUser(username, domain, passwd, LOGON32_LOGON_INTERACTIVE, LOGON32_PROVIDER_DEFAULT, ref tokenHandle);
            return checkok;
        }

        [DllImport("advapi32.dll")]
        private static extern bool LogonUser(string lpszUsername, string lpszDomain, string lpszPassword, int dwLogonType, int dwLogonProvider, ref IntPtr phToken);
    }

    public class UserLoginForDomainBll
    {
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_PROVIDER_DEFAULT = 0;

        WindowsImpersonationContext impersonationContext;

        [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
        public static extern int LogonUser(String lpszUserName,
                                          String lpszDomain,
                                          String lpszPassword,
                                          int dwLogonType,
                                          int dwLogonProvider,
                                          ref IntPtr phToken);
        [DllImport("advapi32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
        public extern static int DuplicateToken(IntPtr hToken,
                                          int impersonationLevel,
                                          ref IntPtr hNewToken);
        /// <summary>  
        /// 输入用户名、密码、登录域判断是否成功  
        /// </summary>  
        /// <example>  
        /// if (impersonateValidUser(UserName, Domain, Password)){}  
        /// </example>  
        /// <param name="userName">账户名称，如：string UserName = UserNameTextBox.Text;</param>  
        /// <param name="domain">要登录的域，如：string Domain   = DomainTextBox.Text;</param>  
        /// <param name="password">账户密码, 如：string Password = PasswordTextBox.Text;</param>  
        /// <returns>成功返回true,否则返回false</returns>  
        public bool ImpersonateValidUser(String userName, String domain, String password)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;

            if (LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
            LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                if (DuplicateToken(token, 2, ref tokenDuplicate) != 0)
                {
                    tempWindowsIdentity = new WindowsIdentity(tokenDuplicate);
                    impersonationContext = tempWindowsIdentity.Impersonate();
                    if (impersonationContext != null)
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
        }


        public bool ImpersonateValidUser2(String userName, String domain, String password)
        {
            WindowsIdentity tempWindowsIdentity;
            IntPtr token = IntPtr.Zero;
            IntPtr tokenDuplicate = IntPtr.Zero;

            int retLoginFlag = LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
            LOGON32_PROVIDER_DEFAULT, ref token);

            try
            {
                FileManager.Common.LogHelper.WriteLog("域账号登录测试", string.Format("userName：{0}---domain:{1}---password:{2}---状态码：{3}", userName, domain, password, retLoginFlag));
            }
            catch { }

            if (retLoginFlag != 0)
            //if (LogonUser(userName, domain, password, LOGON32_LOGON_INTERACTIVE,
            //LOGON32_PROVIDER_DEFAULT, ref token) != 0)
            {
                return true;
            }
            else
                return false;
        }


        public bool AuthDomainUserByAdHelper(string username, string domain, string passwd)
        {
            // 获取配置信息
            var config = BLL.SystemConfigBll.GetConfig();
            if (config != null && !string.IsNullOrEmpty(config.Domin) && !string.IsNullOrEmpty(config.DominAdminName))
            {
                // 获取管理员信息
                var adminUserInfo = new ManagerBll().GetModel(config.DominAdminName);
                if (adminUserInfo != null && !string.IsNullOrEmpty(adminUserInfo.UserName) && !string.IsNullOrEmpty(adminUserInfo.Password))
                {
                    Bll.ADHelper.SetADValue(config.Domin, adminUserInfo.UserName, adminUserInfo.Password);
                    ADHelper.LoginResult result = Bll.ADHelper.LoginByAccount(username, passwd);
                    if (result == ADHelper.LoginResult.LOGIN_USER_OK)
                    {
                        return true;
                    }
                    else
                    {
                        result = Bll.ADHelper.Login(username, passwd);
                        return result == ADHelper.LoginResult.LOGIN_USER_OK;
                    }
                }
            }

            return false;
        }

        public bool AuthDomainUserAuth()
        {
            // 获取配置信息
            var config = BLL.SystemConfigBll.GetConfig();
            if (config != null && !string.IsNullOrEmpty(config.Domin) && !string.IsNullOrEmpty(config.DominAdminName))
            {
                // 获取管理员信息
                var adminUserInfo = new ManagerBll().GetModel(config.DominAdminName);
                if (adminUserInfo != null && !string.IsNullOrEmpty(adminUserInfo.UserName) && !string.IsNullOrEmpty(adminUserInfo.Password))
                {
                    ImpersonateValidUser(adminUserInfo.UserName, config.DominAdminName, adminUserInfo.Password);
                }
            }

            return false;
        }

        public void UndoImpersonation()
        {
            impersonationContext.Undo();
        }
        //  
        // TODO: 在此处添加构造函数逻辑  
        //  
    }

}
