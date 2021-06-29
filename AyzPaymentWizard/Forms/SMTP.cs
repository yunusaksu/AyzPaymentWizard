using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            int port = 587;
            string smtpServer = "smtp.gmail.com";                   // Gmail hesabı için denenmişti
            string smtpUserName = "yunus.aksu.dev@gmail.com";       // Gmail hesabı için denenmişti
            //string smtpServer = "mail.yunusaksu.xyz";
            //string smtpUserName = "info@yunusaksu.xyz";
            string smtpUserPass = "13111035y";

            using (SmtpClient smtpSend = new SmtpClient())
            {
                smtpSend.Host = smtpServer;
                smtpSend.Port = port;

                smtpSend.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpUserPass);

                smtpSend.EnableSsl = true;

                MailMessage emailMessage = new System.Net.Mail.MailMessage();

                emailMessage.To.Add("yunusa@ayz.com.tr");
                emailMessage.From = new MailAddress("dev.yunus.aksu@gmail.com", "Yunus AKSU"); // Gmail hesabı için denenmişti
                //emailMessage.From = new MailAddress("info@yunusaksu.xyz", "yunusaksu.xyz");
                emailMessage.Subject = "ÖDEME PAKETİ ONAYI";
                //emailMessage.Body = "Doğrulama Kodunuz:";
                emailMessage.IsBodyHtml = true;
                string htmlBody;
                htmlBody = "Sayın Fatih Koç <br /><br />";
                htmlBody += "Thank you for registering an account.  Please activate your account by visiting the URL below:<br /><br />";
                htmlBody += "http://" + txtURL.Text + ":80/signin.aspx?activate=123<br /><br />";
                htmlBody += "Thank you.";
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
    }
}

