using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard
{
    public partial class PacketPreparation : Form
    {
        List<Debit> LeftList = new List<Debit>();
        List<Debit> RightList = new List<Debit>();
        List<Debit> FilteredList = new List<Debit>();
        List<Debit> PacketDetailList = new List<Debit>();

        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        public PacketPreparation()
        {
            InitializeComponent();
        }

        #region Ön Filtre Değerlerini Tutan Değişkenler       
        int detailSendingValue = -1, branchValue = -1, voucherType = -1, currencyValue = -1, clientCodeFiltreType = -1;
        List<DateTime> expiryDateList = new List<DateTime>(); List<DateTime> invoiceDateList = new List<DateTime>();
        string clientSpecialCode = "", clientSpecialCode2 = "", clientCodeBeg = "", clientCodeEnd = ""; bool replaceDueDateAndTodayDate;
        List<int> mecraTypeList = new List<int>(); List<int> mecraList = new List<int>();
        List<int> marketingCompantList = new List<int>(); List<int> customerList = new List<int>();
        List<int> planCodeList = new List<int>(); List<int> internetMainCategory = new List<int>(); List<int> internetSubCategory = new List<int>();
        DateTime payBegDate, payEndDate, invBegDate, invEndDate;
        #endregion               

        private void dataGridViewLeft_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dataGridViewLeft.FilterString))
                {
                    LeftList.Clear();
                    var source = new BindingSource();
                    FillLeftList();
                    source.DataSource = LeftList;
                    dataGridViewLeft.DataSource = source;
                  
                }
                else
                {
                    IEnumerable<Debit> enumerable = LeftList.AsEnumerable();
                    LeftList = FilterAndSortDataStr(enumerable, dataGridViewLeft.FilterString, dataGridViewLeft.SortString);
                }
                dataGridViewLeft.DataSource = LeftList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
          
        }

        //Filtereleme Metodu 
        private List<Debit> FilterAndSortDataStr(IEnumerable<Debit> collection, string filter, string sort)
        {
            if (collection == null)
            {
                return new List<Debit>();
            }
            if (string.IsNullOrWhiteSpace(filter) && string.IsNullOrWhiteSpace(sort))
            {
                return collection.ToList();
            }

            var table = new DataTable
            {
                CaseSensitive = false
            };

            var props = typeof(Debit).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(prop => !Attribute.IsDefined(prop, typeof(IgnoreDataMemberAttribute)))
                .ToList();

            table.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());

            table.Columns.Add(new DataColumn { DataType = typeof(int) });

            var itemList = collection.ToArray();
            var count = itemList.Length;
            for (var i = 0; i < count; i++)
            {
                var data = new object[props.Count + 1];
                var dataItems = props.Select(p => p.GetValue(itemList[i], null)).ToArray();

                for (var z = 0; z < props.Count; z++)
                {
                    data[z] = dataItems[z];
                }

                data[props.Count] = i;
                table.Rows.Add(data);
            }

            DataRow[] rows = null;

            try
            {
                var dv = table.DefaultView;
                dv.RowFilter = filter ?? string.Empty;
                dv.Sort = sort ?? string.Empty;
                rows = dv.ToTable().Rows.Cast<DataRow>().ToArray();
            }
            catch (EvaluateException) { }

            var result = new List<Debit>();
            if (rows != null)
            {
                var indexes = rows.Select(r => (int)r[table.Columns.Count - 1]).ToArray();

                for (var i = 0; i < count; i++)
                {
                    if (indexes.Contains(i))
                    {
                        result.Add(itemList[i]);
                    }
                }
            }

            return result;
        }

        private void btnRightsel_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewLeft.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow drv = dataGridViewLeft.Rows[i];
                bool selectedRow = Convert.ToBoolean(drv.Selected);
                if (selectedRow)
                {
                    Debit debit = new Debit();
                    #region şimdilik isimsiz region                    
                    debit.PayRef = Convert.ToInt32(drv.Cells["PayRef"].Value);
                    debit.ClCardRef = Convert.ToInt32(drv.Cells["ClCardRef"].Value);
                    debit.FicheRef = Convert.ToInt32(drv.Cells["FicheRef"].Value);
                    debit.ModuleNr = Convert.ToInt32(drv.Cells["ModuleNr"].Value);
                    debit.DueDate = Convert.ToDateTime(drv.Cells["DueDate"].Value);
                    debit.TrCode = Convert.ToInt32(drv.Cells["TrCode"].Value);
                    debit.Total = Convert.ToDecimal(drv.Cells["Total"].Value);
                    debit.CurCode = drv.Cells["CurCode"].Value.ToString();
                    debit.TrCurr = Convert.ToInt32(drv.Cells["TrCurr"].Value);
                    debit.ClCode = drv.Cells["ClCode"].Value.ToString();
                    debit.ClDef = drv.Cells["ClDef"].Value.ToString();
                    debit.IsPerson = Convert.ToInt32(drv.Cells["IsPerson"].Value);
                    debit.TaxNr = drv.Cells["TaxNr"].Value.ToString();
                    debit.TaxOffice = drv.Cells["TaxOffice"].Value.ToString();
                    debit.IBAN = drv.Cells["IBAN"].Value.ToString();
                    debit.EmailAdres = drv.Cells["EmailAdres"].Value.ToString();
                    debit.FicheDate = Convert.ToDateTime(drv.Cells["FicheDate"].Value);
                    debit.FicheNo = drv.Cells["FicheNo"].Value.ToString();
                    debit.DoCode = drv.Cells["DoCode"].Value.ToString();
                    debit.TrType = drv.Cells["TrType"].Value.ToString();
                    debit.GenExp1 = drv.Cells["GenExp1"].Value.ToString();
                    debit.Branch = Convert.ToInt32(drv.Cells["Branch"].Value);
                    debit.Paid = Convert.ToDecimal(drv.Cells["Total"].Value);
                    #endregion
                    if (detailSendingValue == 3)     // Boyutlu Ödeme Satırları Üzerinden
                    {
                        debit.MecraType = drv.Cells["MecraType"].Value.ToString();
                        debit.Mecra = drv.Cells["Mecra"].Value.ToString();
                        debit.MarketingCompany = drv.Cells["MarketingCompany"].Value.ToString();
                        debit.Customer = drv.Cells["Customer"].Value.ToString();
                        debit.PlanCode = drv.Cells["PlanCode"].Value.ToString();
                        debit.InternetMainCategory = drv.Cells["InternetMainCategory"].Value.ToString();
                        debit.InternetSubCategory = drv.Cells["InternetSubCategory"].Value.ToString();
                        debit.DD1REF = Convert.ToInt32(drv.Cells["DD1REF"].Value);
                        debit.DD2REF = Convert.ToInt32(drv.Cells["DD2REF"].Value);
                        debit.DD3REF = Convert.ToInt32(drv.Cells["DD3REF"].Value);
                        debit.DD4REF = Convert.ToInt32(drv.Cells["DD4REF"].Value);
                        debit.DD5REF = Convert.ToInt32(drv.Cells["DD5REF"].Value);
                        debit.DD6REF = Convert.ToInt32(drv.Cells["DD6REF"].Value);
                        debit.DD7REF = Convert.ToInt32(drv.Cells["DD7REF"].Value);
<<<<<<< HEAD

                    }
                    RightList.Add(debit);
                    var select = LeftList.Where(x => x.PayRef == debit.PayRef).ToList();
                    //LeftList.RemoveAt(drv.Cells[1].RowIndex);                    
                    LeftList.Remove(select[0]);

                    //Adding Selected Left Total to Right and Removing from Left
                    foreach (var sel in select)
                    {
                        textBoxSumL.Text = (Convert.ToDecimal(textBoxSumL.Text) - sel.Total).ToString();
                        textBoxsumR.Text = (Convert.ToDecimal(textBoxsumR.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurR.Text = debit.CurCode.ToString();
                    }
                    
                    //Updating the number of Rows
                    textBox_totalL.Text = (Convert.ToInt32(textBox_totalL.Text) - select.Count).ToString();
                    textBox_totalR.Text= (Convert.ToInt32(textBox_totalR.Text)+select.Count).ToString();
                }
            }

            var source = new BindingSource();
            source.DataSource = RightList;
            dataGridViewRight.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = LeftList;
            dataGridViewLeft.DataSource = source2;
        }

        private void btnLeftsel_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewRight.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow drv = dataGridViewRight.Rows[i];
                //bool chkboxselect = Convert.ToBoolean(drv.Cells["ColRightSelected"].Value);
                bool selectedRow = Convert.ToBoolean(drv.Selected);
                if (selectedRow)
                {
                    Debit debit = new Debit();
                    debit.PayRef = Convert.ToInt32(drv.Cells["PayRef"].Value);
                    debit.ClCardRef = Convert.ToInt32(drv.Cells["ClCardRef"].Value);
                    debit.FicheRef = Convert.ToInt32(drv.Cells["FicheRef"].Value);
                    debit.ModuleNr = Convert.ToInt32(drv.Cells["ModuleNr"].Value);
                    debit.DueDate = Convert.ToDateTime(drv.Cells["DueDate"].Value);
                    debit.TrCode = Convert.ToInt32(drv.Cells["TrCode"].Value);
                    debit.Total = Convert.ToDecimal(drv.Cells["Total"].Value);
                    debit.CurCode = drv.Cells["CurCode"].Value.ToString();
                    debit.TrCurr = Convert.ToInt32(drv.Cells["TrCurr"].Value);
                    debit.ClCode = drv.Cells["ClCode"].Value.ToString();
                    debit.ClDef = drv.Cells["ClDef"].Value.ToString();
                    debit.IsPerson = Convert.ToInt32(drv.Cells["IsPerson"].Value);
                    debit.TaxNr = drv.Cells["TaxNr"].Value.ToString();
                    debit.TaxOffice = drv.Cells["TaxOffice"].Value.ToString();
                    debit.IBAN = drv.Cells["IBAN"].Value.ToString();
                    debit.EmailAdres = drv.Cells["EmailAdres"].Value.ToString();
                    debit.FicheDate = Convert.ToDateTime(drv.Cells["FicheDate"].Value);
                    debit.FicheNo = drv.Cells["FicheNo"].Value.ToString();
                    debit.DoCode = drv.Cells["DoCode"].Value.ToString();
                    debit.TrType = drv.Cells["TrType"].Value.ToString();
                    debit.GenExp1 = drv.Cells["GenExp1"].Value.ToString();
                    debit.Branch = Convert.ToInt32(drv.Cells["Branch"].Value);

                    if (detailSendingValue == 3)
                    {
                        debit.MecraType = drv.Cells["MecraType"].Value.ToString();
                        debit.Mecra = drv.Cells["Mecra"].Value.ToString();
                        debit.MarketingCompany = drv.Cells["MarketingCompany"].Value.ToString();
                        debit.Customer = drv.Cells["Customer"].Value.ToString();
                        debit.PlanCode = drv.Cells["PlanCode"].Value.ToString();
                        debit.InternetMainCategory = drv.Cells["InternetMainCategory"].Value.ToString();
                        debit.InternetSubCategory = drv.Cells["InternetSubCategory"].Value.ToString();
                        debit.DD1REF = Convert.ToInt32(drv.Cells["DD1REF"].Value);
                        debit.DD2REF = Convert.ToInt32(drv.Cells["DD2REF"].Value);
                        debit.DD3REF = Convert.ToInt32(drv.Cells["DD3REF"].Value);
                        debit.DD4REF = Convert.ToInt32(drv.Cells["DD4REF"].Value);
                        debit.DD5REF = Convert.ToInt32(drv.Cells["DD5REF"].Value);
                        debit.DD6REF = Convert.ToInt32(drv.Cells["DD6REF"].Value);
                        debit.DD7REF = Convert.ToInt32(drv.Cells["DD7REF"].Value);
                    }
                    LeftList.Add(debit);
                    var select = RightList.Where(x => x.PayRef == debit.PayRef).ToList();
                    //RightList.RemoveAt(drv.Cells[1].RowIndex);
                    RightList.Remove(select[0]);
                    //Right Row Text Update
                    textBox_totalR.Text = (Convert.ToInt32(textBox_totalR.Text) - select.Count).ToString();
                    textBox_totalL.Text = (Convert.ToInt32(textBox_totalL.Text) + select.Count).ToString();

                    //Adding Selected Rightt Total to Left and Removing from Right
                    foreach (var sel in select)
                    {
                        
                        textBoxsumR.Text = (Convert.ToDecimal(textBoxsumR.Text) - sel.Total).ToString();
                        textBoxSumL.Text = (Convert.ToDecimal(textBoxSumL.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurL.Text = debit.CurCode.ToString();
                    }

=======

                    }
                    RightList.Add(debit);
                    var select = LeftList.Where(x => x.PayRef == debit.PayRef).ToList();
                    //LeftList.RemoveAt(drv.Cells[1].RowIndex);                    
                    LeftList.Remove(select[0]);
>>>>>>> 7bce5ec17c3c2fe154cdfd6f77eb3070bdaa4e79
                }
            }

            var source = new BindingSource();
            source.DataSource = RightList;
            dataGridViewRight.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = LeftList;
            dataGridViewLeft.DataSource = source2;
        }

