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

namespace AyzPaymentWizard
{
    public partial class UserAddForm : Form
    {
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
            var GroupId = cmbGroup.SelectedValue;
            var LogoFirmaNumber = cmbFirmNumber.SelectedValue;

            try
            {
                cmd.CommandText = "INSERT INTO [AYZ_PW_USER](NAME,PASSWORD,USERTYPE,FIRMNR,DATE)VALUES('" + Username + "','" + Password + "',0,'" + LogoFirmaNumber + "', GETDATE());SELECT SCOPE_IDENTITY()";
                cmd.Connection = conn;
                conn.Open();
                int userId = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.CommandText = "INSERT INTO [AYZ_PW_USERGROUPS](GROUPID,USERID) VALUES(" +
                                        " '" + GroupId.ToString() + "', '" + userId.ToString() + "') ";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Kullanıcı başarılı bir şekilde kaydedildi!", "Kullanıcı Kayıt Ekranı");
                this.Hide();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message.ToString());
            }
        }

        private void UserAddForm_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT ID, NAME FROM [AYZ_PW_USER] WHERE USERTYPE = '1' ORDER BY NAME ASC", conn);
            conn.Open();
            DataTable tbl = new DataTable();
            tbl.Load(cmd.ExecuteReader());
            conn.Close();

            cmbGroup.DataSource = tbl;
            cmbGroup.DisplayMember = "NAME";
            cmbGroup.ValueMember = "ID";

            ///
            // Begin            
            ///
            SqlConnection conn2 = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand cmd2 = new SqlCommand("SELECT NR FROM L_CAPIFIRM", conn2);
            conn2.Open();
            DataTable tbl2 = new DataTable();
            tbl2.Load(cmd2.ExecuteReader());
            conn.Close();

            cmbFirmNumber.DataSource = tbl2;
            cmbFirmNumber.DisplayMember = "NR";
            cmbFirmNumber.ValueMember = "NR";
            ///
            // End
            ///
        }
    }
}
