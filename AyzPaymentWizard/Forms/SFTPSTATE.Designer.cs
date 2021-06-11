namespace AyzPaymentWizard.Forms
{
    partial class SFTPSTATE
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
            this.DGVSFTPSTATE = new System.Windows.Forms.DataGridView();
            this.btnToExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSFTPSTATE)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVSFTPSTATE
            // 
            this.DGVSFTPSTATE.AllowUserToAddRows = false;
            this.DGVSFTPSTATE.AllowUserToDeleteRows = false;
            this.DGVSFTPSTATE.BackgroundColor = System.Drawing.Color.White;
            this.DGVSFTPSTATE.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.DGVSFTPSTATE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVSFTPSTATE.Location = new System.Drawing.Point(12, 12);
            this.DGVSFTPSTATE.MultiSelect = false;
            this.DGVSFTPSTATE.Name = "DGVSFTPSTATE";
            this.DGVSFTPSTATE.ReadOnly = true;
            this.DGVSFTPSTATE.Size = new System.Drawing.Size(937, 347);
            this.DGVSFTPSTATE.TabIndex = 0;
            this.DGVSFTPSTATE.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVSFTPSTATE_CellFormatting);
            // 
            // btnToExcel
            // 
            this.btnToExcel.FlatAppearance.BorderSize = 0;
            this.btnToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToExcel.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnToExcel.Location = new System.Drawing.Point(12, 361);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(151, 43);
            this.btnToExcel.TabIndex = 1;
            this.btnToExcel.Text = "Excel\'e Aktar";
            this.btnToExcel.UseVisualStyleBackColor = true;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // SFTPSTATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 410);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.DGVSFTPSTATE);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SFTPSTATE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFTP BAĞLANTI HAREKETLERİ";
            this.Load += new System.EventHandler(this.SFTPSTATE_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSFTPSTATE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVSFTPSTATE;
        private System.Windows.Forms.Button btnToExcel;
    }
}