<<<<<<< HEAD
        private void dataGridViewLeft_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewLeft_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
                if (e.ColumnIndex == 1)
                    textBoxSumL.Text = CellSum().ToString();
        }

        //Getting The Total Sum of LGRID
        private double CellSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridViewLeft.Rows.Count; ++i)
            {
                double d = 0;
                Double.TryParse(dataGridViewLeft.Rows[i].Cells[1].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void dataGridViewRight_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
=======
        private void btnLeftsel_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewRight.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow drv = dataGridViewRight.Rows[i];
                //bool chkboxselect = Convert.ToBoolean(drv.Cells["ColRightSelected"].Value);
                bool selectedRow = Convert.ToBoolean(drv.Selected);
                if (selectedRow)
                {
                    Debit debit = new Debit();
                    debit.PayRef = Convert.ToInt32(drv.Cells["PayRef"].Value);
                    debit.ClCardRef = Convert.ToInt32(drv.Cells["ClCardRef"].Value);
                    debit.FicheRef = Convert.ToInt32(drv.Cells["FicheRef"].Value);
                    debit.ModuleNr = Convert.ToInt32(drv.Cells["ModuleNr"].Value);
                    debit.DueDate = Convert.ToDateTime(drv.Cells["DueDate"].Value);
                    debit.TrCode = Convert.ToInt32(drv.Cells["TrCode"].Value);
                    debit.Total = Convert.ToDecimal(drv.Cells["Total"].Value);
                    debit.CurCode = drv.Cells["CurCode"].Value.ToString();
                    debit.TrCurr = Convert.ToInt32(drv.Cells["TrCurr"].Value);
                    debit.ClCode = drv.Cells["ClCode"].Value.ToString();
                    debit.ClDef = drv.Cells["ClDef"].Value.ToString();
                    debit.IsPerson = Convert.ToInt32(drv.Cells["IsPerson"].Value);
                    debit.TaxNr = drv.Cells["TaxNr"].Value.ToString();
                    debit.TaxOffice = drv.Cells["TaxOffice"].Value.ToString();
                    debit.IBAN = drv.Cells["IBAN"].Value.ToString();
                    debit.EmailAdres = drv.Cells["EmailAdres"].Value.ToString();
                    debit.FicheDate = Convert.ToDateTime(drv.Cells["FicheDate"].Value);
                    debit.FicheNo = drv.Cells["FicheNo"].Value.ToString();
                    debit.DoCode = drv.Cells["DoCode"].Value.ToString();
                    debit.TrType = drv.Cells["TrType"].Value.ToString();
                    debit.GenExp1 = drv.Cells["GenExp1"].Value.ToString();
                    debit.Branch = Convert.ToInt32(drv.Cells["Branch"].Value);

                    if (detailSendingValue == 3)
                    {
                        debit.MecraType = drv.Cells["MecraType"].Value.ToString();
                        debit.Mecra = drv.Cells["Mecra"].Value.ToString();
                        debit.MarketingCompany = drv.Cells["MarketingCompany"].Value.ToString();
                        debit.Customer = drv.Cells["Customer"].Value.ToString();
                        debit.PlanCode = drv.Cells["PlanCode"].Value.ToString();
                        debit.InternetMainCategory = drv.Cells["InternetMainCategory"].Value.ToString();
                        debit.InternetSubCategory = drv.Cells["InternetSubCategory"].Value.ToString();
                        debit.DD1REF = Convert.ToInt32(drv.Cells["DD1REF"].Value);
                        debit.DD2REF = Convert.ToInt32(drv.Cells["DD2REF"].Value);
                        debit.DD3REF = Convert.ToInt32(drv.Cells["DD3REF"].Value);
                        debit.DD4REF = Convert.ToInt32(drv.Cells["DD4REF"].Value);
                        debit.DD5REF = Convert.ToInt32(drv.Cells["DD5REF"].Value);
                        debit.DD6REF = Convert.ToInt32(drv.Cells["DD6REF"].Value);
                        debit.DD7REF = Convert.ToInt32(drv.Cells["DD7REF"].Value);
                    }
                    LeftList.Add(debit);
                    var select = RightList.Where(x => x.PayRef == debit.PayRef).ToList();
                    //RightList.RemoveAt(drv.Cells[1].RowIndex);
                    RightList.Remove(select[0]);

                }
            }

            var source = new BindingSource();
            source.DataSource = RightList;
            dataGridViewRight.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = LeftList;
            dataGridViewLeft.DataSource = source2;
        }

      
