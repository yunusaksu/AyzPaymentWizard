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

namespace AyzPaymentWizard
{
    public partial class LoginForm : Form
    {
        SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
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
            command.CommandText = "SELECT ID, FIRMNR FROM [AYZ_PW_USER] WHERE NAME = '" + userName + "' AND PASSWORD = '" + password + "'";
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kullanıcı adı ve/veya şifre boş geçilemez.", "Uyarı");
            }
            else
            {
                if (txtLoginName.Text == UserRead() && txtLoginPassword.Text == PasswordRead())
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
                    while(dr.Read())
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
                    MessageBox.Show("Kullanıcı adı ve/veya şifre yanlış.", "Uyarı");
                }
            }
            conn.Close();
        }

        private void GetLogoUsernameAndUserPassword()
        {
            string username = "", userpassword = "";
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                command.CommandText = "SELECT * FROM AYZ_PW_LOGO_ACCINFO";
                command.Connection = conn;
                conn.Open();
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    Helper.LOGOUSERNAME = dr["LOGO_USERNAME"].ToString();
                    Helper.LOGOUSERPASS = dr["LOGO_USERPASSWORD"].ToString();
                }
            }
        }

        private string UserRead()
        {
            StringBuilder sb = new StringBuilder(5000);
            GetPrivateProfileString("KullaniciBaslik", "KullaniciAdi", "", sb, sb.Capacity, "C:\\Users\\yunus\\Desktop\\System.ini");
            string user = sb.ToString();
            return user;
        }

        private string PasswordRead()
        {
            StringBuilder sb2 = new StringBuilder(5000);
            GetPrivateProfileString("PasswordBaslik", "Password", "", sb2, sb2.Capacity, "C:\\Users\\yunus\\Desktop\\System.ini");
            string password = sb2.ToString();
            return password;
        }             

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtLoginName.Text = "Admin";
            txtLoginPassword.Text = "admin";
            SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("SELECT NR FROM L_CAPIFIRM", conn2);
            conn2.Open();
            DataTable tbl2 = new DataTable();
            tbl2.Load(cmd2.ExecuteReader());
            conn.Close();

            cmbFirms.DataSource = tbl2;
            cmbFirms.DisplayMember = "NR";
            cmbFirms.ValueMember = "NR";
            cmbFirms.Hide();
            labelFirma.Hide();

            ToolTip showBtnToolTip = new ToolTip();
            showBtnToolTip.SetToolTip(btnShow, "Şifre Göster");
            ToolTip hideBtnToolTip = new ToolTip();
            hideBtnToolTip.SetToolTip(btnHide, "Şifre Gizle");
        }

        private void txtLoginName_DoubleClick(object sender, EventArgs e)
        {
            txtLoginName.Text = "";
            btnLogin.Location = new Point(60, 245);
            cmbFirms.Hide();
            labelFirma.Hide();
            LoginForm.ActiveForm.Size = new Size(351, 348);
        }

        private void txtLoginPassword_DoubleClick(object sender, EventArgs e)
        {
            txtLoginPassword.Text = "";
        }

        private void txtLoginName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtLoginName.Text.ToUpper() == "ADMİN")
            {
                labelFirma.Show();
                cmbFirms.Show();
                btnLogin.Location = new Point(60, 300);
                cmbFirms.Location = new Point(60, 262);
                LoginForm.ActiveForm.Size = new Size(351, 380);
            }
            else
            {
                btnLogin.Location = new Point(60, 245);
                cmbFirms.Hide();
                labelFirma.Hide();
                LoginForm.ActiveForm.Size = new Size(351, 348);
            }
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
