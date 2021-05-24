using AyzPaymentWizard.Forms;
using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using SftpConOperator;
using FileHelpers;
using FileHelpers.Events;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AyzPaymentWizard
{
    public partial class Anasayfa : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<Packet> packets = new List<Packet>();

        public Anasayfa()
        {
            InitializeComponent();
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            UserAddForm form = new UserAddForm();
            form.ShowDialog();
        }

        private void btnGroupAdd_Click(object sender, EventArgs e)
        {
            GroupAddForm form = new GroupAddForm();
            form.ShowDialog();
        }

        private void btnPackageAdd_Click(object sender, EventArgs e)
        {
            FiltersForm filtersForm = new FiltersForm();
            filtersForm.ShowDialog();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            dataGridViewPacket.MultiSelect = false;
            ToolTip editBtnToolTip = new ToolTip();
            editBtnToolTip.SetToolTip(btnEdit, "Paketi Düzenle");
            ToolTip reviewBtnToolTip = new ToolTip();
            reviewBtnToolTip.SetToolTip(btnRewiew, "Paketi İncele");
            ToolTip sendToApproveToolTip = new ToolTip();
            sendToApproveToolTip.SetToolTip(btnSendToApprove, "Onaya Gönder");
            ToolTip ApprovedToolTip = new ToolTip();
            ApprovedToolTip.SetToolTip(btnApproved, "Paketi Onayla");
            ToolTip RejectToolTip = new ToolTip();
            RejectToolTip.SetToolTip(btnReject, "Paketi Reddet");
            ToolTip SendToBankToolTip = new ToolTip();
            SendToBankToolTip.SetToolTip(btnSendToBank, "Bankaya Yolla");
            ToolTip ArchiveToolTip = new ToolTip();
            ArchiveToolTip.SetToolTip(btnArchive, "Paketi Arşivle");
            ToolTip AkibetToolTip = new ToolTip();
            AkibetToolTip.SetToolTip(btnAkibetSorgulama, "Akibet Sorgula");
            FillPacketList();
            #region Paket Kolon Görünüm,Header Text ve Display Index Ayarları
            dataGridViewPacket.ReadOnly = true;
            dataGridViewPacket.Columns["CreatedTime"].Visible = false;
            dataGridViewPacket.Columns["Id"].Visible = false;
            dataGridViewPacket.Columns["CreatedBy"].Visible = false;
            dataGridViewPacket.Columns["ModifiedTime"].Visible = false;
            dataGridViewPacket.Columns["ModifiedBy"].Visible = false;
            dataGridViewPacket.Columns["ApprovedBy"].Visible = false;
            dataGridViewPacket.Columns["UserNr"].Visible = false;
            dataGridViewPacket.Columns["ApprovedTime"].Visible = false;
            dataGridViewPacket.Columns["BankId"].Visible = false;
            dataGridViewPacket.Columns["BankBranchId"].Visible = false;
            dataGridViewPacket.Columns["BankName"].Visible = false;
            dataGridViewPacket.Columns["TigerBankAccountCode"].Visible = false;
            dataGridViewPacket.Columns["TigerAccountCode"].Visible = false;
            dataGridViewPacket.Columns["Status"].Visible = false;
            dataGridViewPacket.Columns["Archived"].Visible = false;
            dataGridViewPacket.Columns["Id"].HeaderText = "ID";
            dataGridViewPacket.Columns["CreatedBy"].HeaderText = "Oluşturan";
            dataGridViewPacket.Columns["CreatedDate"].HeaderText = "Oluşturma Tarihi";
            dataGridViewPacket.Columns["ModifiedBy"].HeaderText = "Güncelleyen";
            dataGridViewPacket.Columns["ModifiedDate"].HeaderText = "Güncelleme Tarihi";
            dataGridViewPacket.Columns["TotalRequired"].HeaderText = "Ödenmesi Gereken";
            dataGridViewPacket.Columns["TotalPaid"].HeaderText = "Ödenecek";
            dataGridViewPacket.Columns["Note"].HeaderText = "Not";
            dataGridViewPacket.Columns["ApprovalNote"].HeaderText = "Onay Notu";
            dataGridViewPacket.Columns["Currency"].HeaderText = "";
            dataGridViewPacket.Columns["FirmNr"].HeaderText = "Firma No";
            dataGridViewPacket.Columns["StatusMask"].HeaderText = "Paket Durumu";
            dataGridViewPacket.Columns["ApprovedBy"].HeaderText = "Onaylayan";
            dataGridViewPacket.Columns["ApprovedDate"].HeaderText = "Onaylama Tarihi";
            dataGridViewPacket.Columns["Archived"].HeaderText = "Arşiv Durumu";
            dataGridViewPacket.Columns["ApprovierName"].HeaderText = "Onaylayan";
            dataGridViewPacket.Columns["ModifiedByName"].HeaderText = "Güncelleyen";
            dataGridViewPacket.Columns["CreatedByName"].HeaderText = "Oluşturan";
            #endregion

            #region DGV'ın Font Ayarı
            dataGridViewPacket.DefaultCellStyle.Font = new Font("Time News Roman", 11);
            dataGridViewPacket.ColumnHeadersDefaultCellStyle.Font = new Font("Time News Roman", 10);
            #endregion

        }
        public void FillPacketList()
        {
            packets.Clear();

            // Login olunan Firmanın tüm paketlerini AYZ_PW_PACKET tablosundan getiren işlemler
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_PACKET WHERE FIRMNR = " + Helper.FIRMNR + " ";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Packet packet = new Packet();
                    packet.Id = Convert.ToInt32(dr["ID"].ToString());
                    packet.UserNr = Convert.ToInt32(dr["USERNR"].ToString());
                    packet.CreatedBy = Convert.ToInt32(dr["CREATED_BY"].ToString());
                    packet.CreatedByName = dr["CREATED_NAME"].ToString();
                    packet.CreatedDate = Convert.ToDateTime(dr["CREATED_DATE"].ToString());
                    packet.CreatedTime = Convert.ToInt32(dr["CREATED_TIME"].ToString());
                    packet.ModifiedBy = dr["MODIFIED_BY"].ToString() == "" ? -1 : Convert.ToInt32(dr["MODIFIED_BY"].ToString());
                    packet.ModifiedByName = dr["MODIFIED_NAME"].ToString();
                    packet.ModifiedDate = dr["MODIFIED_DATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["MODIFIED_DATE"]);
                    packet.ModifiedTime = dr["MODIFIED_TIME"].ToString() == "" ? 0 : Convert.ToInt32(dr["MODIFIED_TIME"]);
                    packet.TotalRequired = Convert.ToDecimal(dr["TOTAL_REQUIRED"].ToString());
                    packet.TotalPaid = Convert.ToDecimal(dr["TOTAL_PAID"].ToString());
                    packet.Currency = dr["CURRENCY"].ToString();
                    packet.Note = dr["NOTE"].ToString();
                    packet.ApprovalNote = dr["APPROVALNOTE"].ToString();
                    packet.FirmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    packet.Status = Convert.ToInt32(dr["STATUS"].ToString());
                    if (packet.Status == 0)
                        packet.StatusMask = "Yeni Paket";
                    else if (packet.Status == 1)
                        packet.StatusMask = "Düzenlenmiş Paket";
                    else if (packet.Status == 2)
                        packet.StatusMask = "Onaylandı";
                    else if (packet.Status == 3)
                        packet.StatusMask = "Reddedildi";
                    else if (packet.Status == 4)
                        packet.StatusMask = "Bankaya Yollandı";
                    else if (packet.Status == 5)
                        packet.StatusMask = "Akıbet Alındı";
                    else if (packet.Status == 6)
                        packet.StatusMask = "Onaya Yollandı";
                    packet.Archived = Convert.ToInt32(dr["ARCHIVED"].ToString());
                    packet.ApprovedBy = dr["APPROVED_BY"].ToString() == "" ? -1 : Convert.ToInt32(dr["APPROVED_BY"].ToString());
                    packet.ApprovierName = dr["APPROVED_NAME"].ToString();
                    packet.ApprovedDate = dr["APPROVED_DATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["APPROVED_DATE"]);
                    packet.ApprovedTime = dr["APPROVED_TIME"].ToString() == "" ? 0 : Convert.ToInt32(dr["APPROVED_TIME"]);
                    packet.BankId = dr["BANKID"].ToString() == "" ? 0 : Convert.ToInt32(dr["BANKID"]);
                    packet.BankBranchId = dr["BNK_BRANCH_ID"].ToString() == "" ? 0 : Convert.ToInt32(dr["BNK_BRANCH_ID"]);
                    packet.BankName = dr["BNK_NAME"].ToString();
                    packet.TigerBankAccountCode = dr["TIGER_BNKACCODE"].ToString();
                    packet.TigerAccountCode = dr["TIGER_ACCOUNT_CODE"].ToString();
                    packets.Add(packet);
                }
            }

            var source = new BindingSource();
            source.DataSource = packets;
            dataGridViewPacket.DataSource = source;

            dataGridViewPacket.Columns["Currency"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int packetId = 0;
            for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
            {
                packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
            }

            if (packetId != 0)
            {
                try
                {
                    PacketEditForm form = new PacketEditForm(packetId, false);
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:\n" + ex.Message);
                }
            }
        }

        private void btnRewiew_Click(object sender, EventArgs e)
        {
            int packetId = 0;
            for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
            {
                packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
            }

            if (packetId != 0)
            {
                try
                {
                    PacketEditForm form = new PacketEditForm(packetId, true);
                    form.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:\n" + ex.Message);
                }
            }
        }

        private void btnSendToApprove_Click(object sender, EventArgs e)
        {
            try
            {
                int packetId = 0;
                for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
                {
                    packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
                }
                if (packetId != 0)
                {
                    string approvalExp = Interaction.InputBox("Onay Notunuz", "Açıklama Giriniz", "Örn: Açıklama....", 500, 250);
                    if (approvalExp.Length > 0)
                    {
                        // Paketin statüsü onaya gönderildi yapılacak ve Onay Notu Güncellenecek
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            CommandText = "UPDATE AYZ_PW_PACKET " +
                                          "\nSET STATUS = " + (int)Helper.PacketStatus.SendToApproval + "," +
                                          "\nAPPROVALNOTE = '" + approvalExp + "'" +
                                          "\nWHERE ID = " + packetId + "";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            komut.ExecuteNonQuery();
                            conn.Close();
                        }

                        // Anasayfayı yenilemek için 2 yöntem vardır.
                        // 1. Yöntem
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                        // 2. Yöntem
                        //FillPacketList();
                        //var source = new BindingSource();
                        //source.DataSource = packets;
                        //dataGridViewPacket.DataSource = source;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message.ToString());
            }
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            try
            {
                int packetId = 0;
                for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
                {
                    packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
                }
                if (packetId != 0)
                {
                    string approvalExp = Interaction.InputBox("Onay Notunuz", "Açıklama Giriniz", "Örn: Açıklama....", 500, 250);
                    if (approvalExp.Length > 0)
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            // Güncellenecek Alanlar
                            // STATUS
                            // APPROVED_BY
                            // APPROVED_DATE
                            // APPROVED_TIME
                            // APPROVALNOTE
                            CommandText = "UPDATE AYZ_PW_PACKET" +
                                          "\nSET STATUS = " + (int)Helper.PacketStatus.Approved + ", " +
                                          "\nAPPROVED_BY = " + Helper.USERID + "," +
                                          "\nAPPROVED_DATE = CONVERT(DATE, GETDATE(), 104)," +
                                          "\nAPPROVED_TIME = " + Helper.GetTime() + "," +
                                          "\nAPPROVED_NAME = '" + Helper.USERNAME + "'," +
                                          "\nAPPROVALNOTE = '" + approvalExp + "'" +
                                          "\nWHERE ID = " + packetId + "";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            komut.ExecuteNonQuery();
                            conn.Close();
                        }

                        // Anasayfayı yenilemek için 2 yöntem vardır.
                        // 1. Yöntem
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                        // 2. Yöntem
                        //FillPacketList();
                        //var source = new BindingSource();
                        //source.DataSource = packets;
                        //dataGridViewPacket.DataSource = source;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                int packetId = 0;
                for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
                {
                    packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
                }
                if (packetId != 0)
                {
                    string approvalExp = Interaction.InputBox("Red Notunuz", "Açıklama Giriniz", "Örn: Açıklama....", 500, 250);
                    if (approvalExp.Length > 0)
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            // Güncellenecek Alanlar
                            // STATUS
                            // APPROVALNOTE
                            CommandText = "UPDATE AYZ_PW_PACKET" +
                                          "\nSET STATUS = " + (int)Helper.PacketStatus.Rejected + ", " +
                                          "\nAPPROVALNOTE = '" + approvalExp + "'" +
                                          "\nWHERE ID = " + packetId + "";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            komut.ExecuteNonQuery();
                            conn.Close();
                        }

                        // Anasayfayı yenilemek için 2 yöntem vardır.
                        // 1. Yöntem
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                        // 2. Yöntem
                        //FillPacketList();
                        //var source = new BindingSource();
                        //source.DataSource = packets;
                        //dataGridViewPacket.DataSource = source;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
        }

        private void btnSendToBank_Click(object sender, EventArgs e)
        {
            int packetId = 0;
            int BankaKodu = 0, SubeKodu = 0, MusteriNo = 0, HesapNo = 0;
            string FirmaAdi = "";
            for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
            {
                packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
            }
            if (packetId != 0)
            {
                List<string> returnKeyList = new List<string>();
                List<string> currCodeList = new List<string>();
                List<int> clientRefList = new List<int>();
                List<decimal> amountList = new List<decimal>();
                bool check = false;

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM AYZ_PW_SUMMARY WHERE PACKETID = " + packetId + "";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    if (dr.HasRows)
                    {
                        check = true;
                    }
                }

                if (check)
                {
                    MessageBox.Show("Bu Paket daha önce bankaya iletildi!", "UYARI");
                }
                else
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            CommandText = "SELECT " +
                                           "\nRIGHT('000000000' + CAST(D.PACKETID AS VARCHAR(9)), 9) + '-' + RIGHT('0000000000' + CAST(D.CLIENTREF AS VARCHAR(10)), 10) RETURNKEY, " +
                                           "\nD.PACKETID, " +
                                           "\nD.CLIENTREF, " +
                                           "\nSUM(D.AMOUNT_PAID) AMOUNT, " +
                                           "\nD.CURRCODE " +
                                           "\nFROM AYZ_PW_PACKET_DETAIL D " +
                                           "\nWHERE PACKETID = " + packetId + " " +
                                           "\nGROUP BY D.PACKETID, D.CLIENTREF, D.CURRCODE";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            dr = komut.ExecuteReader();
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    returnKeyList.Add(dr["RETURNKEY"].ToString());
                                    clientRefList.Add(Convert.ToInt32(dr["CLIENTREF"].ToString()));
                                    amountList.Add(Convert.ToDecimal(dr["AMOUNT"].ToString()));
                                    currCodeList.Add(dr["CURRCODE"].ToString());
                                }
                                conn.Close();
                            }
                        }

                        for (int i = 0; i < returnKeyList.Count; i++)
                        {
                            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                            {
                                CommandText = "INSERT INTO AYZ_PW_SUMMARY(RETURNKEY,PACKETID,CLIENTREF,AMOUNT,CURRCODE,CREATED_DATE,CREATED_TIME) " +
                                                  "\nVALUES(" +
                                                  "\n'" + returnKeyList[i] + "'," +
                                                  "\n" + packetId + "," +
                                                  "\n" + clientRefList[i] + "," +
                                                  "\n" + amountList[i].ToString().Replace(',', '.') + "," +
                                                  "\n'" + currCodeList[i] + "'," +
                                                  "\nCONVERT(DATE, GETDATE(), 104)," +
                                                  "\n" + Helper.GetTime() + ")";
                                komut.CommandText = CommandText;
                                komut.Connection = conn;
                                conn.Open();
                                dr = komut.ExecuteReader();
                            }
                        }

                        decimal sum = 0;
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            CommandText = "SELECT DISTINCT BA.BANKACCOUNTNO,S.AMOUNT,PD.IBAN,S.RETURNKEY,S.CURRCODE,BANKCODE = B.BANKNR," +
                                          "\nOUTBRANCHCODE = B.BRANCHNR, P.NOTE, PD.CL_TAXNR,PD.CL_EMAIL,PD.CL_TAXOFFICE,CUSTOMERNO = B.CUSTOMERNR,B.FIRMNAME  " +
                                          "\nFROM AYZ_PW_SUMMARY AS S " +
                                          "\nLEFT JOIN AYZ_PW_PACKET_DETAIL AS PD ON S.PACKETID = PD.PACKETID AND S.CLIENTREF = PD.CLIENTREF " +
                                          "\nLEFT JOIN AYZ_PW_PACKET AS P ON P.ID = PD.PACKETID " +
                                          "\nLEFT JOIN AYZ_PW_BANKACCOUNT AS BA ON BA.ID = P.ACCOUNTOUTID " +
                                          "\nLEFT JOIN AYZ_PW_BANK AS B ON B.ID = BA.BANKID " +
                                          "\nWHERE PD.PACKETID = " + packetId + "";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();

                            SqlDataAdapter da = new SqlDataAdapter();
                            da.SelectCommand = komut;
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            var Engine = new FileHelperEngine<RecordDetails>();
                            List<RecordDetails> Records = new List<RecordDetails>();
                            foreach (DataRow dr in dt.Rows)
                            {
                                //string sabitD = "D";
                                string HEDEFBANKA1 = (string)dr["BANKCODE"].ToString();
                                string HEDEFSUBE1 = (string)dr["OUTBRANCHCODE"].ToString();
                                string HEDEFHESAPNUMARASI1 = (string)dr["BANKACCOUNTNO"].ToString();
                                string PARAKODU1 = (string)dr["CURRCODE"].ToString();
                                decimal TUTAR1 = (decimal)dr["AMOUNT"];
                                string ACIKLAMA1 = (string)dr["NOTE"].ToString();
                                string FIRMAREFERANS1 = (string)dr["RETURNKEY"].ToString();
                                //string UNVAN1 = (string)dr["UNVAN"];
                                //string ADDRESS1 = (string)dr["ADDRESS"];
                                //string TELEFON1 = (string)dr["TELEFON"];
                                string VERGIKIMLIKNO1 = (string)dr["CL_TAXNR"].ToString();
                                string VERGIDAIRESI1 = (string)dr["CL_TAXOFFICE"].ToString();
                                string EMAIL1 = (string)dr["CL_EMAIL"].ToString();
                                string IBAN1 = (string)dr["IBAN"].ToString();
                                //string TCKN1 = (string)dr["TCKN"];
                                BankaKodu = Convert.ToInt32(dr["BANKCODE"].ToString());
                                SubeKodu = Convert.ToInt32(dr["OUTBRANCHCODE"].ToString());
                                MusteriNo = Convert.ToInt32(dr["CUSTOMERNO"].ToString());
                                HesapNo = Convert.ToInt32(dr["BANKACCOUNTNO"].ToString());
                                FirmaAdi = dr["FIRMNAME"].ToString();
                                //ToplamTutarını alması
                                sum = sum + Convert.ToDecimal(TUTAR1);

                                var infos = new RecordDetails
                                {
                                    Dstring = "D",
                                    HEDEFBANKA = HEDEFBANKA1,
                                    HEDEFSUBE = HEDEFSUBE1,
                                    HEDEFHESAPNUMARASI = HEDEFHESAPNUMARASI1,
                                    PARAKODU = PARAKODU1,
                                    TUTAR = TUTAR1,
                                    ACIKLAMA = ACIKLAMA1,
                                    FIRMAREFERANS = FIRMAREFERANS1,
                                    //UNVAN = UNVAN1,
                                    //ADDRESS = ADDRESS1,
                                    //TELEFON = TELEFON1,
                                    VERGIKIMLIKNO = VERGIKIMLIKNO1,
                                    VERGIDAIRESI = VERGIDAIRESI1,
                                    EMAIL = EMAIL1,
                                    IBAN = IBAN1//,
                                                //TCKN = TCKN1
                                };

                                Records.Add(infos);
                            }
                            //string tempFilePath = @"C:\d";        // Bunu kullanıcıdan alıcaz. Örn: Dosya Yolu Seçin dicez.                             
                            //string filePath = tempFilePath + "\\";
                            #region SFTP Bilgilerini AYZ_PW_SFTP_SETTING tablosundan alma
                            string hostName = "", sftpUserName = "", password = "", folderPath = "", filePath = "";
                            int port = 22;

                            using (SqlConnection connNEW = new SqlConnection(ConnectionHelper.ConnectionString))
                            {
                                CommandText = "SELECT * FROM AYZ_PW_SFTP_SETTING WHERE BANKCODE = '" + BankaKodu + "' AND FIRMNR = '" + Helper.FIRMNR + "' ";
                                komut.CommandText = CommandText;
                                komut.Connection = connNEW;
                                connNEW.Open();
                                dr = komut.ExecuteReader();
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        hostName = dr["HOSTNAME"].ToString();
                                        port = Convert.ToInt32(dr["PORT"].ToString());
                                        sftpUserName = dr["USERNAME"].ToString();
                                        password = dr["PASSWORD"].ToString();
                                        folderPath = dr["FOLDERPATH"].ToString() + "/";
                                        filePath = dr["PAYMENTORDERLOGFOLDER"].ToString() + "\\";
                                    }
                                    connNEW.Close();
                                }
                            }
                            #endregion


                            //  HEADER ----Buradaki Bazı bilgileri Veritabandan çekebiliriz 
                            // KurusHesabı                        
                            string OdemeninHesaptanCikisTarihi = DateTime.Now.Year + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd");
                            int kurusHesabi = 0001882345;
                            string fileHeader = "H6" + DateTime.Now.Year + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + BankaKodu.ToString().PadLeft(4, '0') + SubeKodu.ToString().PadLeft(5, '0') + MusteriNo.ToString().PadLeft(8, '0') + HesapNo.ToString().PadLeft(8, '0') + OdemeninHesaptanCikisTarihi + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + kurusHesabi.ToString().PadLeft(8, '0');
                            Engine.HeaderText = fileHeader;                 //Dosyanın Headerı

                            //DECİMAL  Format
                            CultureInfo myCI = new CultureInfo("tr-TR", false);
                            CultureInfo myCIclone = (CultureInfo)myCI.Clone();
                            myCIclone.NumberFormat.NumberDecimalSeparator = ".";

                            //FOOTER BÖLGESİ
                            string Tfoot = "T";
                            string Odemeadedi = dt.Rows.Count.ToString().PadLeft(12, '0');
                            string OdemeToplamTutar = sum.ToString(myCIclone).PadLeft(20, '0');
                            string FileFooter = Tfoot + Odemeadedi + OdemeToplamTutar;
                            Engine.FooterText = FileFooter;

                            //Dosya ismi
                            string fileName = "OD" + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.Hour.ToString().PadLeft(2, '0') + DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + "G" + HesapNo.ToString().PadLeft(8, '0') + SubeKodu.ToString().PadLeft(4, '0') + FirmaAdi + "$";

                            //Dosyayı Yaz
                            Engine.WriteFile("" + filePath + "" + fileName + ".txt", Records);

                            string sendToBankFileName = filePath + fileName + ".txt";

                            var result = SFTP.Upload(sendToBankFileName, hostName, port, sftpUserName, password, folderPath);
                            JObject json = JObject.Parse(result);
                            string message = json["Message_"].ToString();
                            int resultCode = Convert.ToInt32(json["ResultCode"].ToString());

                            if (resultCode == 1)
                            {
                                MessageBox.Show("Paket Bankaya İletildi!", "UYARI");

                                using (SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString))
                                {
                                    // Güncellenecek Alanlar
                                    // STATUS                            
                                    CommandText = "UPDATE AYZ_PW_PACKET" +
                                                  "\nSET STATUS = " + (int)Helper.PacketStatus.SentToBank + " " +
                                                  "\nWHERE ID = " + packetId + "";
                                    komut.CommandText = CommandText;
                                    komut.Connection = conn;
                                    conn2.Open();
                                    komut.ExecuteNonQuery();
                                    conn2.Close();
                                }
                            }
                            else if (resultCode == 0)
                            {
                                MessageBox.Show("Paket Bankaya İletilirken bir sorun oluştu.!\n " + message + "", "UYARI");
                            }
                        }

                        // Anasayfayı yenilemek için.                        
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata :\n" + ex.ToString());
                    }
                }
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            try
            {
                int packetId = 0;
                for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
                {
                    packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
                }
                if (packetId != 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                    {
                        // Güncellenecek Alanlar : STATUS, APPROVALNOTE
                        CommandText = "UPDATE AYZ_PW_PACKET" +
                                      "\nSET ARCHIVED = " + (int)Helper.ArchiveStatus.Archived + "" +
                                      "\nWHERE ID = " + packetId + "";
                        komut.CommandText = CommandText;
                        komut.Connection = conn;
                        conn.Open();
                        komut.ExecuteNonQuery();
                        conn.Close();
                    }

                    // Anasayfayı yenilemek için 2 yöntem vardır.
                    // 1. Yöntem
                    Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                    form.FillPacketList();
                    // 2. Yöntem
                    //FillPacketList();
                    //var source = new BindingSource();
                    //source.DataSource = packets;
                    //dataGridViewPacket.DataSource = source;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
        }

        private void btnBankAndBankAccAdd_Click_1(object sender, EventArgs e)
        {
            BanksForm form = new BanksForm();
            form.ShowDialog();
        }

        private void sFTPAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sftpForm form = new sftpForm();
            form.ShowDialog();
        }

        private void Anasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnAkibetSorgulama_Click(object sender, EventArgs e)
        {
            int packetId = 0;
            for (int i = 0; i < dataGridViewPacket.SelectedRows.Count; i++)
            {
                packetId = (int)dataGridViewPacket.SelectedRows[i].Cells["ID"].Value;
            }
            if (packetId != 0)
            {
                #region engine 1
                FileHelperEngine<PAYMENTOUTCOME> engineDetail = new FileHelperEngine<PAYMENTOUTCOME>(); // Detail için
                engineDetail.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
                engineDetail.BeforeReadRecord += (eng, i) =>
                {
                    if (i.RecordLine.StartsWith("!") ||
                        i.RecordLine.StartsWith("-"))
                        i.SkipThisRecord = true;
                };
                engineDetail.AfterReadRecord += (eng, xd) =>
                {
                    if (xd.Record.BANKCODE == 0)
                        xd.SkipThisRecord = false;
                };
                #endregion

                #region engine 2
                FileHelperEngine<FOOTER> engineFooter = new FileHelperEngine<FOOTER>();
                engineFooter.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
                engineFooter.BeforeReadRecord += (eng, f) =>
                {
                    if (f.RecordLine.StartsWith("H") ||
                        f.RecordLine.StartsWith("D"))
                        f.SkipThisRecord = true;
                };
                engineFooter.AfterReadRecord += (eng, f) =>
                {
                    if (f.RecordLine.StartsWith(" "))
                        f.SkipThisRecord = true;
                };
                #endregion

                #region SFTP Bilgilerini AYZ_PW_SFTP_SETTING tablosundan alma
                string hostName = "", sftpUserName = "", password = "", folderPath = "", filePath = "";
                int port = 22;

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT SETTING.* FROM AYZ_PW_PACKET AS P " +
                                  "\nLEFT JOIN AYZ_PW_BANKACCOUNT AS BA ON P.ACCOUNTOUTID = BA.ID " +
                                  "\nLEFT JOIN AYZ_PW_BANK AS BANK ON BANK.ID = BA.BANKID " +
                                  "\nLEFT JOIN AYZ_PW_SFTP_SETTING AS SETTING ON SETTING.BANKCODE = BANK.BANKNR " +
                                  "\nWHERE P.ID = '" + packetId + "' AND SETTING.FIRMNR = '" + Helper.FIRMNR + "'";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            hostName = dr["HOSTNAME"].ToString();
                            port = Convert.ToInt32(dr["PORT"].ToString());
                            sftpUserName = dr["USERNAME"].ToString();
                            password = dr["PASSWORD"].ToString();
                            folderPath = dr["FOLDERPATH"].ToString() + "/";
                            filePath = dr["PAYMENTORDERLOGFOLDER"].ToString() + "\\";
                        }
                        conn.Close();
                    }
                }
                #endregion

                List<string> fileNameList = FileNameList(folderPath, hostName, port, sftpUserName, password);
                foreach (var item in fileNameList)
                {
                    int summaryId = 0;
                    bool check = false;
                    PAYMENTOUTCOME[] DetailResult;
                    FOOTER[] FooterResult;
                    string downloadResult = SFTP.Download(filePath, hostName, port, sftpUserName, password, folderPath + item);
                    JObject jsonDownload = JObject.Parse(downloadResult);
                    int downloadResultCode = Convert.ToInt32(jsonDownload["ResultCode"].ToString());
                    if (downloadResultCode == 1)
                    {
                        try
                        {
                            DetailResult = engineDetail.ReadFile(filePath + item);
                            FooterResult = engineFooter.ReadFile(filePath + item);
                            foreach (var value in DetailResult)
                            {
                                string returnKey = value.COMPANYREF;
                                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                                {
                                    CommandText = "SELECT * FROM AYZ_PW_SUMMARY WHERE RETURNKEY = '" + returnKey + "' AND PACKETID = '" + packetId + "'";
                                    komut.CommandText = CommandText;
                                    komut.Connection = conn;
                                    conn.Open();
                                    dr = komut.ExecuteReader();
                                    if (dr.Read())
                                    {
                                        summaryId = Convert.ToInt32(dr["ID"].ToString());
                                    }
                                    if (dr.HasRows)
                                    {
                                        check = true;
                                    }
                                }
                                if (check == true)
                                {
                                    using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                                    {
                                        CommandText = "UPDATE AYZ_PW_SUMMARY SET PAYMENT_STATUS = '" + value.PAYMENTSTATUS + "' WHERE ID = '" + summaryId + "'";
                                        komut.CommandText = CommandText;
                                        komut.Connection = conn;
                                        conn.Open();
                                        komut.ExecuteNonQuery();
                                        conn.Close();
                                    }
                                }
                            }
                            if (check == true)
                            {
                                DebitClosingForm form = new DebitClosingForm(packetId, item, DetailResult, FooterResult);
                                form.ShowDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: \n" + ex.Message);
                        }
                    }
                }
            }
        }

        private List<string> FileNameList(string folderPath, string hostName, int port, string userName, string password)
        {
            List<string> oldDownloadedList = new List<string>();
            #region Daha Önce İndirilen Akibet Dosyalarının ismini oldDownloadedList adlı Listeye alma
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                string name = "";
                CommandText = "SELECT * FROM AYZ_PW_DOWNLOADED_FILE";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    name = dr["FILENAME"].ToString();
                    oldDownloadedList.Add(name);
                }
            }
            #endregion
            string listResult = SFTP.ListDirectory(folderPath, hostName, port, userName, password);
            JObject jsonList = JObject.Parse(listResult);
            string message = jsonList["Message_"].ToString();
            int resultCode = Convert.ToInt32(jsonList["ResultCode"].ToString());
            List<string> names = jsonList["FileNameList"].ToString().Split(',').Where(x => x.Contains("OA")).ToList();
            names = names.Except(oldDownloadedList).ToList();     // Except, names listesinde olup oldDownloadedList listesinde olmayanları bulur ve listeler.
            return names;
        }

        private void dataGridViewPacket_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dataGridViewPacket.Rows[e.RowIndex].Selected = true;
                Rectangle r = dataGridViewPacket.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                contextMenuStripAnasayfa.Show((Control)sender, r.Left + e.X, r.Top + e.Y);
            }
        }

        private void akibetiİnceleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int packetId = (int)dataGridViewPacket.SelectedRows[0].Cells["ID"].Value;
            int packetStatus = (int)dataGridViewPacket.SelectedRows[0].Cells["STATUS"].Value;
            if (packetStatus == (int)Helper.PacketStatus.AnswerReceivedBank)
            {
                bool review = true;
                DebitClosingForm form = new DebitClosingForm(packetId, review);
                form.ShowDialog();
            }
        }

        private void logoUserSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogoUserInfo info = new LogoUserInfo();
            info.ShowDialog();
        }
    }
}
