namespace AyzPaymentWizard.Forms
{
    partial class DebitClosingForm
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
            this.btnDebitClosing = new System.Windows.Forms.Button();
            this.DGVDebitClosing = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVDebitClosing)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDebitClosing
            // 
            this.btnDebitClosing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDebitClosing.BackColor = System.Drawing.Color.ForestGreen;
            this.btnDebitClosing.FlatAppearance.BorderSize = 0;
            this.btnDebitClosing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebitClosing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDebitClosing.ForeColor = System.Drawing.Color.White;
            this.btnDebitClosing.Location = new System.Drawing.Point(919, 568);
            this.btnDebitClosing.Name = "btnDebitClosing";
            this.btnDebitClosing.Size = new System.Drawing.Size(263, 39);
            this.btnDebitClosing.TabIndex = 0;
            this.btnDebitClosing.Text = "BAŞLAT";
            this.btnDebitClosing.UseVisualStyleBackColor = false;
            this.btnDebitClosing.Click += new System.EventHandler(this.btnDebitClosing_Click);
            // 
            // DGVDebitClosing
            // 
            this.DGVDebitClosing.AllowUserToAddRows = false;
            this.DGVDebitClosing.AllowUserToDeleteRows = false;
            this.DGVDebitClosing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVDebitClosing.BackgroundColor = System.Drawing.Color.White;
            this.DGVDebitClosing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVDebitClosing.Location = new System.Drawing.Point(12, 12);
            this.DGVDebitClosing.Name = "DGVDebitClosing";
            this.DGVDebitClosing.Size = new System.Drawing.Size(1170, 508);
            this.DGVDebitClosing.TabIndex = 1;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 568);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(883, 39);
            this.progressBar.TabIndex = 2;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(407, 540);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(82, 13);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Processing...%0";
            // 
            // DebitClosingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 619);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.DGVDebitClosing);
            this.Controls.Add(this.btnDebitClosing);
            this.Name = "DebitClosingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BORÇ KAPAMA";
            this.Load += new System.EventHandler(this.DebitClosingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVDebitClosing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDebitClosing;
        private System.Windows.Forms.DataGridView DGVDebitClosing;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
    }
}