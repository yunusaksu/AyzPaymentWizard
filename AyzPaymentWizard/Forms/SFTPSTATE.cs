using AyzPaymentWizard.Model;
using In.Sontx.SimpleDataGridViewPaging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class SFTPSTATE : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<LOG_FILE> list = new List<LOG_FILE>();

        public SFTPSTATE()
        {
            InitializeComponent();            
            dataGridViewPaging.RequestQueryData += DataGridViewPaging_RequestQueryData;
            dataGridViewPaging.Initialize(count());
            dataGridViewPaging.DataGridView.CellFormatting += new DataGridViewCellFormattingEventHandler(datagridViewPaging_CellFormatting);
        }

        private int count()
        {
            using (SqlConnection con = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                con.Open();
                using (var command = con.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM AYZ_PW_LOG_FILE";
                    var reader = command.ExecuteScalar();
                    return Convert.ToInt32(reader);
                }
            }
        }
        private void SFTPSTATE_Load(object sender, EventArgs e)
        {
            fillSFTPDGV();
        }


        private void DataGridViewPaging_RequestQueryData(object sender, RequestQueryDataEventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                //MaxRecords değerini dataGridViewPaging property'lerinden MaxRecords ile değiştirebilirsiniz!!!
                CommandText = "SELECT * FROM AYZ_PW_LOG_FILE ORDER BY Id  OFFSET " + e.PageOffset + "ROWS FETCH NEXT " + e.MaxRecords + " ROWS ONLY";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dataGridViewPaging.DataSource = komut.ExecuteReader();
            }
        }

        private void fillSFTPDGV()
        {
            #region Boş
            //    using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            //    {
            //        CommandText = "SELECT * FROM AYZ_PW_LOG_FILE";
            //        komut.CommandText = CommandText;
            //        komut.Connection = conn;
            //        conn.Open();
            //        dr = komut.ExecuteReader();
            //        while (dr.Read())
            //        {
            //            LOG_FILE sftp = new LOG_FILE();
            //            sftp.ID = Convert.ToInt32(dr["ID"].ToString());
            //            sftp.LOG_NAME = dr["LOG_NAME"].ToString();
            //            sftp.LOG_DATETIME = Convert.ToDateTime(dr["LOG_DATETIME"].ToString());
            //            sftp.LOG_EXP = dr["LOG_EXP"].ToString();
            //            sftp.PACKETID = Convert.ToInt32(dr["PACKETID"].ToString());
            //            //sftp.LOG_CREATE_USERID = Convert.ToInt32(dr["LOG_CREATE_USERID"].ToString());
            //            sftp.LOG_CREATE_USERNAME = dr["LOG_CREATE_USERNAME"].ToString();
            //            sftp.STATE = dr["STATE"].ToString();
            //            list.Add(sftp);
            //        }
            //    }

            //    BindingSource source = new BindingSource();
            //    source.DataSource = list;
            //    DGVSFTPSTATE.DataSource = source;
            #endregion

            dataGridViewPaging.DataGridView.Columns["LOG_EXP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPaging.DataGridView.Columns["LOG_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewPaging.DataGridView.Columns["ID"].Visible = false;
            //dataGridViewPaging1.DataGridView.Columns["LOG_CREATE_USERID"].Visible = false;
            dataGridViewPaging.DataGridView.Columns["LOG_NAME"].HeaderText = "GÖREV";
            dataGridViewPaging.DataGridView.Columns["LOG_DATETIME"].HeaderText = "TARİH";
            dataGridViewPaging.DataGridView.Columns["LOG_EXP"].HeaderText = "GÖREV TANIMI";
            dataGridViewPaging.DataGridView.Columns["PACKETID"].HeaderText = "PAKET NO";
            dataGridViewPaging.DataGridView.Columns["LOG_CREATE_USERNAME"].HeaderText = "KULLANICISI";
        }


        private void datagridViewPaging_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = dataGridViewPaging.DataGridView.Rows[e.RowIndex].Cells["STATE"];
            string value = cell.Value.ToString() == "Başarılı" ? "Başarılı" : "Başarısız";

            if (value == "Başarılı")
            {
                dataGridViewPaging.DataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                dataGridViewPaging.DataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                dataGridViewPaging.DataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                dataGridViewPaging.DataGridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
        

        private void btnToExcel_Click(object sender, EventArgs e)
        {

            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

            var boldformat = sheet1.get_Range("A1", "T1");
            var m_objfont = boldformat.Font;
            m_objfont.Bold = true;

            int StartCol = 1;
            int StartRow = 1;

            for (int j = 0; j < dataGridViewPaging.DataGridView.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = dataGridViewPaging.DataGridView.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < dataGridViewPaging.DataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridViewPaging.DataGridView.Columns.Count; j++)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = dataGridViewPaging.DataGridView[j, i].Value == null ? "" : dataGridViewPaging.DataGridView[j, i].Value;
                        myRange.NumberFormat = "@";
                        myRange = sheet1.get_Range("B2").EntireColumn;
                        myRange.NumberFormat = "MM.DD.YYYY : hh.mm";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
        }

      
    }
}
