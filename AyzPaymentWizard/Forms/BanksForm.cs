using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class BanksForm : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<Bank> banks = new List<Bank>();

        public BanksForm()
        {
            InitializeComponent();
        }

        private void AddBankAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var bankRef = (int)DGVBank.SelectedRows[0].Cells["BANKREF"].Value;  // LG_001_BANK id'sidir.
            var bankId = (int)DGVBank.SelectedRows[0].Cells["ID"].Value;  // AYZ_PW_BANK id'sidir.
            BankAccounts form = new BankAccounts(bankRef,bankId);
            form.Show();
        }

        private void BanksAndBankAccountsForm_Load(object sender, EventArgs e)
        {
            DGVBank.ReadOnly = true;
            fillDGVBanks();
            txtBankCode.Text = "";
            txtBranchCode.Text = "";
            txtCustomerNo.Text = "";
            txtFirmName.Text = "";

            #region Statüs
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Kullanımda");
            comboSource.Add(0, "Kullanım Dışı");
            comboBoxStatus.DataSource = new BindingSource(comboSource, null);
            comboBoxStatus.DisplayMember = "Value";
            comboBoxStatus.ValueMember = "Key";           
            #endregion

            //BANKA ADI            
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                DataTable tbl = new DataTable();
                CommandText = "SELECT LOGICALREF = 0, DEFINITION_ = 'SEÇİNİZ' UNION SELECT LOGICALREF,DEFINITION_ FROM LG_" + Helper.FIRMANO + "_BNCARD";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                tbl.Load(dr);

                comboBoxBankName.DataSource = tbl;
                comboBoxBankName.DisplayMember = "DEFINITION_";
                comboBoxBankName.ValueMember = "LOGICALREF";
            }

            //BANKA ŞUBESİ
            // Form Load olduğunda Banka Şubesi Combobox'ı boş gelmemesi için Loaddada Banka Şubesi bilgileri çağırılmalıdır.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                int bankref = (int)comboBoxBankName.SelectedValue;
                DataTable tbl = new DataTable();
                CommandText = "SELECT BANKREF = LOGICALREF,BRANCH FROM LG_" + Helper.FIRMANO + "_BNCARD WHERE LOGICALREF = " + bankref + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                tbl.Load(dr);

                comboBoxBankBranch.DataSource = tbl;
                comboBoxBankBranch.DisplayMember = "BRANCH";
                comboBoxBankBranch.ValueMember = "BANKREF";
            }
        }

        private void comboBoxBankName_SelectionChangeCommitted(object sender, EventArgs e)
        {            
            //BANKA ŞUBESİ
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                int bankref = (int)comboBoxBankName.SelectedValue;
                DataTable tbl = new DataTable();
                CommandText = "SELECT BANKREF = LOGICALREF,BRANCH FROM LG_" + Helper.FIRMANO + "_BNCARD WHERE LOGICALREF = " + bankref + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                tbl.Load(dr);

                comboBoxBankBranch.DataSource = tbl;
                comboBoxBankBranch.DisplayMember = "BRANCH";
                comboBoxBankBranch.ValueMember = "BANKREF";
            }

            #region BANKALAR GRIDINI SEÇİLEN BANKAYA GÖRE DOLDURMA
            banks.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_BANK WHERE BANKREF = " + comboBoxBankName.SelectedValue + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Bank bank = new Bank();
                    bank.Id = Convert.ToInt32(dr["ID"].ToString());
                    bank.BankRef = Convert.ToInt32(dr["BANKREF"].ToString());
                    bank.BankNr = dr["BANKNR"].ToString() == "" ? -1 : Convert.ToInt32(dr["BANKNR"].ToString());
                    bank.BranchNr = dr["BRANCHNR"].ToString() == "" ? -1 : Convert.ToInt32(dr["BRANCHNR"].ToString());
                    bank.BankName = dr["BANKNAME"].ToString();
                    bank.BranchName = dr["BRANCHNAME"].ToString();
                    bank.FirmName = dr["FIRMNAME"].ToString();
                    bank.CustomerNo = dr["CUSTOMERNR"].ToString();
                    bank.FirmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    bank.Status = Convert.ToBoolean(dr["STATUS"].ToString()) == false ? 0 : 1;
                    banks.Add(bank);
                }
            }

            var source = new BindingSource();
            source.DataSource = banks;
            DGVBank.DataSource = source;
            #endregion

            txtBankCode.Text = "";
            txtBranchCode.Text = "";
            txtCustomerNo.Text = "";
            txtFirmName.Text = "";
            #region Statüs
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "Kullanımda");
            comboSource.Add(0, "Kullanım Dışı");
            comboBoxStatus.DataSource = new BindingSource(comboSource, null);
            comboBoxStatus.DisplayMember = "Value";
            comboBoxStatus.ValueMember = "Key";
            #endregion
        }

        private void btnBankAdd_Click(object sender, EventArgs e)
        {
            // AYZ_PW_BANK Tablosuna Banka Ekleme İşlemleri
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    int bankref = (int)comboBoxBankName.SelectedValue;
                    string bankName = (string)comboBoxBankName.Text;
                    string branchName = (string)comboBoxBankBranch.Text;
                    string firmName = txtFirmName.Text;
                    int customerNr = Convert.ToInt32(txtCustomerNo.Text);
                    string bankcode = txtBankCode.Text;
                    string branchcode = txtBranchCode.Text;
                    int status = (int)comboBoxStatus.SelectedValue;
                    CommandText = "INSERT INTO AYZ_PW_BANK" +
                        "\n(BANKREF,BANKNAME,BRANCHNAME,FIRMNAME,CUSTOMERNR,FIRMNR,BANKNR,BRANCHNR,STATUS) " +
                        "\nVALUES('" + bankref + "','" + bankName + "'," +
                        "\n'" + branchName + "','" + firmName + "','" + customerNr + "','" + Helper.FIRMNR + "','" + bankcode + "'," +
                        "\n'" + branchcode + "','" + status + "')";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();

                    BanksForm form = (BanksForm)Application.OpenForms["BanksForm"];
                    form.fillDGVBanks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: \n" + ex.Message,"Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DGVBank_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                DGVBank.Rows[e.RowIndex].Selected = true;
                Rectangle r = DGVBank.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                contextMenuStripBank.Show((Control)sender, r.Left + e.X, r.Top + e.Y);

                //int bankId = (int)DGVBank.Rows[e.RowIndex].Cells["BANKREF"].Value;
            }
        }

        private void fillDGVBanks()
        {
            banks.Clear();
            //BANKALAR GRIDINI DOLDURMA
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_BANK";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Bank bank = new Bank();
                    bank.Id = Convert.ToInt32(dr["ID"].ToString());
                    bank.BankRef = Convert.ToInt32(dr["BANKREF"].ToString());
                    bank.BankNr = dr["BANKNR"].ToString() == "" ? -1 : Convert.ToInt32(dr["BANKNR"].ToString());
                    bank.BranchNr = dr["BRANCHNR"].ToString() == "" ? -1 : Convert.ToInt32(dr["BRANCHNR"].ToString());
                    bank.BankName = dr["BANKNAME"].ToString();
                    bank.BranchName = dr["BRANCHNAME"].ToString();
                    bank.FirmName = dr["FIRMNAME"].ToString();
                    bank.CustomerNo = dr["CUSTOMERNR"].ToString();
                    bank.FirmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    bank.Status = Convert.ToBoolean(dr["STATUS"].ToString()) == false ? 0 : 1;
                    banks.Add(bank);
                }
            }

            var source = new BindingSource();
            source.DataSource = banks;
            DGVBank.DataSource = source;
        }


        int indexRow;
        private void DGVBank_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Seçili olan satırın değerlerini üst taraftaki textboxlara ve comboboxlara doldur!
            indexRow = e.RowIndex;
            DataGridViewRow row = DGVBank.Rows[indexRow];
            txtFirmName.Text = row.Cells["FirmName"].Value.ToString();
            txtCustomerNo.Text = row.Cells["CustomerNo"].Value.ToString();
            comboBoxBankName.Text = row.Cells["BankName"].Value.ToString();
            comboBoxBankBranch.Text = row.Cells["BranchName"].Value.ToString();
            comboBoxStatus.Text = row.Cells["Status"].Value.ToString() == "0" ? "Kullanım Dışı" : "Kullanımda";
            txtBankCode.Text = row.Cells["BankNr"].Value.ToString();
            txtBranchCode.Text = row.Cells["BranchNr"].Value.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int Id = (int)DGVBank.SelectedRows[0].Cells["Id"].Value;
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    int bankref = (int)comboBoxBankName.SelectedValue;
                    string bankName = (string)comboBoxBankName.Text;
                    string branchName = (string)comboBoxBankBranch.Text;
                    string firmName = txtFirmName.Text;
                    int customerNr = Convert.ToInt32(txtCustomerNo.Text);
                    string bankcode = txtBankCode.Text;
                    string branchcode = txtBranchCode.Text;
                    int status = (int)comboBoxStatus.SelectedValue;
                    CommandText = "UPDATE AYZ_PW_BANK " +
                                  "\nSET " +
                                  "\nBANKREF = '" + bankref + "'," +
                                  "\nBANKNR = '" + bankcode + "', " +
                                  "\nBRANCHNR = '" + branchcode + "', " +
                                  "\nBANKNAME = '" + bankName + "', " +
                                  "\nBRANCHNAME = '" + branchName + "', " +
                                  "\nFIRMNAME =  '" + firmName + "'," +
                                  "\nCUSTOMERNR = '" + customerNr + "', " +
                                  "\nSTATUS = '" + status + "' " +
                                  "\nWHERE ID = '" + Id + "'";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();

                    BanksForm form = (BanksForm)Application.OpenForms["BanksForm"];
                    form.fillDGVBanks();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: \n" + ex.Message,"Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
