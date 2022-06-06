using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class BankAccounts : Form
    {
        List<BankAcc> accounts = new List<BankAcc>();

        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        int Bankref;
        int BankId;
        public BankAccounts()
        {
            InitializeComponent();
        }
        public BankAccounts(int bankref, int bankId)
        {
            Bankref = bankref;
            BankId = bankId;
            InitializeComponent();
        }

        private void BankAccounts_Load(object sender, EventArgs e)
        {
            DGVBankAccount.ReadOnly = true;
            fillDGVBankAcc();

            // Hesap Döviz Türü
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                DataTable tbl = new DataTable();
                CommandText = "SELECT - 1 CURTYPE, 'SEÇİNİZ' CURCODE, 'SEÇİNİZ' CURNAME " +
                              "\nUNION " +
                              "\nSELECT 0 CURTYPE, 'TL' CURCODE, 'Türk Lirası' CURNAME " +
                              "\nUNION " +
                              "\nSELECT DISTINCT CURTYPE,CURCODE,CURNAME FROM L_CURRENCYLIST " +
                              "\nWHERE CURTYPE IN(1,20,17)";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                tbl.Load(dr);

                comboBoxCurrency.DataSource = tbl;
                comboBoxCurrency.DisplayMember = "CURCODE";
                comboBoxCurrency.ValueMember = "CURTYPE";
            }
        }
        private void btnBankAccAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                string title = txtTitle.Text;
                int currency = (int)comboBoxCurrency.SelectedValue;
                int bankAccRef = (int)comboBoxAccountNo.SelectedValue;
                var bankAccountNo = "";
                var tigerBankAccountNo = "";
                CommandText = "SELECT * FROM LG_" + Helper.FIRMANO + "_BANKACC WHERE LOGICALREF = '" + bankAccRef + "' ";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    bankAccountNo = dr["ACCOUNTNO"].ToString();
                    tigerBankAccountNo = dr["CODE"].ToString();
                }
                conn.Close();
                try
                {
                    CommandText = "INSERT INTO AYZ_PW_BANKACCOUNT" +
                    "\n(BANKREF,BANKACCREF,BANKID,BANKACCOUNTNO,TITLE,FIRMNR,CURRENCY,TIGERBANKACCOUNTNO) " +
                    "\nVALUES('" + Bankref + "','" + bankAccRef + "','" + BankId + "'," +
                    "\n'" + bankAccountNo + "','" + title + "','" + Helper.FIRMNR + "','" + currency + "','" + tigerBankAccountNo + "')";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();

                    BankAccounts form = (BankAccounts)Application.OpenForms["BankAccounts"];
                    form.fillDGVBankAcc();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: \n" + ex.Message,"Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void fillDGVBankAcc()
        {
            accounts.Clear();
            //BANKA HESAPLARI GRIDINI DOLDURMA
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_BANKACCOUNT WHERE BANKREF = " + Bankref + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    BankAcc acc = new BankAcc();
                    acc.Id = Convert.ToInt32(dr["ID"].ToString());
                    acc.BankRef = Convert.ToInt32(dr["BANKREF"].ToString());
                    acc.BankAccRef = Convert.ToInt32(dr["BANKACCREF"].ToString());
                    acc.BankAccountNo = dr["BANKACCOUNTNO"].ToString();
                    acc.TigerBankAccountNo = dr["TIGERBANKACCOUNTNO"].ToString();
                    acc.Title = dr["TITLE"].ToString();
                    acc.FirmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    acc.Currency = Convert.ToInt32(dr["CURRENCY"].ToString());
                    accounts.Add(acc);
                }
            }

            var source = new BindingSource();
            source.DataSource = accounts;
            DGVBankAccount.DataSource = source;
        }

        private void comboBoxCurrency_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Hesap No
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                DataTable tbl = new DataTable();
                CommandText = "SELECT * FROM LG_" + Helper.FIRMANO + "_BANKACC WHERE BANKREF = '" + Bankref + "' AND CURRENCY = '" + (int)comboBoxCurrency.SelectedValue + "' ";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                tbl.Load(dr);

                comboBoxAccountNo.DataSource = tbl;
                comboBoxAccountNo.DisplayMember = "DEFINITION_";
                comboBoxAccountNo.ValueMember = "LOGICALREF";
            }
        }
    }
}
