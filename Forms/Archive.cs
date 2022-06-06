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

namespace AyzPaymentWizard.Forms
{
    public partial class Archive : Form
    {

        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<Packet> packets = new List<Packet>();


        public Archive()
        {
            InitializeComponent();
        }

        private void Archive_Load(object sender, EventArgs e)
        {
            fillUnarchivedPacket();
            #region Kolon Görünüm,Header Text ve Display Index Ayarları
            dataGridViewUnarchived.ReadOnly = true;
            dataGridViewUnarchived.Columns["CreatedTime"].Visible = false;
            dataGridViewUnarchived.Columns["Id"].Visible = false;
            dataGridViewUnarchived.Columns["CreatedBy"].Visible = false;
            dataGridViewUnarchived.Columns["ModifiedTime"].Visible = false;
            dataGridViewUnarchived.Columns["ModifiedBy"].Visible = false;
            dataGridViewUnarchived.Columns["ApprovedBy"].Visible = false;
            dataGridViewUnarchived.Columns["UserNr"].Visible = false;
            dataGridViewUnarchived.Columns["ApprovedTime"].Visible = false;
            dataGridViewUnarchived.Columns["BankId"].Visible = false;
            dataGridViewUnarchived.Columns["BankBranchId"].Visible = false;
            dataGridViewUnarchived.Columns["BankName"].Visible = false;
            dataGridViewUnarchived.Columns["TigerBankAccountCode"].Visible = false;
            dataGridViewUnarchived.Columns["TigerAccountCode"].Visible = false;
            dataGridViewUnarchived.Columns["Status"].Visible = false;
            dataGridViewUnarchived.Columns["Archived"].Visible = false;
            dataGridViewUnarchived.Columns["Id"].HeaderText = "ID";
            dataGridViewUnarchived.Columns["CreatedBy"].HeaderText = "Oluşturan";
            dataGridViewUnarchived.Columns["CreatedBy"].Width = 180;
            dataGridViewUnarchived.Columns["CreatedDate"].HeaderText = "Oluşturma Tarihi";
            dataGridViewUnarchived.Columns["CreatedDate"].Width = 180;
            dataGridViewUnarchived.Columns["ModifiedBy"].HeaderText = "Güncelleyen";
            dataGridViewUnarchived.Columns["ModifiedBy"].Width = 180;
            dataGridViewUnarchived.Columns["ModifiedDate"].HeaderText = "Güncelleme Tarihi";
            dataGridViewUnarchived.Columns["ModifiedDate"].Width = 180;
            dataGridViewUnarchived.Columns["TotalRequired"].HeaderText = "Ödenmesi Gereken";
            dataGridViewUnarchived.Columns["TotalRequired"].Width = 180;
            dataGridViewUnarchived.Columns["TotalPaid"].HeaderText = "Ödenecek";
            dataGridViewUnarchived.Columns["TotalPaid"].Width = 180;
            dataGridViewUnarchived.Columns["Note"].HeaderText = "Not";
            dataGridViewUnarchived.Columns["Note"].Width = 180;
            dataGridViewUnarchived.Columns["ApprovalNote"].HeaderText = "Onay Notu";
            dataGridViewUnarchived.Columns["ApprovalNote"].Width = 180;
            dataGridViewUnarchived.Columns["Currency"].HeaderText = "";
            dataGridViewUnarchived.Columns["Currency"].Width = 180;
            dataGridViewUnarchived.Columns["FirmNr"].HeaderText = "Firma No";
            dataGridViewUnarchived.Columns["FirmNr"].Width = 180;
            dataGridViewUnarchived.Columns["StatusMask"].HeaderText = "Paket Durumu";
            dataGridViewUnarchived.Columns["StatusMask"].Width = 180;
            dataGridViewUnarchived.Columns["ApprovedBy"].HeaderText = "Onaylayan";
            dataGridViewUnarchived.Columns["ApprovedBy"].Width = 180;
            dataGridViewUnarchived.Columns["ApprovedDate"].HeaderText = "Onaylama Tarihi";
            dataGridViewUnarchived.Columns["ApprovedDate"].Width = 180;
            dataGridViewUnarchived.Columns["Archived"].HeaderText = "Arşiv Durumu";
            dataGridViewUnarchived.Columns["Archived"].Width = 180;
            dataGridViewUnarchived.Columns["ApprovierName"].HeaderText = "Onaylayan";
            dataGridViewUnarchived.Columns["ApprovierName"].Width = 180;
            dataGridViewUnarchived.Columns["ModifiedByName"].HeaderText = "Güncelleyen";
            dataGridViewUnarchived.Columns["ModifiedByName"].Width = 180;
            dataGridViewUnarchived.Columns["CreatedByName"].HeaderText = "Oluşturan";
            dataGridViewUnarchived.Columns["CreatedByName"].Width = 180;
            #endregion

            #region DGV'ın Font Ayarı
            dataGridViewUnarchived.DefaultCellStyle.Font = new Font("Time News Roman", 12);
            dataGridViewUnarchived.ColumnHeadersDefaultCellStyle.Font = new Font("Time News Roman", 10);
            #endregion

        }


