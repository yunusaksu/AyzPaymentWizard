using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
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
            if (dataGridViewGroup.SelectedRows.Count > 0)
            {
                #region Edit
                if (String.IsNullOrEmpty(txtGroupName.Text) || CheckedNodes(AuthorityTreeView))
                {
                    MessageBox.Show("Lütfen yıldız işaretli alanları doldurunuz!");
                }
                else
                {

                    int groupId = (int)dataGridViewGroup.SelectedRows[0].Cells["ID"].Value;
                    using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                    {
                        try
                        {
                            string groupName = txtGroupName.Text;
                            CommandText = "UPDATE AYZ_PW_USER " +
                                          "\nSET " +
                                          "\nNAME = '" + groupName + "'" +
                                          "\nWHERE ID = '" + groupId + "'";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            dr = komut.ExecuteReader();
                            conn.Close();
                            CommandText = "UPDATE AYZ_PW_USERRIGHTS " +
                                          "\nSET " +
                                          "\nADD_PACKAGE = '" + AuthorityTreeView.Nodes["PackageAdd"].Checked + "'," +
                                          "\nEDIT_PACKAGE = '" + AuthorityTreeView.Nodes["PackageEdit"].Checked + "', " +
                                          "\nAPPROVE_PACKAGE = '" + AuthorityTreeView.Nodes["PackageApprove"].Checked + "' , " +
                                          "\nREJECT_PACKAGE = '" + AuthorityTreeView.Nodes["PackageReject"].Checked + "', " +
                                          "\nSENDTO_APPROVE = '" + AuthorityTreeView.Nodes["PackageSendToApprove"].Checked + "', " +
                                          "\nFORWARDTO_BANK = '" + AuthorityTreeView.Nodes["ForwardToBank"].Checked + "', " +
                                          "\nAKIBET_AL = '" + AuthorityTreeView.Nodes["PackageAkibetAl"].Checked + "', " +
                                          "\nADD_USER = '" + AuthorityTreeView.Nodes["AddUser"].Checked + "', " +
                                          "\nADD_GROUP = '" + AuthorityTreeView.Nodes["AddGroup"].Checked + "' " +
                                          "\nWHERE GROUPID = " + groupId + "";
                            komut.CommandText = CommandText;
                            komut.Connection = conn;
                            conn.Open();
                            dr = komut.ExecuteReader();
                            conn.Close();
                            MessageBox.Show("Güncellendi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region Save
                if (String.IsNullOrEmpty(txtGroupName.Text) || CheckedNodes(AuthorityTreeView))
                {
                    MessageBox.Show("Lütfen yıldız işaretli alanları doldurunuz!");
                }
                else
                {
                    string groupName = txtGroupName.Text;
                    bool PackageAdd = AuthorityTreeView.Nodes["PackageAdd"].Checked;
                    bool PackageEdit = AuthorityTreeView.Nodes["PackageEdit"].Checked;
                    bool PackageApprove = AuthorityTreeView.Nodes["PackageApprove"].Checked;
                    bool PackageReject = AuthorityTreeView.Nodes["PackageReject"].Checked;
                    bool PackageSendToApprove = AuthorityTreeView.Nodes["PackageSendToApprove"].Checked;
                    bool PackageForwardToBank = AuthorityTreeView.Nodes["ForwardToBank"].Checked;
                    bool PackageAkibet = AuthorityTreeView.Nodes["PackageAkibetAl"].Checked;
                    bool AddUser = AuthorityTreeView.Nodes["AddUser"].Checked;
                    bool AddGroup = AuthorityTreeView.Nodes["AddGroup"].Checked;

                    SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString);
                    SqlCommand komut = new SqlCommand();                    
                    try
                    {
                        komut.CommandText = "INSERT INTO [AYZ_PW_USER](NAME,USERTYPE,DATE) VALUES(" +
                                        "'" + groupName + "',1 ,GETDATE());" +
                                        "SELECT SCOPE_IDENTITY()";
                        komut.Connection = conn;
                        conn.Open();
                        int groupId = Convert.ToInt32(komut.ExecuteScalar());
                        komut.CommandText = "INSERT INTO [AYZ_PW_USERRIGHTS]" +
                                            "(GROUPID,ADD_PACKAGE,EDIT_PACKAGE,APPROVE_PACKAGE,REJECT_PACKAGE,SENDTO_APPROVE,FORWARDTO_BANK,AKIBET_AL,ADD_USER,ADD_GROUP) " +
                                            "VALUES(" +
                                            " '" + groupId + "', " +
                                            "'" + PackageAdd + "'," +
                                            "'" + PackageEdit + "', " +
                                            "'" + PackageApprove + "', " +
                                            "'" + PackageReject + "'," +
                                            "'" + PackageSendToApprove + "'," +
                                            "'" + PackageForwardToBank + "'," +
                                            "'" + PackageAkibet + "'," +
                                            "'" + AddUser + "'," +
                                            "'" + AddGroup + "'" +
                                            ") ";
                        komut.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Grup başarılı bir şekilde kaydedildi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                #endregion
            }
            fillGroupsDGV();
            dataGridViewGroup.ClearSelection();
            txtGroupName.Text = "";
            for (int i = 0; i < AuthorityTreeView.Nodes.Count; i++)
            {
                AuthorityTreeView.Nodes[i].Checked = false;
            }
        }

        private void GroupAddForm_Load(object sender, EventArgs e)
        {
            ToolTip infoBtnToolTip = new ToolTip();
            infoBtnToolTip.SetToolTip(btnInfo, "Silmek İçin: Satırı Seçtikten Sonra Delete Tuşuna Basınız!");
            ToolTip newRecordBtnToolTip = new ToolTip();
            newRecordBtnToolTip.SetToolTip(btnNewRecord, "Yeni Grup Ekle!");

            fillGroupsDGV();
            dataGridViewGroup.ClearSelection();
            txtGroupName.Text = "";
            for (int i = 0; i < AuthorityTreeView.Nodes.Count; i++)
            {
                AuthorityTreeView.Nodes[i].Checked = false;
            }
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

        private void dataGridViewGroup_KeyDown(object sender, KeyEventArgs e)
        {
            int id = 0;
            int selectedRowCount = dataGridViewGroup.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {

                for (int i = 0; i < selectedRowCount; i++)
                {
                    id = (int)dataGridViewGroup.SelectedRows[i].Cells["ID"].Value;
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
                                string sql2 = "DELETE FROM AYZ_PW_USERGROUPS WHERE GROUPID=" + id + "";
                                komut = new SqlCommand(sql2, conn);
                                conn.Open();
                                komut.ExecuteNonQuery();
                                conn.Close();
                                string sql3 = "DELETE FROM AYZ_PW_USERRIGHTS WHERE GROUPID=" + id + "";
                                komut = new SqlCommand(sql3, conn);
                                conn.Open();
                                komut.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Silindi!");
                                for (int i = 0; i < AuthorityTreeView.Nodes.Count; i++)
                                {
                                    AuthorityTreeView.Nodes[i].Checked = false;
                                }
                                txtGroupName.Text = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    fillGroupsDGV();
                    dataGridViewGroup.ClearSelection();
                    txtGroupName.Text = "";
                    for (int i = 0; i < AuthorityTreeView.Nodes.Count; i++)
                    {
                        AuthorityTreeView.Nodes[i].Checked = false;
                    }
                }
            }
        }

        private void dataGridViewGroup_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewGroup.SelectedRows.Count > 0)
            {
                int groupId = (int)dataGridViewGroup.SelectedRows[0].Cells["ID"].Value;
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT * FROM AYZ_PW_USERRIGHTS AS UR LEFT JOIN AYZ_PW_USER AS U ON UR.GROUPID = U.ID WHERE GROUPID = " + groupId + "";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        AuthorityTreeView.Nodes["PackageAdd"].Checked = Convert.ToBoolean(dr["ADD_PACKAGE"].ToString());
                        AuthorityTreeView.Nodes["PackageEdit"].Checked = Convert.ToBoolean(dr["EDIT_PACKAGE"].ToString());
                        AuthorityTreeView.Nodes["PackageApprove"].Checked = Convert.ToBoolean(dr["APPROVE_PACKAGE"].ToString());
                        AuthorityTreeView.Nodes["PackageReject"].Checked = Convert.ToBoolean(dr["REJECT_PACKAGE"].ToString());
                        AuthorityTreeView.Nodes["PackageSendToApprove"].Checked = Convert.ToBoolean(dr["SENDTO_APPROVE"].ToString());
                        AuthorityTreeView.Nodes["ForwardToBank"].Checked = Convert.ToBoolean(dr["FORWARDTO_BANK"].ToString());
                        AuthorityTreeView.Nodes["PackageAkibetAl"].Checked = Convert.ToBoolean(dr["AKIBET_AL"].ToString());
                        AuthorityTreeView.Nodes["AddUser"].Checked = Convert.ToBoolean(dr["ADD_USER"].ToString());
                        AuthorityTreeView.Nodes["AddGroup"].Checked = Convert.ToBoolean(dr["ADD_GROUP"].ToString());
                        txtGroupName.Text = dr["NAME"].ToString();
                    }
                }
            }
        }

        private void btnNewRecord_Click(object sender, EventArgs e)
        {
            int count = AuthorityTreeView.Nodes.Count;
            txtGroupName.Text = "";
            for (int i = 0; i < count; i++)
            {
                AuthorityTreeView.Nodes[i].Checked = false;
            }
            dataGridViewGroup.ClearSelection();
        }

        // Return a list of the TreeNodes that are checked.
        private void FindCheckedNodes(List<TreeNode> checked_nodes, TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                // Add this node.
                if (node.Checked)
                    checked_nodes.Add(node);

                // Check the node's descendants.
                FindCheckedNodes(checked_nodes, node.Nodes);
            }
        }
        private bool CheckedNodes(TreeView trv)
        {
            List<TreeNode> checked_nodes = new List<TreeNode>();
            FindCheckedNodes(checked_nodes, AuthorityTreeView.Nodes);
            if (checked_nodes.Count > 0)
                return false;
            else
                return true;
        }
    }
}
