using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class SqlServerInfosForm : Form
    {
        public SqlServerInfosForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtUserPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtUserPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtUserPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtUserPassword.PasswordChar = '*';
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string EncryptedSqlServerName = EncryptionAlgorithm.Encrytion(txtSqlServerName.Text);
            WriteINI("ServerNameBaslik", "Server", EncryptedSqlServerName, ConnectionHelper.SystemIniPath);
            string EncryptedUserName = EncryptionAlgorithm.Encrytion(txtUsername.Text);
            WriteINI("ServerUserNameBaslik", "ServerUser", EncryptedUserName, ConnectionHelper.SystemIniPath);
            string EncryptedUserPassword = EncryptionAlgorithm.Encrytion(txtUserPassword.Text);
            WriteINI("ServerUserPasswordBaslik", "ServerPass", EncryptedUserPassword, ConnectionHelper.SystemIniPath);
            string EncryptedDatabaseName = EncryptionAlgorithm.Encrytion(txtDatabaseName.Text);
            WriteINI("DatabaseNameBaslik", "Database", EncryptedDatabaseName, ConnectionHelper.SystemIniPath);
            MessageBox.Show("Bilgiler Kaydedildi!", "Bilgi Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SqlServerInfosForm_Load(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString("ServerNameBaslik", "Server", "", sb, sb.Capacity, ConnectionHelper.SystemIniPath);
            txtSqlServerName.Text = EncryptionAlgorithm.Decrytion(sb.ToString());
            GetPrivateProfileString("ServerUserNameBaslik", "ServerUser", "", sb, sb.Capacity, ConnectionHelper.SystemIniPath);
            txtUsername.Text = EncryptionAlgorithm.Decrytion(sb.ToString());
            GetPrivateProfileString("ServerUserPasswordBaslik", "ServerPass", "", sb, sb.Capacity, ConnectionHelper.SystemIniPath);
            txtUserPassword.Text = EncryptionAlgorithm.Decrytion(sb.ToString());
            GetPrivateProfileString("DatabaseNameBaslik", "Database", "", sb, sb.Capacity, ConnectionHelper.SystemIniPath);
            txtDatabaseName.Text = EncryptionAlgorithm.Decrytion(sb.ToString());


            ToolTip showBtnToolTip = new ToolTip();
            showBtnToolTip.SetToolTip(btnShow, "Şifre Göster");
            ToolTip hideBtnToolTip = new ToolTip();
            hideBtnToolTip.SetToolTip(btnHide, "Şifre Gizle");
        }

        private void btnSqlTest_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection("Data Source =" + txtSqlServerName.Text + "; Initial Catalog = " + txtDatabaseName.Text + "; Persist Security Info = True; User ID = " + txtUsername.Text + "; Password = " + txtUserPassword.Text + ""))
                {
                    conn.Open();
                    if ((int)conn.State == 1)
                    {
                        MessageBox.Show("Database Bağlantısı Kuruldu!", "Bağlantı Test Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if ((int)conn.State == 0)
                    {
                        MessageBox.Show("Bağlantı Kapalı!", "Bağlantı Test Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata Meydana Geldi!\n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