>>>>>>> 7bce5ec17c3c2fe154cdfd6f77eb3070bdaa4e79

        private void dataGridViewLeft_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(dataGridViewLeft.SortString) == true)
                {
                    LeftList.Clear();
                    var source = new BindingSource();
                    FillLeftList();
                    source.DataSource = LeftList;
                    dataGridViewLeft.DataSource = source;
                }
                else
                {
                    var sortStr = dataGridViewLeft.SortString.Replace("[", "").Replace("]", "");

                    if (string.IsNullOrEmpty(dataGridViewLeft.FilterString) == true)
                    {
                        // the grid is not filtered!
                        LeftList = LeftList.OrderBy(sortStr).ToList();
                        dataGridViewLeft.DataSource = LeftList;
                    }
                    else
                    {
                        // the grid is filtered!
                        LeftList = LeftList.OrderBy(sortStr).ToList();
                        dataGridViewLeft.DataSource = LeftList;
                    }

                    //textBox_sort.Text = sortStr;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
<<<<<<< HEAD
        }

=======
            
        }

       

>>>>>>> 7bce5ec17c3c2fe154cdfd6f77eb3070bdaa4e79
        private void button_unloadfilters_Click(object sender, EventArgs e)
        {
            dataGridViewLeft.CleanFilterAndSort();
        }

        private void Package_Load(object sender, EventArgs e)
        {

            var source = new BindingSource();
            FillLeftList();
            source.DataSource = LeftList;
            dataGridViewLeft.DataSource = source;

            // Ödeme çıkış hesap bilgilerini AYZ_PW_BANKACCOUNT tablosundan combobox'a getiren kod.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                DataTable tbl = new DataTable();
                CommandText = "SELECT * FROM AYZ_PW_BANKACCOUNT WHERE CURRENCY = " + currencyValue + " AND FIRMNR = " + Helper.FIRMNR + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                tbl.Load(dr);

                cmbOutAccountInfo.DataSource = tbl;
                cmbOutAccountInfo.DisplayMember = "TITLE";
                cmbOutAccountInfo.ValueMember = "ID";
            }


            #region Left Grid Kolon Görünüm,Header Text ve Display Index Ayarları
            dataGridViewLeft.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridViewLeft.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewLeft.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Regular);
            dataGridViewLeft.EnableHeadersVisualStyles = false;

            if (detailSendingValue == 2) // Değer 2 ise Ödeme Satırları Üzerinden ödeme yapılacaktır anlamına gelir. Bu yüzden boyut kolonlarını göstermicem.
            {
                dataGridViewLeft.Columns["MecraType"].Visible = false;
                dataGridViewLeft.Columns["Mecra"].Visible = false;
                dataGridViewLeft.Columns["MarketingCompany"].Visible = false;
                dataGridViewLeft.Columns["Customer"].Visible = false;
                dataGridViewLeft.Columns["PlanCode"].Visible = false;
                dataGridViewLeft.Columns["InternetMainCategory"].Visible = false;
                dataGridViewLeft.Columns["InternetSubCategory"].Visible = false;
                dataGridViewLeft.Columns["DD1REF"].Visible = false;
                dataGridViewLeft.Columns["DD2REF"].Visible = false;
                dataGridViewLeft.Columns["DD3REF"].Visible = false;
                dataGridViewLeft.Columns["DD4REF"].Visible = false;
                dataGridViewLeft.Columns["DD5REF"].Visible = false;
                dataGridViewLeft.Columns["DD6REF"].Visible = false;
                dataGridViewLeft.Columns["DD7REF"].Visible = false;
                dataGridViewLeft.Columns["NotInPayTrans"].Visible = false;
                dataGridViewLeft.Columns["NotInPayTransFrame"].Visible = false;
            }
            else if (detailSendingValue == 3) // Değer 3 ise Boyut Satırları Üzerinden ödeme yapılacaktır anlamına gelir.
            {
                dataGridViewLeft.Columns["MecraType"].HeaderText = "Mecra Türü";
                dataGridViewLeft.Columns["MarketingCompany"].HeaderText = "Pazarlama Şirketi";
                dataGridViewLeft.Columns["Customer"].HeaderText = "Müşteri";
                dataGridViewLeft.Columns["PlanCode"].HeaderText = "Plan Kodu";
                dataGridViewLeft.Columns["InternetMainCategory"].HeaderText = "İnternet Ana Kategori";
                dataGridViewLeft.Columns["InternetSubCategory"].HeaderText = "İnternet Alt Kategori";
                dataGridViewLeft.Columns["MecraType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewLeft.Columns["Mecra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewLeft.Columns["MarketingCompany"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewLeft.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewLeft.Columns["PlanCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewLeft.Columns["InternetMainCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewLeft.Columns["InternetSubCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            dataGridViewLeft.Columns["PayRef"].Visible = false;
            dataGridViewLeft.Columns["ClCardRef"].Visible = false;
            dataGridViewLeft.Columns["FicheRef"].Visible = false;
            dataGridViewLeft.Columns["ModuleNr"].Visible = false;
            dataGridViewLeft.Columns["TrCode"].Visible = false;
            dataGridViewLeft.Columns["IsPerson"].Visible = false;
            dataGridViewLeft.Columns["Branch"].Visible = false;
            dataGridViewLeft.Columns["TrType"].Visible = false;
            dataGridViewLeft.Columns["Paid"].Visible = false;
            dataGridViewLeft.Columns["GenExp1"].Visible = false;
            dataGridViewLeft.Columns["EmailAdres"].Visible = false;
            dataGridViewLeft.Columns["TrCode"].Visible = false;
            dataGridViewLeft.Columns["TrCurr"].Visible = false;
            dataGridViewLeft.Columns["TaxNr"].Visible = false;
            dataGridViewLeft.Columns["TaxOffice"].Visible = false;
            dataGridViewLeft.Columns["DD1REF"].Visible = false;
            dataGridViewLeft.Columns["DD2REF"].Visible = false;
            dataGridViewLeft.Columns["DD3REF"].Visible = false;
            dataGridViewLeft.Columns["DD4REF"].Visible = false;
            dataGridViewLeft.Columns["DD5REF"].Visible = false;
            dataGridViewLeft.Columns["DD6REF"].Visible = false;
            dataGridViewLeft.Columns["DD7REF"].Visible = false;
            dataGridViewLeft.Columns["NotInPayTrans"].Visible = false;
            dataGridViewLeft.Columns["NotInPayTransFrame"].Visible = false;
            dataGridViewLeft.Columns["DueDate"].HeaderText = "Vade Tarihi";
            dataGridViewLeft.Columns["CurCode"].HeaderText = "Döviz";
            dataGridViewLeft.Columns["Total"].HeaderText = "Tutar";
            dataGridViewLeft.Columns["ClCode"].HeaderText = "Cari Kod";
            dataGridViewLeft.Columns["ClDef"].HeaderText = "Cari Hesap Tanımı";
            dataGridViewLeft.Columns["FicheDate"].HeaderText = "Fiş Tarihi";
            dataGridViewLeft.Columns["FicheNo"].HeaderText = "Fiş Numarası";
            dataGridViewLeft.Columns["DoCode"].HeaderText = "Belge Numarası";
            dataGridViewLeft.Columns["NotInPayTransFrame"].HeaderText = "Active";
            dataGridViewLeft.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewLeft.Columns["ClCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewLeft.Columns["ClDef"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewLeft.Columns["IBAN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewLeft.Columns["DoCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewLeft.Columns["CurCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewLeft.Columns["FicheDate"].Width = 75;
            dataGridViewLeft.Columns["FicheNo"].Width = 90;

            
            //LEft Grid Middle Centered Aligned
            Dictionary<string, DataGridView> LGCentered = new Dictionary<string, DataGridView>();
            DataGridView dgl = dataGridViewLeft;
            string[] strLeft = { "CurCode", "Total" };
            foreach (var str in strLeft)
            {
                LGCentered.Add(str, dgl);
                foreach (var LC in LGCentered)
                {
                    LC.Value.Columns[LC.Key].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

<<<<<<< HEAD
            
=======
            //dataGridViewLeft.Columns["CurCode"].DisplayIndex = 1; HANGİ COLUMNDA Göstermek istersek bu şekilde yapabiliriz.
>>>>>>> 7bce5ec17c3c2fe154cdfd6f77eb3070bdaa4e79
            #endregion

            var source2 = new BindingSource();
            source2.DataSource = RightList;
            dataGridViewRight.DataSource = source2;
            #region Right Grid Kolon Görünüm,Header Text ve Display Index Ayarları

            dataGridViewRight.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridViewRight.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRight.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Regular);
            dataGridViewRight.EnableHeadersVisualStyles = false;

            dataGridViewRight.Columns["PayRef"].Visible = false;
            dataGridViewRight.Columns["ClCardRef"].Visible = false;
            dataGridViewRight.Columns["FicheRef"].Visible = false;
            dataGridViewRight.Columns["ModuleNr"].Visible = false;
            dataGridViewRight.Columns["TrCode"].Visible = false;
            dataGridViewRight.Columns["GenExp1"].Visible = false;
            dataGridViewRight.Columns["TrType"].Visible = false;
            dataGridViewRight.Columns["EmailAdres"].Visible = false;
            dataGridViewRight.Columns["IsPerson"].Visible = false;
            dataGridViewRight.Columns["CurCode"].HeaderText = "Döviz";
            dataGridViewRight.Columns["Branch"].Visible = false;
            dataGridViewRight.Columns["TaxNr"].Visible = false;
            dataGridViewRight.Columns["TaxOffice"].Visible = false;
            dataGridViewRight.Columns["TrCurr"].Visible = false;
            dataGridViewRight.Columns["DD1REF"].Visible = false;
            dataGridViewRight.Columns["DD2REF"].Visible = false;
            dataGridViewRight.Columns["DD3REF"].Visible = false;
            dataGridViewRight.Columns["DD4REF"].Visible = false;
            dataGridViewRight.Columns["DD5REF"].Visible = false;
            dataGridViewRight.Columns["DD6REF"].Visible = false;
            dataGridViewRight.Columns["DD7REF"].Visible = false;
            dataGridViewRight.Columns["NotInPayTrans"].Visible = false;
            dataGridViewRight.Columns["NotInPayTransFrame"].Visible = false;
            dataGridViewRight.Columns["Paid"].HeaderText = "Ödenecek";
            dataGridViewRight.Columns["Paid"].HeaderCell.Style.BackColor = Color.Red;
            dataGridViewRight.Columns["Total"].HeaderText = "Ödenmesi Gereken";
            dataGridViewRight.Columns["DueDate"].HeaderText = "Vade Tarihi";
            dataGridViewRight.Columns["ClDef"].HeaderText = "Cari Hesap Tanımı";
            dataGridViewRight.Columns["ClCode"].HeaderText = "Cari Kod";
            dataGridViewRight.Columns["FicheDate"].HeaderText = "Fiş Tarihi";
            dataGridViewRight.Columns["FicheNo"].HeaderText = "Fiş Numarası";
            dataGridViewRight.Columns["DoCode"].HeaderText = "Belge Numarası";
            dataGridViewRight.Columns["MecraType"].HeaderText = "Mecra Türü";
            dataGridViewRight.Columns["MarketingCompany"].HeaderText = "Pazarlama Şirketi";
            dataGridViewRight.Columns["Customer"].HeaderText = "Müşteri";
            dataGridViewRight.Columns["PlanCode"].HeaderText = "Plan Kodu";
            dataGridViewRight.Columns["InternetMainCategory"].HeaderText = "İnternet Ana Kategori";
            dataGridViewRight.Columns["InternetSubCategory"].HeaderText = "İnternet Alt Kategori";
            dataGridViewRight.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["ClCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["ClDef"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["IBAN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["DoCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["CurCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["MecraType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["Mecra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["MarketingCompany"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["PlanCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["InternetMainCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRight.Columns["InternetSubCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //MiddleCenter Align  alligned for Right Grid
            Dictionary<string,DataGridView > RGCentered = new Dictionary<string,DataGridView >();
            DataGridView dgr = dataGridViewRight;
            string[] strRight = { "Paid", "CurCode" };
            foreach(var str in strRight)
            {
                RGCentered.Add(str, dgr);
                foreach (var ab in RGCentered)
                {
                    ab.Value.Columns[ab.Key].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            
           
            
            if (detailSendingValue == 2) // Ödeme Satırları Üzerinden
            {
                dataGridViewRight.Columns["MecraType"].Visible = false;
                dataGridViewRight.Columns["Mecra"].Visible = false;
                dataGridViewRight.Columns["MarketingCompany"].Visible = false;
                dataGridViewRight.Columns["Customer"].Visible = false;
                dataGridViewRight.Columns["PlanCode"].Visible = false;
                dataGridViewRight.Columns["InternetMainCategory"].Visible = false;
                dataGridViewRight.Columns["InternetSubCategory"].Visible = false;
                dataGridViewRight.Columns["DD1REF"].Visible = false;
                dataGridViewRight.Columns["DD2REF"].Visible = false;
                dataGridViewRight.Columns["DD3REF"].Visible = false;
                dataGridViewRight.Columns["DD4REF"].Visible = false;
                dataGridViewRight.Columns["DD5REF"].Visible = false;
                dataGridViewRight.Columns["DD6REF"].Visible = false;
                dataGridViewRight.Columns["DD7REF"].Visible = false;
                dataGridViewRight.Columns["NotInPayTrans"].Visible = false;
                dataGridViewRight.Columns["NotInPayTransFrame"].Visible = false;
            }
            #endregion

            //Getting the total columns in 
            textBox_totalL.Text = dataGridViewLeft.Rows.Count.ToString();

            textBox_totalR.Text = "0";
            
            //Getting the total value
            decimal sumL = 0.00m;
            for (int i = 0; i < dataGridViewLeft.Rows.Count; ++i)
            {
                sumL += Convert.ToDecimal(dataGridViewLeft.Rows[i].Cells["Total"].Value);
                //Getting Currency Code for Left Grid
                labelCurL.Text = dataGridViewLeft.Rows[i].Cells["CurCode"].Value.ToString();
            }
            textBoxSumL.Text = sumL.ToString();
            
            //Getting the total columns in RGRID

            decimal sumR = 0.00m;
            for (int i = 0; i < dataGridViewRight.Rows.Count; ++i)
            {
                sumR += Convert.ToDecimal(dataGridViewRight.Rows[i].Cells["Total"].Value);
            }
            textBoxsumR.Text = sumR.ToString();
            
        }


        void FillLeftList()
        {
            // Login olan kullanıcının filterelerini AYZ_PW_FILTER_VALUES tablosundan alarak, paketleri getiren işlemler            
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_FILTER_VALUES WHERE FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.DetailSendig)
                        detailSendingValue = Convert.ToInt32(dr["VALUE"].ToString());
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.Currency)
                        currencyValue = Convert.ToInt32(dr["VALUE"].ToString());
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ExpiryDate)
                        expiryDateList.Add(Convert.ToDateTime(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.InvoiceDate)
                        invoiceDateList.Add(Convert.ToDateTime(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ClientCodeType)
                        clientCodeFiltreType = Convert.ToInt32(dr["VALUE"].ToString());
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ClientCodeBeg)
                        clientCodeBeg = dr["VALUE"].ToString();
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ClientCodeEnd)
                        clientCodeEnd = dr["VALUE"].ToString();
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ClientSpecialCode)
                        clientSpecialCode = dr["VALUE"].ToString();
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ClientSpecialCode2)
                        clientSpecialCode2 = dr["VALUE"].ToString();
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.ReplaceDueDateAndTodayDate)
                        replaceDueDateAndTodayDate = Convert.ToBoolean(dr["VALUE"].ToString());
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.VoucherType)
                        voucherType = Convert.ToInt32(dr["VALUE"].ToString());
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.MecraType)
                        mecraTypeList.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.Mecra)
                        mecraList.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.MarketingCompany)
                        marketingCompantList.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.Customer)
                        customerList.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.PlanCode)
                        planCodeList.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.InternerMainCategory)
                        internetMainCategory.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.InternetSubCategory)
                        internetSubCategory.Add(Convert.ToInt32(dr["VALUE"].ToString()));
                    if (Convert.ToInt32(dr["TYPE_"].ToString()) == (int)Helper.FilterType.Branch)
                        branchValue = Convert.ToInt32(dr["VALUE"].ToString());
                }
                conn.Close();

                #region Vade Tarihi ve Fatura Tarihi Başlangıç, Bitiş atamasını yapma
                if (Convert.ToDateTime(expiryDateList[0]) > Convert.ToDateTime(expiryDateList[1]))
                {
                    payBegDate = expiryDateList[1];
                    payEndDate = expiryDateList[0];
                }
                else if (Convert.ToDateTime(expiryDateList[1]) > Convert.ToDateTime(expiryDateList[0]))
                {
                    payBegDate = expiryDateList[0];
                    payEndDate = expiryDateList[1];
                }
                else
                {
                    payBegDate = expiryDateList[0];
                    payEndDate = expiryDateList[1];
                }

                if (Convert.ToDateTime(invoiceDateList[0]) > Convert.ToDateTime(invoiceDateList[1]))
                {
                    invBegDate = invoiceDateList[1];
                    invEndDate = invoiceDateList[0];
                }
                else if (Convert.ToDateTime(invoiceDateList[1]) > Convert.ToDateTime(invoiceDateList[0]))
                {
                    invBegDate = invoiceDateList[0];
                    invEndDate = invoiceDateList[1];
                }
                else
                {
                    invBegDate = invoiceDateList[0];
                    invEndDate = invoiceDateList[1];
                }
                #endregion

            }

            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                if (detailSendingValue == 2)
                {
                    using (SqlCommand cmd = new SqlCommand("AYZ_SP_PW_PAYTRANS", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 240;
                        #region StoredProcedure Paremetreleri
                        cmd.Parameters.Add("@FIRMNR", SqlDbType.Int).Value = Helper.FIRMNR;
                        cmd.Parameters.Add("@PERNR", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@BRANCH", SqlDbType.Int).Value = branchValue;
                        cmd.Parameters.Add("@payBegDate", SqlDbType.DateTime).Value = payBegDate;
                        cmd.Parameters.Add("@payEndDate", SqlDbType.DateTime).Value = payEndDate;
                        cmd.Parameters.Add("@invBegDate", SqlDbType.DateTime).Value = invBegDate;
                        cmd.Parameters.Add("@invEndDate", SqlDbType.DateTime).Value = invEndDate;
                        cmd.Parameters.Add("@DateFormat", SqlDbType.Int).Value = 104;
                        cmd.Parameters.Add("@CLFLTR", SqlDbType.Int).Value = clientCodeFiltreType;
                        cmd.Parameters.Add("@CLCODEBEG", SqlDbType.NVarChar).Value = clientCodeBeg;
                        cmd.Parameters.Add("@CLCODEEND", SqlDbType.NVarChar).Value = clientCodeEnd;
                        cmd.Parameters.Add("@CURTYPE", SqlDbType.SmallInt).Value = currencyValue;
                        cmd.Parameters.Add("@FICHETYPE", SqlDbType.SmallInt).Value = voucherType;
                        cmd.Parameters.Add("@HASIBAN", SqlDbType.SmallInt).Value = 1;
                        #endregion
                        conn.Open();
                        dr = cmd.ExecuteReader();

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Debit debit = new Debit();
                                debit.PayRef = Convert.ToInt32(dr["PAYREF"].ToString());
                                debit.ClCardRef = Convert.ToInt32(dr["CLCARDREF"].ToString());
                                debit.FicheRef = Convert.ToInt32(dr["FICHEREF"].ToString());
                                debit.ModuleNr = Convert.ToInt32(dr["MODULENR"].ToString());
                                debit.DueDate = Convert.ToDateTime(dr["DUEDATE"].ToString());
                                debit.TrCode = Convert.ToInt32(dr["TRCODE"].ToString());
                                debit.Total = Convert.ToDecimal(dr["TOTAL"].ToString());
                                debit.CurCode = dr["CURCODE"].ToString();
                                debit.TrCurr = Convert.ToInt32(dr["TRCURR"].ToString());
                                debit.ClCode = dr["CLCODE"].ToString();
                                debit.ClDef = dr["CLDEF"].ToString();

                                int imageWidth;
                                if (Int32.TryParse(dr["ISPERSON"].ToString(), out imageWidth))
                                {
                                    debit.IsPerson = dr["ISPERSON"].ToString() == "" ? 0 : imageWidth;
                                    
                                }
                             //   debit.IsPerson = dr["ISPERSON"].ToString() == "" ? 0 : Convert.ToInt32(dr["ISPERSON"].ToString());
                                debit.TaxNr = dr["TAXNR"].ToString();
                                debit.TaxOffice = dr["TAXOFFICE"].ToString();
                                debit.IBAN = dr["IBAN"].ToString();
                                debit.EmailAdres = dr["EMAILADDR"].ToString();
                                debit.FicheDate = Convert.ToDateTime(dr["FICHEDATE"].ToString());
                                debit.FicheNo = dr["FICHENO"].ToString();
                                debit.DoCode = dr["DOCODE"].ToString();
                                debit.TrType = dr["TRTYPE"].ToString();
                                debit.GenExp1 = dr["GENEXP1"].ToString();
                                debit.Branch = Convert.ToInt32(dr["BRANCH"].ToString());
                                LeftList.Add(debit);
                            }
                        }
                        conn.Close();
                    }
                }

                else if (detailSendingValue == 3)
                {
                    using (SqlCommand cmd = new SqlCommand("AYZ_SP_PW_PAYTRANS_DIM", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        #region StoredProcedure Paremetreleri
                        cmd.Parameters.Add("@FIRMNR", SqlDbType.Int).Value = Helper.FIRMNR;
                        cmd.Parameters.Add("@PERNR", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@BRANCH", SqlDbType.Int).Value = branchValue;
                        cmd.Parameters.Add("@payBegDate", SqlDbType.DateTime).Value = payBegDate;
                        cmd.Parameters.Add("@payEndDate", SqlDbType.DateTime).Value = payEndDate;
                        cmd.Parameters.Add("@invBegDate", SqlDbType.DateTime).Value = invBegDate;
                        cmd.Parameters.Add("@invEndDate", SqlDbType.DateTime).Value = invEndDate;
                        cmd.Parameters.Add("@DateFormat", SqlDbType.Int).Value = 104;
                        cmd.Parameters.Add("@CLFLTR", SqlDbType.Int).Value = clientCodeFiltreType;
                        cmd.Parameters.Add("@CLCODEBEG", SqlDbType.NVarChar).Value = clientCodeBeg;
                        cmd.Parameters.Add("@CLCODEEND", SqlDbType.NVarChar).Value = clientCodeEnd;
                        cmd.Parameters.Add("@CURTYPE", SqlDbType.SmallInt).Value = currencyValue;
                        cmd.Parameters.Add("@FICHETYPE", SqlDbType.SmallInt).Value = voucherType;
                        cmd.Parameters.Add("@HASIBAN", SqlDbType.SmallInt).Value = 1;
                        cmd.Parameters.Add("@DD1REF", SqlDbType.NVarChar).Value = string.Join(",", mecraTypeList.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", mecraTypeList.Select(n => n.ToString()).ToArray());
                        cmd.Parameters.Add("@DD2REF", SqlDbType.NVarChar).Value = string.Join(",", mecraList.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", mecraList.Select(n => n.ToString()).ToArray());
                        cmd.Parameters.Add("@DD3REF", SqlDbType.NVarChar).Value = string.Join(",", marketingCompantList.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", marketingCompantList.Select(n => n.ToString()).ToArray());
                        cmd.Parameters.Add("@DD4REF", SqlDbType.NVarChar).Value = string.Join(",", customerList.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", customerList.Select(n => n.ToString()).ToArray());
                        cmd.Parameters.Add("@DD5REF", SqlDbType.NVarChar).Value = string.Join(",", planCodeList.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", planCodeList.Select(n => n.ToString()).ToArray());
                        cmd.Parameters.Add("@DD6REF", SqlDbType.NVarChar).Value = string.Join(",", internetMainCategory.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", internetMainCategory.Select(n => n.ToString()).ToArray());
                        cmd.Parameters.Add("@DD7REF", SqlDbType.NVarChar).Value = string.Join(",", internetSubCategory.Select(n => n.ToString()).ToArray()) == "" ? "-1" : string.Join(",", internetSubCategory.Select(n => n.ToString()).ToArray());
                        #endregion
                        conn.Open();
                        dr = cmd.ExecuteReader();
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Debit debit = new Debit();
                                debit.PayRef = Convert.ToInt32(dr["PAYREF"].ToString());
                                debit.ClCardRef = Convert.ToInt32(dr["CLCARDREF"].ToString());
                                debit.FicheRef = Convert.ToInt32(dr["FICHEREF"].ToString());
                                debit.ModuleNr = Convert.ToInt32(dr["MODULENR"].ToString());
                                debit.DueDate = Convert.ToDateTime(dr["DUEDATE"].ToString());
                                debit.TrCode = Convert.ToInt32(dr["TRCODE"].ToString());
                                debit.Total = Convert.ToDecimal(dr["TOTAL"].ToString());
                                debit.CurCode = dr["CURCODE"].ToString();
                                debit.TrCurr = Convert.ToInt32(dr["TRCURR"].ToString());
                                debit.ClCode = dr["CLCODE"].ToString();
                                debit.ClDef = dr["CLDEF"].ToString();
                                debit.IsPerson = dr["ISPERSON"].ToString() == "" ? 0 : Convert.ToInt32(dr["ISPERSON"].ToString());
                                debit.TaxNr = dr["TAXNR"].ToString();
                                debit.TaxOffice = dr["TAXOFFICE"].ToString();
                                debit.IBAN = dr["IBAN"].ToString();
                                debit.EmailAdres = dr["EMAILADDR"].ToString();
                                debit.FicheDate = Convert.ToDateTime(dr["FICHEDATE"].ToString());
                                debit.FicheNo = dr["FICHENO"].ToString();
                                debit.DoCode = dr["DOCODE"].ToString();
                                debit.TrType = dr["TRTYPE"].ToString();
                                debit.GenExp1 = dr["GENEXP1"].ToString();
                                debit.Branch = Convert.ToInt32(dr["BRANCH"].ToString());
                                debit.MecraType = dr["Mecra_Turu"].ToString();
                                debit.Mecra = dr["Mecra"].ToString();
                                debit.MarketingCompany = dr["Pazarlama_Sirketi"].ToString();
                                debit.Customer = dr["Musteri"].ToString();
                                debit.PlanCode = dr["Plan_Kodu"].ToString();
                                debit.InternetMainCategory = dr["Internet_Ana_Kategori"].ToString();
                                debit.InternetSubCategory = dr["Internet_Alt_Kategori"].ToString();
                                debit.DD1REF = Convert.ToInt32(dr["MediaTypeRef"].ToString());
                                debit.DD2REF = Convert.ToInt32(dr["MediaRef"].ToString());
                                debit.DD3REF = Convert.ToInt32(dr["MarkettingRef"].ToString());
                                debit.DD4REF = Convert.ToInt32(dr["CustomerRef"].ToString());
                                debit.DD5REF = Convert.ToInt32(dr["PlanRef"].ToString());
                                debit.DD6REF = Convert.ToInt32(dr["InternetMainRef"].ToString());
                                debit.DD7REF = Convert.ToInt32(dr["InternetSubRef"].ToString());
                                LeftList.Add(debit);
                               
                            }
                        }
                        conn.Close();
                    }
                }
            }

            #region Daha önce oluşturulan paket satırlarının sol gride gelmesini engelleyen kod bloku           
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_PACKET_DETAIL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Debit debit = new Debit();
                        debit.PayRef = Convert.ToInt32(dr["PAYTRANSREF"].ToString());
                        PacketDetailList.Add(debit);
                    }
                }
                conn.Close();
            }
            foreach (var item in PacketDetailList)
            {
                var select = LeftList.Where(x => x.PayRef == item.PayRef).ToList();
                if (select.Count > 0)
                    LeftList.Remove(select[0]);
            }
            
            #endregion
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewLeft.Rows.Count - 1; i >= 0; i--)
            {
                dataGridViewLeft.SelectAll();
                DataGridViewRow drv = dataGridViewLeft.Rows[i];
                bool selectedRow = Convert.ToBoolean(drv.Selected);
                if (selectedRow)
                {
                    Debit debit = new Debit();
                    #region şimdilik isimsiz region                    
                    debit.PayRef = Convert.ToInt32(drv.Cells["PayRef"].Value);
                    debit.ClCardRef = Convert.ToInt32(drv.Cells["ClCardRef"].Value);
                    debit.FicheRef = Convert.ToInt32(drv.Cells["FicheRef"].Value);
                    debit.ModuleNr = Convert.ToInt32(drv.Cells["ModuleNr"].Value);
                    debit.DueDate = Convert.ToDateTime(drv.Cells["DueDate"].Value);
                    debit.TrCode = Convert.ToInt32(drv.Cells["TrCode"].Value);
                    debit.Total = Convert.ToDecimal(drv.Cells["Total"].Value);
                    debit.CurCode = drv.Cells["CurCode"].Value.ToString();
                    debit.TrCurr = Convert.ToInt32(drv.Cells["TrCurr"].Value);
                    debit.ClCode = drv.Cells["ClCode"].Value.ToString();
                    debit.ClDef = drv.Cells["ClDef"].Value.ToString();
                    debit.IsPerson = Convert.ToInt32(drv.Cells["IsPerson"].Value);
                    debit.TaxNr = drv.Cells["TaxNr"].Value.ToString();
                    debit.TaxOffice = drv.Cells["TaxOffice"].Value.ToString();
                    debit.IBAN = drv.Cells["IBAN"].Value.ToString();
                    debit.EmailAdres = drv.Cells["EmailAdres"].Value.ToString();
                    debit.FicheDate = Convert.ToDateTime(drv.Cells["FicheDate"].Value);
                    debit.FicheNo = drv.Cells["FicheNo"].Value.ToString();
                    debit.DoCode = drv.Cells["DoCode"].Value.ToString();
                    debit.TrType = drv.Cells["TrType"].Value.ToString();
                    debit.GenExp1 = drv.Cells["GenExp1"].Value.ToString();
                    debit.Branch = Convert.ToInt32(drv.Cells["Branch"].Value);
                    debit.Paid = Convert.ToDecimal(drv.Cells["Total"].Value);
                    #endregion
                    if (detailSendingValue == 3)     // Boyutlu Ödeme Satırları Üzerinden
                    {
                        debit.MecraType = drv.Cells["MecraType"].Value.ToString();
                        debit.Mecra = drv.Cells["Mecra"].Value.ToString();
                        debit.MarketingCompany = drv.Cells["MarketingCompany"].Value.ToString();
                        debit.Customer = drv.Cells["Customer"].Value.ToString();
                        debit.PlanCode = drv.Cells["PlanCode"].Value.ToString();
                        debit.InternetMainCategory = drv.Cells["InternetMainCategory"].Value.ToString();
                        debit.InternetSubCategory = drv.Cells["InternetSubCategory"].Value.ToString();
                        debit.DD1REF = Convert.ToInt32(drv.Cells["DD1REF"].Value);
                        debit.DD2REF = Convert.ToInt32(drv.Cells["DD2REF"].Value);
                        debit.DD3REF = Convert.ToInt32(drv.Cells["DD3REF"].Value);
                        debit.DD4REF = Convert.ToInt32(drv.Cells["DD4REF"].Value);
                        debit.DD5REF = Convert.ToInt32(drv.Cells["DD5REF"].Value);
                        debit.DD6REF = Convert.ToInt32(drv.Cells["DD6REF"].Value);
                        debit.DD7REF = Convert.ToInt32(drv.Cells["DD7REF"].Value);

                    }
                    RightList.Add(debit);
                    var select = LeftList.Where(x => x.PayRef == debit.PayRef).ToList();
                    //LeftList.RemoveAt(drv.Cells[1].RowIndex);                    
                    LeftList.Remove(select[0]);
                    //Updating Rows Text
                    textBox_totalL.Text = (Convert.ToInt32(textBox_totalL.Text) - select.Count).ToString();
                    textBox_totalR.Text = (Convert.ToInt32(textBox_totalR.Text) + select.Count).ToString();

                    //Adding Selected Left Total to Right and Removing from Left
                    foreach (var sel in select)
                    {
                        textBoxSumL.Text = (Convert.ToDecimal(textBoxSumL.Text) - sel.Total).ToString();
                        textBoxsumR.Text = (Convert.ToDecimal(textBoxsumR.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurR.Text = debit.CurCode.ToString();

                    }

                }
            }

            var source = new BindingSource();
            source.DataSource = RightList;
            dataGridViewRight.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = LeftList;
            dataGridViewLeft.DataSource = source2;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            for (int i = dataGridViewRight.Rows.Count - 1; i >= 0; i--)
            {
                dataGridViewRight.SelectAll();
                DataGridViewRow drv = dataGridViewRight.Rows[i];
                //bool chkboxselect = Convert.ToBoolean(drv.Cells["ColRightSelected"].Value);
                bool selectedRow = Convert.ToBoolean(drv.Selected);
                if (selectedRow)
                {
                    Debit debit = new Debit();
                    debit.PayRef = Convert.ToInt32(drv.Cells["PayRef"].Value);
                    debit.ClCardRef = Convert.ToInt32(drv.Cells["ClCardRef"].Value);
                    debit.FicheRef = Convert.ToInt32(drv.Cells["FicheRef"].Value);
                    debit.ModuleNr = Convert.ToInt32(drv.Cells["ModuleNr"].Value);
                    debit.DueDate = Convert.ToDateTime(drv.Cells["DueDate"].Value);
                    debit.TrCode = Convert.ToInt32(drv.Cells["TrCode"].Value);
                    debit.Total = Convert.ToDecimal(drv.Cells["Total"].Value);
                    debit.CurCode = drv.Cells["CurCode"].Value.ToString();
                    debit.TrCurr = Convert.ToInt32(drv.Cells["TrCurr"].Value);
                    debit.ClCode = drv.Cells["ClCode"].Value.ToString();
                    debit.ClDef = drv.Cells["ClDef"].Value.ToString();
                    debit.IsPerson = Convert.ToInt32(drv.Cells["IsPerson"].Value);
                    debit.TaxNr = drv.Cells["TaxNr"].Value.ToString();
                    debit.TaxOffice = drv.Cells["TaxOffice"].Value.ToString();
                    debit.IBAN = drv.Cells["IBAN"].Value.ToString();
                    debit.EmailAdres = drv.Cells["EmailAdres"].Value.ToString();
                    debit.FicheDate = Convert.ToDateTime(drv.Cells["FicheDate"].Value);
                    debit.FicheNo = drv.Cells["FicheNo"].Value.ToString();
                    debit.DoCode = drv.Cells["DoCode"].Value.ToString();
                    debit.TrType = drv.Cells["TrType"].Value.ToString();
                    debit.GenExp1 = drv.Cells["GenExp1"].Value.ToString();
                    debit.Branch = Convert.ToInt32(drv.Cells["Branch"].Value);

                    if (detailSendingValue == 3)
                    {
                        debit.MecraType = drv.Cells["MecraType"].Value.ToString();
                        debit.Mecra = drv.Cells["Mecra"].Value.ToString();
                        debit.MarketingCompany = drv.Cells["MarketingCompany"].Value.ToString();
                        debit.Customer = drv.Cells["Customer"].Value.ToString();
                        debit.PlanCode = drv.Cells["PlanCode"].Value.ToString();
                        debit.InternetMainCategory = drv.Cells["InternetMainCategory"].Value.ToString();
                        debit.InternetSubCategory = drv.Cells["InternetSubCategory"].Value.ToString();
                        debit.DD1REF = Convert.ToInt32(drv.Cells["DD1REF"].Value);
                        debit.DD2REF = Convert.ToInt32(drv.Cells["DD2REF"].Value);
                        debit.DD3REF = Convert.ToInt32(drv.Cells["DD3REF"].Value);
                        debit.DD4REF = Convert.ToInt32(drv.Cells["DD4REF"].Value);
                        debit.DD5REF = Convert.ToInt32(drv.Cells["DD5REF"].Value);
                        debit.DD6REF = Convert.ToInt32(drv.Cells["DD6REF"].Value);
                        debit.DD7REF = Convert.ToInt32(drv.Cells["DD7REF"].Value);
                    }
                    LeftList.Add(debit);
                    var select = RightList.Where(x => x.PayRef == debit.PayRef).ToList();
                    //RightList.RemoveAt(drv.Cells[1].RowIndex);
                    RightList.Remove(select[0]);

                    //Right Row Text Update
                    textBox_totalR.Text = (Convert.ToInt32(textBox_totalR.Text) - select.Count).ToString();
                    textBox_totalL.Text = (Convert.ToInt32(textBox_totalL.Text) + select.Count).ToString();

                    //Adding Selected Rightt Total to Left and Removing from Right
                    foreach (var sel in select)
                    {

                        textBoxsumR.Text = (Convert.ToDecimal(textBoxsumR.Text) - sel.Total).ToString();
                        textBoxSumL.Text = (Convert.ToDecimal(textBoxSumL.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurL.Text = debit.CurCode.ToString();

                    }

                }
            }

            var source = new BindingSource();
            source.DataSource = RightList;
            dataGridViewRight.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = LeftList;
            dataGridViewLeft.DataSource = source2;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            var source = new BindingSource();
            source.DataSource = FilteredList;
            dataGridViewLeft.DataSource = source;

            LeftList = FilteredList;
        }

        private void btnCreatePackage_Click(object sender, EventArgs e)
        {
            decimal sumRequire = RightList.Sum(x => x.Total);                                                       // Ödenmesi Gereken
            decimal sumPaid = RightList.Sum(x => x.Paid);                                                           // Ödenecek Tutar        
            int bankOutAccID = (int)cmbOutAccountInfo.SelectedValue;
            string bankAccountNo = "";
            string bankCode = "";
            string kurusAccount = "";
            string bankName = "";
            int bankref = 0;
            string tigerBankAccountCode = "";

            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    if (RightList.Count > 0)
                    {
                        komut.CommandText = "INSERT INTO AYZ_PW_PACKET" +
                                    "(" +
                                    "\nNOTE," +
                                    "\nUSERNR, " +
                                    "\nCREATED_BY, " +
                                    "\nCREATED_DATE, " +
                                    "\nCREATED_TIME, " +
                                    "\nTOTAL_REQUIRED, " +
                                    "\nTOTAL_PAID, " +
                                    "\nFIRMNR, " +
                                    "\nSTATUS, " +
                                    "\nARCHIVED," +
                                    "\nBANKID," +
                                    "\nBNK_NAME," +
                                    "\nTIGER_BNKACCODE," +
                                    "\nTIGER_ACCOUNT_CODE," +
                                    "\nACCOUNTOUTID," +
                                    "\nCURRENCY," +
                                    "\nCREATED_NAME" +
                                    "\n) " +
                                    "\nVALUES" +
                                    "(" +
                                    "\n '" + txtPacketExp.Text + "'," +
                                    "\n'" + Helper.USERID + "'," +
                                    "\n'" + Helper.USERID + "'," +
                                    "\nCONVERT(DATE, GETDATE(), 104)," +
                                    "\n" + Helper.GetTime() + "," +
                                    "\n" + sumRequire.ToString().Replace(',', '.') + "," +
                                    "\n" + sumPaid.ToString().Replace(',', '.') + ", " +
                                    "\n" + Helper.FIRMNR + ", " +
                                    "\n" + (int)Helper.PacketStatus.NewPacket + ", " +
                                    "\n " + (int)Helper.ArchiveStatus.Unarchived + ", " +
                                    "\n " + bankref + ", " +
                                    "\n '" + bankName + "', " +
                                    "\n '" + bankCode + "', " +
                                    "\n '" + tigerBankAccountCode + "', " +
                                    "\n '" + bankOutAccID + "', " +
                                    "\n '" + getCurrency(currencyValue) + "', " +
                                    "\n '" + Helper.USERNAME + "' " +
                                    "\n);" +
                                    "\nSELECT SCOPE_IDENTITY()";
                        komut.Connection = conn;
                        conn.Open();
                        int PacketId = Convert.ToInt32(komut.ExecuteScalar());

                        foreach (var item in RightList)
                        {
                            komut.CommandText = "INSERT INTO AYZ_PW_PACKET_DETAIL" +
                                                "(" +
                                                "\nPACKETID," +
                                                "\nPAYTRANSREF," +
                                                "\nFICHEREF," +
                                                "\nFICHENO," +
                                                "\nCLIENTREF," +
                                                "\nCLIENTNAME," +
                                                "\nIBAN," +
                                                "\nAMOUNT_REQUIRED," +
                                                "\nAMOUNT_PAID," +
                                                "\nCURRCODE," +
                                                "\nMODULENR," +
                                                "\nTRCODE," +
                                                "\nDOCODE," +
                                                "\nTRTYPE," +
                                                "\nGENEXP1," +
                                                "\nCL_CODE," +
                                                "\nCL_EMAIL," +
                                                "\nCL_TAXNR," +
                                                "\nCL_TAXOFFICE," +
                                                "\nDUE_DATE," +
                                                "\nFICHEDATE," +
                                                "\nDD1REF," +
                                                "\nDD2REF," +
                                                "\nDD3REF," +
                                                "\nDD4REF," +
                                                "\nDD5REF," +
                                                "\nDD6REF," +
                                                "\nDD7REF," +
                                                "\nMECRA_TYPE," +
                                                "\nMECRA," +
                                                "\nMARKETING_COMPANY," +
                                                "\nCUSTOMER," +
                                                "\nPLAN_CODE," +
                                                "\nINTERNET_MAIN_CATEGORY," +
                                                "\nINTERNET_SUB_CATEGORY" +
                                                "\n)" +
                                                "\nVALUES" +
                                                "\n(" +
                                                "\n" + PacketId + "," +
                                                "\n" + item.PayRef + "," +
                                                "\n" + item.FicheRef + "," +
                                                "\n'" + item.FicheNo + "'," +
                                                "\n" + item.ClCardRef + "," +
                                                "\n'" + item.ClDef + "'," +
                                                "\n'" + item.IBAN + "'," +
                                                "\n" + item.Total.ToString().Replace(',', '.') + "," +
                                                "\n" + item.Paid.ToString().Replace(',', '.') + "," +
                                                "\n'" + item.CurCode + "'," +
                                                "\n" + item.ModuleNr + "," +
                                                "\n" + item.TrCode + "," +
                                                "\n'" + item.DoCode + "'," +
                                                "\n '" + item.TrType + "'," +
                                                "\n '" + item.GenExp1 + "'," +
                                                "\n'" + item.ClCode + "'," +
                                                "\n'" + item.EmailAdres + "'," +
                                                "\n'" + item.TaxNr + "'," +
                                                "\n'" + item.TaxOffice + "'," +
                                                "\nCONVERT(datetime, '" + item.DueDate + "', 104)," +
                                                "\nCONVERT(datetime, '" + item.FicheDate + "', 104)," +
                                                "\n" + item.DD1REF + "," +
                                                "\n" + item.DD2REF + "," +
                                                "\n" + item.DD3REF + "," +
                                                "\n" + item.DD4REF + "," +
                                                "\n" + item.DD5REF + "," +
                                                "\n" + item.DD6REF + "," +
                                                "\n" + item.DD7REF + "," +
                                                "\n'" + item.MecraType + "'," +
                                                "\n'" + item.Mecra + "'," +
                                                "\n'" + item.MarketingCompany + "'," +
                                                "\n'" + item.Customer + "'," +
                                                "\n'" + item.PlanCode + "'," +
                                                "\n'" + item.InternetMainCategory + "'," +
                                                "\n'" + item.InternetSubCategory + "'" +
                                                "\n)";
                            komut.ExecuteNonQuery();
                        }
                        MessageBox.Show("Paket başarılı bir şekilde kaydedildi!", "Paket Oluşturma Ekranı");
                        SavePacketFilters(PacketId);
                        this.Hide();
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                    }
                    else if (RightList.Count == 0)
                    {
                        MessageBox.Show("Pakete eklenmiş bir ödeme yoktur!", "UYARI!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message.ToString());
                }
            }
        }

        private string getCurrency(int currencyValue)
        {
            string CurCode = "";
            if(currencyValue !=0)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT CURCODE FROM L_CURRENCYLIST WHERE CURTYPE = '" + currencyValue + "' AND FIRMNR = '" + Helper.FIRMNR + "'";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    dr = komut.ExecuteReader();
                    while (dr.Read())
                    {
                        CurCode = dr["CURCODE"].ToString();
                    }
                }
                return CurCode;
            }
            else
            {
                return "TL";
            }
        }

        /// <summary>
        /// Kaydedilen paketin filtre bilgilerini AYZ_PW_FILTER_VALUES tablosuna daha sonra edit edilebilmesi için kayıt eder.
        /// </summary>
        /// <param name="packetId"></param>
        void SavePacketFilters(int packetId)
        {
            // Yeni Paketin Filtre değerlerini kaydetmek için eski filtre verilerini temizleme işlemi yapılıyor.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "DELETE FROM AYZ_PW_FILTER_VALUES WHERE FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID = " + packetId + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 1. DETAYLI GÖNDERİMDE SEÇİLİ OLAN GÖNDERİM TİPİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZICAM. DETAYLI GÖNDERİNİN TYPE_'ı 0.            
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.DetailSendig) + "','" + detailSendingValue + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "', '" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 2. OLARAK ÖNCE İŞLEM DÖVİZİNDE SEÇİLİ OLAN KUR VARSA ONLARI AYZ_PW_FILTER_VALUES TABLOSUNA YAZICAM. İŞLEM DÖVİZİNİN TYPE_'ı 1.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.Currency) + "','" + currencyValue + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "', '" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 3. OLARAK VADE TARİHLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ExpiryDate) + "', '" + payBegDate.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "', '" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ExpiryDate) + "', '" + payEndDate.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "', '" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 4. OLARAK FATURA TARİHLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.InvoiceDate) + "', '" + invBegDate.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.InvoiceDate) + "', '" + invEndDate.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 5. OLARAK CARİ HESAP TİPİNİ ve DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientCodeType) + "', '" + clientCodeFiltreType + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientCodeBeg) + "', '" + clientCodeBeg + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientCodeEnd) + "', '" + clientCodeEnd + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 6. OLARAK CARİ HESAP ÖZEL KODUNU AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientSpecialCode) + "', '" + clientSpecialCode + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 7. OLARAK CARİ HESAP ÖZEL KODU 2 AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientSpecialCode2) + "', '" + clientSpecialCode2 + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 8. OLARAK VADE TARİHİ GEÇMİŞ OLANLARI GÜNÜN TARİHİ İLE DEĞİŞTİRME DEĞERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID)VALUES('" + Convert.ToInt32(Helper.FilterType.ReplaceDueDateAndTodayDate) + "', '" + replaceDueDateAndTodayDate + "', '5','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 9. OLARAK FİŞ TÜRLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.VoucherType) + "','" + voucherType + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 10. OLARAK MECRA TÜRLERİNİN DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < mecraTypeList.Count; i++)
                {
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.MecraType) + "','" + mecraTypeList[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 11. OLARAK MECRA DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < mecraList.Count; i++)
                {
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.Mecra) + "','" + mecraList[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 12. OLARAK PAZARLAMA ŞİRKETİ DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < marketingCompantList.Count; i++)
                {
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.MarketingCompany) + "','" + marketingCompantList[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 13. OLARAK MÜŞTERİ DEĞERLERİNİN AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < customerList.Count; i++)
                {
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.Customer) + "','" + customerList[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 14. OLARAK PLAN KODU DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < planCodeList.Count; i++)
                {
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.PlanCode) + "','" + planCodeList[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 15. OLARAK INTERNET ANA KATEGORİ DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < internetMainCategory.Count; i++)
                {

                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.InternerMainCategory) + "','" + internetMainCategory[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 16. OLARAK INTERNET ALT KATEGORİ DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < internetSubCategory.Count; i++)
                {
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.InternetSubCategory) + "','" + internetSubCategory[i] + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')"; // USERNR login olan kullanıcının ID'si.
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // 17. OLARAK BRANCH(İŞ YERLERİNİN) DEĞERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR,PACKETID) VALUES('" + Convert.ToInt32(Helper.FilterType.Branch) + "','" + branchValue + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "','" + packetId + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
