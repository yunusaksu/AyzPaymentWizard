namespace AyzPaymentWizard
{
    partial class PacketPreparation
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
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOutAccountInfo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridViewLeft = new Zuby.ADGV.AdvancedDataGridView();
            this.dataGridViewRight = new System.Windows.Forms.DataGridView();
            this.txtPacketExp = new System.Windows.Forms.TextBox();
            this.btnRightsel = new System.Windows.Forms.Button();
            this.btnLeftsel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreatePackage
            // 
            this.btnCreatePackage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreatePackage.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCreatePackage.FlatAppearance.BorderSize = 0;
            this.btnCreatePackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCreatePackage.ForeColor = System.Drawing.Color.White;
            this.btnCreatePackage.Location = new System.Drawing.Point(692, 637);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(625, 32);
            this.btnCreatePackage.TabIndex = 2;
            this.btnCreatePackage.Text = "PAKETİ OLUŞTUR";
            this.btnCreatePackage.UseVisualStyleBackColor = false;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRight.Location = new System.Drawing.Point(639, 295);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(47, 44);
            this.btnRight.TabIndex = 11;
            this.btnRight.Text = ">>";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLeft.Location = new System.Drawing.Point(639, 345);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(47, 44);
            this.btnLeft.TabIndex = 12;
            this.btnLeft.Text = "<<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(688, 567);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "AÇIKLAMA";
            // 
            // cmbOutAccountInfo
            // 
            this.cmbOutAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutAccountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOutAccountInfo.FormattingEnabled = true;
            this.cmbOutAccountInfo.Location = new System.Drawing.Point(847, 597);
            this.cmbOutAccountInfo.Name = "cmbOutAccountInfo";
            this.cmbOutAccountInfo.Size = new System.Drawing.Size(470, 28);
            this.cmbOutAccountInfo.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(688, 603);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "ÇIKIŞ HESABI";
            // 
            // dataGridViewLeft
            // 
            this.dataGridViewLeft.AllowUserToAddRows = false;
            this.dataGridViewLeft.AllowUserToDeleteRows = false;
            this.dataGridViewLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewLeft.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeft.FilterAndSortEnabled = true;
            this.dataGridViewLeft.Location = new System.Drawing.Point(5, 5);
            this.dataGridViewLeft.Name = "dataGridViewLeft";
            this.dataGridViewLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLeft.Size = new System.Drawing.Size(628, 664);
            this.dataGridViewLeft.TabIndex = 18;
            this.dataGridViewLeft.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.dataGridViewLeft_SortStringChanged);
            this.dataGridViewLeft.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.dataGridViewLeft_FilterStringChanged);
            // 
            // dataGridViewRight
            // 
            this.dataGridViewRight.AllowUserToAddRows = false;
            this.dataGridViewRight.AllowUserToDeleteRows = false;
            this.dataGridViewRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewRight.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRight.Location = new System.Drawing.Point(692, 5);
            this.dataGridViewRight.Name = "dataGridViewRight";
            this.dataGridViewRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRight.Size = new System.Drawing.Size(625, 550);
            this.dataGridViewRight.TabIndex = 20;
            // 
            // txtPacketExp
            // 
            this.txtPacketExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacketExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPacketExp.Location = new System.Drawing.Point(847, 561);
            this.txtPacketExp.Name = "txtPacketExp";
            this.txtPacketExp.Size = new System.Drawing.Size(470, 26);
            this.txtPacketExp.TabIndex = 21;
            // 
            // btnRightsel
            // 
            this.btnRightsel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRightsel.Location = new System.Drawing.Point(639, 191);
            this.btnRightsel.Name = "btnRightsel";
            this.btnRightsel.Size = new System.Drawing.Size(47, 44);
            this.btnRightsel.TabIndex = 22;
            this.btnRightsel.Text = ">";
            this.btnRightsel.UseVisualStyleBackColor = true;
            this.btnRightsel.Click += new System.EventHandler(this.btnRightsel_Click);
            // 
            // btnLeftsel
            // 
            this.btnLeftsel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLeftsel.Location = new System.Drawing.Point(639, 241);
            this.btnLeftsel.Name = "btnLeftsel";
            this.btnLeftsel.Size = new System.Drawing.Size(47, 44);
            this.btnLeftsel.TabIndex = 23;
            this.btnLeftsel.Text = "<";
            this.btnLeftsel.UseVisualStyleBackColor = true;
            this.btnLeftsel.Click += new System.EventHandler(this.btnLeftsel_Click);
            // 
            // PacketPreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 681);
            this.Controls.Add(this.btnLeftsel);
            this.Controls.Add(this.btnRightsel);
            this.Controls.Add(this.txtPacketExp);
            this.Controls.Add(this.dataGridViewRight);
            this.Controls.Add(this.dataGridViewLeft);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbOutAccountInfo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnCreatePackage);
            this.Name = "PacketPreparation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paket Hazırlama Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Package_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOutAccountInfo;
        private System.Windows.Forms.Label label5;
        private Zuby.ADGV.AdvancedDataGridView dataGridViewLeft;
        private System.Windows.Forms.DataGridView dataGridViewRight;
        private System.Windows.Forms.TextBox txtPacketExp;
        private System.Windows.Forms.Button btnRightsel;
        private System.Windows.Forms.Button btnLeftsel;
    }
}