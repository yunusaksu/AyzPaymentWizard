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
            this.dataGridViewPaging = new In.Sontx.SimpleDataGridViewPaging.DataGridViewPaging();
            this.btnToExcel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dataGridViewPaging
            // 
            this.dataGridViewPaging.AutoHideNavigator = false;
            this.dataGridViewPaging.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewPaging.DataSource = null;
            this.dataGridViewPaging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewPaging.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewPaging.MaxRecords = 100;
            this.dataGridViewPaging.Name = "dataGridViewPaging";
            this.dataGridViewPaging.Size = new System.Drawing.Size(1281, 502);
            this.dataGridViewPaging.TabIndex = 2;
            // 
            // btnToExcel
            // 
            this.btnToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnToExcel.BackColor = System.Drawing.Color.White;
            this.btnToExcel.FlatAppearance.BorderSize = 0;
            this.btnToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToExcel.ForeColor = System.Drawing.Color.ForestGreen;
            this.btnToExcel.Location = new System.Drawing.Point(0, 464);
            this.btnToExcel.Name = "btnToExcel";
            this.btnToExcel.Size = new System.Drawing.Size(170, 38);
            this.btnToExcel.TabIndex = 3;
            this.btnToExcel.Text = "Excel\'e Aktar";
            this.btnToExcel.UseVisualStyleBackColor = false;
            this.btnToExcel.Click += new System.EventHandler(this.btnToExcel_Click);
            // 
            // SFTPSTATE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1281, 502);
            this.Controls.Add(this.btnToExcel);
            this.Controls.Add(this.dataGridViewPaging);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SFTPSTATE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SFTP BAĞLANTI HAREKETLERİ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SFTPSTATE_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private In.Sontx.SimpleDataGridViewPaging.DataGridViewPaging dataGridViewPaging;
        private System.Windows.Forms.Button btnToExcel;
    }
}