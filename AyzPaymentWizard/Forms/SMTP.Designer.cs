namespace AyzPaymentWizard.Forms
{
    partial class SMTP
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.txtServerAddress = new System.Windows.Forms.TextBox();
            this.checkboxSecureConnection = new System.Windows.Forms.CheckBox();
            this.txtPortNo = new System.Windows.Forms.TextBox();
            this.txtSmtpUserName = new System.Windows.Forms.TextBox();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.txtSenderMailAdress = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnTrialMail = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTestMailSendingAddresses = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "SMTP Sunucu Adresi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(13, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "SMTP Güvenli Bağlantı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "SMTP Port Numarası";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(12, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Gönderici Görünen Ad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(12, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "SMTP Şifre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(13, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Gönderici Mail Adresi";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(12, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Onay İçin URL Adresi";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtURL.Location = new System.Drawing.Point(184, 21);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(500, 27);
            this.txtURL.TabIndex = 8;
            // 
            // txtServerAddress
            // 
            this.txtServerAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtServerAddress.Location = new System.Drawing.Point(184, 64);
            this.txtServerAddress.Name = "txtServerAddress";
            this.txtServerAddress.Size = new System.Drawing.Size(500, 27);
            this.txtServerAddress.TabIndex = 9;
            // 
            // checkboxSecureConnection
            // 
            this.checkboxSecureConnection.AutoSize = true;
            this.checkboxSecureConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkboxSecureConnection.Location = new System.Drawing.Point(184, 123);
            this.checkboxSecureConnection.Name = "checkboxSecureConnection";
            this.checkboxSecureConnection.Size = new System.Drawing.Size(15, 14);
            this.checkboxSecureConnection.TabIndex = 10;
            this.checkboxSecureConnection.UseVisualStyleBackColor = true;
            // 
            // txtPortNo
            // 
            this.txtPortNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPortNo.Location = new System.Drawing.Point(184, 156);
            this.txtPortNo.Name = "txtPortNo";
            this.txtPortNo.Size = new System.Drawing.Size(500, 27);
            this.txtPortNo.TabIndex = 11;
            // 
            // txtSmtpUserName
            // 
            this.txtSmtpUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSmtpUserName.Location = new System.Drawing.Point(184, 206);
            this.txtSmtpUserName.Name = "txtSmtpUserName";
            this.txtSmtpUserName.Size = new System.Drawing.Size(500, 27);
            this.txtSmtpUserName.TabIndex = 12;
            // 
            // txtSmtpPassword
            // 
            this.txtSmtpPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSmtpPassword.Location = new System.Drawing.Point(184, 257);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.PasswordChar = '*';
            this.txtSmtpPassword.Size = new System.Drawing.Size(500, 27);
            this.txtSmtpPassword.TabIndex = 13;
            // 
            // txtSenderMailAdress
            // 
            this.txtSenderMailAdress.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSenderMailAdress.Location = new System.Drawing.Point(184, 309);
            this.txtSenderMailAdress.Name = "txtSenderMailAdress";
            this.txtSenderMailAdress.Size = new System.Drawing.Size(500, 27);
            this.txtSenderMailAdress.TabIndex = 14;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(320, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(179, 38);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(505, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(179, 38);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Vazgeç";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnTrialMail
            // 
            this.btnTrialMail.BackColor = System.Drawing.SystemColors.GrayText;
            this.btnTrialMail.FlatAppearance.BorderSize = 0;
            this.btnTrialMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrialMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTrialMail.ForeColor = System.Drawing.Color.White;
            this.btnTrialMail.Location = new System.Drawing.Point(16, 444);
            this.btnTrialMail.Name = "btnTrialMail";
            this.btnTrialMail.Size = new System.Drawing.Size(216, 38);
            this.btnTrialMail.TabIndex = 17;
            this.btnTrialMail.Text = "Deneme Maili Yolla";
            this.btnTrialMail.UseVisualStyleBackColor = false;
            this.btnTrialMail.Click += new System.EventHandler(this.btnTrialMail_Click);
            // 
            // btnShow
            // 
            this.btnShow.BackColor = System.Drawing.Color.White;
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShow.ForeColor = System.Drawing.Color.Black;
            this.btnShow.Image = global::AyzPaymentWizard.Properties.Resources.show_icon;
            this.btnShow.Location = new System.Drawing.Point(648, 257);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(36, 27);
            this.btnShow.TabIndex = 18;
            this.btnShow.UseVisualStyleBackColor = false;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.White;
            this.btnHide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHide.ForeColor = System.Drawing.Color.Black;
            this.btnHide.Image = global::AyzPaymentWizard.Properties.Resources.hide_icon;
            this.btnHide.Location = new System.Drawing.Point(648, 257);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(36, 27);
            this.btnHide.TabIndex = 19;
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(13, 364);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 34);
            this.label8.TabIndex = 20;
            this.label8.Text = "Test Mail \r\nGönderim Adresi\r\n";
            // 
            // txtTestMailSendingAddresses
            // 
            this.txtTestMailSendingAddresses.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTestMailSendingAddresses.Location = new System.Drawing.Point(184, 371);
            this.txtTestMailSendingAddresses.Name = "txtTestMailSendingAddresses";
            this.txtTestMailSendingAddresses.Size = new System.Drawing.Size(500, 27);
            this.txtTestMailSendingAddresses.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(181, 401);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(513, 18);
            this.label9.TabIndex = 22;
            this.label9.Text = "* Birden fazla mail adresine yollamak istiyorsanız aralarında ; koyarak yazınız.";
            // 
            // SMTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 494);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTestMailSendingAddresses);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnTrialMail);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSenderMailAdress);
            this.Controls.Add(this.txtSmtpPassword);
            this.Controls.Add(this.txtSmtpUserName);
            this.Controls.Add(this.txtPortNo);
            this.Controls.Add(this.checkboxSecureConnection);
            this.Controls.Add(this.txtServerAddress);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SMTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMTP SUNUCU AYARLARI";
            this.Load += new System.EventHandler(this.SMTP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.TextBox txtServerAddress;
        private System.Windows.Forms.CheckBox checkboxSecureConnection;
        private System.Windows.Forms.TextBox txtPortNo;
        private System.Windows.Forms.TextBox txtSmtpUserName;
        private System.Windows.Forms.TextBox txtSmtpPassword;
        private System.Windows.Forms.TextBox txtSenderMailAdress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnTrialMail;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTestMailSendingAddresses;
        private System.Windows.Forms.Label label9;
    }
}