using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace AyzPaymentWizard
{

    public  class ConnectionHelper
    {

        public static string SystemIniPath = Application.StartupPath + @"\System.ini";
        static bool existIni = File.Exists(SystemIniPath);
        
        private static string DecryptionServername = EncryptionAlgorithm.Decrytion(GetServerName());
        private static string DecryptionDatabasename = EncryptionAlgorithm.Decrytion(GetDatabaseName());
        private static string DecryptionServerUsername = EncryptionAlgorithm.Decrytion(GetServerUserName());
        private static string DecryptionServerUserPass = EncryptionAlgorithm.Decrytion(GetUserPass());
        static string server;
        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        private static string GetServerName()
        {
                if (existIni == true)
                {
                StringBuilder sb = new StringBuilder(5000);
                GetPrivateProfileString("ServerNameBaslik", "Server", "", sb, sb.Capacity, SystemIniPath);
                server = sb.ToString();
                return server;

                }
               else
               {
                 throw new Exception("System.INI Dosyasi Bulunamadi");
               }

        }

        private static string GetDatabaseName()
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString("DatabaseNameBaslik", "Database", "", sb, sb.Capacity, SystemIniPath);
            string db = sb.ToString();
            return db;
        }
        private static string GetServerUserName()
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString("ServerUserNameBaslik", "ServerUser", "", sb, sb.Capacity, SystemIniPath);
            string name = sb.ToString();
            return name;
        }


        private static string GetUserPass()
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString("ServerUserPasswordBaslik", "ServerPass", "", sb, sb.Capacity, SystemIniPath);
            string pass = sb.ToString();
            return pass;
        }

        public static string ConnectionString = @"Data Source=" + DecryptionServername + ";Initial Catalog=" + DecryptionDatabasename + "; Persist Security Info=True;User ID=" + DecryptionServerUsername + ";Password=" + DecryptionServerUserPass + "";
    }
}
