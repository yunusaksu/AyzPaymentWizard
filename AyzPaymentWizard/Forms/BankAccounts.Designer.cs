namespace AyzPaymentWizard.Forms
{
    partial class BankAccounts
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxAccountNo = new System.Windows.Forms.ComboBox();
            this.comboBoxCurrency = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DGVBankAccount = new System.Windows.Forms.DataGridView();
            this.btnBankAccAdd = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBankAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtTitle.Location = new System.Drawing.Point(152, 26);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(420, 26);
            this.txtTitle.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "HESAP ADI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "BANKA HESABI";
            // 
            // comboBoxAccountNo
            // 
            this.comboBoxAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxAccountNo.FormattingEnabled = true;
            this.comboBoxAccountNo.Location = new System.Drawing.Point(152, 131);
            this.comboBoxAccountNo.Name = "comboBoxAccountNo";
            this.comboBoxAccountNo.Size = new System.Drawing.Size(420, 28);
            this.comboBoxAccountNo.TabIndex = 3;
            // 
            // comboBoxCurrency
            // 
            this.comboBoxCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxCurrency.FormattingEnabled = true;
            this.comboBoxCurrency.Location = new System.Drawing.Point(152, 78);
            this.comboBoxCurrency.Name = "comboBoxCurrency";
            this.comboBoxCurrency.Size = new System.Drawing.Size(420, 28);
            this.comboBoxCurrency.TabIndex = 5;
            this.comboBoxCurrency.SelectionChangeCommitted += new System.EventHandler(this.comboBoxCurrency_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 40);
            this.label3.TabIndex = 4;
            this.label3.Text = "HESAP DÖVİZ\r\nTÜRÜ\r\n";
            // 
            // DGVBankAccount
            // 
            this.DGVBankAccount.AllowUserToAddRows = false;
            this.DGVBankAccount.AllowUserToDeleteRows = false;
            this.DGVBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBankAccount.BackgroundColor = System.Drawing.Color.White;
            this.DGVBankAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBankAccount.Location = new System.Drawing.Point(16, 255);
            this.DGVBankAccount.Name = "DGVBankAccount";
            this.DGVBankAccount.Size = new System.Drawing.Size(1063, 255);
            this.DGVBankAccount.TabIndex = 6;
            // 
            // btnBankAccAdd
            // 
            this.btnBankAccAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBankAccAdd.FlatAppearance.BorderSize = 0;
            this.btnBankAccAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankAccAdd.Font = new System.Drawing.Font("Consolas", 14F, System.Drawing.FontStyle.Bold);
            this.btnBankAccAdd.ForeColor = System.Drawing.Color.White;
            this.btnBankAccAdd.Location = new System.Drawing.Point(152, 174);
            this.btnBankAccAdd.Name = "btnBankAccAdd";
            this.btnBankAccAdd.Size = new System.Drawing.Size(420, 28);
            this.btnBankAccAdd.TabIndex = 7;
            this.btnBankAccAdd.Text = "BANKA HESABI EKLE";
            this.btnBankAccAdd.UseVisualStyleBackColor = false;
            this.btnBankAccAdd.Click += new System.EventHandler(this.btnBankAccAdd_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(11, 226);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(192, 26);
            this.label8.TabIndex = 16;
            this.label8.Text = "BANKA HESAPLARI";
            // 
            // BankAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1091, 513);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnBankAccAdd);
            this.Controls.Add(this.DGVBankAccount);
            this.Controls.Add(this.comboBoxCurrency);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxAccountNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTitle);
            this.Name = "BankAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BANKA HESAPLARI";
            this.Load += new System.EventHandler(this.BankAccounts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBankAccount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxAccountNo;
        private System.Windows.Forms.ComboBox comboBoxCurrency;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView DGVBankAccount;
        private System.Windows.Forms.Button btnBankAccAdd;
        private System.Windows.Forms.Label label8;
    }
}