        void fillUnarchivedPacket()
        {
            int getSelectedRowIndex = 0;
            if (dataGridViewUnarchived.Rows.Count != 0 && dataGridViewUnarchived.SelectedRows.Count > 0)
                getSelectedRowIndex = dataGridViewUnarchived.SelectedRows[0].Index;

            packets.Clear();

            // Login olunan Firmanın tüm paketlerini AYZ_PW_PACKET tablosundan getiren işlemler
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_PACKET WHERE FIRMNR = " + Helper.FIRMNR + " AND ARCHIVED = " + (int)Helper.ArchiveStatus.Archived + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    Packet packet = new Packet();
                    packet.Id = Convert.ToInt32(dr["ID"].ToString());
                    packet.UserNr = Convert.ToInt32(dr["USERNR"].ToString());
                    packet.CreatedBy = Convert.ToInt32(dr["CREATED_BY"].ToString());
                    packet.CreatedByName = dr["CREATED_NAME"].ToString();
                    packet.CreatedDate = Convert.ToDateTime(dr["CREATED_DATE"].ToString());
                    packet.CreatedTime = Convert.ToInt32(dr["CREATED_TIME"].ToString());
                    packet.ModifiedBy = dr["MODIFIED_BY"].ToString() == "" ? -1 : Convert.ToInt32(dr["MODIFIED_BY"].ToString());
                    packet.ModifiedByName = dr["MODIFIED_NAME"].ToString();
                    packet.ModifiedDate = dr["MODIFIED_DATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["MODIFIED_DATE"]);
                    packet.ModifiedTime = dr["MODIFIED_TIME"].ToString() == "" ? 0 : Convert.ToInt32(dr["MODIFIED_TIME"]);
                    packet.TotalRequired = Convert.ToDecimal(dr["TOTAL_REQUIRED"].ToString());
                    packet.TotalPaid = Convert.ToDecimal(dr["TOTAL_PAID"].ToString());
                    packet.Currency = dr["CURRENCY"].ToString();
                    packet.Note = dr["NOTE"].ToString();
                    packet.ApprovalNote = dr["APPROVALNOTE"].ToString();
                    packet.FirmNr = Convert.ToInt32(dr["FIRMNR"].ToString());
                    packet.Status = Convert.ToInt32(dr["STATUS"].ToString());
                    if (packet.Status == 0)
                        packet.StatusMask = "Yeni Paket";
                    else if (packet.Status == 1)
                        packet.StatusMask = "Onaya Yollandı";
                    else if (packet.Status == 2)
                        packet.StatusMask = "Onaylandı";
                    else if (packet.Status == 3)
                        packet.StatusMask = "Reddedildi";
                    else if (packet.Status == 4)
                        packet.StatusMask = "Bankaya Yollandı";
                    else if (packet.Status == 5)
                        packet.StatusMask = "Akibet Alındı";
                    packet.Archived = Convert.ToInt32(dr["ARCHIVED"].ToString());
                    packet.ApprovedBy = dr["APPROVED_BY"].ToString() == "" ? -1 : Convert.ToInt32(dr["APPROVED_BY"].ToString());
                    packet.ApprovierName = dr["APPROVED_NAME"].ToString();
                    packet.ApprovedDate = dr["APPROVED_DATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["APPROVED_DATE"]);
                    packet.ApprovedTime = dr["APPROVED_TIME"].ToString() == "" ? 0 : Convert.ToInt32(dr["APPROVED_TIME"]);
                    packet.BankId = dr["BANKID"].ToString() == "" ? 0 : Convert.ToInt32(dr["BANKID"]);
                    packet.BankBranchId = dr["BNK_BRANCH_ID"].ToString() == "" ? 0 : Convert.ToInt32(dr["BNK_BRANCH_ID"]);
                    packet.BankName = dr["BNK_NAME"].ToString();
                    packet.TigerBankAccountCode = dr["TIGER_BNKACCODE"].ToString();
                    packet.TigerAccountCode = dr["TIGER_ACCOUNT_CODE"].ToString();
                    packets.Add(packet);
                }
            }

            var source = new BindingSource();
            source.DataSource = packets;
            dataGridViewUnarchived.DataSource = source;
        }

        private void btnUnArchive_Click(object sender, EventArgs e)
        {
            int packetId = 0, status = 0;
            for (int i = 0; i < dataGridViewUnarchived.SelectedRows.Count; i++)
            {
                packetId = (int)dataGridViewUnarchived.SelectedRows[i].Cells["ID"].Value;
                status = (int)dataGridViewUnarchived.SelectedRows[i].Cells["STATUS"].Value;
            }
                if (packetId != 0)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                    {
                        // Güncellenecek Alanlar : STATUS, APPROVALNOTE
                        CommandText = "UPDATE AYZ_PW_PACKET" +
                                      "\nSET ARCHIVED = " + (int)Helper.ArchiveStatus.Unarchived + "" +
                                      "\nWHERE ID = " + packetId + "";
                        komut.CommandText = CommandText;
                        komut.Connection = conn;
                        conn.Open();
                        komut.ExecuteNonQuery();
                        conn.Close();
                    }

                    //Helper.PacketHistorySave(packetId, "Arşivlendi", "Paket Arşivlendi.");

                    #region Arşivi yenilemek için
                    Archive form = (Archive)Application.OpenForms["Archive"];
                    form.fillUnarchivedPacket();
                    #endregion

                }            
        }
    }
}
