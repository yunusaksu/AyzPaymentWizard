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
            if (String.IsNullOrEmpty(txtGroupName.Text))
            {
                MessageBox.Show("Lütfen yıldız işaretli alanları doldurunuz!");
            }
            else
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
                    GroupAddForm form = (GroupAddForm)Application.OpenForms["GroupAddForm"];
                    form.fillGroupsDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void GroupAddForm_Load(object sender, EventArgs e)
        {
            ToolTip infoBtnToolTip = new ToolTip();
            infoBtnToolTip.SetToolTip(btnInfo, "Silmek İçin: Satırı Seçtikten Sonra Delete Tuşuna Basınız!");
            dataGridViewGroup.ClearSelection();
            fillGroupsDGV();
            dataGridViewGroup.ReadOnly = true;
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

        private void dataGridViewGroup_RowEnter(object sender, DataGridViewCellEventArgs e)
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
                        txtGroupName.Text = dr["NAME"].ToString();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewGroup.SelectedRows.Count > 0)
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
                                      "\nAKIBET_AL = '" + AuthorityTreeView.Nodes["PackageAkibetAl"].Checked + "' " +
                                      "\nWHERE GROUPID = " + groupId + "";
                        komut.CommandText = CommandText;
                        komut.Connection = conn;
                        conn.Open();
                        dr = komut.ExecuteReader();
                        conn.Close();
                        GroupAddForm form = (GroupAddForm)Application.OpenForms["GroupAddForm"];
                        form.fillGroupsDGV();
                        MessageBox.Show("Güncellendi!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
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
                                for (int i = 0; i < 7; i++)
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
                }
            }
        }
    }
}
