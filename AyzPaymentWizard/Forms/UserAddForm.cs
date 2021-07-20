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

        private void btnUserSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand();
            // User Kaydederken UserType = 0 olmalıdır.
            var Username = txtUsername.Text;
            var Password = txtPassword.Text;
            var email = txtEmail.Text;
            string encrytedPassword = EncryptionAlgorithm.Encrytion(Password);
            //var GroupId = cmbGroup.SelectedValue;
            var LogoFirmaNumber = cmbFirmNumber.SelectedValue;

            if (mailCheck(email, LogoFirmaNumber))
            {
                MessageBox.Show("Bu mail ile kayıt olmuş kullanıcı zaten mevcut!\nLütfen farklı bir mail ile kayıt olunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (String.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Yıldız(*) ile işaretli olanların doldurulması zorunludur!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        fillUsersDGV();
                        conn.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private bool mailCheck(string email, object LogoFirmNr)
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

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            ToolTip infoBtnToolTip = new ToolTip();
            infoBtnToolTip.SetToolTip(btnInfo, "Silmek İçin: Satırı Seçtikten Sonra Delete Tuşuna Basınız!");

            ///
            // Begin            
            ///
            SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("SELECT NR FROM L_CAPIFIRM", conn2);
            conn2.Open();
            DataTable tbl2 = new DataTable();
            tbl2.Load(cmd2.ExecuteReader());
            conn2.Close();

            cmbFirmNumber.DataSource = tbl2;
            cmbFirmNumber.DisplayMember = "NR";
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

            dataGridViewUsers.ClearSelection();
            fillUsersDGV();

        }

        private void fillUsersDGV()
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

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                btnHide.BringToFront();
                txtPassword.PasswordChar = '\0';
            }
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                btnShow.BringToFront();
                txtPassword.PasswordChar = '*';
            }
        }

        private void dataGridViewUsers_RowEnter(object sender, DataGridViewCellEventArgs e)
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
                        SqlCommand cmd2 = new SqlCommand("SELECT NR FROM L_CAPIFIRM", conn2);
                        conn2.Open();
                        DataTable tbl2 = new DataTable();
                        tbl2.Load(cmd2.ExecuteReader());
                        conn2.Close();

                        cmbFirmNumber.DataSource = tbl2;
                        cmbFirmNumber.DisplayMember = "NR";
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewUsers.SelectedRows.Count > 0)
            {
                int userId = (int)dataGridViewUsers.SelectedRows[0].Cells["ID"].Value;
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {

                    string userName = txtUsername.Text;
                    string userPassword = txtPassword.Text;
                    string encrytedPassword = EncryptionAlgorithm.Encrytion(userPassword);
                    string userEmail = txtEmail.Text;
                    var firmNr = cmbFirmNumber.SelectedValue;
                    CommandText = "UPDATE AYZ_PW_USER " +
                                  "\nSET " +
                                  "\nNAME = '" + userName + "'," +
                                  "\nPASSWORD = '" + encrytedPassword + "'," +
                                  "\nEMAIL = '" + userEmail + "'," +
                                  "\nFIRMNR = '" + firmNr + "'" +
                                  "\nWHERE ID = '" + userId + "'";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    conn.Close();
                }
                var list = checkedListBoxGroup.CheckedItems;

                #region Güncellenecek User'ın USERGROUPS verilerini sıfırlama                
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "DELETE FROM AYZ_PW_USERGROUPS WHERE USERID = " + userId + "";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    conn.Close();
                }
                #endregion

                #region Kullanıcıları USERGROUPS tablosuna ekleme  
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    foreach (DataRowView dataRow in list)
                    {
                        int groupId = (int)dataRow.Row.ItemArray[0];
                        CommandText = "INSERT INTO [AYZ_PW_USERGROUPS](GROUPID,USERID) VALUES(" +
                                                "'" + groupId.ToString() + "', '" + userId.ToString() + "') ";
                        komut.CommandText = CommandText;
                        komut.Connection = conn;
                        conn.Open();
                        dr = komut.ExecuteReader();
                        conn.Close();
                    }
                }
                #endregion
                UserAddForm form = (UserAddForm)Application.OpenForms["UserAddForm"];
                form.fillUsersDGV();
                MessageBox.Show("Güncellendi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridViewUsers_KeyDown(object sender, KeyEventArgs e)
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
                                MessageBox.Show("Silindi!");

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    fillUsersDGV();
                }
            }
        }
    }
}

