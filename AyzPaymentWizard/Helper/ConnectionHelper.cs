using AyzPaymentWizard.Forms;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard
{
    public static class ConnectionHelper
    {

        // Projeyi Müşteriye Yüklerken Şu Şekilde Yüklücem
        // AYZ ÖDEME SİHİRBAZI adında bir tane klasör oluşturucam. Bu klasörün içine .exe dosyasını ve System.INI dosyasını yüklücem ve .exe dosyasının ShortCutini 
        // oluşturucam Masaüstünde
        public static string SystemIniPath = Application.StartupPath + "\\System.INI";        

        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        private static string GetServerName()
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString("ServerNameBaslik", "Server", "", sb, sb.Capacity, SystemIniPath);
            string server = sb.ToString();
            return server;
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

        public static string ConnectionString = @"Data Source=" + GetServerName() + ";Initial Catalog=" + GetDatabaseName() + "; Persist Security Info=True;User ID=" + GetServerUserName() + ";Password=" + GetUserPass() + "";
    }
}
