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
    public partial class GroupAddForm : Form
    {
        public GroupAddForm()
        {
            InitializeComponent();
        }

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            bool PackageAdd = false, PackageEdit = false, PackageApprove = false, PackageReject = false;
            for (int i = 0; i < yetkiTreeView.Nodes.Count; i++)
            {
                PackageAdd = yetkiTreeView.Nodes["PackageAdd"].Checked;
                PackageEdit = yetkiTreeView.Nodes["PackageEdit"].Checked;
                PackageApprove = yetkiTreeView.Nodes["PackageApprove"].Checked;
                PackageReject = yetkiTreeView.Nodes["PackageReject"].Checked;

            }

            SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
            SqlCommand komut = new SqlCommand();
            SqlDataReader dr;
            try
            {
                komut.CommandText = "INSERT INTO [AYZ_PW_USER](NAME,USERTYPE,DATE) VALUES(" +
                                "'" + groupName + "',1 ,GETDATE());" +
                                "SELECT SCOPE_IDENTITY()";
                komut.Connection = conn;
                conn.Open();
                int groupId = Convert.ToInt32(komut.ExecuteScalar());
                komut.CommandText = "INSERT INTO [AYZ_PW_USERRIGHTS](GROUPID,ADD_PACKAGE,EDIT_PACKAGE,APPROVE_PACKAGE,REJECT_PACKAGE) VALUES(" +
                                    " '" + groupId + "', '" + PackageAdd.ToString() + "','" + PackageEdit.ToString() + "', '" + PackageApprove.ToString() + "', '" + PackageReject.ToString() + "') ";
                komut.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Grup başarılı bir şekilde kaydedildi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
