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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PacketEditForm));
            this.btnEditPacket = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbOutAccountInfoEdit = new System.Windows.Forms.ComboBox();
            this.txtPacketEditExp = new System.Windows.Forms.TextBox();
            this.DGVLeftEdit = new Zuby.ADGV.AdvancedDataGridView();
            this.DGVRightEdit = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtPaid = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSumRightDGV = new System.Windows.Forms.TextBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.labelCurREd = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtTotalRightDGV = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnToLeftt = new System.Windows.Forms.Button();
            this.btnAllToLeft = new System.Windows.Forms.Button();
            this.btnToRight = new System.Windows.Forms.Button();
            this.btnAllToRight = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSumLeftDGV = new System.Windows.Forms.TextBox();
            this.panel11 = new System.Windows.Forms.Panel();
            this.labelCurLEd = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalLeftDGV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.collapsibleSplitContainer1 = new SoftGee.CollapsibleSplitContainer();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeftEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRightEdit)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel11.SuspendLayout();
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
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEditPacket
            // 
            this.btnEditPacket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditPacket.BackColor = System.Drawing.Color.ForestGreen;
            this.btnEditPacket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditPacket.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEditPacket.ForeColor = System.Drawing.Color.White;
            this.btnEditPacket.Location = new System.Drawing.Point(5, 91);
            this.btnEditPacket.Name = "btnEditPacket";
            this.btnEditPacket.Size = new System.Drawing.Size(599, 36);
            this.btnEditPacket.TabIndex = 13;
            this.btnEditPacket.Text = "PAKETİ DÜZENLE";
            this.btnEditPacket.UseVisualStyleBackColor = false;
            this.btnEditPacket.Click += new System.EventHandler(this.BtnEditPacket_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(6, 31);
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
            this.label5.Location = new System.Drawing.Point(6, 65);
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
            this.cmbOutAccountInfoEdit.Location = new System.Drawing.Point(160, 57);
            this.cmbOutAccountInfoEdit.Name = "cmbOutAccountInfoEdit";
            this.cmbOutAccountInfoEdit.Size = new System.Drawing.Size(444, 28);
            this.cmbOutAccountInfoEdit.TabIndex = 17;
            // 
            // txtPacketEditExp
            // 
            this.txtPacketEditExp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPacketEditExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtPacketEditExp.Location = new System.Drawing.Point(160, 25);
            this.txtPacketEditExp.Name = "txtPacketEditExp";
            this.txtPacketEditExp.Size = new System.Drawing.Size(444, 26);
            this.txtPacketEditExp.TabIndex = 19;
            // 
            // DGVLeftEdit
            // 
            this.DGVLeftEdit.AllowUserToAddRows = false;
            this.DGVLeftEdit.AllowUserToDeleteRows = false;
            this.DGVLeftEdit.BackgroundColor = System.Drawing.Color.White;
            this.DGVLeftEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVLeftEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVLeftEdit.FilterAndSortEnabled = true;
            this.DGVLeftEdit.Location = new System.Drawing.Point(0, 0);
            this.DGVLeftEdit.Name = "DGVLeftEdit";
            this.DGVLeftEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVLeftEdit.Size = new System.Drawing.Size(547, 504);
            this.DGVLeftEdit.TabIndex = 27;
            this.DGVLeftEdit.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.DGVLeftEdit_SortStringChanged_1);
            this.DGVLeftEdit.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.DGVLeftEdit_FilterStringChanged_1);
            // 
            // DGVRightEdit
            // 
            this.DGVRightEdit.AllowUserToAddRows = false;
            this.DGVRightEdit.AllowUserToDeleteRows = false;
            this.DGVRightEdit.BackgroundColor = System.Drawing.Color.White;
            this.DGVRightEdit.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.DGVRightEdit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVRightEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVRightEdit.Location = new System.Drawing.Point(0, 0);
            this.DGVRightEdit.Name = "DGVRightEdit";
            this.DGVRightEdit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVRightEdit.Size = new System.Drawing.Size(607, 376);
            this.DGVRightEdit.TabIndex = 13;
            this.DGVRightEdit.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRightEdit_CellEndEdit);
            this.DGVRightEdit.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVRightEdit_CellEnter);
            this.DGVRightEdit.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DGVRightEdit_CellFormatting);
            this.DGVRightEdit.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.DGVRightEdit_CellValidating);
            this.DGVRightEdit.CurrentCellDirtyStateChanged += new System.EventHandler(this.DGVRightEdit_CurrentCellDirtyStateChanged);
            this.DGVRightEdit.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGVRightEdit_EditingControlShowing);
            this.DGVRightEdit.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGVRightEdit_RowsAdded);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEditPacket);
            this.panel3.Controls.Add(this.cmbOutAccountInfoEdit);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.txtPacketEditExp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(607, 131);
            this.panel3.TabIndex = 14;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Controls.Add(this.label7);
            this.panel9.Controls.Add(this.textBox5);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 39);
            this.panel9.Margin = new System.Windows.Forms.Padding(1);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(607, 131);
            this.panel9.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(3, -22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "AÇIKLAMA";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox5.Location = new System.Drawing.Point(161, -28);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(437, 26);
            this.textBox5.TabIndex = 21;
            // 
            // txtPaid
            // 
            this.txtPaid.Location = new System.Drawing.Point(265, 10);
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.Size = new System.Drawing.Size(129, 20);
            this.txtPaid.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(411, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Sum:";
            // 
            // txtSumRightDGV
            // 
            this.txtSumRightDGV.Location = new System.Drawing.Point(448, 10);
            this.txtSumRightDGV.Name = "txtSumRightDGV";
            this.txtSumRightDGV.ReadOnly = true;
            this.txtSumRightDGV.Size = new System.Drawing.Size(111, 20);
            this.txtSumRightDGV.TabIndex = 21;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.labelCurREd);
            this.panel17.Controls.Add(this.label11);
            this.panel17.Controls.Add(this.txtPaid);
            this.panel17.Controls.Add(this.label14);
            this.panel17.Controls.Add(this.label12);
            this.panel17.Controls.Add(this.txtTotalRightDGV);
            this.panel17.Controls.Add(this.txtSumRightDGV);
            this.panel17.Controls.Add(this.label13);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(0, 0);
            this.panel17.Margin = new System.Windows.Forms.Padding(1);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(607, 39);
            this.panel17.TabIndex = 28;
            // 
            // labelCurREd
            // 
            this.labelCurREd.AutoSize = true;
            this.labelCurREd.Location = new System.Drawing.Point(578, 14);
            this.labelCurREd.Name = "labelCurREd";
            this.labelCurREd.Size = new System.Drawing.Size(0, 13);
            this.labelCurREd.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Ödenecek:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(597, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 13);
            this.label14.TabIndex = 23;
            // 
            // txtTotalRightDGV
            // 
            this.txtTotalRightDGV.Location = new System.Drawing.Point(69, 11);
            this.txtTotalRightDGV.Name = "txtTotalRightDGV";
            this.txtTotalRightDGV.ReadOnly = true;
            this.txtTotalRightDGV.Size = new System.Drawing.Size(114, 20);
            this.txtTotalRightDGV.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Total rows:";
            // 
            // btnToLeftt
            // 
            this.btnToLeftt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToLeftt.Location = new System.Drawing.Point(-1, 65);
            this.btnToLeftt.Name = "btnToLeftt";
            this.btnToLeftt.Size = new System.Drawing.Size(36, 24);
            this.btnToLeftt.TabIndex = 23;
            this.btnToLeftt.Text = "<";
            this.btnToLeftt.UseVisualStyleBackColor = true;
            this.btnToLeftt.Click += new System.EventHandler(this.BtnToLeft_Click);
            // 
            // btnAllToLeft
            // 
            this.btnAllToLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllToLeft.Location = new System.Drawing.Point(-2, 95);
            this.btnAllToLeft.Name = "btnAllToLeft";
            this.btnAllToLeft.Size = new System.Drawing.Size(37, 27);
            this.btnAllToLeft.TabIndex = 12;
            this.btnAllToLeft.Text = "<<";
            this.btnAllToLeft.UseVisualStyleBackColor = true;
            this.btnAllToLeft.Click += new System.EventHandler(this.BtnAllToLeft_Click);
            // 
            // btnToRight
            // 
            this.btnToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnToRight.Location = new System.Drawing.Point(-2, 65);
            this.btnToRight.Name = "btnToRight";
            this.btnToRight.Size = new System.Drawing.Size(37, 25);
            this.btnToRight.TabIndex = 22;
            this.btnToRight.Text = ">";
            this.btnToRight.UseVisualStyleBackColor = true;
            this.btnToRight.Click += new System.EventHandler(this.BtnToRight_Click);
            // 
            // btnAllToRight
            // 
            this.btnAllToRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAllToRight.Location = new System.Drawing.Point(-2, 96);
            this.btnAllToRight.Name = "btnAllToRight";
            this.btnAllToRight.Size = new System.Drawing.Size(37, 26);
            this.btnAllToRight.TabIndex = 11;
            this.btnAllToRight.Text = ">>";
            this.btnAllToRight.UseVisualStyleBackColor = true;
            this.btnAllToRight.Click += new System.EventHandler(this.BtnAllToRight_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(309, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Sum:";
            // 
            // txtSumLeftDGV
            // 
            this.txtSumLeftDGV.Location = new System.Drawing.Point(346, 10);
            this.txtSumLeftDGV.Name = "txtSumLeftDGV";
            this.txtSumLeftDGV.ReadOnly = true;
            this.txtSumLeftDGV.Size = new System.Drawing.Size(173, 20);
            this.txtSumLeftDGV.TabIndex = 19;
            // 
            // panel11
            // 
            this.panel11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel11.Controls.Add(this.labelCurLEd);
            this.panel11.Controls.Add(this.label8);
            this.panel11.Controls.Add(this.label9);
            this.panel11.Controls.Add(this.txtSumLeftDGV);
            this.panel11.Controls.Add(this.txtTotalLeftDGV);
            this.panel11.Controls.Add(this.label6);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 4);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(547, 38);
            this.panel11.TabIndex = 26;
            // 
            // labelCurLEd
            // 
            this.labelCurLEd.AutoSize = true;
            this.labelCurLEd.Location = new System.Drawing.Point(538, 13);
            this.labelCurLEd.Name = "labelCurLEd";
            this.labelCurLEd.Size = new System.Drawing.Size(0, 13);
            this.labelCurLEd.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(596, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 21;
            // 
            // txtTotalLeftDGV
            // 
            this.txtTotalLeftDGV.Location = new System.Drawing.Point(68, 14);
            this.txtTotalLeftDGV.Name = "txtTotalLeftDGV";
            this.txtTotalLeftDGV.ReadOnly = true;
            this.txtTotalLeftDGV.Size = new System.Drawing.Size(164, 20);
            this.txtTotalLeftDGV.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Total rows:";
            // 
            // collapsibleSplitContainer1
            // 
            this.collapsibleSplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.collapsibleSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.collapsibleSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.collapsibleSplitContainer1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.collapsibleSplitContainer1.Location = new System.Drawing.Point(0, 0);
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
            this.collapsibleSplitContainer1.Size = new System.Drawing.Size(1258, 550);
            this.collapsibleSplitContainer1.SplitterButtonBitmap = ((System.Drawing.Bitmap)(resources.GetObject("collapsibleSplitContainer1.SplitterButtonBitmap")));
            this.collapsibleSplitContainer1.SplitterButtonPosition = SoftGee.ButtonPosition.Center;
            this.collapsibleSplitContainer1.SplitterButtonStyle = SoftGee.ButtonStyle.PushButton;
            this.collapsibleSplitContainer1.SplitterDistance = 588;
            this.collapsibleSplitContainer1.SplitterWidth = 22;
            this.collapsibleSplitContainer1.TabIndex = 29;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(547, 546);
            this.panel7.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.panel12);
            this.panel8.Controls.Add(this.panel10);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(547, 546);
            this.panel8.TabIndex = 1;
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.DGVLeftEdit);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel12.Location = new System.Drawing.Point(0, 0);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(547, 504);
            this.panel12.TabIndex = 1;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.panel11);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel10.Location = new System.Drawing.Point(0, 504);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(547, 42);
            this.panel10.TabIndex = 0;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel13.Controls.Add(this.btnToRight);
            this.panel13.Controls.Add(this.btnAllToRight);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel13.Location = new System.Drawing.Point(547, 0);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(37, 546);
            this.panel13.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.panel15);
            this.panel14.Controls.Add(this.panel16);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel14.Location = new System.Drawing.Point(37, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(607, 546);
            this.panel14.TabIndex = 2;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.DGVRightEdit);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Margin = new System.Windows.Forms.Padding(1);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(607, 376);
            this.panel15.TabIndex = 1;
            // 
            // panel16
            // 
            this.panel16.Controls.Add(this.panel9);
            this.panel16.Controls.Add(this.panel17);
            this.panel16.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel16.Location = new System.Drawing.Point(0, 376);
            this.panel16.Margin = new System.Windows.Forms.Padding(1);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(607, 170);
            this.panel16.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.btnToLeftt);
            this.panel6.Controls.Add(this.btnAllToLeft);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(37, 546);
            this.panel6.TabIndex = 1;
            // 
            // PacketEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 550);
            this.Controls.Add(this.collapsibleSplitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PacketEditForm";
            this.Text = "PAKET DÜZENLEME EKRANI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PacketEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVLeftEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGVRightEdit)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel17.ResumeLayout(false);
            this.panel17.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
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
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEditPacket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbOutAccountInfoEdit;
        private System.Windows.Forms.TextBox txtPacketEditExp;
        private Zuby.ADGV.AdvancedDataGridView DGVLeftEdit;
        private System.Windows.Forms.DataGridView DGVRightEdit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox txtPaid;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSumRightDGV;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label labelCurREd;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtTotalRightDGV;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnToLeftt;
        private System.Windows.Forms.Button btnAllToLeft;
        private System.Windows.Forms.Button btnToRight;
        private System.Windows.Forms.Button btnAllToRight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSumLeftDGV;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label labelCurLEd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalLeftDGV;
        private System.Windows.Forms.Label label6;
        private SoftGee.CollapsibleSplitContainer collapsibleSplitContainer1;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel6;
    }
}