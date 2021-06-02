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
            this.btnAllToRight = new System.Windows.Forms.Button();
            this.btnAllToLeft = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOutAccountInfo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPacketExp = new System.Windows.Forms.TextBox();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCurL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSumLeftDGV = new System.Windows.Forms.TextBox();
            this.txtTotalLeftDGV = new System.Windows.Forms.TextBox();
            this.label_total = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewLeft = new Zuby.ADGV.AdvancedDataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridViewRight = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelodenR = new System.Windows.Forms.Label();
            this.txtPaidRightDGV = new System.Windows.Forms.TextBox();
            this.labelCurR = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotalRightDGV = new System.Windows.Forms.TextBox();
            this.txtSumRightDGV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.btnCreatePackage.Location = new System.Drawing.Point(7, 82);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(620, 32);
            this.btnCreatePackage.TabIndex = 2;
            this.btnCreatePackage.Text = "PAKETİ OLUŞTUR";
            this.btnCreatePackage.UseVisualStyleBackColor = false;
            this.btnCreatePackage.Click += new System.EventHandler(this.btnCreatePackage_Click);
            // 
            // btnAllToRight
            // 
            this.btnAllToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllToRight.Location = new System.Drawing.Point(642, 295);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(47, 44);
            this.btnAllToRight.TabIndex = 11;
            this.btnAllToRight.Text = ">>";
            this.btnAllToRight.UseVisualStyleBackColor = true;
            this.btnAllToRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllToLeft.Location = new System.Drawing.Point(642, 345);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(47, 44);
            this.btnAllToLeft.TabIndex = 12;
            this.btnAllToLeft.Text = "<<";
            this.btnAllToLeft.UseVisualStyleBackColor = true;
            this.btnAllToLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(3, 14);
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
            this.cmbOutAccountInfo.Location = new System.Drawing.Point(161, 45);
            this.cmbOutAccountInfo.Name = "cmbOutAccountInfo";
            this.cmbOutAccountInfo.Size = new System.Drawing.Size(466, 28);
            this.cmbOutAccountInfo.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(3, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "ÇIKIŞ HESABI";
            // 
            // txtPacketExp
            // 
            this.txtPacketExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacketExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPacketExp.Location = new System.Drawing.Point(161, 8);
            this.txtPacketExp.Name = "txtPacketExp";
            this.txtPacketExp.Size = new System.Drawing.Size(466, 26);
            this.txtPacketExp.TabIndex = 21;
            // 
            // btnToRight
            // 
            this.btnToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToRight.Location = new System.Drawing.Point(642, 191);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(47, 44);
            this.btnToRight.TabIndex = 22;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.btnRightsel_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToLeft.Location = new System.Drawing.Point(642, 241);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(47, 44);
            this.btnToLeft.TabIndex = 23;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.btnLeftsel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCurL);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSumLeftDGV);
            this.panel1.Controls.Add(this.txtTotalLeftDGV);
            this.panel1.Controls.Add(this.label_total);
            this.panel1.Location = new System.Drawing.Point(5, 637);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 38);
            this.panel1.TabIndex = 24;
            // 
            // labelCurL
            // 
            this.labelCurL.AutoSize = true;
            this.labelCurL.Location = new System.Drawing.Point(596, 17);
            this.labelCurL.Name = "labelCurL";
            this.labelCurL.Size = new System.Drawing.Size(0, 13);
            this.labelCurL.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Sum:";
            // 
            // txtSumLeftDGV
            // 
            this.txtSumLeftDGV.Location = new System.Drawing.Point(451, 12);
            this.txtSumLeftDGV.Name = "txtSumLeftDGV";
            this.txtSumLeftDGV.ReadOnly = true;
            this.txtSumLeftDGV.Size = new System.Drawing.Size(139, 20);
            this.txtSumLeftDGV.TabIndex = 19;
            // 
            // txtTotalLeftDGV
            // 
            this.txtTotalLeftDGV.Location = new System.Drawing.Point(68, 14);
            this.txtTotalLeftDGV.Name = "txtTotalLeftDGV";
            this.txtTotalLeftDGV.ReadOnly = true;
            this.txtTotalLeftDGV.Size = new System.Drawing.Size(70, 20);
            this.txtTotalLeftDGV.TabIndex = 17;
            // 
            // label_total
            // 
            this.label_total.AutoSize = true;
            this.label_total.Location = new System.Drawing.Point(3, 17);
            this.label_total.Name = "label_total";
            this.label_total.Size = new System.Drawing.Size(59, 13);
            this.label_total.TabIndex = 18;
            this.label_total.Text = "Total rows:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewLeft);
            this.panel2.Location = new System.Drawing.Point(5, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(634, 640);
            this.panel2.TabIndex = 25;
            // 
            // dataGridViewLeft
            // 
            this.dataGridViewLeft.AllowUserToAddRows = false;
            this.dataGridViewLeft.AllowUserToDeleteRows = false;
            this.dataGridViewLeft.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeft.FilterAndSortEnabled = true;
            this.dataGridViewLeft.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewLeft.Name = "dataGridViewLeft";
            this.dataGridViewLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLeft.Size = new System.Drawing.Size(628, 634);
            this.dataGridViewLeft.TabIndex = 20;
            this.dataGridViewLeft.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.dataGridViewLeft_SortStringChanged_1);
            this.dataGridViewLeft.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.dataGridViewLeft_FilterStringChanged_1);
            this.dataGridViewLeft.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewLeft_CellValueChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridViewRight);
            this.panel3.Location = new System.Drawing.Point(692, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(632, 516);
            this.panel3.TabIndex = 26;
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
            this.dataGridViewRight.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewRight.Name = "dataGridViewRight";
            this.dataGridViewRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRight.Size = new System.Drawing.Size(626, 510);
            this.dataGridViewRight.TabIndex = 24;
            this.dataGridViewRight.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRight_CellEndEdit);
            this.dataGridViewRight.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRight_CellEnter);
            this.dataGridViewRight.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewRight_CellValidating);
            this.dataGridViewRight.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRight_CellValueChanged);
            this.dataGridViewRight.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewRight_CurrentCellDirtyStateChanged);
            this.dataGridViewRight.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewRight_EditingControlShowing);
            this.dataGridViewRight.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewRight_RowsAdded);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnCreatePackage);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.cmbOutAccountInfo);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.txtPacketExp);
            this.panel4.Location = new System.Drawing.Point(692, 561);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(632, 128);
            this.panel4.TabIndex = 25;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.labelodenR);
            this.panel5.Controls.Add(this.txtPaidRightDGV);
            this.panel5.Controls.Add(this.labelCurR);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.txtTotalRightDGV);
            this.panel5.Controls.Add(this.txtSumRightDGV);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Location = new System.Drawing.Point(692, 524);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(632, 39);
            this.panel5.TabIndex = 27;
            // 
            // labelodenR
            // 
            this.labelodenR.AutoSize = true;
            this.labelodenR.Location = new System.Drawing.Point(201, 14);
            this.labelodenR.Name = "labelodenR";
            this.labelodenR.Size = new System.Drawing.Size(60, 13);
            this.labelodenR.TabIndex = 27;
            this.labelodenR.Text = "Ödenecek:";
            // 
            // txtPaidRightDGV
            // 
            this.txtPaidRightDGV.Location = new System.Drawing.Point(265, 10);
            this.txtPaidRightDGV.Name = "txtPaidRightDGV";
            this.txtPaidRightDGV.ReadOnly = true;
            this.txtPaidRightDGV.Size = new System.Drawing.Size(139, 20);
            this.txtPaidRightDGV.TabIndex = 26;
            // 
            // labelCurR
            // 
            this.labelCurR.AutoSize = true;
            this.labelCurR.Location = new System.Drawing.Point(597, 14);
            this.labelCurR.Name = "labelCurR";
            this.labelCurR.Size = new System.Drawing.Size(0, 13);
            this.labelCurR.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(415, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Sum:";
            // 
            // txtTotalRightDGV
            // 
            this.txtTotalRightDGV.Location = new System.Drawing.Point(69, 11);
            this.txtTotalRightDGV.Name = "txtTotalRightDGV";
            this.txtTotalRightDGV.ReadOnly = true;
            this.txtTotalRightDGV.Size = new System.Drawing.Size(70, 20);
            this.txtTotalRightDGV.TabIndex = 17;
            // 
            // txtSumRightDGV
            // 
            this.txtSumRightDGV.Location = new System.Drawing.Point(452, 11);
            this.txtSumRightDGV.Name = "txtSumRightDGV";
            this.txtSumRightDGV.ReadOnly = true;
            this.txtSumRightDGV.Size = new System.Drawing.Size(139, 20);
            this.txtSumRightDGV.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Total rows:";
            // 
            // PacketPreparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 681);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnToLeft);
            this.Controls.Add(this.btnToRight);
            this.Controls.Add(this.btnAllToLeft);
            this.Controls.Add(this.btnAllToRight);
            this.Name = "PacketPreparation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAKET HAZIRLAMA EKRANI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Package_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCreatePackage;
        private System.Windows.Forms.Button btnAllToRight;
        private System.Windows.Forms.Button btnAllToLeft;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbOutAccountInfo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPacketExp;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnToLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTotalLeftDGV;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Panel panel2;
        private Zuby.ADGV.AdvancedDataGridView dataGridViewLeft;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridViewRight;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtTotalRightDGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSumLeftDGV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSumRightDGV;
        private System.Windows.Forms.Label labelCurL;
        private System.Windows.Forms.Label labelCurR;
        private System.Windows.Forms.Label labelodenR;
        private System.Windows.Forms.TextBox txtPaidRightDGV;
    }
}