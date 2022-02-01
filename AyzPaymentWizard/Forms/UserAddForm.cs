using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace AyzPaymentWizard
{
    public partial class UserAddForm : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<User> users = new List<User>();
        public UserAddForm()
        {
            InitializeComponent();
        }

        private void BtnUserSave_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {

                #region Edit
                try
                {
                    string userName = txtUsername.Text;
                    string userPassword = txtPassword.Text;
                    string encrytedPassword2 = EncryptionAlgorithm.Encrytion(userPassword);
                    string userEmail = txtEmail.Text;
                    var firmNr = cmbFirmNumber.SelectedValue;
                    if (dataGridViewUsers.SelectedRows.Count > 0)
                    {
                        if (String.IsNullOrEmpty(userEmail) || checkedListBoxGroup.CheckedItems.Count == 0)
                        {
                            MessageBox.Show("Yıldız(*) ile işaretli olanların doldurulması zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (firmNr == null)
                        {
                            MessageBox.Show("Geçerli Firma Numarası Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            int userId = (int)dataGridViewUsers.SelectedRows[0].Cells["ID"].Value;
                            using (SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString))
                            {
                                CommandText = "UPDATE AYZ_PW_USER " +
                                              "\nSET " +
                                              "\nNAME = '" + userName + "'," +
                                              "\nPASSWORD = '" + encrytedPassword2 + "'," +
                                              "\nEMAIL = '" + userEmail + "'," +
                                              "\nFIRMNR = '" + firmNr + "'" +
                                              "\nWHERE ID = '" + userId + "'";
                                komut.CommandText = CommandText;
                                komut.Connection = conn2;
                                conn2.Open();
                                dr = komut.ExecuteReader();
                                conn2.Close();
                            }
                            var list = checkedListBoxGroup.CheckedItems;

                            #region Güncellenecek User'ın USERGROUPS verilerini sıfırlama                
                            using (SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString))
                            {
                                CommandText = "DELETE FROM AYZ_PW_USERGROUPS WHERE USERID = " + userId + "";
                                komut.CommandText = CommandText;
                                komut.Connection = conn2;
                                conn2.Open();
                                dr = komut.ExecuteReader();
                                conn2.Close();
                            }
                            #endregion

                            #region Kullanıcıları USERGROUPS tablosuna ekleme  
                            using (SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString))
                            {
                                foreach (DataRowView dataRow in list)
                                {
                                    int groupId = (int)dataRow.Row.ItemArray[0];
                                    CommandText = "INSERT INTO [AYZ_PW_USERGROUPS](GROUPID,USERID) VALUES(" +
                                                            "'" + groupId.ToString() + "', '" + userId.ToString() + "') ";
                                    komut.CommandText = CommandText;
                                    komut.Connection = conn2;
                                    conn2.Open();
                                    dr = komut.ExecuteReader();
                                    conn2.Close();
                                }
                            }
                            #endregion                                                        
                            MessageBox.Show("Güncellendi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Kullanıcı Güncelleme Ekranında Bir Sorun İle Karşılaşıldı!\n" + ex.Message);
                }
                #endregion
            }
            else
            {
                #region Save
                SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
                SqlCommand cmd = new SqlCommand();
                // User Kaydederken UserType = 0 olmalıdır.
                var Username = txtUsername.Text;
                var Password = txtPassword.Text;
                var email = txtEmail.Text;
                string encrytedPassword = EncryptionAlgorithm.Encrytion(Password);
                //var GroupId = cmbGroup.SelectedValue;
                var LogoFirmaNumber = cmbFirmNumber.SelectedValue;

                if (MailCheck(email, LogoFirmaNumber))
                {
                    MessageBox.Show("Bu mail ile kayıt olmuş kullanıcı zaten mevcut!\nLütfen farklı bir mail ile kayıt olunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (String.IsNullOrEmpty(email) || checkedListBoxGroup.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Yıldız(*) ile işaretli olanların doldurulması zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (LogoFirmaNumber == null)
                    {
                        MessageBox.Show("Geçerli Firma Numarası Seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        try
                        {
                            cmd.CommandText = "INSERT INTO [AYZ_PW_USER](NAME,PASSWORD,USERTYPE,FIRMNR,DATE,EMAIL)VALUES('" + Username + "','" + encrytedPassword + "',0,'" + LogoFirmaNumber + "', GETDATE(),'" + email + "');SELECT SCOPE_IDENTITY()";
                            cmd.Connection = conn;
                            conn.Open();
                            int userId = Convert.ToInt32(cmd.ExecuteScalar());
                            #region Kullanıcıları USERGROUPS tablosuna ekleme
                            var list = checkedListBoxGroup.CheckedItems;
                            foreach (DataRowView dataRow in list)
                            {
                                int groupId = (int)dataRow.Row.ItemArray[0];

                                cmd.CommandText = "INSERT INTO [AYZ_PW_USERGROUPS](GROUPID,USERID) VALUES(" +
                                                        " '" + groupId.ToString() + "', '" + userId.ToString() + "') ";
                                cmd.ExecuteNonQuery();
                            }
                            #endregion
                            conn.Close();
                            MessageBox.Show("Kullanıcı başarılı bir şekilde kaydedildi!", "Kullanıcı Kayıt Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                #endregion
            }
            FillUsersDGV();
            dataGridViewUsers.ClearSelection();
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
            {
                checkedListBoxGroup.SetItemCheckState(i, CheckState.Unchecked);
            }
        }

        private bool MailCheck(string email, object LogoFirmNr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM AYZ_PW_USER WHERE EMAIL = '" + email + "' AND FIRMNR = '" + LogoFirmNr + "' ";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    if (dr.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                throw new Exception("Mail Check İşleminde Hata Meydana Geldi!.");
            }

        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            try
            {
                ToolTip infoBtnToolTip = new ToolTip();
                infoBtnToolTip.SetToolTip(btnInfo, "Silmek İçin: Satırı Seçtikten Sonra Delete Tuşuna Basınız!");
                ToolTip newRecordBtnToolTip = new ToolTip();
                newRecordBtnToolTip.SetToolTip(btnNewRecord, "Kullanıcı Ekle");

                ///
                // Begin            
                ///
                SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString);
                SqlCommand cmd2 = new SqlCommand("SELECT NR,NAME FROM L_CAPIFIRM", conn2);
                conn2.Open();
                DataTable tbl2 = new DataTable();
                tbl2.Load(cmd2.ExecuteReader());
                conn2.Close();

                cmbFirmNumber.DataSource = tbl2;
                cmbFirmNumber.DisplayMember = "NAME";
                cmbFirmNumber.ValueMember = "NR";
                ///
                // End
                ///

                #region Group Checklistbox Doldurma
                using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    using (SqlCommand cmdGroup = new SqlCommand("SELECT ID, NAME FROM [AYZ_PW_USER] WHERE USERTYPE = '1' ORDER BY NAME ASC", con))
                    {
                        cmdGroup.CommandType = CommandType.Text;
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmdGroup))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            ((ListBox)checkedListBoxGroup).DataSource = dt;
                            ((ListBox)checkedListBoxGroup).DisplayMember = "NAME";
                            ((ListBox)checkedListBoxGroup).ValueMember = "ID";
                        }
                    }
                }
                #endregion

                ToolTip showBtnToolTip = new ToolTip();
                showBtnToolTip.SetToolTip(btnShow, "Şifre Göster");
                ToolTip hideBtnToolTip = new ToolTip();
                hideBtnToolTip.SetToolTip(btnHide, "Şifre Gizle");

                FillUsersDGV();
                dataGridViewUsers.ClearSelection();
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtUsername.Text = "";
                for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
                {
                    checkedListBoxGroup.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillUsersDGV()
        {
            users.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_USER WHERE USERTYPE = 0";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    User user = new User();
                    user.ID = Convert.ToInt32(dr["ID"].ToString());
                    user.Username = dr["NAME"].ToString();
                    user.Password = dr["PASSWORD"].ToString();
                    user.FirmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    user.Email = dr["EMAIL"].ToString();
                    user.Date_ = Convert.ToDateTime(dr["DATE"].ToString());
                    users.Add(user);
                }
            }
            var source = new BindingSource();
            source.DataSource = users;
            dataGridViewUsers.DataSource = source;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }
        private void BtnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }


        private void DataGridViewUsers_KeyDown(object sender, KeyEventArgs e)
        {
            int id = 0;
            int selectedRowCount = dataGridViewUsers.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {
                for (int i = 0; i < selectedRowCount; i++)
                {
                    id = (int)dataGridViewUsers.SelectedRows[i].Cells["ID"].Value;
                }

                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Bu kayıdı silmek istediğinize emin misiniz?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                            {
                                string sql = "DELETE FROM AYZ_PW_USER WHERE ID=" + id + "";
                                komut = new SqlCommand(sql, conn);
                                conn.Open();
                                komut.ExecuteNonQuery();
                                conn.Close();
                                string sql2 = "DELETE FROM AYZ_PW_USERGROUPS WHERE USERID=" + id + "";
                                komut = new SqlCommand(sql2, conn);
                                conn.Open();
                                komut.ExecuteNonQuery();
                                conn.Close();
                                int firmNr = (int)dataGridViewUsers.SelectedRows[0].Cells["FIRMNR"].Value;
                                string sql3 = "DELETE FROM AYZ_PW_FILTER_VALUES WHERE USERNR=" + id + " AND PACKETID IS NULL AND FIRMNR = '" + firmNr + "'";
                                komut = new SqlCommand(sql3, conn);
                                conn.Open();
                                komut.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Silindi!","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Silme işlemi sırasında bir hata ile oluştu.\n" + ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    FillUsersDGV();
                    dataGridViewUsers.ClearSelection();
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtUsername.Text = "";
                    for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
                    {
                        checkedListBoxGroup.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
        }

        private void BtnNewRecord_Click(object sender, EventArgs e)
        {
            cmbFirmNumber.SelectedIndex = 0;
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsername.Text = "";
            for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
            {
                checkedListBoxGroup.SetItemCheckState(i, CheckState.Unchecked);
            }
            dataGridViewUsers.ClearSelection();
        }

        private void DataGridViewUsers_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int userId = (int)dataGridViewUsers.SelectedRows[0].Cells["ID"].Value;
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM AYZ_PW_USER WHERE ID = " + userId + "";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        txtUsername.Text = dr["NAME"].ToString();
                        txtPassword.Text = EncryptionAlgorithm.Decrytion(dr["PASSWORD"].ToString());
                        txtEmail.Text = dr["EMAIL"].ToString();

                        SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString);
                        SqlCommand cmd2 = new SqlCommand("SELECT NR,NAME FROM L_CAPIFIRM", conn2);
                        conn2.Open();
                        DataTable tbl2 = new DataTable();
                        tbl2.Load(cmd2.ExecuteReader());
                        conn2.Close();

                        cmbFirmNumber.DataSource = tbl2;
                        cmbFirmNumber.DisplayMember = "NAME";
                        cmbFirmNumber.ValueMember = "NR";
                        cmbFirmNumber.SelectedValue = Convert.ToInt32(dr["FIRMNR"].ToString());
                    }
                }

                for (int i = 0; i < checkedListBoxGroup.Items.Count; i++)
                {
                    checkedListBoxGroup.SetItemCheckState(i, CheckState.Unchecked);
                }

                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM AYZ_PW_USERGROUPS AS UG LEFT JOIN AYZ_PW_USER AS U ON UG.GROUPID = U.ID WHERE UG.USERID = " + userId + "";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        foreach (DataRowView item in checkedListBoxGroup.Items)
                        {
                            string x = (string)item.Row.ItemArray[1];
                            string name_ = dr["NAME"].ToString();
                            if (x == name_)
                            {
                                checkedListBoxGroup.SetItemCheckState(checkedListBoxGroup.Items.IndexOf(item), CheckState.Checked);
                                break;
                            }
                        }
                    }
                }

            }
        }
    }
}

