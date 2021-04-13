namespace AyzPaymentWizard
{
    partial class GroupAddForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Paket Ekle");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Paket Düzenle");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Paket Onay");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Paket Ret");
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.yetkiTreeView = new System.Windows.Forms.TreeView();
            this.btnGroupSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(60, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Grup Adı";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGroupName.Location = new System.Drawing.Point(152, 50);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(560, 27);
            this.txtGroupName.TabIndex = 1;
            // 
            // yetkiTreeView
            // 
            this.yetkiTreeView.CheckBoxes = true;
            this.yetkiTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yetkiTreeView.ForeColor = System.Drawing.SystemColors.GrayText;
            this.yetkiTreeView.Location = new System.Drawing.Point(152, 83);
            this.yetkiTreeView.Name = "yetkiTreeView";
            treeNode1.Name = "PackageAdd";
            treeNode1.Text = "Paket Ekle";
            treeNode2.Name = "PackageEdit";
            treeNode2.Text = "Paket Düzenle";
            treeNode3.Name = "PackageApprove";
            treeNode3.Text = "Paket Onay";
            treeNode4.Name = "PackageReject";
            treeNode4.Text = "Paket Ret";
            this.yetkiTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            this.yetkiTreeView.Size = new System.Drawing.Size(560, 226);
            this.yetkiTreeView.TabIndex = 2;
            // 
            // btnGroupSave
            // 
            this.btnGroupSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGroupSave.FlatAppearance.BorderSize = 0;
            this.btnGroupSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGroupSave.ForeColor = System.Drawing.Color.White;
            this.btnGroupSave.Location = new System.Drawing.Point(152, 315);
            this.btnGroupSave.Name = "btnGroupSave";
            this.btnGroupSave.Size = new System.Drawing.Size(560, 36);
            this.btnGroupSave.TabIndex = 3;
            this.btnGroupSave.Text = "Kaydet";
            this.btnGroupSave.UseVisualStyleBackColor = false;
            this.btnGroupSave.Click += new System.EventHandler(this.btnGroupSave_Click);
            // 
            // GroupAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGroupSave);
            this.Controls.Add(this.yetkiTreeView);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.Name = "GroupAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grup Ekleme Ekranı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TreeView yetkiTreeView;
        private System.Windows.Forms.Button btnGroupSave;
    }
}