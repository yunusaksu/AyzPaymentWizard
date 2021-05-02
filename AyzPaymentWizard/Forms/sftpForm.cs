using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class sftpForm : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        List<SecureFTP> list = new List<SecureFTP>();

        public sftpForm()
        {
            InitializeComponent();
        }

        private void sftpForm_Load(object sender, EventArgs e)
        {
            fillDGVsftp();
            dgvSftp.Columns["ID"].Visible = false;
            dgvSftp.Columns["BANKCODE"].HeaderText = "BANKA KODU";
            dgvSftp.Columns["FIRMNR"].HeaderText = "FIRMA NO";
            dgvSftp.Columns["HOSTNAME"].HeaderText = "SFTP ADRESİ";
            dgvSftp.Columns["HOSTNAME"].Width = 220;
            dgvSftp.Columns["USERNAME"].HeaderText = "KULLANICI ADI";
            dgvSftp.Columns["USERNAME"].Width = 150;
            dgvSftp.Columns["PASSWORD"].HeaderText = "ŞİFRE";
            dgvSftp.Columns["PASSWORD"].Width = 125;
            dgvSftp.Columns["FOLDERPATH"].HeaderText = "SFTP KLASÖR YOLU (/E/AYZ_FTP/Yunus/ şeklinde)";                                  
            dgvSftp.Columns["FOLDERPATH"].Width = 370;
            dgvSftp.Columns["PAYMENTORDERLOGFOLDER"].HeaderText = "ÖDEME EMİRLERİ KAYIT KLASÖRÜ";
            dgvSftp.Columns["PAYMENTORDERLOGFOLDER"].Width = 300;                        
            dgvSftp.DefaultCellStyle.Font = new Font("Time News Roman", 11);
            dgvSftp.ColumnHeadersDefaultCellStyle.Font = new Font("Time News Roman", 10);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            #region AYZ_PW_SFTP_SETTING tablosunu boşaltma
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "DELETE FROM AYZ_PW_SFTP_SETTING WHERE FIRMNR = " + Helper.FIRMNR + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }
            #endregion
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                    {
                        CommandText = "INSERT INTO AYZ_PW_SFTP_SETTING(BANKCODE,FIRMNR,HOSTNAME,USERNAME,PASSWORD,PORT,FOLDERPATH,PAYMENTORDERLOGFOLDER) " +
                                          "\nVALUES(" +
                                          "\n'" + list[i].BANKCODE + "'," +
                                          "\n'" + list[i].FIRMNR + "'," +
                                          "\n'" + list[i].HOSTNAME + "'," +
                                          "\n'" + list[i].USERNAME + "'," +
                                          "\n'" + list[i].PASSWORD + "'," +
                                          "\n'" + list[i].PORT + "'," +
                                          "\n'" + list[i].FOLDERPATH + "'," +
                                          "\n'" + list[i].PAYMENTORDERLOGFOLDER + "'" +
                                          "\n)";

                        komut.CommandText = CommandText;
                        komut.Connection = conn;
                        conn.Open();
                        dr = komut.ExecuteReader();
                    }
                }
                MessageBox.Show("Kayıt Başarılı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void fillDGVsftp()
        {
            list.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_SFTP_SETTING --WHERE FIRMNR = " + Helper.FIRMNR + " ";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    SecureFTP sftp = new SecureFTP();
                    sftp.ID = Convert.ToInt32(dr["ID"].ToString());
                    sftp.BANKCODE = Convert.ToInt32(dr["BANKCODE"].ToString());
                    sftp.FIRMNR = Convert.ToInt32(dr["FIRMNR"].ToString());
                    sftp.HOSTNAME = dr["HOSTNAME"].ToString();
                    sftp.USERNAME = dr["USERNAME"].ToString();
                    sftp.PASSWORD = dr["PASSWORD"].ToString();
                    sftp.PORT = Convert.ToInt32(dr["PORT"].ToString());
                    sftp.FOLDERPATH = dr["FOLDERPATH"].ToString();                   
                    sftp.PAYMENTORDERLOGFOLDER = dr["PAYMENTORDERLOGFOLDER"].ToString();                   
                    list.Add(sftp);
                }
            }

            BindingSource source = new BindingSource();
            source.DataSource = list;
            dgvSftp.DataSource = source;
        }

        private void dgvSftp_KeyDown(object sender, KeyEventArgs e)
        {
            int id = 0;
            int selectedRowCount = dgvSftp.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (selectedRowCount > 0)
            {

                for (int i = 0; i < selectedRowCount; i++)
                {
                    id = (int)dgvSftp.SelectedRows[i].Cells["ID"].Value;
                }

                if (e.KeyCode == Keys.Delete)
                {
                    if (MessageBox.Show("Bu kayıdı silmek istediğinize emin misiniz?", "Mesaj", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                        {
                            string sql = "DELETE FROM AYZ_PW_SFTP_SETTING WHERE ID=" + id + "";
                            komut = new SqlCommand(sql, conn);
                            conn.Open();
                            komut.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    fillDGVsftp();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dgvSftp_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedRowIndex = e.RowIndex;
            var selectedAddressColumnIndex = dgvSftp.Rows[selectedRowIndex].Cells["PAYMENTORDERLOGFOLDER"].ColumnIndex;
            if (e.ColumnIndex == selectedAddressColumnIndex)
            {                
                using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Yolu Seçiniz" })
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string item in Directory.GetFiles(fbd.SelectedPath))
                        {
                            FileInfo fi = new FileInfo(item);
                            dgvSftp[e.ColumnIndex, e.RowIndex].Value = fi.Directory;
                        }
                    }
                }
            }
        }
    }
}
