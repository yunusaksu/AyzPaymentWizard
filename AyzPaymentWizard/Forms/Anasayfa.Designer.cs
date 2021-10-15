namespace AyzPaymentWizard
{
    partial class Anasayfa
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Anasayfa));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnNewPacket = new System.Windows.Forms.Button();
            this.imageListPacketIcon = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAkibetSorgulama = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnSendToBank = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnApproved = new System.Windows.Forms.Button();
            this.btnSendToApprove = new System.Windows.Forms.Button();
            this.btnRewiew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dataGridViewPacket = new System.Windows.Forms.DataGridView();
            this.contextMenuStripAnasayfa = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.akibetiİnceleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paketSeruveniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownSettingButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.sFTPAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBankAndBankAccAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.logoUserSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sFTPBaglantiLoglariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMTPSunucuAyarlariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelAyarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAnasayfa = new System.Windows.Forms.ToolStrip();
            this.btnGroupAdd = new System.Windows.Forms.ToolStripButton();
            this.btnUserAdd = new System.Windows.Forms.ToolStripButton();
            this.OnlineUsertoolStripLabel = new System.Windows.Forms.ToolStripDropDownButton();
            this.SignOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacket)).BeginInit();
            this.contextMenuStripAnasayfa.SuspendLayout();
            this.toolStripAnasayfa.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.dataGridViewPacket);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1316, 677);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(509, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "HAZIRLANMIŞ PAKETLER";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnNewPacket);
            this.panel3.Controls.Add(this.btnRefresh);
            this.panel3.Controls.Add(this.btnAkibetSorgulama);
            this.panel3.Controls.Add(this.btnArchive);
            this.panel3.Controls.Add(this.btnSendToBank);
            this.panel3.Controls.Add(this.btnReject);
            this.panel3.Controls.Add(this.btnApproved);
            this.panel3.Controls.Add(this.btnSendToApprove);
            this.panel3.Controls.Add(this.btnRewiew);
            this.panel3.Controls.Add(this.btnEdit);
            this.panel3.Location = new System.Drawing.Point(3, 512);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1159, 85);
            this.panel3.TabIndex = 2;
            // 
            // btnNewPacket
            // 
            this.btnNewPacket.BackColor = System.Drawing.Color.Transparent;
            this.btnNewPacket.FlatAppearance.BorderSize = 0;
            this.btnNewPacket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewPacket.ImageIndex = 7;
            this.btnNewPacket.ImageList = this.imageListPacketIcon;
            this.btnNewPacket.Location = new System.Drawing.Point(8, 12);
            this.btnNewPacket.Name = "btnNewPacket";
            this.btnNewPacket.Size = new System.Drawing.Size(68, 65);
            this.btnNewPacket.TabIndex = 9;
            this.btnNewPacket.Tag = "";
            this.btnNewPacket.UseVisualStyleBackColor = false;
            this.btnNewPacket.Click += new System.EventHandler(this.btnNewPacket_Click);
            // 
            // imageListPacketIcon
            // 
            this.imageListPacketIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPacketIcon.ImageStream")));
            this.imageListPacketIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPacketIcon.Images.SetKeyName(0, "editButton.png");
            this.imageListPacketIcon.Images.SetKeyName(1, "reviewButton.png");
            this.imageListPacketIcon.Images.SetKeyName(2, "approveButton.png");
            this.imageListPacketIcon.Images.SetKeyName(3, "sendToApprove.png");
            this.imageListPacketIcon.Images.SetKeyName(4, "bank.png");
            this.imageListPacketIcon.Images.SetKeyName(5, "archive.png");
            this.imageListPacketIcon.Images.SetKeyName(6, "performed_process.png");
            this.imageListPacketIcon.Images.SetKeyName(7, "newPacketButton.png");
            this.imageListPacketIcon.Images.SetKeyName(8, "rejectButton.png");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(1077, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(68, 65);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Tag = "";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnAkibetSorgulama
            // 
            this.btnAkibetSorgulama.BackColor = System.Drawing.Color.Transparent;
            this.btnAkibetSorgulama.FlatAppearance.BorderSize = 0;
            this.btnAkibetSorgulama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAkibetSorgulama.ImageIndex = 6;
            this.btnAkibetSorgulama.ImageList = this.imageListPacketIcon;
            this.btnAkibetSorgulama.Location = new System.Drawing.Point(523, 13);
            this.btnAkibetSorgulama.Name = "btnAkibetSorgulama";
            this.btnAkibetSorgulama.Size = new System.Drawing.Size(68, 65);
            this.btnAkibetSorgulama.TabIndex = 7;
            this.btnAkibetSorgulama.Tag = "";
            this.btnAkibetSorgulama.UseVisualStyleBackColor = false;
            this.btnAkibetSorgulama.Click += new System.EventHandler(this.btnAkibetSorgulama_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.Transparent;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.ImageIndex = 5;
            this.btnArchive.ImageList = this.imageListPacketIcon;
            this.btnArchive.Location = new System.Drawing.Point(463, 13);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(68, 65);
            this.btnArchive.TabIndex = 6;
            this.btnArchive.Tag = "";
            this.btnArchive.UseVisualStyleBackColor = false;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnSendToBank
            // 
            this.btnSendToBank.BackColor = System.Drawing.Color.Transparent;
            this.btnSendToBank.FlatAppearance.BorderSize = 0;
            this.btnSendToBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToBank.ImageIndex = 4;
            this.btnSendToBank.ImageList = this.imageListPacketIcon;
            this.btnSendToBank.Location = new System.Drawing.Point(395, 13);
            this.btnSendToBank.Name = "btnSendToBank";
            this.btnSendToBank.Size = new System.Drawing.Size(68, 65);
            this.btnSendToBank.TabIndex = 5;
            this.btnSendToBank.Tag = "";
            this.btnSendToBank.UseVisualStyleBackColor = false;
            this.btnSendToBank.Click += new System.EventHandler(this.btnSendToBank_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.White;
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.ImageIndex = 8;
            this.btnReject.ImageList = this.imageListPacketIcon;
            this.btnReject.Location = new System.Drawing.Point(330, 13);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(68, 65);
            this.btnReject.TabIndex = 4;
            this.btnReject.Tag = "";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApproved
            // 
            this.btnApproved.BackColor = System.Drawing.Color.Transparent;
            this.btnApproved.FlatAppearance.BorderSize = 0;
            this.btnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApproved.ImageIndex = 2;
            this.btnApproved.ImageList = this.imageListPacketIcon;
            this.btnApproved.Location = new System.Drawing.Point(266, 13);
            this.btnApproved.Name = "btnApproved";
            this.btnApproved.Size = new System.Drawing.Size(68, 65);
            this.btnApproved.TabIndex = 3;
            this.btnApproved.Tag = "";
            this.btnApproved.UseVisualStyleBackColor = false;
            this.btnApproved.Click += new System.EventHandler(this.btnApproved_Click);
            // 
            // btnSendToApprove
            // 
            this.btnSendToApprove.BackColor = System.Drawing.Color.Transparent;
            this.btnSendToApprove.FlatAppearance.BorderSize = 0;
            this.btnSendToApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendToApprove.ImageIndex = 3;
            this.btnSendToApprove.ImageList = this.imageListPacketIcon;
            this.btnSendToApprove.Location = new System.Drawing.Point(199, 13);
            this.btnSendToApprove.Name = "btnSendToApprove";
            this.btnSendToApprove.Size = new System.Drawing.Size(68, 65);
            this.btnSendToApprove.TabIndex = 2;
            this.btnSendToApprove.Tag = "";
            this.btnSendToApprove.UseVisualStyleBackColor = false;
            this.btnSendToApprove.Click += new System.EventHandler(this.btnSendToApprove_Click);
            // 
            // btnRewiew
            // 
            this.btnRewiew.BackColor = System.Drawing.Color.Transparent;
            this.btnRewiew.FlatAppearance.BorderSize = 0;
            this.btnRewiew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRewiew.ImageIndex = 1;
            this.btnRewiew.ImageList = this.imageListPacketIcon;
            this.btnRewiew.Location = new System.Drawing.Point(137, 12);
            this.btnRewiew.Name = "btnRewiew";
            this.btnRewiew.Size = new System.Drawing.Size(68, 65);
            this.btnRewiew.TabIndex = 1;
            this.btnRewiew.Tag = "";
            this.btnRewiew.UseVisualStyleBackColor = false;
            this.btnRewiew.Click += new System.EventHandler(this.btnRewiew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Transparent;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.ImageIndex = 0;
            this.btnEdit.ImageList = this.imageListPacketIcon;
            this.btnEdit.Location = new System.Drawing.Point(72, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 65);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Tag = "";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dataGridViewPacket
            // 
            this.dataGridViewPacket.AllowUserToAddRows = false;
            this.dataGridViewPacket.AllowUserToDeleteRows = false;
            this.dataGridViewPacket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPacket.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPacket.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewPacket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacket.Location = new System.Drawing.Point(3, 42);
            this.dataGridViewPacket.Name = "dataGridViewPacket";
            this.dataGridViewPacket.ReadOnly = true;
            this.dataGridViewPacket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPacket.Size = new System.Drawing.Size(1159, 469);
            this.dataGridViewPacket.TabIndex = 1;
            this.dataGridViewPacket.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPacket_CellMouseDown);
            this.dataGridViewPacket.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridViewPacket_RowStateChanged);
            // 
            // contextMenuStripAnasayfa
            // 
            this.contextMenuStripAnasayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akibetiİnceleToolStripMenuItem,
            this.paketSeruveniToolStripMenuItem});
            this.contextMenuStripAnasayfa.Name = "contextMenuStripAnasayfa";
            this.contextMenuStripAnasayfa.Size = new System.Drawing.Size(146, 48);
            this.contextMenuStripAnasayfa.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripAnasayfa_Opening);
            // 
            // akibetiİnceleToolStripMenuItem
            // 
            this.akibetiİnceleToolStripMenuItem.Name = "akibetiİnceleToolStripMenuItem";
            this.akibetiİnceleToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.akibetiİnceleToolStripMenuItem.Text = "Akibeti İncele";
            this.akibetiİnceleToolStripMenuItem.Click += new System.EventHandler(this.akibetiİnceleToolStripMenuItem_Click);
            // 
            // paketSeruveniToolStripMenuItem
            // 
            this.paketSeruveniToolStripMenuItem.Name = "paketSeruveniToolStripMenuItem";
            this.paketSeruveniToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.paketSeruveniToolStripMenuItem.Text = "Kayıt Bilgisi";
            this.paketSeruveniToolStripMenuItem.Click += new System.EventHandler(this.paketSeruveniToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripDropDownSettingButton
            // 
            this.toolStripDropDownSettingButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sFTPAyarlarıToolStripMenuItem,
            this.btnBankAndBankAccAdd,
            this.logoUserSettingsToolStripMenuItem,
            this.sFTPBaglantiLoglariToolStripMenuItem,
            this.sMTPSunucuAyarlariToolStripMenuItem,
            this.genelAyarlarToolStripMenuItem});
            this.toolStripDropDownSettingButton.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.toolStripDropDownSettingButton.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripDropDownSettingButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownSettingButton.Name = "toolStripDropDownSettingButton";
            this.toolStripDropDownSettingButton.Size = new System.Drawing.Size(80, 29);
            this.toolStripDropDownSettingButton.Text = "Ayarlar";
            // 
            // sFTPAyarlarıToolStripMenuItem
            // 
            this.sFTPAyarlarıToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.sFTPAyarlarıToolStripMenuItem.Name = "sFTPAyarlarıToolStripMenuItem";
            this.sFTPAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.sFTPAyarlarıToolStripMenuItem.Text = "SFTP Ayarları";
            this.sFTPAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.sFTPAyarlarıToolStripMenuItem_Click);
            // 
            // btnBankAndBankAccAdd
            // 
            this.btnBankAndBankAccAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnBankAndBankAccAdd.Name = "btnBankAndBankAccAdd";
            this.btnBankAndBankAccAdd.Size = new System.Drawing.Size(257, 30);
            this.btnBankAndBankAccAdd.Text = "Çalışılan Bankalar";
            this.btnBankAndBankAccAdd.Click += new System.EventHandler(this.btnBankAndBankAccAdd_Click_1);
            // 
            // logoUserSettingsToolStripMenuItem
            // 
            this.logoUserSettingsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.logoUserSettingsToolStripMenuItem.Name = "logoUserSettingsToolStripMenuItem";
            this.logoUserSettingsToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.logoUserSettingsToolStripMenuItem.Text = "Logo Kullanıcı Ayarları";
            this.logoUserSettingsToolStripMenuItem.Click += new System.EventHandler(this.logoUserSettingsToolStripMenuItem_Click);
            // 
            // sFTPBaglantiLoglariToolStripMenuItem
            // 
            this.sFTPBaglantiLoglariToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.sFTPBaglantiLoglariToolStripMenuItem.Name = "sFTPBaglantiLoglariToolStripMenuItem";
            this.sFTPBaglantiLoglariToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.sFTPBaglantiLoglariToolStripMenuItem.Text = "SFTP Bağlantı Logları";
            this.sFTPBaglantiLoglariToolStripMenuItem.Click += new System.EventHandler(this.sFTPBaglantiLoglariToolStripMenuItem_Click);
            // 
            // sMTPSunucuAyarlariToolStripMenuItem
            // 
            this.sMTPSunucuAyarlariToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.sMTPSunucuAyarlariToolStripMenuItem.Name = "sMTPSunucuAyarlariToolStripMenuItem";
            this.sMTPSunucuAyarlariToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.sMTPSunucuAyarlariToolStripMenuItem.Text = "SMTP Sunucu Ayarları";
            this.sMTPSunucuAyarlariToolStripMenuItem.Click += new System.EventHandler(this.sMTPSunucuAyarlariToolStripMenuItem_Click);
            // 
            // genelAyarlarToolStripMenuItem
            // 
            this.genelAyarlarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.genelAyarlarToolStripMenuItem.Name = "genelAyarlarToolStripMenuItem";
            this.genelAyarlarToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.genelAyarlarToolStripMenuItem.Text = "Genel Ayarlar";
            this.genelAyarlarToolStripMenuItem.Click += new System.EventHandler(this.genelAyarlarToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripAnasayfa
            // 
            this.toolStripAnasayfa.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripAnasayfa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripAnasayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGroupAdd,
            this.toolStripSeparator2,
            this.btnUserAdd,
            this.toolStripSeparator3,
            this.toolStripDropDownSettingButton,
            this.toolStripSeparator5,
            this.OnlineUsertoolStripLabel});
            this.toolStripAnasayfa.Location = new System.Drawing.Point(0, 0);
            this.toolStripAnasayfa.Name = "toolStripAnasayfa";
            this.toolStripAnasayfa.Size = new System.Drawing.Size(1174, 32);
            this.toolStripAnasayfa.TabIndex = 0;
            this.toolStripAnasayfa.Text = "AnasayfaToolStrip";
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGroupAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnGroupAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnGroupAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupAdd.Image")));
            this.btnGroupAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(74, 29);
            this.btnGroupAdd.Text = "Gruplar";
            this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUserAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnUserAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnUserAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnUserAdd.Image")));
            this.btnUserAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(98, 29);
            this.btnUserAdd.Text = "Kullanıcılar";
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // OnlineUsertoolStripLabel
            // 
            this.OnlineUsertoolStripLabel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.OnlineUsertoolStripLabel.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SignOutToolStripMenuItem});
            this.OnlineUsertoolStripLabel.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.OnlineUsertoolStripLabel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.OnlineUsertoolStripLabel.Image = global::AyzPaymentWizard.Properties.Resources.Man;
            this.OnlineUsertoolStripLabel.Name = "OnlineUsertoolStripLabel";
            this.OnlineUsertoolStripLabel.Size = new System.Drawing.Size(132, 29);
            this.OnlineUsertoolStripLabel.Text = "Online User";
            // 
            // SignOutToolStripMenuItem
            // 
            this.SignOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.SignOutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.SignOutToolStripMenuItem.Name = "SignOutToolStripMenuItem";
            this.SignOutToolStripMenuItem.Size = new System.Drawing.Size(174, 24);
            this.SignOutToolStripMenuItem.Text = "Oturum Kapat";
            this.SignOutToolStripMenuItem.Click += new System.EventHandler(this.SignOutToolStripMenuItem_Click);
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 649);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripAnasayfa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANASAYFA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Anasayfa_FormClosed);
            this.Load += new System.EventHandler(this.Anasayfa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Anasayfa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacket)).EndInit();
            this.contextMenuStripAnasayfa.ResumeLayout(false);
            this.toolStripAnasayfa.ResumeLayout(false);
            this.toolStripAnasayfa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dataGridViewPacket;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ImageList imageListPacketIcon;
        private System.Windows.Forms.Button btnRewiew;
        private System.Windows.Forms.Button btnSendToApprove;
        private System.Windows.Forms.Button btnApproved;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnSendToBank;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.ToolStripButton btnGroupAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUserAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownSettingButton;
        private System.Windows.Forms.ToolStripMenuItem sFTPAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnBankAndBankAccAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolStripAnasayfa;
        private System.Windows.Forms.Button btnAkibetSorgulama;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAnasayfa;
        private System.Windows.Forms.ToolStripMenuItem akibetiİnceleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoUserSettingsToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem sFTPBaglantiLoglariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paketSeruveniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMTPSunucuAyarlariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genelAyarlarToolStripMenuItem;
        private System.Windows.Forms.Button btnNewPacket;
        private System.Windows.Forms.ToolStripDropDownButton OnlineUsertoolStripLabel;
        private System.Windows.Forms.ToolStripMenuItem SignOutToolStripMenuItem;
    }
}