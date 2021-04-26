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
            #region Paket Id'den paranın çıkacağı hesap bulunur. (AYZ_PW_BANKACCOUNT tablosundan)
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT B.* FROM AYZ_PW_PACKET AS P LEFT JOIN AYZ_PW_BANKACCOUNT AS B ON P.ACCOUNTOUTID = B.ID WHERE P.ID = '" + PacketID + "'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    TigerBankAccNo = dr["TIGERBANKACCOUNTNO"].ToString();
                }
            }
            #endregion

            foreach (var item in liste)
            {
                UnityObjects.UnityApplication UnityApp = new UnityObjects.UnityApplication();
                if (UnityApp.Login("Logo", "logo", 1))
                {
                    UnityObjects.Data bankvo = UnityApp.NewDataObject(UnityObjects.DataObjectType.doBankVoucher);
                    bankvo.New();
                    bankvo.DataFields.FieldByName("DATE").Value = "01.07.2020";
                    bankvo.DataFields.FieldByName("NUMBER").Value = "~";
                    bankvo.DataFields.FieldByName("DIVISION").Value = 0;
                    bankvo.DataFields.FieldByName("DEPARMENT").Value = 0;
                    bankvo.DataFields.FieldByName("TYPE").Value = 4;
                    bankvo.DataFields.FieldByName("GL_POSTED").Value = 1;
                    bankvo.DataFields.FieldByName("SIGN").Value = 1;
                    bankvo.DataFields.FieldByName("NOTES1").Value = "TEB GÖNDERİLEN HAVALELER";
                    bankvo.DataFields.FieldByName("ACCFICHEREF").Value = 14459;
                    bankvo.DataFields.FieldByName("CURRSEL_TOTALS").Value = 1;

                    UnityObjects.Lines transactions_lines = bankvo.DataFields.FieldByName("TRANSACTIONS").Lines;
                    transactions_lines.AppendLine();
                    transactions_lines[transactions_lines.Count - 1].FieldByName("INTERNAL_REFERENCE").Value = 5077;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TYPE").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TRANNO").Value = 2020070100002;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BANKACC_CODE").Value = "" + TigerBankAccNo + "";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("ARP_CODE").Value = "" + item.CLCODE + "";
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("GL_CODE1").Value = "320.001.001.0250";
                    //transactions_lines[transactions_lines.Count - 1].FieldByName("GL_CODE2").Value = "102.001.001.0004";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("SOURCEFREF").Value = 1217;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DATE").Value = "01.07.2020";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("SIGN").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TRCODE").Value = 4;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("MODULENR").Value = 7;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DESCRIPTION").Value = "" + item.DESCRIPTION + "";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("CREDIT").Value = Convert.ToDecimal(item.AMOUNT);
                    transactions_lines[transactions_lines.Count - 1].FieldByName("AMOUNT").Value = Convert.ToDecimal(item.AMOUNT);
                    transactions_lines[transactions_lines.Count - 1].FieldByName("TC_AMOUNT").Value = Convert.ToDecimal(item.AMOUNT);
                    transactions_lines[transactions_lines.Count - 1].FieldByName("RC_XRATE").Value = 6.8432;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("RC_AMOUNT").Value = 1724.34;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BANK_PROC_TYPE").Value = 2;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DUE_DATE").Value = "01.07.2020";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("AFFECT_RISK").Value = 0;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("IBAN").Value = "" + item.IBAN + "";
                    transactions_lines[transactions_lines.Count - 1].FieldByName("BN_CRDTYPE").Value = 1;
                    transactions_lines[transactions_lines.Count - 1].FieldByName("DIVISION").Value = 0;
                    bankvo.DataFields.FieldByName("EBOOK_DOCTYPE").Value = 99;
                    bankvo.FillAccCodes();
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
    }
}
