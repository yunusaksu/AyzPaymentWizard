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

namespace AyzPaymentWizard
{
    public partial class GroupAddForm : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<UserGroup> groups = new List<UserGroup>();
        public GroupAddForm()
        {
            InitializeComponent();
        }

        private void btnGroupSave_Click(object sender, EventArgs e)
        {
            string groupName = txtGroupName.Text;
            bool PackageAdd = false, PackageEdit = false, PackageApprove = false, PackageReject = false, PackageSendToApprove = false, PackageForwardToBank = false, PackageAkibet = false;

            for (int i = 0; i < AuthorityTreeView.Nodes.Count; i++)
            {
                PackageAdd = AuthorityTreeView.Nodes["PackageAdd"].Checked;
                PackageEdit = AuthorityTreeView.Nodes["PackageEdit"].Checked;
                PackageApprove = AuthorityTreeView.Nodes["PackageApprove"].Checked;
                PackageReject = AuthorityTreeView.Nodes["PackageReject"].Checked;
                PackageSendToApprove = AuthorityTreeView.Nodes["PackageSendToApprove"].Checked;
                PackageForwardToBank = AuthorityTreeView.Nodes["ForwardToBank"].Checked;
                PackageAkibet = AuthorityTreeView.Nodes["PackageAkibetAl"].Checked;
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
                komut.CommandText = "INSERT INTO [AYZ_PW_USERRIGHTS]" +
                                    "(GROUPID,ADD_PACKAGE,EDIT_PACKAGE,APPROVE_PACKAGE,REJECT_PACKAGE,SENDTO_APPROVE,FORWARDTO_BANK,AKIBET_AL) " +
                                    "VALUES(" +
                                    " '" + groupId + "', " +
                                    "'" + PackageAdd + "'," +
                                    "'" + PackageEdit + "', " +
                                    "'" + PackageApprove + "', " +
                                    "'" + PackageReject + "'," +
                                    "'" + PackageSendToApprove + "'," +
                                    "'" + PackageForwardToBank + "'," +
                                    "'" + PackageAkibet + "') ";
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

        private void GroupAddForm_Load(object sender, EventArgs e)
        {
            dataGridViewGroup.ClearSelection();
            fillGroupsDGV();
            
        }

        private void fillGroupsDGV()
        {
            groups.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_USER WHERE USERTYPE = 1";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    UserGroup group = new UserGroup();
                    group.ID = Convert.ToInt32(dr["ID"].ToString());
                    group.Name = dr["NAME"].ToString();
                    groups.Add(group);
                }
            }
            var source = new BindingSource();
            source.DataSource = groups;
            dataGridViewGroup.DataSource = source;

            dataGridViewGroup.Columns["Date_"].Visible = false;
            dataGridViewGroup.Columns["UserType"].Visible = false;
        }

        int indexRow;
        private void dataGridViewGroup_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            indexRow = e.RowIndex;
            // Seçili olan satırın değerlerini üst taraftaki textboxlara ve treeViewa doldurur.
            if (dataGridViewGroup.SelectedRows.Count>0)
            {
                AuthorityTreeView.Nodes["PackageAdd"].Checked = true;
            }
        }
    }
}
