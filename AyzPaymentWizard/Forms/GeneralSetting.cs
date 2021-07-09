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
    public partial class GeneralSetting : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        public GeneralSetting()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GeneralSetting_Load(object sender, EventArgs e)
        {
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            comboSource.Add("RATES1", "1. Tür");
            comboSource.Add("RATES2", "2. Tür");
            comboSource.Add("RATES3", "3. Tür");
            comboSource.Add("RATES4", "4. Tür");
            cmbCurrType.DataSource = new BindingSource(comboSource, null);
            cmbCurrType.DisplayMember = "Value";
            cmbCurrType.ValueMember = "Key";

            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VAL_= SETTING_VALUE FROM AYZ_PW_GENERAL_SETTING WHERE FIRMNR = " + Helper.FIRMNR + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    cmbCurrType.SelectedValue = dr["VAL_"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "TRUNCATE TABLE AYZ_PW_GENERAL_SETTING";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    conn.Close();
                }

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "INSERT INTO AYZ_PW_GENERAL_SETTING(SETTING_NAME,SETTING_VALUE,FIRMNR)" +
                                  "\nVALUES('CURRTYPE', '" + (string)cmbCurrType.SelectedValue + "', " + Helper.FIRMNR + ")";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    MessageBox.Show("Kayıt Başarılı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
