using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AyzPaymentWizard
{
    public partial class LoginForm : Form
    {

        SqlConnection conn;
        SqlCommand command = new SqlCommand();
        SqlDataReader dr;
        public LoginForm()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        bool WriteINI(string SectionName, string KeyName, string StringToWrite, string INIFileName)
        {
            bool Return;
            Return = WritePrivateProfileString(SectionName, KeyName, StringToWrite, INIFileName);
            return Return;
        }

        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);


        private void LoginScreenExitLabel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var userName = txtLoginName.Text;
            var password = txtLoginPassword.Text;

            string encryptionText = EncryptionAlgorithm.Encrytion(password);
            string decryptionText = EncryptionAlgorithm.Decrytion(encryptionText);
            command.CommandText = "SELECT ID, FIRMNR FROM [AYZ_PW_USER] " +
                "\nWHERE NAME = '" + userName + "' AND PASSWORD = '" + encryptionText + "' AND FIRMNR = '" + Convert.ToInt32(cmbFirms.Text) + "'";
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş geçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtLoginPassword.Text == PasswordRead() && txtLoginName.Text == UserRead())
                {
                    Helper.USERID = 0; // Admin için USERID SIFIRDIR(0).
                    Helper.USERNAME = userName;
                    Helper.FIRMNR = Convert.ToInt32(cmbFirms.Text);
                    GetLogoUsernameAndUserPassword();
                    Anasayfa form = new Anasayfa();
                    form.Show();
                    this.Hide();
                }
                else if (dr.HasRows)
                {
                    int id = 0;
                    int firmNr = 0;
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr["ID"].ToString());
                        firmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    }
                    Helper.USERID = id;
                    Helper.USERNAME = userName;
                    Helper.FIRMNR = firmNr;
                    Anasayfa form = new Anasayfa();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ve/veya şifre yanlış.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            conn.Close();
        }

        private void GetLogoUsernameAndUserPassword()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                command.CommandText = "SELECT * FROM AYZ_PW_LOGO_ACCINFO";
                command.Connection = conn;
                conn.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Helper.LOGOUSERNAME = dr["LOGO_USERNAME"].ToString();
                    Helper.LOGOUSERPASS = EncryptionAlgorithm.Decrytion(dr["LOGO_USERPASSWORD"].ToString());
                }
            }
        }

        private string UserRead()
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniData generateData = parser.ReadFile(ConnectionHelper.SystemIniPath);

            //Reading the Content of the File
            string AdminuserName = generateData["AdminNameBaslik"]["AdminUser"].ToString();
            string user = EncryptionAlgorithm.Decrytion(AdminuserName);
            return user;
        }

        private string PasswordRead()
        {
            StringBuilder sb2 = new StringBuilder(5000);
            GetPrivateProfileString("AdminPassWordBaslik", "AdminPassword", "", sb2, sb2.Capacity, ConnectionHelper.SystemIniPath);
            string password = EncryptionAlgorithm.Decrytion(sb2.ToString());
            return password;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(ConnectionHelper.ConnectionString);
                IsExistDatabase();
                SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString);
                SqlCommand cmd2 = new SqlCommand("SELECT NR FROM L_CAPIFIRM", conn2);
                conn2.Open();
                DataTable tbl2 = new DataTable();
                tbl2.Load(cmd2.ExecuteReader());
                conn.Close();

#if DEBUG
                txtLoginName.Text = UserRead();
                txtLoginPassword.Text = PasswordRead();
#endif

                cmbFirms.DataSource = tbl2;
                cmbFirms.DisplayMember = "NR";
                cmbFirms.ValueMember = "NR";

                ToolTip showBtnToolTip = new ToolTip();
                showBtnToolTip.SetToolTip(btnShow, "Şifre Göster");
                ToolTip hideBtnToolTip = new ToolTip();
                hideBtnToolTip.SetToolTip(btnHide, "Şifre Gizle");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "UYARI");
                Application.Exit();
            }
        }

        private void IsExistDatabase()
        {
            string path = Application.StartupPath + @"\CreateDatabaseTables";

            #region AppStartPath'de veritabanı create dosyalarının koyulacağı dosya yoksa create edilir.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            #endregion

            #region AppStartPath'de veritabanı güncelleme dosyalarının koyulacağı dosya yoksa create edilir.
            string path2 = Application.StartupPath + @"\UpdateDatabaseTables";
            if (!Directory.Exists(path2))
            {
                Directory.CreateDirectory(path2);
            }
            #endregion


            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                command.CommandText = "SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME LIKE '%AYZ_PW%'";
                command.Connection = conn;
                conn.Open();
                dr = command.ExecuteReader();
                if (dr.HasRows == false)
                {

                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    foreach (FileInfo item in directoryInfo.GetFiles())
                    {
                        string script = File.ReadAllText(path + @"\" + item + "");
                        // split script on GO command
                        IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                        using (SqlConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            connection.Open();
                            foreach (string commandString in commandStrings)
                            {
                                if (commandString.Trim() != "")
                                {
                                    using (var command = new SqlCommand(commandString, connection))
                                    {
                                        try
                                        {
                                            command.ExecuteNonQuery();
                                        }
                                        catch (SqlException ex)
                                        {
                                            string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
                                            MessageBox.Show(string.Format("Please check the SqlServer script.\nFile: {0} \nLine: {1} \nError: {2} \nSQL Command: \n{3}", Application.StartupPath + "" + item + "", ex.LineNumber, ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtLoginName_DoubleClick(object sender, EventArgs e)
        {
            txtLoginName.Text = "";
        }

        private void txtLoginPassword_DoubleClick(object sender, EventArgs e)
        {
            txtLoginPassword.Text = "";
        }        

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtLoginPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtLoginPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtLoginPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtLoginPassword.PasswordChar = '*';
            }
        }

    }
}
