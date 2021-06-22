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
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("PAKET EKLE");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("PAKET DÜZENLE");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("PAKET ONAY");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("PAKET RET");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("ONAYA YOLLA");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("BANKAYA YOLLA");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("AKİBET AL");
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.AuthorityTreeView = new System.Windows.Forms.TreeView();
            this.btnGroupSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "GRUP ADI";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGroupName.Location = new System.Drawing.Point(127, 15);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(560, 27);
            this.txtGroupName.TabIndex = 1;
            // 
            // AuthorityTreeView
            // 
            this.AuthorityTreeView.CheckBoxes = true;
            this.AuthorityTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AuthorityTreeView.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AuthorityTreeView.Location = new System.Drawing.Point(127, 48);
            this.AuthorityTreeView.Name = "AuthorityTreeView";
            treeNode15.Name = "PackageAdd";
            treeNode15.Text = "PAKET EKLE";
            treeNode16.Name = "PackageEdit";
            treeNode16.Text = "PAKET DÜZENLE";
            treeNode17.Name = "PackageApprove";
            treeNode17.Text = "PAKET ONAY";
            treeNode18.Name = "PackageReject";
            treeNode18.Text = "PAKET RET";
            treeNode19.Name = "PackageSendToApprove";
            treeNode19.Text = "ONAYA YOLLA";
            treeNode20.Name = "ForwardToBank";
            treeNode20.Text = "BANKAYA YOLLA";
            treeNode21.Name = "PackageAkibetAl";
            treeNode21.Text = "AKİBET AL";
            this.AuthorityTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21});
            this.AuthorityTreeView.Size = new System.Drawing.Size(560, 189);
            this.AuthorityTreeView.TabIndex = 2;
            // 
            // btnGroupSave
            // 
            this.btnGroupSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGroupSave.FlatAppearance.BorderSize = 0;
            this.btnGroupSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGroupSave.ForeColor = System.Drawing.Color.White;
            this.btnGroupSave.Location = new System.Drawing.Point(701, 201);
            this.btnGroupSave.Name = "btnGroupSave";
            this.btnGroupSave.Size = new System.Drawing.Size(185, 36);
            this.btnGroupSave.TabIndex = 3;
            this.btnGroupSave.Text = "Kaydet";
            this.btnGroupSave.UseVisualStyleBackColor = false;
            this.btnGroupSave.Click += new System.EventHandler(this.btnGroupSave_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Gray;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(701, 392);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(185, 36);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Düzelt";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AllowUserToAddRows = false;
            this.dataGridViewGroup.AllowUserToDeleteRows = false;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Location = new System.Drawing.Point(127, 253);
            this.dataGridViewGroup.MultiSelect = false;
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroup.Size = new System.Drawing.Size(560, 175);
            this.dataGridViewGroup.TabIndex = 5;
            this.dataGridViewGroup.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroup_RowEnter);
            this.dataGridViewGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewGroup_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(12, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "GRUPLAR";
            // 
            // btnInfo
            // 
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Image = global::AyzPaymentWizard.Properties.Resources.info;
            this.btnInfo.Location = new System.Drawing.Point(16, 276);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(33, 34);
            this.btnInfo.TabIndex = 8;
            this.btnInfo.UseVisualStyleBackColor = true;
            // 
            // GroupAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 436);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewGroup);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnGroupSave);
            this.Controls.Add(this.AuthorityTreeView);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "GroupAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRUP EKLEME EKRANI";
            this.Load += new System.EventHandler(this.GroupAddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.TreeView AuthorityTreeView;
        private System.Windows.Forms.Button btnGroupSave;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInfo;
    }
}