using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class DebitClosingForm : Form
    {
        List<SUB_PAYMENTOUTCOME> liste = new List<SUB_PAYMENTOUTCOME>();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        int PacketID;
        bool Review = false;
        string Item = "";
        PAYMENTOUTCOME[] DetailResult;
        FOOTER[] FooterResult;
        public DebitClosingForm()
        {
            InitializeComponent();
        }

        public DebitClosingForm(int packetId, bool review)
        {
            PacketID = packetId;
            Review = review;
            InitializeComponent();
        }


        public DebitClosingForm(int packetId, string item, PAYMENTOUTCOME[] detailResult, FOOTER[] footerResult)
        {
            InitializeComponent();
            PacketID = packetId;
            Item = item;
            DetailResult = detailResult;
            FooterResult = footerResult;
        }

        private void DebitClosingForm_Load(object sender, EventArgs e)
        {
            if (Review == false)
            {
                fillDGVDebitClosing();
            }
            else
            {
                ReviewfillDGVDebitClosing();
                btnDebitClosing.Enabled = false;
            }

            #region DGVDebitClosing Gridinin Kolon Görünüm,Header Text ve Display Index Ayarları
            DGVDebitClosing.Columns["CLCARDID"].Visible = false;
            DGVDebitClosing.Columns["TYPE"].Visible = false;
            DGVDebitClosing.Columns["COMPANYREF"].Visible = false;
            DGVDebitClosing.Columns["PAYMENTSTATUS"].Visible = false;
            DGVDebitClosing.Columns["EFTQUERYNO"].Visible = false;
            DGVDebitClosing.Columns["TRANSACTIONNO"].HeaderText = "İŞLEM NO";
            DGVDebitClosing.Columns["DESCRIPTION"].HeaderText = "AÇIKLAMA";
            DGVDebitClosing.Columns["BANKCODE"].HeaderText = "BANKA KODU";
            DGVDebitClosing.Columns["TRANSACTION_DATE"].HeaderText = "İŞLEM TARİHİ";
            DGVDebitClosing.Columns["AMOUNT"].HeaderText = "İŞLEM TUTARI";
            DGVDebitClosing.Columns["CURRENCYCODE"].HeaderText = "KUR";
            DGVDebitClosing.Columns["BRANCHCODE"].HeaderText = "ŞUBE KODU";
            DGVDebitClosing.Columns["CLCODE"].HeaderText = "CARİ HESAP KODU";
            DGVDebitClosing.Columns["ACCOUNTNO"].HeaderText = "HESAP NO";
            #endregion

        }

        private void fillDGVDebitClosing()
        {
            for (int i = 0; i < DetailResult.Length; i++)
            {
                SUB_PAYMENTOUTCOME payment = new SUB_PAYMENTOUTCOME();
                payment.ACCOUNTNO = DetailResult[i].ACCOUNTNO;
                payment.BRANCHCODE = DetailResult[i].BRANCHCODE;
                payment.BANKCODE = DetailResult[i].BANKCODE;
                payment.PAYMENTSTATUS = DetailResult[i].PAYMENTSTATUS;
                payment.CURRENCYCODE = DetailResult[i].CURRENCYCODE;
                payment.AMOUNT = Convert.ToDecimal(DetailResult[i].AMOUNT.Replace(".", ",")).ToString();
                payment.DESCRIPTION = DetailResult[i].DESCRIPTION;
                payment.COMPANYREF = DetailResult[i].COMPANYREF;
                payment.TRANSACTIONNO = DetailResult[i].TRANSACTIONNO;
                payment.EFTQUERYNO = DetailResult[i].EFTQUERYNO;
                payment.IBAN = DetailResult[i].IBAN;
                payment.TYPE = DetailResult[i].TYPE;
                payment.TRANSACTION_DATE = DetailResult[i].TRANSACTION_DATE;
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT C.CODE,C.LOGICALREF FROM AYZ_PW_SUMMARY AS S " +
                                  "\nLEFT JOIN LG_" + Helper.FIRMANO + "_CLCARD AS C ON C.LOGICALREF = S.CLIENTREF " +
                                  "\nWHERE S.RETURNKEY = '" + payment.COMPANYREF + "'";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        payment.CLCODE = dr["CODE"].ToString();
                        payment.CLCARDID = Convert.ToInt32(dr["LOGICALREF"].ToString());
                    }
                }
                liste.Add(payment);
            }

            var source = new BindingSource();
            source.DataSource = liste;
            DGVDebitClosing.DataSource = source;
        }

        private void ReviewfillDGVDebitClosing()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT D.*, S.CLIENTREF,CLIENT.CODE FROM AYZ_PW_SUMMARY AS S " +
                              "\nLEFT JOIN AYZ_PW_DOWNLOADED_FILE_DETAIL AS D ON S.RETURNKEY = D.COMPANY_REF " +
                              "\nLEFT JOIN LG_" + Helper.FIRMANO + "_CLCARD AS CLIENT ON CLIENT.LOGICALREF  = S.CLIENTREF " +
                              "\nWHERE S.PACKETID = " + PacketID + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    SUB_PAYMENTOUTCOME payment = new SUB_PAYMENTOUTCOME();
                    payment.CLCODE = dr["CODE"].ToString();
                    payment.ACCOUNTNO = dr["TARGET_ACCNO"].ToString();
                    payment.BRANCHCODE = Convert.ToInt32(dr["TARGET_BRANCH"].ToString());
                    payment.BANKCODE = Convert.ToInt32(dr["TARGET_BANK"].ToString());
                    payment.PAYMENTSTATUS = Convert.ToInt32(dr["PAYMENT_STATUS"].ToString());
                    payment.CURRENCYCODE = dr["CURRCODE"].ToString();
                    payment.AMOUNT = dr["AMOUNT"].ToString();
                    payment.DESCRIPTION = dr["EXPLAIN"].ToString();
                    payment.COMPANYREF = dr["COMPANY_REF"].ToString();
                    payment.TRANSACTIONNO = Convert.ToInt32(dr["TRANSACTIONNO"].ToString());
                    payment.EFTQUERYNO = Convert.ToInt32(dr["EFTQUERY_NO"].ToString());
                    payment.IBAN = dr["IBAN"].ToString();
                    payment.TYPE = dr["RECORD_TYPE"].ToString();
                    payment.CLCARDID = Convert.ToInt32(dr["CLIENTREF"].ToString());
                    liste.Add(payment);
                }
            }

            var source = new BindingSource();
            source.DataSource = liste;
            DGVDebitClosing.DataSource = source;
        }

        private void btnDebitClosing_Click(object sender, EventArgs e)
        {
            string TigerBankAccNo = "";
            string BankName = "";
            #region Paket Id'den paranın çıkacağı hesap bulunur. (AYZ_PW_BANKACCOUNT tablosundan)
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT B.*,BN.DEFINITION_ FROM AYZ_PW_PACKET AS P " +
                              "\nLEFT JOIN AYZ_PW_BANKACCOUNT AS B ON P.ACCOUNTOUTID = B.ID " +
                              "\nLEFT JOIN LG_" + Helper.FIRMANO + "_BNCARD AS BN ON BN.LOGICALREF = B.BANKREF " +
                              "\nWHERE P.ID = '" + PacketID + "'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    TigerBankAccNo = dr["TIGERBANKACCOUNTNO"].ToString();
                    BankName = dr["DEFINITION_"].ToString();
                }
            }
            #endregion

            UnityObjects.UnityApplication UnityApp = new UnityObjects.UnityApplication();
            if (UnityApp.Login("" + Helper.LOGOUSERNAME + "", "" + Helper.LOGOUSERPASS + "", Helper.FIRMNR))
            {
                foreach (var item in liste)
                {
                    int CurType = GetCurType(item.CURRENCYCODE);
                    decimal CurRate = GetCurRate(item.CURRENCYCODE);
                    decimal ReportCurRate = GetReportCurRate();
                    string day = item.TRANSACTION_DATE.ToString().Substring(0, 2);
                    string month = item.TRANSACTION_DATE.ToString().Substring(2, 2);
                    string year = item.TRANSACTION_DATE.ToString().Substring(4, 4);
                    UnityObjects.Data bankvo = UnityApp.NewDataObject(UnityObjects.DataObjectType.doBankVoucher);
                    bankvo.New();
                    bankvo.DataFields.FieldByName("INTERNAL_REFERENCE").Value = "~";
                    bankvo.DataFields.FieldByName("DATE").Value = "" + day + "." + month + "." + year + "";
                    bankvo.DataFields.FieldByName("NUMBER").Value = "~";
                    bankvo.DataFields.FieldByName("DIVISION").Value = 0;
                    bankvo.DataFields.FieldByName("DEPARMENT").Value = 0;
                    bankvo.DataFields.FieldByName("TYPE").Value = 4;
                    bankvo.DataFields.FieldByName("SIGN").Value = 1;
                    bankvo.DataFields.FieldByName("CREATED_BY").Value = 1;
                    bankvo.DataFields.FieldByName("CURRSEL_TOTALS").Value = 1;
                    bankvo.DataFields.FieldByName("DATA_REFERENCE").Value = "~";
                    bankvo.DataFields.FieldByName("NOTES1").Value = "" + BankName + " GÖNDERİLEN HAVALELER";

                    UnityObjects.Lines transactions_lines = bankvo.DataFields.FieldByName("TRANSACTIONS").Lines;
                    transactions_lines.AppendLine();
                    transactions_lines[transactions_lines.Count - 1].FieldByName("INTERNAL_REFERENCE").Value = "~";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TYPE").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BANKACC_CODE").Value = "" + TigerBankAccNo + "";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("ARP_CODE").Value = "" + item.CLCODE + "";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("GL_CODE1").Value = "" + GetClCardEmuhaccCode(item.CLCODE) + "";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCEFREF").Value = "~";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("SIGN").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TRCODE").Value = 4;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("MODULENR").Value = 7;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("CURR_TRANS").Value = "" + CurType + ""; // dolar için 1 Euro için 20 ...
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("CREDIT").Value = 128.84;
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("AMOUNT").Value = item.AMOUNT;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TC_AMOUNT").Value = item.AMOUNT.Replace(",", ".");  // Transaction Currency Amount
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TC_XRATE").Value = "" + CurRate + ""; // işlem döviz kurunun değeri örn: 8 buçuk lira
                    transactions_lines[transactions_lines.Count - 1].FieldByName("RC_XRATE").Value = "" + ReportCurRate + "";    // Report Curreny Rate
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("RC_AMOUNT").Value = 16.11;  // Report Currency Amount
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BANK_PROC_TYPE").Value = 2;
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("DUE_DATE").Value = "27.07.2020";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DATA_REFERENCE").Value = "~";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("AFFECT_RISK").Value = 0;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("IBAN").Value = "" + item.IBAN + "";

                    UnityObjects.Lines payment_list0 = transactions_lines[transactions_lines.Count - 1].FieldByName("PAYMENT_LIST").Lines;
                    payment_list0.AppendLine();
                    payment_list0[payment_list0.Count - 1].FieldByName("INTERNAL_REFERENCE").Value = "~";
                    payment_list0[payment_list0.Count - 1].FieldByName("MODULENR").Value = 7;
                    payment_list0[payment_list0.Count - 1].FieldByName("TRCODE").Value = 4;
                    payment_list0[payment_list0.Count - 1].FieldByName("PROCDATE").Value = "" + day + "." + month + "." + year + "";
                    payment_list0[payment_list0.Count - 1].FieldByName("DATE").Value = "" + day + "." + month + "." + year + "";
                    payment_list0[payment_list0.Count - 1].FieldByName("DATA_REFERENCE").Value = 0;
                    payment_list0[payment_list0.Count - 1].FieldByName("DISCTRDELLIST").Value = 0;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BN_CRDTYPE").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DIVISION").Value = 0;
                    bankvo.DataFields.FieldByName("EBOOK_DOCTYPE").Value = 99;
                    bankvo.FillAccCodes();

                    if (bankvo.Post() == true)
                    {
                        //MessageBox.Show("POST OK !");
                        int BANKFICHEREF = bankvo.DataFields.FieldByName("INTERNAL_REFERENCE").Value; // Gönderilen Havale-EFT'nin referansı
                        int BANKFICHELINEREF = 0;                                                     // Gönderilen Havale-EFT'nin satır referansı
                        int BANKFICHELINEPAYTRANSREF = 0;
                        int INVOICEPAYTRANSREF = 0;
                        int invoiceRef = 0;
                        #region Gönderilen Havale-EFT'nin LG_XXX_BNFLINE referansını elde ediyoruz.
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            CommandText = "SELECT LOGICALREF " +
                                          "\nFROM LG_" + Helper.FIRMANO + "_01_BNFLINE L WHERE L.SOURCEFREF = '" + BANKFICHEREF + "' AND CLIENTREF = '" + item.CLCARDID + "' " +
                                          "\nAND MODULENR = 7 AND TRCODE = 4";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            dr = komut.ExecuteReader();
                            while (dr.Read())
                            {
                                BANKFICHELINEREF = Convert.ToInt32(dr["LOGICALREF"].ToString());
                            }
                        }
                        #endregion                        

                        var temp = item.COMPANYREF.Split('-');
                        int packetId = Convert.ToInt32(temp[0]);
                        int clientref = Convert.ToInt32(temp[1]);
                        List<Debit> debitList = new List<Debit>();
                        #region Packet Detail Tablosundan Yapılacak Ödemeyi ve Faturanın PayTransRef'ini Getirme
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            CommandText = "SELECT * FROM AYZ_PW_PACKET_DETAIL WHERE PACKETID = '" + PacketID + "' AND CLIENTREF = '" + clientref + "'";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            dr = komut.ExecuteReader();
                            while (dr.Read())
                            {
                                Debit d = new Debit();
                                d.Paid = Convert.ToDecimal(dr["AMOUNT_PAID"].ToString());
                                d.PayRef = Convert.ToInt32(dr["PAYTRANSREF"].ToString());
                                debitList.Add(d);
                            }
                        }
                        // Gönderilen Havele-Eft ile yolladığımız para yetene kadar Paket Detail tablosundaki tüm satırları kapatıcam.
                        decimal totalAmount = Convert.ToDecimal(item.AMOUNT.Replace('.', ','));
                        #endregion
                        if (debitList.Count == 1)
                        {
                            decimal NecessaryAmountPaid = Convert.ToDecimal(debitList[0].Paid);
                            if (totalAmount >= NecessaryAmountPaid)
                            {
                                #region Gönderilen Havale-EFT'nin oluşturduğu Ödeme Hareketinin PAYTRANSREF'i                        
                                BANKFICHELINEPAYTRANSREF = GetBankFicheLinePayTransRef(BANKFICHELINEREF);
                                #endregion
                                bool foo = UnityApp.DebtClose(BANKFICHELINEPAYTRANSREF, debitList[0].PayRef, Convert.ToDouble(NecessaryAmountPaid));
                                if (foo == true)
                                {
                                    //MessageBox.Show("Borç Kapama Tamamlandı!");
                                }
                                else
                                    MessageBox.Show("Borç Kapama Emri Sırasında Hata Oluştu!");
                            }
                        }
                        else if (debitList.Count > 0)
                        {
                            for (int i = 0; i < debitList.Count; i++)
                            {
                                decimal NecessaryAmountPaid = Convert.ToDecimal(debitList[i].Paid);
                                if (totalAmount > 0)
                                {
                                    #region Gönderilen Havale-EFT'nin oluşturduğu Ödeme Hareketinin PAYTRANSREF'i                        
                                    BANKFICHELINEPAYTRANSREF = GetBankFicheLinePayTransRef(BANKFICHELINEREF);
                                    #endregion
                                    bool foo = UnityApp.DebtClose(BANKFICHELINEPAYTRANSREF, debitList[i].PayRef, Convert.ToDouble(NecessaryAmountPaid));
                                    if (foo == true)
                                    {
                                        totalAmount = totalAmount - NecessaryAmountPaid;
                                        //MessageBox.Show("Borç Kapama Tamamlandı!");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Borç Kapama Emri Sırasında Hata Oluştu!\n" + UnityApp.GetLastError() + " " + UnityApp.GetLastErrorString(), "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (bankvo.ErrorCode != 0)
                        {
                            MessageBox.Show("DBError(" + bankvo.ErrorCode.ToString() + ")-" + bankvo.ErrorDesc + bankvo.DBErrorDesc, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (bankvo.ValidateErrors.Count > 0)
                        {
                            string result = "XML ErrorList:";
                            for (int i = 0; i < bankvo.ValidateErrors.Count; i++)
                            {
                                result += "(" + bankvo.ValidateErrors[i].ID.ToString() + ") - " + bankvo.ValidateErrors[i].Error;
                            }
                            MessageBox.Show(result);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Hatalı Logo Giriş Bilgileri Tespit Edildi!", "Logo Bilgileri Hatalı!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT PAYMENT_STATUS FROM AYZ_PW_SUMMARY WHERE PAYMENT_STATUS IS NOT NULL AND PACKETID = '" + PacketID + "'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                if (dr.HasRows)
                {
                    using (SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString))
                    {
                        // Güncellenecek Alanlar: STATUS                        
                        CommandText = "UPDATE AYZ_PW_PACKET" +
                                      "\nSET STATUS = " + (int)Helper.PacketStatus.AnswerReceivedBank + "" +
                                      "\nWHERE ID = " + PacketID + "";
                        komut.CommandText = CommandText;
                        komut.Connection = conn2;
                        conn2.Open();
                        komut.ExecuteNonQuery();
                        conn2.Close();
                    }
                    Helper.PacketHistorySave(PacketID, "Akibet Alındı", "Akibet Alındı.");
                    saveDownloadedFiles(Item, DetailResult, FooterResult);
                    Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                    form.FillPacketList();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Bu Paketin Banka Tarafından Henüz Akibet Dosyası Yollanmamıştır!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private int GetBankFicheLinePayTransRef(int bankfichelineref)
        {
            int result = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGICALREF FROM LG_" + Helper.FIRMANO + "_01_PAYTRANS P " +
                              "\nWHERE MODULENR = 7 AND TRCODE = 4 AND CROSSREF = 0 AND P.FICHEREF = " + bankfichelineref + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    result = Convert.ToInt32(dr["LOGICALREF"].ToString());
                }
                conn.Close();
            }
            return result;
        }

        private string GetClCardEmuhaccCode(string clCode)
        {
            string accoutingCode = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT MUHAC.CODE FROM LG_" + Helper.FIRMANO + "_CLCARD AS CLIENT " +
                                  "\nLEFT JOIN LG_" + Helper.FIRMANO + "_CRDACREF AS CRDACREF ON CLIENT.LOGICALREF = CRDACREF.CARDREF " +
                                  "\nLEFT JOIN LG_" + Helper.FIRMANO + "_EMUHACC AS MUHAC ON MUHAC.LOGICALREF = CRDACREF.ACCOUNTREF " +
                                  "\nWHERE CLIENT.CODE = '" + clCode + "' AND TYP = 1 AND TRCODE = 5";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        accoutingCode = dr["CODE"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return accoutingCode;
        }

        private decimal GetCurRate(string curCode)
        {
            string CurrRatesName = "";
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VAL_ = SETTING_VALUE,* FROM AYZ_PW_GENERAL_SETTING WHERE FIRMNR = " + Helper.FIRMNR + " AND SETTING_NAME = 'CURRTYPE'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CurrRatesName = dr["VAL_"].ToString();
                }
            }
            int val = GetCurType(curCode);

            decimal result = 0;
            if (curCode != "TRY")
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM L_DAILYEXCHANGES WHERE EDATE = '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "' AND CRTYPE = " + val + "";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        result = Convert.ToDecimal(dr["" + CurrRatesName + ""].ToString());
                    }
                }
            }
            else
            {
                result = 1;
                return result;
            }

            return result;
        }

        private int GetCurType(string curCode)
        {
            int result = 0;
            if (curCode != "TRY")
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM L_CURRENCYLIST WHERE CURCODE = '" + curCode + "' AND FIRMNR = '" + Helper.FIRMNR + "'";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        result = Convert.ToInt32(dr["CURTYPE"].ToString());
                    }
                }
            }
            else
            {
                result = 160;
                return result;
            }

            return result;
        }

        private decimal GetReportCurRate()
        {
            string CurrRatesName = "";
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VAL_ = SETTING_VALUE,* FROM AYZ_PW_GENERAL_SETTING WHERE FIRMNR = " + Helper.FIRMNR + " AND SETTING_NAME = 'CURRTYPE'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    CurrRatesName = dr["VAL_"].ToString();
                }
            }

            int ReportCurType = 0;
            decimal ReportCurRate = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT REPORTCUR.PERREPCURR,DAILY.EDATE,DAILY.RATES1,DAILY.RATES2,DAILY.RATES3,DAILY.RATES4 FROM L_CAPIPERIOD AS REPORTCUR " +
                              "\nLEFT JOIN L_DAILYEXCHANGES AS DAILY ON DAILY.CRTYPE = REPORTCUR.PERREPCURR " +
                              "\nWHERE ACTIVE = 1 AND FIRMNR = '" + Helper.FIRMNR + "' AND " +
                              "\nEDATE = '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ReportCurRate = Convert.ToDecimal(dr["" + CurrRatesName + ""].ToString());
                    ReportCurType = Convert.ToInt32(dr["PERREPCURR"].ToString());
                }
            }
            return ReportCurRate;
        }

        private void saveDownloadedFiles(string item, PAYMENTOUTCOME[] result, FOOTER[] footerResult)
        {
            decimal SumOfLines = Convert.ToDecimal(footerResult[0].PAYMENT_TOTAL);
            int CountOfLines = Convert.ToInt32(footerResult[0].PAYMENT_COUNT);
            int DownloadedFileID;
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "INSERT INTO AYZ_PW_DOWNLOADED_FILE(FILENAME,FIRMNR,DOWNLOAD_DATE,DOWNLOAD_TIME,COUNT_LINE,SUM_LINE) " +
                              "VALUES(" +
                              "\n'" + item + "'," +
                              "\n'" + Helper.FIRMNR + "'," +
                              "\nCONVERT(DATE, GETDATE(), 104)," +
                              "\n'" + Helper.GetTime() + "'," +
                              "\n'" + CountOfLines + "'," +
                              "\n'" + SumOfLines + "'" +
                              "\n);SELECT SCOPE_IDENTITY()";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    DownloadedFileID = Convert.ToInt32(komut.ExecuteScalar());
                    for (int i = 0; i < result.Length; i++)
                    {
                        string day = result[i].TRANSACTION_DATE.ToString().Substring(0, 2);
                        string month = result[i].TRANSACTION_DATE.ToString().Substring(2, 2);
                        string year = result[i].TRANSACTION_DATE.ToString().Substring(4, 4);
                        string date = day + "." + month + "." + year;
                        komut.CommandText = "INSERT INTO [AYZ_PW_DOWNLOADED_FILE_DETAIL]        (PARENTREF,FIRMNR,RECORD_TYPE,TARGET_BANK,TARGET_BRANCH,TARGET_ACCNO,CURRCODE,AMOUNT,EXPLAIN,COMPANY_REF," +
                                  "PAYMENT_STATUS,TRANSACTIONNO,TRANSACTION_DATE,EFTQUERY_NO,IBAN) " +
                                  "VALUES(" +
                                          "\n'" + DownloadedFileID + "', " +
                                          "\n'" + Helper.FIRMNR + "'," +
                                          "\n'" + result[i].TYPE + "', " +
                                          "\n'" + result[i].BANKCODE + "', " +
                                          "\n'" + result[i].BRANCHCODE + "', " +
                                          "\n'" + result[i].ACCOUNTNO + "', " +
                                          "\n'" + result[i].CURRENCYCODE + "', " +
                                          "\n'" + result[i].AMOUNT + "', " +
                                          "\n'" + result[i].DESCRIPTION + "', " +
                                          "\n'" + result[i].COMPANYREF + "', " +
                                          "\n'" + result[i].PAYMENTSTATUS + "', " +
                                          "\n'" + result[i].TRANSACTIONNO + "', " +
                                          "\n CONVERT(DATE,'" + date + "', 104), " +
                                          "\n'" + result[i].EFTQUERYNO + "', " +
                                          "\n'" + result[i].IBAN + "' " +
                                          ")";
                        komut.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
