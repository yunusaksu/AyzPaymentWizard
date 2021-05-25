namespace AyzPaymentWizard.Forms
{
    partial class PacketEditForm
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
            this.btnRightPacketEdit = new System.Windows.Forms.Button();
            this.btnLeftPacketEdit = new System.Windows.Forms.Button();
            this.btnEditPacket = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOutAccountInfoEdit = new System.Windows.Forms.ComboBox();
            this.txtPacketEditExp = new System.Windows.Forms.TextBox();
            this.btnPLeft = new System.Windows.Forms.Button();
            this.btnPRight = new System.Windows.Forms.Button();
            this.panelLEd = new System.Windows.Forms.Panel();
            this.labelCurLEd = new System.Windows.Forms.Label();
            this.labelsumLEd = new System.Windows.Forms.Label();
            this.textBoxSumLEd = new System.Windows.Forms.TextBox();
            this.textBox_totalLEd = new System.Windows.Forms.TextBox();
            this.label_totalEd = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGVLeftEdit = new Zuby.ADGV.AdvancedDataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DGVRightEdit = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelodenecek = new System.Windows.Forms.Label();
            this.textBoxodenecek = new System.Windows.Forms.TextBox();
            this.labelCurREd = new System.Windows.Forms.Label();
            this.labelSumEd = new System.Windows.Forms.Label();
            this.textBox_totalREd = new System.Windows.Forms.TextBox();
            this.textBoxsumREd = new System.Windows.Forms.TextBox();
            this.labelsumREd = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelLEd.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeftEdit)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRightEdit)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRightPacketEdit
            // 
            this.btnRightPacketEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRightPacketEdit.Location = new System.Drawing.Point(639, 257);
            this.btnRightPacketEdit.Name = "btnRightPacketEdit";
            this.btnRightPacketEdit.Size = new System.Drawing.Size(47, 44);
            this.btnRightPacketEdit.TabIndex = 10;
            this.btnRightPacketEdit.Text = ">>";
            this.btnRightPacketEdit.UseVisualStyleBackColor = true;
            this.btnRightPacketEdit.Click += new System.EventHandler(this.btnRightPacketEdit_Click);
            // 
            // btnLeftPacketEdit
            // 
            this.btnLeftPacketEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLeftPacketEdit.Location = new System.Drawing.Point(639, 307);
            this.btnLeftPacketEdit.Name = "btnLeftPacketEdit";
            this.btnLeftPacketEdit.Size = new System.Drawing.Size(47, 44);
            this.btnLeftPacketEdit.TabIndex = 11;
            this.btnLeftPacketEdit.Text = "<<";
            this.btnLeftPacketEdit.UseVisualStyleBackColor = true;
            this.btnLeftPacketEdit.Click += new System.EventHandler(this.btnLeftPacketEdit_Click);
            // 
            // btnEditPacket
            // 
            this.btnEditPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPacket.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEditPacket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEditPacket.ForeColor = System.Drawing.Color.White;
            this.btnEditPacket.Location = new System.Drawing.Point(5, 72);
            this.btnEditPacket.Name = "btnEditPacket";
            this.btnEditPacket.Size = new System.Drawing.Size(621, 36);
            this.btnEditPacket.TabIndex = 13;
            this.btnEditPacket.Text = "PAKETİ DÜZENLE";
            this.btnEditPacket.UseVisualStyleBackColor = false;
            this.btnEditPacket.Click += new System.EventHandler(this.btnEditPacket_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "AÇIKLAMA";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(3, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "ÇIKIŞ HESABI";
            // 
            // cmbOutAccountInfoEdit
            // 
            this.cmbOutAccountInfoEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutAccountInfoEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOutAccountInfoEdit.FormattingEnabled = true;
            this.cmbOutAccountInfoEdit.Location = new System.Drawing.Point(160, 38);
            this.cmbOutAccountInfoEdit.Name = "cmbOutAccountInfoEdit";
            this.cmbOutAccountInfoEdit.Size = new System.Drawing.Size(466, 28);
            this.cmbOutAccountInfoEdit.TabIndex = 17;
            // 
            // txtPacketEditExp
            // 
            this.txtPacketEditExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacketEditExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPacketEditExp.Location = new System.Drawing.Point(160, 6);
            this.txtPacketEditExp.Name = "txtPacketEditExp";
            this.txtPacketEditExp.Size = new System.Drawing.Size(466, 26);
            this.txtPacketEditExp.TabIndex = 19;
            // 
            // btnPLeft
            // 
            this.btnPLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPLeft.Location = new System.Drawing.Point(639, 157);
            this.btnPLeft.Name = "btnPLeft";
            this.btnPLeft.Size = new System.Drawing.Size(47, 44);
            this.btnPLeft.TabIndex = 20;
            this.btnPLeft.Text = ">";
            this.btnPLeft.UseVisualStyleBackColor = true;
            this.btnPLeft.Click += new System.EventHandler(this.btnPLeft_Click);
            // 
            // btnPRight
            // 
            this.btnPRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPRight.Location = new System.Drawing.Point(639, 207);
            this.btnPRight.Name = "btnPRight";
            this.btnPRight.Size = new System.Drawing.Size(47, 44);
            this.btnPRight.TabIndex = 21;
            this.btnPRight.Text = "<";
            this.btnPRight.UseVisualStyleBackColor = true;
            this.btnPRight.Click += new System.EventHandler(this.btnPRight_Click);
            // 
            // panelLEd
            // 
            this.panelLEd.Controls.Add(this.labelCurLEd);
            this.panelLEd.Controls.Add(this.labelsumLEd);
            this.panelLEd.Controls.Add(this.textBoxSumLEd);
            this.panelLEd.Controls.Add(this.textBox_totalLEd);
            this.panelLEd.Controls.Add(this.label_totalEd);
            this.panelLEd.Location = new System.Drawing.Point(2, 653);
            this.panelLEd.Name = "panelLEd";
            this.panelLEd.Size = new System.Drawing.Size(631, 27);
            this.panelLEd.TabIndex = 25;
            // 
            // labelCurLEd
            // 
            this.labelCurLEd.AutoSize = true;
            this.labelCurLEd.Location = new System.Drawing.Point(596, 6);
            this.labelCurLEd.Name = "labelCurLEd";
            this.labelCurLEd.Size = new System.Drawing.Size(0, 13);
            this.labelCurLEd.TabIndex = 21;
            // 
            // labelsumLEd
            // 
            this.labelsumLEd.AutoSize = true;
            this.labelsumLEd.Location = new System.Drawing.Point(414, 6);
            this.labelsumLEd.Name = "labelsumLEd";
            this.labelsumLEd.Size = new System.Drawing.Size(31, 13);
            this.labelsumLEd.TabIndex = 20;
            this.labelsumLEd.Text = "Sum:";
            // 
            // textBoxSumLEd
            // 
            this.textBoxSumLEd.Location = new System.Drawing.Point(451, 4);
            this.textBoxSumLEd.Name = "textBoxSumLEd";
            this.textBoxSumLEd.ReadOnly = true;
            this.textBoxSumLEd.Size = new System.Drawing.Size(139, 20);
            this.textBoxSumLEd.TabIndex = 19;
            // 
            // textBox_totalLEd
            // 
            this.textBox_totalLEd.Location = new System.Drawing.Point(68, 3);
            this.textBox_totalLEd.Name = "textBox_totalLEd";
            this.textBox_totalLEd.ReadOnly = true;
            this.textBox_totalLEd.Size = new System.Drawing.Size(70, 20);
            this.textBox_totalLEd.TabIndex = 17;
            // 
            // label_totalEd
            // 
            this.label_totalEd.AutoSize = true;
            this.label_totalEd.Location = new System.Drawing.Point(3, 6);
            this.label_totalEd.Name = "label_totalEd";
            this.label_totalEd.Size = new System.Drawing.Size(59, 13);
            this.label_totalEd.TabIndex = 18;
            this.label_totalEd.Text = "Total rows:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGVLeftEdit);
            this.panel2.Location = new System.Drawing.Point(2, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(631, 646);
            this.panel2.TabIndex = 26;
            // 
            // DGVLeftEdit
            // 
            this.DGVLeftEdit.AllowUserToAddRows = false;
            this.DGVLeftEdit.AllowUserToDeleteRows = false;
            this.DGVLeftEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.DGVLeftEdit.BackgroundColor = System.Drawing.Color.White;
            this.DGVLeftEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLeftEdit.FilterAndSortEnabled = true;
            this.DGVLeftEdit.Location = new System.Drawing.Point(3, 3);
            this.DGVLeftEdit.Name = "DGVLeftEdit";
            this.DGVLeftEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLeftEdit.Size = new System.Drawing.Size(625, 640);
            this.DGVLeftEdit.TabIndex = 27;
            this.DGVLeftEdit.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.DGVLeftEdit_SortStringChanged_1);
            this.DGVLeftEdit.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.DGVLeftEdit_FilterStringChanged_1);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DGVRightEdit);
            this.panel1.Location = new System.Drawing.Point(692, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 519);
            this.panel1.TabIndex = 27;
            // 
            // DGVRightEdit
            // 
            this.DGVRightEdit.AllowUserToAddRows = false;
            this.DGVRightEdit.AllowUserToDeleteRows = false;
            this.DGVRightEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVRightEdit.BackgroundColor = System.Drawing.Color.White;
            this.DGVRightEdit.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DGVRightEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRightEdit.Location = new System.Drawing.Point(4, 3);
            this.DGVRightEdit.Name = "DGVRightEdit";
            this.DGVRightEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRightEdit.Size = new System.Drawing.Size(625, 513);
            this.DGVRightEdit.TabIndex = 13;
            this.DGVRightEdit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRightEdit_CellEndEdit);
            this.DGVRightEdit.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRightEdit_CellEnter);
            this.DGVRightEdit.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVRightEdit_CellFormatting);
            this.DGVRightEdit.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVRightEdit_CellValidating);
            this.DGVRightEdit.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGVRightEdit_CurrentCellDirtyStateChanged);
            this.DGVRightEdit.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVRightEdit_EditingControlShowing);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.labelodenecek);
            this.panel5.Controls.Add(this.textBoxodenecek);
            this.panel5.Controls.Add(this.labelCurREd);
            this.panel5.Controls.Add(this.labelSumEd);
            this.panel5.Controls.Add(this.textBox_totalREd);
            this.panel5.Controls.Add(this.textBoxsumREd);
            this.panel5.Controls.Add(this.labelsumREd);
            this.panel5.Location = new System.Drawing.Point(692, 529);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(629, 39);
            this.panel5.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(178, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "odenecek:";
            // 
            // labelodenecek
            // 
            this.labelodenecek.AutoSize = true;
            this.labelodenecek.Location = new System.Drawing.Point(178, 11);
            this.labelodenecek.Name = "labelodenecek";
            this.labelodenecek.Size = new System.Drawing.Size(58, 13);
            this.labelodenecek.TabIndex = 25;
            this.labelodenecek.Text = "odenecek:";
            // 
            // textBoxodenecek
            // 
            this.textBoxodenecek.Location = new System.Drawing.Point(242, 11);
            this.textBoxodenecek.Name = "textBoxodenecek";
            this.textBoxodenecek.ReadOnly = true;
            this.textBoxodenecek.Size = new System.Drawing.Size(139, 20);
            this.textBoxodenecek.TabIndex = 24;
            // 
            // labelCurREd
            // 
            this.labelCurREd.AutoSize = true;
            this.labelCurREd.Location = new System.Drawing.Point(597, 14);
            this.labelCurREd.Name = "labelCurREd";
            this.labelCurREd.Size = new System.Drawing.Size(0, 13);
            this.labelCurREd.TabIndex = 23;
            // 
            // labelSumEd
            // 
            this.labelSumEd.AutoSize = true;
            this.labelSumEd.Location = new System.Drawing.Point(415, 14);
            this.labelSumEd.Name = "labelSumEd";
            this.labelSumEd.Size = new System.Drawing.Size(31, 13);
            this.labelSumEd.TabIndex = 22;
            this.labelSumEd.Text = "Sum:";
            // 
            // textBox_totalREd
            // 
            this.textBox_totalREd.Location = new System.Drawing.Point(69, 11);
            this.textBox_totalREd.Name = "textBox_totalREd";
            this.textBox_totalREd.ReadOnly = true;
            this.textBox_totalREd.Size = new System.Drawing.Size(70, 20);
            this.textBox_totalREd.TabIndex = 17;
            // 
            // textBoxsumREd
            // 
            this.textBoxsumREd.Location = new System.Drawing.Point(452, 11);
            this.textBoxsumREd.Name = "textBoxsumREd";
            this.textBoxsumREd.ReadOnly = true;
            this.textBoxsumREd.Size = new System.Drawing.Size(139, 20);
            this.textBoxsumREd.TabIndex = 21;
            // 
            // labelsumREd
            // 
            this.labelsumREd.AutoSize = true;
            this.labelsumREd.Location = new System.Drawing.Point(4, 14);
            this.labelsumREd.Name = "labelsumREd";
            this.labelsumREd.Size = new System.Drawing.Size(59, 13);
            this.labelsumREd.TabIndex = 18;
            this.labelsumREd.Text = "Total rows:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEditPacket);
            this.panel3.Controls.Add(this.cmbOutAccountInfoEdit);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtPacketEditExp);
            this.panel3.Location = new System.Drawing.Point(692, 568);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(629, 112);
            this.panel3.TabIndex = 14;
            // 
            // PacketEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 681);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelLEd);
            this.Controls.Add(this.btnPRight);
            this.Controls.Add(this.btnPLeft);
            this.Controls.Add(this.btnLeftPacketEdit);
            this.Controls.Add(this.btnRightPacketEdit);
            this.Name = "PacketEditForm";
            this.Text = "Paket Düzenleme Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PacketEditForm_Load);
            this.panelLEd.ResumeLayout(false);
            this.panelLEd.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeftEdit)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRightEdit)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRightPacketEdit;
        private System.Windows.Forms.Button btnLeftPacketEdit;
        private System.Windows.Forms.Button btnEditPacket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOutAccountInfoEdit;
        private System.Windows.Forms.TextBox txtPacketEditExp;
        private System.Windows.Forms.Button btnPLeft;
        private System.Windows.Forms.Button btnPRight;
        private System.Windows.Forms.Panel panelLEd;
        private System.Windows.Forms.Label labelCurLEd;
        private System.Windows.Forms.Label labelsumLEd;
        private System.Windows.Forms.TextBox textBoxSumLEd;
        private System.Windows.Forms.TextBox textBox_totalLEd;
        private System.Windows.Forms.Label label_totalEd;
        private System.Windows.Forms.Panel panel2;
        private Zuby.ADGV.AdvancedDataGridView DGVLeftEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGVRightEdit;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelCurREd;
        private System.Windows.Forms.Label labelSumEd;
        private System.Windows.Forms.TextBox textBox_totalREd;
        private System.Windows.Forms.TextBox textBoxsumREd;
        private System.Windows.Forms.Label labelsumREd;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelodenecek;
        private System.Windows.Forms.TextBox textBoxodenecek;
    }
}