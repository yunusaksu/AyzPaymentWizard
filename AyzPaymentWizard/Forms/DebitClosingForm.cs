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

namespace AyzPaymentWizard.Forms
{
    public partial class DebitClosingForm : Form
    {
        List<SUB_PAYMENTOUTCOME> liste = new List<SUB_PAYMENTOUTCOME>();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        int PacketID;

        public DebitClosingForm()
        {
            InitializeComponent();
        }

        public DebitClosingForm(int packetId)
        {
            InitializeComponent();
            PacketID = packetId;
        }

        private void DebitClosingForm_Load(object sender, EventArgs e)
        {
            fillDGVDebitClosing();
        }

        private void fillDGVDebitClosing()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT DISTINCT DETAIL.*,CL_CODE FROM AYZ_PW_PACKET_DETAIL AS P " +
                              "\nLEFT JOIN AYZ_PW_SUMMARY AS SUMMARY ON P.PACKETID = SUMMARY.PACKETID " +
                              "\nLEFT JOIN AYZ_PW_DOWNLOADED_FILE_DETAIL AS DETAIL ON DETAIL.COMPANY_REF = SUMMARY.RETURNKEY " +
                              "\nLEFT JOIN AYZ_PW_DOWNLOADED_FILE AS DOWNLOADED ON DOWNLOADED.ID = DETAIL.PARENTREF " +
                              "\nWHERE P.PACKETID = '" + PacketID + "' AND DETAIL.ID IS NOT NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    SUB_PAYMENTOUTCOME payment = new SUB_PAYMENTOUTCOME();
                    payment.ID = Convert.ToInt32(dr["ID"].ToString());
                    payment.PARANTREF = Convert.ToInt32(dr["PARENTREF"].ToString());
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
                    payment.CLCODE = dr["CL_CODE"].ToString();
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

            foreach (var item in liste)
            {
                int CurType = GetCurType(item.CURRENCYCODE);
                decimal CurRate = GetCurRate(item.CURRENCYCODE);
                decimal ReportCurRate = GetReportCurRate();

                UnityObjects.UnityApplication UnityApp = new UnityObjects.UnityApplication();
                if (UnityApp.Login("Logo", "logo", 1))
                {
                    UnityObjects.Data bankvo = UnityApp.NewDataObject(UnityObjects.DataObjectType.doBankVoucher);
                    bankvo.New();
                    bankvo.DataFields.FieldByName("INTERNAL_REFERENCE").Value = "~";
                    bankvo.DataFields.FieldByName("DATE").Value = "" + DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year + "";
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
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("GL_CODE2").Value = "102.001.001.0003";
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
                    //payment_list0[payment_list0.Count - 1].FieldByName("TOTAL").Value = 128.84;
                    //payment_list0[payment_list0.Count - 1].FieldByName("PROCDATE").Value = "27.07.2020";
                    //payment_list0[payment_list0.Count - 1].FieldByName("REPORTRATE").Value = 8;
                    payment_list0[payment_list0.Count - 1].FieldByName("DATA_REFERENCE").Value = 0;
                    payment_list0[payment_list0.Count - 1].FieldByName("DISCTRDELLIST").Value = 0;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BN_CRDTYPE").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DIVISION").Value = 0;
                    bankvo.DataFields.FieldByName("EBOOK_DOCTYPE").Value = 99;
                    bankvo.FillAccCodes();
                    // Muhasebe Kodlarının otomatik gelmesi için Tigerda Genel Muhasebe > Ana Kayıtlar > Muhasebe Bağlantı Kodları > Cari Hesap Bağlantı Kodları 
                    // içerisine girerek ilgili cari hesaba gerekli muhasebe kodu tanımlanmalıdır. Sonrasında tekrar Muhasebe bağlantı Kodları'na girerek
                    // Bu sefer Banka Kodları > Banka Cari Hesap Kodları kısmını açarak orada da ilgili banka hesabını gerekli muhasebe koduyla ilişkilendirilmesi
                    // gerekmektedir.

                    if (bankvo.Post() == true)
                    {
                        MessageBox.Show("POST OK !");
                    }
                    else
                    {
                        if (bankvo.ErrorCode != 0)
                        {
                            MessageBox.Show("DBError(" + bankvo.ErrorCode.ToString() + ")-" + bankvo.ErrorDesc + bankvo.DBErrorDesc);
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
                else
                {
                    MessageBox.Show("Hatalı");
                }
            }

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
                MessageBox.Show("Hata: \n" + ex.Message);
            }

            return accoutingCode;
        }

        private decimal GetCurRate(string curCode)
        {
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
                        result = Convert.ToDecimal(dr["RATES1"].ToString());
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
            int ReportCurType = 0;
            decimal ReportCurRate = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT REPORTCUR.PERREPCURR,DAILY.EDATE,DAILY.RATES1 FROM L_CAPIPERIOD AS REPORTCUR " +
                              "\nLEFT JOIN L_DAILYEXCHANGES AS DAILY ON DAILY.CRTYPE = REPORTCUR.PERREPCURR " +
                              "\nWHERE ACTIVE = 1 AND FIRMNR = '" + Helper.FIRMNR + "' AND " +
                              "\nEDATE = '" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    ReportCurRate = Convert.ToDecimal(dr["RATES1"].ToString());
                    ReportCurType = Convert.ToInt32(dr["PERREPCURR"].ToString());
                }
            }
            return ReportCurRate;
        }
    }
}
