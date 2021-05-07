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
            this.DGVRightEdit = new System.Windows.Forms.DataGridView();
            this.btnEditPacket = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOutAccountInfoEdit = new System.Windows.Forms.ComboBox();
            this.DGVLeftEdit = new Zuby.ADGV.AdvancedDataGridView();
            this.txtPacketEditExp = new System.Windows.Forms.TextBox();
            this.btnPLeft = new System.Windows.Forms.Button();
            this.btnPRight = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRightEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeftEdit)).BeginInit();
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
            // DGVRightEdit
            // 
            this.DGVRightEdit.AllowUserToAddRows = false;
            this.DGVRightEdit.AllowUserToDeleteRows = false;
            this.DGVRightEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVRightEdit.BackgroundColor = System.Drawing.Color.White;
            this.DGVRightEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRightEdit.Location = new System.Drawing.Point(693, 4);
            this.DGVRightEdit.Name = "DGVRightEdit";
            this.DGVRightEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRightEdit.Size = new System.Drawing.Size(625, 552);
            this.DGVRightEdit.TabIndex = 12;
            this.DGVRightEdit.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVRightEdit_CellFormatting);
            // 
            // btnEditPacket
            // 
            this.btnEditPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPacket.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEditPacket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEditPacket.ForeColor = System.Drawing.Color.White;
            this.btnEditPacket.Location = new System.Drawing.Point(692, 633);
            this.btnEditPacket.Name = "btnEditPacket";
            this.btnEditPacket.Size = new System.Drawing.Size(625, 36);
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
            this.label4.Location = new System.Drawing.Point(689, 568);
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
            this.label5.Location = new System.Drawing.Point(688, 600);
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
            this.cmbOutAccountInfoEdit.Location = new System.Drawing.Point(846, 597);
            this.cmbOutAccountInfoEdit.Name = "cmbOutAccountInfoEdit";
            this.cmbOutAccountInfoEdit.Size = new System.Drawing.Size(472, 28);
            this.cmbOutAccountInfoEdit.TabIndex = 17;
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
            this.DGVLeftEdit.Location = new System.Drawing.Point(12, 4);
            this.DGVLeftEdit.Name = "DGVLeftEdit";
            this.DGVLeftEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLeftEdit.Size = new System.Drawing.Size(621, 665);
            this.DGVLeftEdit.TabIndex = 18;
            this.DGVLeftEdit.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.DGVLeftEdit_SortStringChanged);
            this.DGVLeftEdit.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.DGVLeftEdit_FilterStringChanged);
            // 
            // txtPacketEditExp
            // 
            this.txtPacketEditExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacketEditExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPacketEditExp.Location = new System.Drawing.Point(846, 562);
            this.txtPacketEditExp.Name = "txtPacketEditExp";
            this.txtPacketEditExp.Size = new System.Drawing.Size(472, 26);
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
            // PacketEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 681);
            this.Controls.Add(this.btnPRight);
            this.Controls.Add(this.btnPLeft);
            this.Controls.Add(this.txtPacketEditExp);
            this.Controls.Add(this.DGVLeftEdit);
            this.Controls.Add(this.cmbOutAccountInfoEdit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnEditPacket);
            this.Controls.Add(this.DGVRightEdit);
            this.Controls.Add(this.btnLeftPacketEdit);
            this.Controls.Add(this.btnRightPacketEdit);
            this.Name = "PacketEditForm";
            this.Text = "Paket Düzenleme Ekranı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PacketEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVRightEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeftEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnRightPacketEdit;
        private System.Windows.Forms.Button btnLeftPacketEdit;
        private System.Windows.Forms.Button btnEditPacket;
        private System.Windows.Forms.DataGridView DGVRightEdit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOutAccountInfoEdit;
        private Zuby.ADGV.AdvancedDataGridView DGVLeftEdit;
        private System.Windows.Forms.TextBox txtPacketEditExp;
        private System.Windows.Forms.Button btnPLeft;
        private System.Windows.Forms.Button btnPRight;
    }
}