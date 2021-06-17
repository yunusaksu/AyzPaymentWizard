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
    public partial class PacketAdventure : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        int PacketId = 0;
        public PacketAdventure()
        {
            InitializeComponent();
        }
        public PacketAdventure(int packetId)
        {
            PacketId = packetId;
            InitializeComponent();
        }

        private void PacketAdventure_Load(object sender, EventArgs e)
        {
            string addName = ""; DateTime dateTimeAdd = new DateTime();
            string updateName = ""; DateTime dateTimeUpdate = new DateTime();
            string sendApproveName = ""; DateTime dateTimeSendApprove = new DateTime();
            string approvedName = ""; DateTime dateTimeApproved = new DateTime();
            string rejectName = ""; DateTime dateTimeReject = new DateTime();
            string archiveName = ""; DateTime dateTimeArchive = new DateTime();
            string sendToBankName = ""; DateTime dateTimeSendToBank = new DateTime();
            string receivedName = ""; DateTime dateTimeReceived = new DateTime();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Yeni Paket' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    addName = dr["USERNAME"].ToString();
                    dateTimeAdd = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if(dr.HasRows)
                {
                    var temp = dateTimeAdd.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblPacketAddName.Text = addName;
                    lblAddDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeAdd.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblPacketAddName.Text = addName;
                    lblAddDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Güncellenmiş Paket' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    updateName = dr["USERNAME"].ToString();
                    dateTimeUpdate = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if(dr.HasRows)
                {
                    var temp = dateTimeUpdate.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblUpdateName.Text = updateName;
                    lblUpdateDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeUpdate.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblUpdateName.Text = updateName;
                    lblUpdateDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Onaya Yollandı' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    sendApproveName = dr["USERNAME"].ToString();
                    dateTimeSendApprove = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if (dr.HasRows)
                {
                    var temp = dateTimeSendApprove.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblApproveSendName.Text = sendApproveName;
                    lblApproveSendDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeSendApprove.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblApproveSendName.Text = sendApproveName;
                    lblApproveSendDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Onaylandı' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    approvedName = dr["USERNAME"].ToString();
                    dateTimeApproved = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if (dr.HasRows)
                {
                    var temp = dateTimeApproved.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblApprovedName.Text = approvedName;
                    lblApprovedDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeApproved.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblApprovedName.Text = approvedName;
                    lblApprovedDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Paket Reddedildi' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    rejectName = dr["USERNAME"].ToString();
                    dateTimeReject = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if (dr.HasRows)
                {
                    var temp = dateTimeReject.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblRejectName.Text = rejectName;
                    lblRejectDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeReject.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblRejectName.Text = rejectName;
                    lblRejectDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Arşivlendi' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    archiveName = dr["USERNAME"].ToString();
                    dateTimeArchive = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if (dr.HasRows)
                {
                    var temp = dateTimeArchive.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblArchiveName.Text = archiveName;
                    lblArchiveDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeArchive.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblArchiveName.Text = archiveName;
                    lblArchiveDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Bankaya İletildi' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    sendToBankName = dr["USERNAME"].ToString();
                    dateTimeSendToBank = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if (dr.HasRows)
                {
                    var temp = dateTimeSendToBank.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblSendToBankName.Text = sendToBankName;
                    lblSendToBankDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeSendToBank.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblSendToBankName.Text = sendToBankName;
                    lblSendToBankDate.Text = date + " " + time;
                }
            }
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT TOP 1 * FROM AYZ_PW_PACKET_HISTORY WHERE STATUS = 'Akibet Alındı' AND PACKETID = " + PacketId + " ORDER BY DATE_ DESC";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    receivedName = dr["USERNAME"].ToString();
                    dateTimeReceived = Convert.ToDateTime(dr["DATE_"].ToString());
                }
                if (dr.HasRows)
                {
                    var temp = dateTimeReceived.ToString().Split(' ');
                    var date = temp[0];
                    var time = temp[1];
                    lblReceivedName.Text = receivedName;
                    lblReceivedDate.Text = date + " Saat: " + time;
                }
                else
                {
                    var temp = dateTimeReceived.ToString().Split(' ');
                    var date = "";
                    var time = "";
                    lblReceivedName.Text = receivedName;
                    lblReceivedDate.Text = date + " " + time;
                }
            }
        }
    }
}
