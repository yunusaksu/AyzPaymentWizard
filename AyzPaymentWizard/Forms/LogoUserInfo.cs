using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class LogoUserInfo : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        public LogoUserInfo()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtLogoUserPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtLogoUserPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtLogoUserPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtLogoUserPassword.PasswordChar = '*';
            }
        }

        private void LogoUserInfo_Load(object sender, EventArgs e)
        {
            ToolTip showBtnToolTip = new ToolTip();
            showBtnToolTip.SetToolTip(btnShow, "Şifre Göster");
            ToolTip hideBtnToolTip = new ToolTip();
            hideBtnToolTip.SetToolTip(btnHide, "Şifre Gizle");
            string username = "", userpassword = "";
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_LOGO_ACCINFO";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    username = dr["LOGO_USERNAME"].ToString();
                    userpassword = dr["LOGO_USERPASSWORD"].ToString();
                }
            }
            txtLogoUserName.Text = username;
            txtLogoUserPassword.Text = EncryptionAlgorithm.Decrytion(userpassword);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "TRUNCATE TABLE AYZ_PW_LOGO_ACCINFO";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    conn.Close();
                }

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "INSERT INTO AYZ_PW_LOGO_ACCINFO(LOGO_USERNAME,LOGO_USERPASSWORD) " +
                                  "\nVALUES('" + txtLogoUserName.Text + "','" + EncryptionAlgorithm.Encrytion(txtLogoUserPassword.Text) + "')";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                }
                MessageBox.Show("Kayıt Başarılı.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata:\n" + ex.Message);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            UnityObjects.UnityApplication UnityApp = new UnityObjects.UnityApplication();
            if (UnityApp.Login(txtLogoUserName.Text, txtLogoUserPassword.Text, Helper.FIRMNR))
                MessageBox.Show("Logo Bağlantısı Kuruldu!","LOGO BAĞLANTISI TEST EKRANI");
            else
                MessageBox.Show("Hatalı Logo Giriş Bilgileri Tespit Edildi!", "Logo Bilgileri Hatalı!");

        }
    }
}
