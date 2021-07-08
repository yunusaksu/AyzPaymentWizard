using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class SMTP : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        public SMTP()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnTrialMail_Click(object sender, EventArgs e)
        {
            int port = Convert.ToInt32(txtPortNo.Text);
            string smtpServer = txtServerAddress.Text;
            string smtpUserName = txtSmtpUserName.Text; ;
            string smtpUserPass = txtSmtpPassword.Text;

            using (SmtpClient smtpSend = new SmtpClient())
            {
                smtpSend.Host = smtpServer;
                smtpSend.Port = port;

                smtpSend.Credentials = new System.Net.NetworkCredential(txtSenderMailAdress.Text, smtpUserPass);

                smtpSend.EnableSsl = checkboxSecureConnection.Checked;

                MailMessage emailMessage = new System.Net.Mail.MailMessage();

                var testMails = txtTestMailSendingAddresses.Text.ToString().Split(';');
                foreach (var item in testMails)
                {
                    emailMessage.To.Add(item);
                }

                emailMessage.From = new MailAddress(txtSenderMailAdress.Text, smtpUserName);
                emailMessage.Subject = "ÖDEME PAKETİ ONAYI";
                emailMessage.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "Sayın Yetkili <br /><br />";
                htmlBody += "Onaylanmayı bekleyen bir paketiniz vardır:<br /><br />";
                htmlBody += "" + txtURL.Text + ":80/signin.aspx?activate=123<br /><br />";
                htmlBody += "Teşekkür ederiz.";
                emailMessage.Body = htmlBody;

                if (!Regex.IsMatch(emailMessage.Body, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase) ||
                        !Regex.IsMatch(emailMessage.Subject, @"^([0-9a-z!@#\$\%\^&\*\(\)\-=_\+])", RegexOptions.IgnoreCase))
                {
                    emailMessage.BodyEncoding = Encoding.Unicode;
                }

                try
                {
                    smtpSend.Send(emailMessage);
                    MessageBox.Show("Deneme Maili Gönderme Başarılı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SmtpException ex)
                {
                    string msg = "\nSMTP sunucusuna bağlantı başarısız oldu.Bunun sebebi aşağıdaki sebepler olabilir:" +
                                 "\n1- Kimlik doğrulama başarısız oldu." +
                                 "\n2- İşlem zaman aşımına uğradı." +
                                 "\n3- System.Net.Mail.SmtpClient.EnableSsl true olarak ayarlanmış ancak System.Net.Mail.SmtpClient.DeliveryMethod " +
                                 "özelliği System.Net.Mail.SmtpDeliveryMethod.SpecifiedPickupDirectory olarak ayarlandı " +
                                 "\n4- System.Net.Mail.SmtpDeliveryMethod.PickupDirectoryFromIis.Veya System.Net.Mail.SmtpClient.EnableSsl true olarak ayarlandı, ancak SMTP posta sunucusu EHLO komutuna yanıt olarak STARTTLS'yi tanıtmadı. \n";
                    MessageBox.Show("Deneme Maili Gönderme Başarısız!\n " + msg + " \nEk Bilgi:\n" + ex.Message + "", "Uyarı", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information);
                }
                catch (ArgumentNullException ex)
                {
                    MessageBox.Show("Deneme Maili Gönderme Başarısız!\n " + ex.Message + "", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show("Deneme Maili Gönderme Başarısız!\n " + ex.Message + "", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "DELETE FROM AYZ_PW_SMTP_SETTING";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    conn.Close();
                }

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    string encryptionPssword = EncryptionAlgorithm.Encrytion(txtSmtpPassword.Text);
                    CommandText = "INSERT INTO AYZ_PW_SMTP_SETTING" +
                                  "\n(APPROVE_URL, SMTP_SERVERNAME, SMTP_SSL_CONN, SMTP_PORT_NO, SMTP_USERNAME,SMTP_USERPASSWORD,SENDER_MAILADDRESS,TEST_MAILADDRESS)" +
                                  "\nVALUES('" + txtURL.Text + "','" + txtServerAddress.Text + "','" + checkboxSecureConnection.Checked + "'," +
                                  "\n'" + txtPortNo.Text + "','" + txtSmtpUserName.Text + "','" + encryptionPssword + "','" + txtSenderMailAdress.Text + "'," +
                                  "\n'" + txtTestMailSendingAddresses.Text + "'" +
                                  ")";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    MessageBox.Show("Ayarlar Kaydedildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtSmtpPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtSmtpPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtSmtpPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtSmtpPassword.PasswordChar = '*';
            }
        }

        private void SMTP_Load(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM AYZ_PW_SMTP_SETTING";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        txtURL.Text = dr["APPROVE_URL"].ToString();
                        txtServerAddress.Text = dr["SMTP_SERVERNAME"].ToString();
                        checkboxSecureConnection.CheckState = Convert.ToBoolean(dr["SMTP_SSL_CONN"].ToString()) == true ? CheckState.Checked : CheckState.Unchecked;
                        txtPortNo.Text = dr["SMTP_PORT_NO"].ToString();
                        txtSmtpUserName.Text = dr["SMTP_USERNAME"].ToString();
                        txtSmtpPassword.Text = EncryptionAlgorithm.Decrytion(dr["SMTP_USERPASSWORD"].ToString());
                        txtSenderMailAdress.Text = dr["SENDER_MAILADDRESS"].ToString();
                        txtTestMailSendingAddresses.Text = dr["TEST_MAILADDRESS"].ToString();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


            ToolTip showBtnToolTip = new ToolTip();
            showBtnToolTip.SetToolTip(btnShow, "Şifre Göster");
            ToolTip hideBtnToolTip = new ToolTip();
            hideBtnToolTip.SetToolTip(btnHide, "Şifre Gizle");
        }

    }
}

