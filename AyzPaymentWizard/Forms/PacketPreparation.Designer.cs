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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketPreparation));
            this.btnCreatePackage = new System.Windows.Forms.Button();
            this.btnAllToRight = new System.Windows.Forms.Button();
            this.btnAllToLeft = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbOutAccountInfo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPacketExp = new System.Windows.Forms.TextBox();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnToLeft = new System.Windows.Forms.Button();
            this.dataGridViewLeft = new Zuby.ADGV.AdvancedDataGridView();
            this.dataGridViewRight = new System.Windows.Forms.DataGridView();
            this.txtSumLeftDGV = new System.Windows.Forms.TextBox();
            this.txtTotalLeftDGV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel11 = new System.Windows.Forms.Panel();
            this.labelCurL = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.collapsibleSplitContainer1 = new SoftGee.CollapsibleSplitContainer();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.labelCurR = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPaidRightDGV = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTotalRightDGV = new System.Windows.Forms.TextBox();
            this.txtSumRightDGV = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).BeginInit();
            this.collapsibleSplitContainer1.Panel1.SuspendLayout();
            this.collapsibleSplitContainer1.Panel2.SuspendLayout();
            this.collapsibleSplitContainer1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel17.SuspendLayout();
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
            this.btnCreatePackage.Location = new System.Drawing.Point(5, 118);
            this.btnCreatePackage.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreatePackage.Name = "btnCreatePackage";
            this.btnCreatePackage.Size = new System.Drawing.Size(804, 39);
            this.btnCreatePackage.TabIndex = 2;
            this.btnCreatePackage.Text = "PAKETİ OLUŞTUR";
            this.btnCreatePackage.UseVisualStyleBackColor = false;
            this.btnCreatePackage.Click += new System.EventHandler(this.BtnCreatePackage_Click);
            // 
            // btnAllToRight
            // 
            this.btnAllToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllToRight.Location = new System.Drawing.Point(-3, 118);
            this.btnAllToRight.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(49, 32);
            this.btnAllToRight.TabIndex = 11;
            this.btnAllToRight.Text = ">>";
            this.btnAllToRight.UseVisualStyleBackColor = true;
            this.btnAllToRight.Click += new System.EventHandler(this.BtnRight_Click);
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllToLeft.Location = new System.Drawing.Point(-3, 117);
            this.btnAllToLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(49, 33);
            this.btnAllToLeft.TabIndex = 12;
            this.btnAllToLeft.Text = "<<";
            this.btnAllToLeft.UseVisualStyleBackColor = true;
            this.btnAllToLeft.Click += new System.EventHandler(this.BtnLeft_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(4, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "AÇIKLAMA";
            // 
            // cmbOutAccountInfo
            // 
            this.cmbOutAccountInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbOutAccountInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbOutAccountInfo.FormattingEnabled = true;
            this.cmbOutAccountInfo.Location = new System.Drawing.Point(211, 73);
            this.cmbOutAccountInfo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOutAccountInfo.Name = "cmbOutAccountInfo";
            this.cmbOutAccountInfo.Size = new System.Drawing.Size(596, 33);
            this.cmbOutAccountInfo.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(4, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "ÇIKIŞ HESABI";
            // 
            // txtPacketExp
            // 
            this.txtPacketExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacketExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPacketExp.Location = new System.Drawing.Point(211, 27);
            this.txtPacketExp.Margin = new System.Windows.Forms.Padding(4);
            this.txtPacketExp.Name = "txtPacketExp";
            this.txtPacketExp.Size = new System.Drawing.Size(596, 30);
            this.txtPacketExp.TabIndex = 21;
            // 
            // btnToRight
            // 
            this.btnToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToRight.Location = new System.Drawing.Point(-3, 80);
            this.btnToRight.Margin = new System.Windows.Forms.Padding(4);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(49, 31);
            this.btnToRight.TabIndex = 22;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.BtnRightsel_Click);
            // 
            // btnToLeft
            // 
            this.btnToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToLeft.Location = new System.Drawing.Point(-1, 80);
            this.btnToLeft.Margin = new System.Windows.Forms.Padding(4);
            this.btnToLeft.Name = "btnToLeft";
            this.btnToLeft.Size = new System.Drawing.Size(48, 30);
            this.btnToLeft.TabIndex = 23;
            this.btnToLeft.Text = "<";
            this.btnToLeft.UseVisualStyleBackColor = true;
            this.btnToLeft.Click += new System.EventHandler(this.BtnLeftsel_Click);
            // 
            // dataGridViewLeft
            // 
            this.dataGridViewLeft.AllowUserToAddRows = false;
            this.dataGridViewLeft.AllowUserToDeleteRows = false;
            this.dataGridViewLeft.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewLeft.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewLeft.FilterAndSortEnabled = true;
            this.dataGridViewLeft.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewLeft.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewLeft.Name = "dataGridViewLeft";
            this.dataGridViewLeft.RowHeadersWidth = 51;
            this.dataGridViewLeft.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewLeft.Size = new System.Drawing.Size(761, 614);
            this.dataGridViewLeft.TabIndex = 20;
            this.dataGridViewLeft.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.DataGridViewLeft_SortStringChanged_1);
            this.dataGridViewLeft.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.DataGridViewLeft_FilterStringChanged_1);
            this.dataGridViewLeft.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewLeft_CellValueChanged);
            // 
            // dataGridViewRight
            // 
            this.dataGridViewRight.AllowUserToAddRows = false;
            this.dataGridViewRight.AllowUserToDeleteRows = false;
            this.dataGridViewRight.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewRight.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRight.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRight.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridViewRight.Name = "dataGridViewRight";
            this.dataGridViewRight.RowHeadersWidth = 51;
            this.dataGridViewRight.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRight.Size = new System.Drawing.Size(810, 457);
            this.dataGridViewRight.TabIndex = 24;
            this.dataGridViewRight.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRight_CellEndEdit);
            this.dataGridViewRight.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRight_CellEnter);
            this.dataGridViewRight.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DataGridViewRight_CellValidating);
            this.dataGridViewRight.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewRight_CellValueChanged);
            this.dataGridViewRight.CurrentCellDirtyStateChanged += new System.EventHandler(this.DataGridViewRight_CurrentCellDirtyStateChanged);
            this.dataGridViewRight.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DataGridViewRight_EditingControlShowing);
            this.dataGridViewRight.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DataGridViewRight_RowsAdded);
            // 
            // txtSumLeftDGV
            // 
            this.txtSumLeftDGV.Location = new System.Drawing.Point(461, 12);
            this.txtSumLeftDGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtSumLeftDGV.Name = "txtSumLeftDGV";
            this.txtSumLeftDGV.ReadOnly = true;
            this.txtSumLeftDGV.Size = new System.Drawing.Size(229, 22);
            this.txtSumLeftDGV.TabIndex = 19;
            // 
            // txtTotalLeftDGV
            // 
            this.txtTotalLeftDGV.Location = new System.Drawing.Point(91, 17);
            this.txtTotalLeftDGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalLeftDGV.Name = "txtTotalLeftDGV";
            this.txtTotalLeftDGV.ReadOnly = true;
            this.txtTotalLeftDGV.Size = new System.Drawing.Size(217, 22);
            this.txtTotalLeftDGV.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total rows:";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(4, -27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "AÇIKLAMA";
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.labelCurL);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Controls.Add(this.txtSumLeftDGV);
            this.panel11.Controls.Add(this.txtTotalLeftDGV);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 6);
            this.panel11.Margin = new System.Windows.Forms.Padding(4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(761, 46);
            this.panel11.TabIndex = 26;
            // 
            // labelCurL
            // 
            this.labelCurL.AutoSize = true;
            this.labelCurL.Location = new System.Drawing.Point(717, 16);
            this.labelCurL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurL.Name = "labelCurL";
            this.labelCurL.Size = new System.Drawing.Size(0, 17);
            this.labelCurL.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(795, 21);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 17);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sum:";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.btnToLeft);
            this.panel6.Controls.Add(this.btnAllToLeft);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(48, 666);
            this.panel6.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox5.Location = new System.Drawing.Point(215, -34);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(582, 30);
            this.textBox5.TabIndex = 21;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnCreatePackage);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.label4);
            this.panel9.Controls.Add(this.textBox5);
            this.panel9.Controls.Add(this.cmbOutAccountInfo);
            this.panel9.Controls.Add(this.label5);
            this.panel9.Controls.Add(this.txtPacketExp);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 48);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(810, 161);
            this.panel9.TabIndex = 29;
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.collapsibleSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.collapsibleSplitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.collapsibleSplitContainer1.Name = "collapsibleSplitContainer1";
            // 
            // collapsibleSplitContainer1.Panel1
            // 
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.panel7);
            this.collapsibleSplitContainer1.Panel1.Controls.Add(this.panel13);
            // 
            // collapsibleSplitContainer1.Panel2
            // 
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panel14);
            this.collapsibleSplitContainer1.Panel2.Controls.Add(this.panel6);
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1704, 670);
            this.collapsibleSplitContainer1.SplitterButtonBitmap = ((System.Drawing.Bitmap)(resources.GetObject("collapsibleSplitContainer1.SplitterButtonBitmap")));
            this.collapsibleSplitContainer1.SplitterButtonPosition = SoftGee.ButtonPosition.Center;
            this.collapsibleSplitContainer1.SplitterButtonStyle = SoftGee.ButtonStyle.PushButton;
            this.collapsibleSplitContainer1.SplitterDistance = 813;
            this.collapsibleSplitContainer1.SplitterWidth = 29;
            this.collapsibleSplitContainer1.TabIndex = 28;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(761, 666);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(761, 666);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.dataGridViewLeft);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Margin = new System.Windows.Forms.Padding(4);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(761, 614);
            this.panel12.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 614);
            this.panel10.Margin = new System.Windows.Forms.Padding(4);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(761, 52);
            this.panel10.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel13.Controls.Add(this.btnToRight);
            this.panel13.Controls.Add(this.btnAllToRight);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(761, 0);
            this.panel13.Margin = new System.Windows.Forms.Padding(4);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(48, 666);
            this.panel13.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(48, 0);
            this.panel14.Margin = new System.Windows.Forms.Padding(4);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(810, 666);
            this.panel14.TabIndex = 2;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.dataGridViewRight);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(1);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(810, 457);
            this.panel15.TabIndex = 1;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel9);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Location = new System.Drawing.Point(0, 457);
            this.panel16.Margin = new System.Windows.Forms.Padding(1);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(810, 209);
            this.panel16.TabIndex = 0;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.labelCurR);
            this.panel17.Controls.Add(this.label11);
            this.panel17.Controls.Add(this.txtPaidRightDGV);
            this.panel17.Controls.Add(this.label14);
            this.panel17.Controls.Add(this.label12);
            this.panel17.Controls.Add(this.txtTotalRightDGV);
            this.panel17.Controls.Add(this.txtSumRightDGV);
            this.panel17.Controls.Add(this.label13);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Margin = new System.Windows.Forms.Padding(1);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(810, 48);
            this.panel17.TabIndex = 28;
            // 
            // labelCurR
            // 
            this.labelCurR.AutoSize = true;
            this.labelCurR.Location = new System.Drawing.Point(789, 17);
            this.labelCurR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelCurR.Name = "labelCurR";
            this.labelCurR.Size = new System.Drawing.Size(0, 17);
            this.labelCurR.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.ForeColor = System.Drawing.Color.DarkGreen;
            this.label11.Location = new System.Drawing.Point(520, 19);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.TabIndex = 27;
            this.label11.Text = "Ödenecek:";
            // 
            // txtPaidRightDGV
            // 
            this.txtPaidRightDGV.Location = new System.Drawing.Point(619, 14);
            this.txtPaidRightDGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtPaidRightDGV.Name = "txtPaidRightDGV";
            this.txtPaidRightDGV.ReadOnly = true;
            this.txtPaidRightDGV.Size = new System.Drawing.Size(171, 22);
            this.txtPaidRightDGV.TabIndex = 26;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(789, 17);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 17);
            this.label14.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(263, 8);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 34);
            this.label12.TabIndex = 22;
            this.label12.Text = "Ödenmesi\r\nGereken";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTotalRightDGV
            // 
            this.txtTotalRightDGV.Location = new System.Drawing.Point(92, 14);
            this.txtTotalRightDGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalRightDGV.Name = "txtTotalRightDGV";
            this.txtTotalRightDGV.ReadOnly = true;
            this.txtTotalRightDGV.Size = new System.Drawing.Size(151, 22);
            this.txtTotalRightDGV.TabIndex = 17;
            // 
            // txtSumRightDGV
            // 
            this.txtSumRightDGV.Location = new System.Drawing.Point(361, 14);
            this.txtSumRightDGV.Margin = new System.Windows.Forms.Padding(4);
            this.txtSumRightDGV.Name = "txtSumRightDGV";
            this.txtSumRightDGV.ReadOnly = true;
            this.txtSumRightDGV.Size = new System.Drawing.Size(147, 22);
            this.txtSumRightDGV.TabIndex = 21;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 17);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 17);
            this.label13.TabIndex = 18;
            this.label13.Text = "Total rows:";
            // 
            // PacketPreparation
            // 
            this.AcceptButton = this.btnCreatePackage;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1704, 670);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PacketPreparation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAKET HAZIRLAMA EKRANI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Package_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRight)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.collapsibleSplitContainer1.Panel1.ResumeLayout(false);
            this.collapsibleSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.collapsibleSplitContainer1)).EndInit();
            this.collapsibleSplitContainer1.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
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
        private Zuby.ADGV.AdvancedDataGridView dataGridViewLeft;
        private System.Windows.Forms.DataGridView dataGridViewRight;
        private System.Windows.Forms.TextBox txtSumLeftDGV;
        private System.Windows.Forms.TextBox txtTotalLeftDGV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label labelCurL;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Panel panel9;
        private SoftGee.CollapsibleSplitContainer collapsibleSplitContainer1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPaidRightDGV;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTotalRightDGV;
        private System.Windows.Forms.TextBox txtSumRightDGV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelCurR;
    }
}