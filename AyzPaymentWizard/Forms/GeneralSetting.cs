using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
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

        private void BtnCancel_Click(object sender, EventArgs e)
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

        private void BtnSave_Click(object sender, EventArgs e)
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

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string path = Helper.root + @"\AYZ PAYMENT WIZARD" + @"\dbo.UPDATE_DATABASE";

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (FileInfo item in directoryInfo.GetFiles())
            {
                string script = File.ReadAllText(path + @"\" + item + "");
                // split script on GO command
                IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                using (SqlConnection connection = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    connection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
                                    MessageBox.Show(string.Format("Lütfen SqlServer scrpitlerinizi kontorl ediniz.\nFile: {0} \nLine: {1} \nError: {2} \nSQL Command: \n{3}", Helper.root + @"\AYZ PAYMENT WIZARD", ex.LineNumber, ex.Message, spError), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                #region Güncellenen Table Daha Sonra UpdateDatabaseTables klasöründen kaldırılır.
                File.Delete(path + @"\" + item + "");
                #endregion

            }
            MessageBox.Show("Veri Tabanı Başarı İle Güncelledi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
