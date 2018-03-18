using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace FileManager.Common
{
    /// <summary>
    /// 系统异常帮组
    /// </summary>
    public class CustomException : Exception
    {
        private string errorMessage;
        private string methodName;
        private string stackTrace;

        public CustomException() { }

        /// <summary>
        /// 业务类异常，可以不用记录日志
        /// </summary>
        /// <param name="errorMessage"></param>
        public CustomException(string errorMessage)
            : base(errorMessage)
        {

        }

        /// <summary>
        /// 需要异步记录日志
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="innerException"></param>
        public CustomException(string errorMessage, Exception innerException)
            : base(errorMessage, innerException)
        {
            this.methodName = innerException.TargetSite.Name;
            this.errorMessage = errorMessage;
            this.stackTrace = innerException.StackTrace;
            new Thread(new ThreadStart(this.WriteLog)).Start();
        }

        public override Exception GetBaseException()
        {
            return this;
        }

        public override string ToString()
        {
            return base.GetType().FullName;
        }

        private void WriteLog()
        {
            this.WriteLog(this.methodName, this.errorMessage, this.stackTrace);
        }

        /// <summary>
        /// 异常记录
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="errorMessage"></param>
        /// <param name="stackTrace"></param>
        private void WriteLog(string methodName, string errorMessage, string stackTrace)
        {
            try
            {
                string str = string.Format(@"{0}\Log", System.Environment.CurrentDirectory);
                string path = string.Format(@"{0}\{1}_{2}.log", str, methodName, DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
                using (FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    string s = string.Concat(new object[] { "输出时间：", DateTime.Now, Environment.NewLine, "　→　输出信息：", errorMessage, Environment.NewLine, "　→　堆栈信息：", stackTrace, Environment.NewLine, Environment.NewLine });
                    byte[] bytes = Encoding.UTF8.GetBytes(s);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (IOException exception)
            {
                throw new IOException(exception.Message, exception);
            }
        }
    }
}
