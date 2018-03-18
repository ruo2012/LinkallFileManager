using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using FileManager.Common;
using FileManager.BLL;

namespace FileManager
{
    public class FileAutoUpload
    {
        public static string AutoUpload = string.Empty;

        private static object uploadlock =new object();

        public static void SetAutoUploadSign(string valule)
        {
            lock (uploadlock)
            {
                AutoUpload = valule;
            }
        }
    }
}
