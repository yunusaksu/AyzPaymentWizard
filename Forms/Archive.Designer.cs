
namespace AyzPaymentWizard.Forms
{
    partial class Archive
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
            this.dataGridViewUnarchived = new System.Windows.Forms.DataGridView();
            this.btnUnArchive = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnarchived)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewUnarchived
            // 
            this.dataGridViewUnarchived.AllowDrop = true;
            this.dataGridViewUnarchived.AllowUserToAddRows = false;
            this.dataGridViewUnarchived.AllowUserToDeleteRows = false;
            this.dataGridViewUnarchived.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewUnarchived.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUnarchived.Location = new System.Drawing.Point(12, 22);
            this.dataGridViewUnarchived.MultiSelect = false;
            this.dataGridViewUnarchived.Name = "dataGridViewUnarchived";
            this.dataGridViewUnarchived.ReadOnly = true;
            this.dataGridViewUnarchived.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUnarchived.Size = new System.Drawing.Size(1129, 402);
            this.dataGridViewUnarchived.TabIndex = 0;
            // 
            // btnUnArchive
            // 
            this.btnUnArchive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUnArchive.Location = new System.Drawing.Point(12, 440);
            this.btnUnArchive.Name = "btnUnArchive";
            this.btnUnArchive.Size = new System.Drawing.Size(174, 45);
            this.btnUnArchive.TabIndex = 1;
            this.btnUnArchive.Text = "Arşivden Çıkar";
            this.btnUnArchive.UseVisualStyleBackColor = true;
            this.btnUnArchive.Click += new System.EventHandler(this.btnUnArchive_Click);
            // 
            // Archive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 497);
            this.Controls.Add(this.btnUnArchive);
            this.Controls.Add(this.dataGridViewUnarchived);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Archive";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arşiv";
            this.Load += new System.EventHandler(this.Archive_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUnarchived)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUnarchived;
        private System.Windows.Forms.Button btnUnArchive;
    }
}