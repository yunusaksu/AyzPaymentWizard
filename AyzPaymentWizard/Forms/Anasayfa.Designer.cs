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
            this.labelUserName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnAkibetSorgulama = new System.Windows.Forms.Button();
            this.imageListPacketIcon = new System.Windows.Forms.ImageList(this.components);
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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPackageAdd = new System.Windows.Forms.ToolStripButton();
            this.btnGroupAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUserAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.sFTPAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnBankAndBankAccAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.logoUserSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnsqlBağlantiAyarlariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sFTPBaglantiLoglariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMTPSunucuAyarlariToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.genelAyarlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripAnasayfa = new System.Windows.Forms.ToolStrip();
            this.label3 = new System.Windows.Forms.Label();
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
            // labelUserName
            // 
            this.labelUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUserName.AutoSize = true;
            this.labelUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelUserName.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.labelUserName.ForeColor = System.Drawing.SystemColors.GrayText;
            this.labelUserName.Location = new System.Drawing.Point(1014, 6);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(96, 23);
            this.labelUserName.TabIndex = 3;
            this.labelUserName.Text = "User Name";
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
            this.btnAkibetSorgulama.ImageIndex = 7;
            this.btnAkibetSorgulama.ImageList = this.imageListPacketIcon;
            this.btnAkibetSorgulama.Location = new System.Drawing.Point(458, 4);
            this.btnAkibetSorgulama.Name = "btnAkibetSorgulama";
            this.btnAkibetSorgulama.Size = new System.Drawing.Size(68, 65);
            this.btnAkibetSorgulama.TabIndex = 7;
            this.btnAkibetSorgulama.Tag = "";
            this.btnAkibetSorgulama.UseVisualStyleBackColor = false;
            this.btnAkibetSorgulama.Click += new System.EventHandler(this.btnAkibetSorgulama_Click);
            // 
            // imageListPacketIcon
            // 
            this.imageListPacketIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListPacketIcon.ImageStream")));
            this.imageListPacketIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListPacketIcon.Images.SetKeyName(0, "editButton.png");
            this.imageListPacketIcon.Images.SetKeyName(1, "reviewButton.png");
            this.imageListPacketIcon.Images.SetKeyName(2, "approveButton.png");
            this.imageListPacketIcon.Images.SetKeyName(3, "sendToApprove.png");
            this.imageListPacketIcon.Images.SetKeyName(4, "rejectButton.png");
            this.imageListPacketIcon.Images.SetKeyName(5, "bank.png");
            this.imageListPacketIcon.Images.SetKeyName(6, "archive.png");
            this.imageListPacketIcon.Images.SetKeyName(7, "performed_process.png");
            // 
            // btnArchive
            // 
            this.btnArchive.BackColor = System.Drawing.Color.Transparent;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnArchive.ImageIndex = 6;
            this.btnArchive.ImageList = this.imageListPacketIcon;
            this.btnArchive.Location = new System.Drawing.Point(398, 4);
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
            this.btnSendToBank.ImageIndex = 5;
            this.btnSendToBank.ImageList = this.imageListPacketIcon;
            this.btnSendToBank.Location = new System.Drawing.Point(330, 4);
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
            this.btnReject.ImageIndex = 4;
            this.btnReject.ImageList = this.imageListPacketIcon;
            this.btnReject.Location = new System.Drawing.Point(265, 4);
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
            this.btnApproved.Location = new System.Drawing.Point(201, 4);
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
            this.btnSendToApprove.Location = new System.Drawing.Point(134, 4);
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
            this.btnRewiew.Location = new System.Drawing.Point(72, 3);
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
            this.btnEdit.Location = new System.Drawing.Point(7, 3);
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
            this.dataGridViewPacket.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewPacket.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.dataGridViewPacket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacket.Location = new System.Drawing.Point(3, 42);
            this.dataGridViewPacket.Name = "dataGridViewPacket";
            this.dataGridViewPacket.ReadOnly = true;
            this.dataGridViewPacket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPacket.Size = new System.Drawing.Size(1159, 469);
            this.dataGridViewPacket.TabIndex = 1;
            this.dataGridViewPacket.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewPacket_CellMouseDown);
            // 
            // contextMenuStripAnasayfa
            // 
            this.contextMenuStripAnasayfa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.akibetiİnceleToolStripMenuItem,
            this.paketSeruveniToolStripMenuItem});
            this.contextMenuStripAnasayfa.Name = "contextMenuStripAnasayfa";
            this.contextMenuStripAnasayfa.Size = new System.Drawing.Size(146, 48);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // btnPackageAdd
            // 
            this.btnPackageAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPackageAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnPackageAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnPackageAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnPackageAdd.Image")));
            this.btnPackageAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPackageAdd.Name = "btnPackageAdd";
            this.btnPackageAdd.Size = new System.Drawing.Size(94, 29);
            this.btnPackageAdd.Text = "Paket Ekle";
            this.btnPackageAdd.Click += new System.EventHandler(this.btnPackageAdd_Click);
            // 
            // btnGroupAdd
            // 
            this.btnGroupAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnGroupAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnGroupAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnGroupAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnGroupAdd.Image")));
            this.btnGroupAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGroupAdd.Name = "btnGroupAdd";
            this.btnGroupAdd.Size = new System.Drawing.Size(91, 29);
            this.btnGroupAdd.Text = "Grup Ekle";
            this.btnGroupAdd.Click += new System.EventHandler(this.btnGroupAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUserAdd.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnUserAdd.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnUserAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnUserAdd.Image")));
            this.btnUserAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(115, 29);
            this.btnUserAdd.Text = "Kullanıcı Ekle";
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sFTPAyarlarıToolStripMenuItem,
            this.btnBankAndBankAccAdd,
            this.logoUserSettingsToolStripMenuItem,
            this.btnsqlBağlantiAyarlariToolStripMenuItem,
            this.sFTPBaglantiLoglariToolStripMenuItem,
            this.sMTPSunucuAyarlariToolStripMenuItem,
            this.genelAyarlarToolStripMenuItem});
            this.toolStripDropDownButton1.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.toolStripDropDownButton1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(80, 29);
            this.toolStripDropDownButton1.Text = "Ayarlar";
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
            // btnsqlBağlantiAyarlariToolStripMenuItem
            // 
            this.btnsqlBağlantiAyarlariToolStripMenuItem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnsqlBağlantiAyarlariToolStripMenuItem.Name = "btnsqlBağlantiAyarlariToolStripMenuItem";
            this.btnsqlBağlantiAyarlariToolStripMenuItem.Size = new System.Drawing.Size(257, 30);
            this.btnsqlBağlantiAyarlariToolStripMenuItem.Text = "Sql Bağlantı Ayarları";
            this.btnsqlBağlantiAyarlariToolStripMenuItem.Click += new System.EventHandler(this.btnsqlBağlantiAyarlariToolStripMenuItem_Click);
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
            this.btnPackageAdd,
            this.toolStripSeparator1,
            this.btnGroupAdd,
            this.toolStripSeparator2,
            this.btnUserAdd,
            this.toolStripSeparator3,
            this.toolStripDropDownButton1,
            this.toolStripSeparator5});
            this.toolStripAnasayfa.Location = new System.Drawing.Point(0, 0);
            this.toolStripAnasayfa.Name = "toolStripAnasayfa";
            this.toolStripAnasayfa.Size = new System.Drawing.Size(1174, 32);
            this.toolStripAnasayfa.TabIndex = 0;
            this.toolStripAnasayfa.Text = "AnasayfaToolStrip";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Microsoft PhagsPa", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(931, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Kullanıcı:";
            // 
            // Anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1174, 649);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStripAnasayfa);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Anasayfa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ANASAYFA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Anasayfa_FormClosed);
            this.Load += new System.EventHandler(this.Anasayfa_Load);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPackageAdd;
        private System.Windows.Forms.ToolStripButton btnGroupAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnUserAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem sFTPAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnBankAndBankAccAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStrip toolStripAnasayfa;
        private System.Windows.Forms.Button btnAkibetSorgulama;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAnasayfa;
        private System.Windows.Forms.ToolStripMenuItem akibetiİnceleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoUserSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnsqlBağlantiAyarlariToolStripMenuItem;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolStripMenuItem sFTPBaglantiLoglariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paketSeruveniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMTPSunucuAyarlariToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem genelAyarlarToolStripMenuItem;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Label label3;
    }
}