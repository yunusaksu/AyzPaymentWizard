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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("PAKET EKLE");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("PAKET DÜZENLE");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("PAKET ONAY");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("PAKET RET");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("ONAYA YOLLA");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("BANKAYA YOLLA");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("AKİBET AL");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("KULLANICI EKLEME");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("GRUP EKLEME");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("PAKETİ TEKRAR HAZIRLAMAYA YOLLA");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupAddForm));
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.AuthorityTreeView = new System.Windows.Forms.TreeView();
            this.btnGroupSave = new System.Windows.Forms.Button();
            this.dataGridViewGroup = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnNewRecord = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "GRUP ADI";
            // 
            // txtGroupName
            // 
            this.txtGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGroupName.Location = new System.Drawing.Point(169, 18);
            this.txtGroupName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(745, 32);
            this.txtGroupName.TabIndex = 1;
            // 
            // AuthorityTreeView
            // 
            this.AuthorityTreeView.CheckBoxes = true;
            this.AuthorityTreeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.AuthorityTreeView.ForeColor = System.Drawing.SystemColors.GrayText;
            this.AuthorityTreeView.Location = new System.Drawing.Point(169, 59);
            this.AuthorityTreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.AuthorityTreeView.Name = "AuthorityTreeView";
            treeNode1.Name = "PackageAdd";
            treeNode1.Text = "PAKET EKLE";
            treeNode2.Name = "PackageEdit";
            treeNode2.Text = "PAKET DÜZENLE";
            treeNode3.Name = "PackageApprove";
            treeNode3.Text = "PAKET ONAY";
            treeNode4.Name = "PackageReject";
            treeNode4.Text = "PAKET RET";
            treeNode5.Name = "PackageSendToApprove";
            treeNode5.Text = "ONAYA YOLLA";
            treeNode6.Name = "ForwardToBank";
            treeNode6.Text = "BANKAYA YOLLA";
            treeNode7.Name = "PackageAkibetAl";
            treeNode7.Text = "AKİBET AL";
            treeNode8.Name = "AddUser";
            treeNode8.Text = "KULLANICI EKLEME";
            treeNode9.Name = "AddGroup";
            treeNode9.Text = "GRUP EKLEME";
            treeNode10.Name = "TryAgainPackage";
            treeNode10.Text = "PAKETİ TEKRAR HAZIRLAMAYA YOLLA";
            this.AuthorityTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9,
            treeNode10});
            this.AuthorityTreeView.Size = new System.Drawing.Size(745, 267);
            this.AuthorityTreeView.TabIndex = 2;
            // 
            // btnGroupSave
            // 
            this.btnGroupSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGroupSave.FlatAppearance.BorderSize = 0;
            this.btnGroupSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGroupSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGroupSave.ForeColor = System.Drawing.Color.White;
            this.btnGroupSave.Location = new System.Drawing.Point(935, 505);
            this.btnGroupSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGroupSave.Name = "btnGroupSave";
            this.btnGroupSave.Size = new System.Drawing.Size(247, 44);
            this.btnGroupSave.TabIndex = 3;
            this.btnGroupSave.Text = "Kaydet";
            this.btnGroupSave.UseVisualStyleBackColor = false;
            this.btnGroupSave.Click += new System.EventHandler(this.btnGroupSave_Click);
            // 
            // dataGridViewGroup
            // 
            this.dataGridViewGroup.AllowUserToAddRows = false;
            this.dataGridViewGroup.AllowUserToDeleteRows = false;
            this.dataGridViewGroup.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGroup.Location = new System.Drawing.Point(169, 334);
            this.dataGridViewGroup.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewGroup.MultiSelect = false;
            this.dataGridViewGroup.Name = "dataGridViewGroup";
            this.dataGridViewGroup.ReadOnly = true;
            this.dataGridViewGroup.RowHeadersWidth = 51;
            this.dataGridViewGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewGroup.Size = new System.Drawing.Size(747, 215);
            this.dataGridViewGroup.TabIndex = 5;
            this.dataGridViewGroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewGroup_CellContentClick);
            this.dataGridViewGroup.SelectionChanged += new System.EventHandler(this.dataGridViewGroup_SelectionChanged);
            this.dataGridViewGroup.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridViewGroup_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(16, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "GRUPLAR";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(925, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(925, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(16, 138);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "YETKİLER";
            // 
            // btnInfo
            // 
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Image = global::AyzPaymentWizard.Properties.Resources.info;
            this.btnInfo.Location = new System.Drawing.Point(21, 363);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(44, 42);
            this.btnInfo.TabIndex = 8;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnNewRecord
            // 
            this.btnNewRecord.FlatAppearance.BorderSize = 0;
            this.btnNewRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnNewRecord.Image")));
            this.btnNewRecord.Location = new System.Drawing.Point(924, 334);
            this.btnNewRecord.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNewRecord.Name = "btnNewRecord";
            this.btnNewRecord.Size = new System.Drawing.Size(67, 62);
            this.btnNewRecord.TabIndex = 12;
            this.btnNewRecord.UseVisualStyleBackColor = true;
            this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecord_Click);
            // 
            // GroupAddForm
            // 
            this.AcceptButton = this.btnGroupSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1197, 558);
            this.Controls.Add(this.btnNewRecord);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewGroup);
            this.Controls.Add(this.btnGroupSave);
            this.Controls.Add(this.AuthorityTreeView);
            this.Controls.Add(this.txtGroupName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "GroupAddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GRUPLAR";
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
        private System.Windows.Forms.DataGridView dataGridViewGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNewRecord;
    }
}