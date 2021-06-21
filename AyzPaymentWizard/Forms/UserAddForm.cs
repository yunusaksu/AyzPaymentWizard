using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

            try
            {
                cmd.CommandText = "INSERT INTO [AYZ_PW_USER](NAME,PASSWORD,USERTYPE,FIRMNR,DATE,EMAIL)VALUES('" + Username + "','" + encrytedPassword + "',0,'" + LogoFirmaNumber + "', GETDATE(),'" + email + "');SELECT SCOPE_IDENTITY()";
                cmd.Connection = conn;
                conn.Open();
                int userId = Convert.ToInt32(cmd.ExecuteScalar());
                #region MyRegion
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
                this.Hide();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            ToolTip infoBtnToolTip = new ToolTip();
            infoBtnToolTip.SetToolTip(btnInfo, "Silmek İçin: Satırı Seçtikten Sonra Delete Tuşuna Basınız!");
            //SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
            //SqlCommand cmd = new SqlCommand("SELECT ID, NAME FROM [AYZ_PW_USER] WHERE USERTYPE = '1' ORDER BY NAME ASC", conn);
            //conn.Open();
            //DataTable tbl = new DataTable();
            //tbl.Load(cmd.ExecuteReader());
            //conn.Close();

            //cmbGroup.DataSource = tbl;
            //cmbGroup.DisplayMember = "NAME";
            //cmbGroup.ValueMember = "ID";

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
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
    }
}
