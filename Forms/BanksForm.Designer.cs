namespace AyzPaymentWizard.Forms
{
    partial class BanksForm
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxBankName = new System.Windows.Forms.ComboBox();
            this.txtBankCode = new System.Windows.Forms.TextBox();
            this.txtBranchCode = new System.Windows.Forms.TextBox();
            this.txtFirmName = new System.Windows.Forms.TextBox();
            this.comboBoxBankBranch = new System.Windows.Forms.ComboBox();
            this.btnBankAdd = new System.Windows.Forms.Button();
            this.DGVBank = new System.Windows.Forms.DataGridView();
            this.contextMenuStripBank = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddBankAccountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCustomerNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.btnEdit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVBank)).BeginInit();
            this.contextMenuStripBank.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(14, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Banka";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(14, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Banka Şubesi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(465, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Banka Kodu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(465, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Şube Kodu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(16, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Firma Adı";
            // 
            // comboBoxBankName
            // 
            this.comboBoxBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxBankName.FormattingEnabled = true;
            this.comboBoxBankName.Location = new System.Drawing.Point(128, 19);
            this.comboBoxBankName.Name = "comboBoxBankName";
            this.comboBoxBankName.Size = new System.Drawing.Size(315, 28);
            this.comboBoxBankName.TabIndex = 7;
            this.comboBoxBankName.SelectionChangeCommitted += new System.EventHandler(this.comboBoxBankName_SelectionChangeCommitted);
            // 
            // txtBankCode
            // 
            this.txtBankCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBankCode.Location = new System.Drawing.Point(577, 21);
            this.txtBankCode.Name = "txtBankCode";
            this.txtBankCode.Size = new System.Drawing.Size(317, 26);
            this.txtBankCode.TabIndex = 9;
            // 
            // txtBranchCode
            // 
            this.txtBranchCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtBranchCode.Location = new System.Drawing.Point(577, 58);
            this.txtBranchCode.Name = "txtBranchCode";
            this.txtBranchCode.Size = new System.Drawing.Size(317, 26);
            this.txtBranchCode.TabIndex = 10;
            // 
            // txtFirmName
            // 
            this.txtFirmName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtFirmName.Location = new System.Drawing.Point(128, 103);
            this.txtFirmName.Name = "txtFirmName";
            this.txtFirmName.Size = new System.Drawing.Size(317, 26);
            this.txtFirmName.TabIndex = 11;
            // 
            // comboBoxBankBranch
            // 
            this.comboBoxBankBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxBankBranch.FormattingEnabled = true;
            this.comboBoxBankBranch.Location = new System.Drawing.Point(128, 60);
            this.comboBoxBankBranch.Name = "comboBoxBankBranch";
            this.comboBoxBankBranch.Size = new System.Drawing.Size(315, 28);
            this.comboBoxBankBranch.TabIndex = 12;
            // 
            // btnBankAdd
            // 
            this.btnBankAdd.BackColor = System.Drawing.Color.ForestGreen;
            this.btnBankAdd.FlatAppearance.BorderSize = 0;
            this.btnBankAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBankAdd.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBankAdd.ForeColor = System.Drawing.Color.White;
            this.btnBankAdd.Location = new System.Drawing.Point(1113, 103);
            this.btnBankAdd.Name = "btnBankAdd";
            this.btnBankAdd.Size = new System.Drawing.Size(124, 26);
            this.btnBankAdd.TabIndex = 13;
            this.btnBankAdd.Text = "KAYDET";
            this.btnBankAdd.UseVisualStyleBackColor = false;
            this.btnBankAdd.Click += new System.EventHandler(this.btnBankAdd_Click);
            // 
            // DGVBank
            // 
            this.DGVBank.AllowUserToAddRows = false;
            this.DGVBank.AllowUserToDeleteRows = false;
            this.DGVBank.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVBank.BackgroundColor = System.Drawing.Color.White;
            this.DGVBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVBank.Location = new System.Drawing.Point(20, 206);
            this.DGVBank.MultiSelect = false;
            this.DGVBank.Name = "DGVBank";
            this.DGVBank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVBank.Size = new System.Drawing.Size(1217, 374);
            this.DGVBank.TabIndex = 14;
            this.DGVBank.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DGVBank_CellMouseDown);
            this.DGVBank.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVBank_RowEnter);
            // 
            // contextMenuStripBank
            // 
            this.contextMenuStripBank.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBankAccountToolStripMenuItem});
            this.contextMenuStripBank.Name = "contextMenuStrip1";
            this.contextMenuStripBank.Size = new System.Drawing.Size(170, 26);
            // 
            // AddBankAccountToolStripMenuItem
            // 
            this.AddBankAccountToolStripMenuItem.Name = "AddBankAccountToolStripMenuItem";
            this.AddBankAccountToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.AddBankAccountToolStripMenuItem.Text = "Banka Hesabı Ekle";
            this.AddBankAccountToolStripMenuItem.Click += new System.EventHandler(this.AddBankAccountToolStripMenuItem_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label8.Location = new System.Drawing.Point(15, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 26);
            this.label8.TabIndex = 15;
            this.label8.Text = "BANKALAR";
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCustomerNo.Location = new System.Drawing.Point(577, 103);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Size = new System.Drawing.Size(317, 26);
            this.txtCustomerNo.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(465, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 17;
            this.label1.Text = "Müşteri No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(914, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Statüsü";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Location = new System.Drawing.Point(994, 21);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(243, 28);
            this.comboBoxStatus.TabIndex = 19;
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.SlateGray;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Consolas", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(971, 103);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(124, 26);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "DÜZELT";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // BanksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 592);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCustomerNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.DGVBank);
            this.Controls.Add(this.btnBankAdd);
            this.Controls.Add(this.comboBoxBankBranch);
            this.Controls.Add(this.txtFirmName);
            this.Controls.Add(this.txtBranchCode);
            this.Controls.Add(this.txtBankCode);
            this.Controls.Add(this.comboBoxBankName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BanksForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ÇALIŞILAN BANKALAR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BanksAndBankAccountsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVBank)).EndInit();
            this.contextMenuStripBank.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxBankName;
        private System.Windows.Forms.TextBox txtBankCode;
        private System.Windows.Forms.TextBox txtBranchCode;
        private System.Windows.Forms.TextBox txtFirmName;
        private System.Windows.Forms.ComboBox comboBoxBankBranch;
        private System.Windows.Forms.Button btnBankAdd;
        private System.Windows.Forms.DataGridView DGVBank;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBank;
        private System.Windows.Forms.ToolStripMenuItem AddBankAccountToolStripMenuItem;
        private System.Windows.Forms.TextBox txtCustomerNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Button btnEdit;
    }
}