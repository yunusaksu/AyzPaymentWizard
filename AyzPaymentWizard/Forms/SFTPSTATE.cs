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
    public partial class SFTPSTATE : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        List<LOG_FILE> list = new List<LOG_FILE>();

        public SFTPSTATE()
        {
            InitializeComponent();
        }

        private void SFTPSTATE_Load(object sender, EventArgs e)
        {
            fillSFTPDGV();            
        }

        private void fillSFTPDGV()
        {
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_LOG_FILE";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    LOG_FILE sftp = new LOG_FILE();
                    sftp.ID = Convert.ToInt32(dr["ID"].ToString());
                    sftp.LOG_NAME = dr["LOG_NAME"].ToString();
                    sftp.LOG_DATETIME = Convert.ToDateTime(dr["LOG_DATETIME"].ToString());
                    sftp.LOG_EXP = dr["LOG_EXP"].ToString();
                    sftp.PACKETID = Convert.ToInt32(dr["PACKETID"].ToString());
                    //sftp.LOG_CREATE_USERID = Convert.ToInt32(dr["LOG_CREATE_USERID"].ToString());
                    sftp.LOG_CREATE_USERNAME = dr["LOG_CREATE_USERNAME"].ToString();
                    sftp.STATE = dr["STATE"].ToString();
                    list.Add(sftp);
                }
            }

            BindingSource source = new BindingSource();
            source.DataSource = list;
            DGVSFTPSTATE.DataSource = source;

            DGVSFTPSTATE.Columns["LOG_EXP"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVSFTPSTATE.Columns["LOG_NAME"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVSFTPSTATE.Columns["ID"].Visible = false;
            //DGVSFTPSTATE.Columns["LOG_CREATE_USERID"].Visible = false;
            DGVSFTPSTATE.Columns["LOG_NAME"].HeaderText = "GÖREV";
            DGVSFTPSTATE.Columns["LOG_DATETIME"].HeaderText = "TARİH";
            DGVSFTPSTATE.Columns["LOG_EXP"].HeaderText = "GÖREV TANIMI";
            DGVSFTPSTATE.Columns["PACKETID"].HeaderText = "PAKET NO";
            DGVSFTPSTATE.Columns["LOG_CREATE_USERNAME"].HeaderText = "KULLANICISI";
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

            for (int j = 0; j < DGVSFTPSTATE.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                myRange.Value2 = DGVSFTPSTATE.Columns[j].HeaderText;
            }
            StartRow++;
            for (int i = 0; i < DGVSFTPSTATE.Rows.Count; i++)
            {
                for (int j = 0; j < DGVSFTPSTATE.Columns.Count; j++)
                {
                    try
                    {
                        Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                        myRange.Value2 = DGVSFTPSTATE[j, i].Value == null ? "" : DGVSFTPSTATE[j, i].Value;
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

        private void DGVSFTPSTATE_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = DGVSFTPSTATE.Rows[e.RowIndex].Cells["STATE"];
            string value = cell.Value.ToString() == "Başarılı" ? "Başarılı" : "Başarısız";            

            if (value == "Başarılı")
            {
                DGVSFTPSTATE.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                DGVSFTPSTATE.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

            }
            else
            {
                DGVSFTPSTATE.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                DGVSFTPSTATE.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
