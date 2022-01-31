using AyzPaymentWizard.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Windows.Forms;
using SoftGee;

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

        private void BtnRightsel_Click(object sender, EventArgs e)
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
                    debit.GeneralBalance = drv.Cells["GeneralBalance"].Value.ToString();
                    debit.TLBalance = drv.Cells["TLBalance"].Value.ToString();
                    debit.USDBalance = drv.Cells["USDBalance"].Value.ToString();
                    debit.EUROBalance = drv.Cells["EUROBalance"].Value.ToString();
                    debit.GBPBalance = drv.Cells["GBPBalance"].Value.ToString();
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

                    //Adding Selected Left Total to Right and Removing from Left
                    //  decimal sumtobeofPaid = 0.0m;
                    foreach (var sel in select)
                    {
                        txtSumLeftDGV.Text = (Convert.ToDecimal(txtSumLeftDGV.Text) - sel.Total).ToString();
                        txtSumRightDGV.Text = (Convert.ToDecimal(txtSumRightDGV.Text) + sel.Total).ToString();

                        //    sumtobeofPaid += sel.Total;
                        //Getting the Currency Code
                        labelCurR.Text = debit.CurCode.ToString();
                        //odencekR update
                        txtPaidRightDGV.Text = (Convert.ToDecimal(txtPaidRightDGV.Text) + Convert.ToDecimal(sel.Total)).ToString();
                    }

                    //txtPaidRightDGV.Text = (Convert.ToDecimal(txtPaidRightDGV.Text) + sumtobeofPaid).ToString();
                    //Updating the number of Rows
                    txtTotalLeftDGV.Text = (Convert.ToInt32(txtTotalLeftDGV.Text) - select.Count).ToString();
                    txtTotalRightDGV.Text = (Convert.ToInt32(txtTotalRightDGV.Text) + select.Count).ToString();
                }
            }

            var source = new BindingSource();
            source.DataSource = RightList;
            dataGridViewRight.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = LeftList;
            dataGridViewLeft.DataSource = source2;
        }

        private void BtnLeftsel_Click(object sender, EventArgs e)
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
                    debit.GeneralBalance = drv.Cells["GeneralBalance"].Value.ToString();
                    debit.TLBalance = drv.Cells["TLBalance"].Value.ToString();
                    debit.USDBalance = drv.Cells["USDBalance"].Value.ToString();
                    debit.EUROBalance = drv.Cells["EUROBalance"].Value.ToString();
                    debit.GBPBalance = drv.Cells["GBPBalance"].Value.ToString();
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
                    txtTotalRightDGV.Text = (Convert.ToInt32(txtTotalRightDGV.Text) - select.Count).ToString();
                    txtTotalLeftDGV.Text = (Convert.ToInt32(txtTotalLeftDGV.Text) + select.Count).ToString();

                    //Adding Selected Rightt Total to Left and Removing from Right
                    foreach (var sel in select)
                    {

                        txtSumRightDGV.Text = (Convert.ToDecimal(txtSumRightDGV.Text) - sel.Total).ToString();
                        txtSumLeftDGV.Text = (Convert.ToDecimal(txtSumLeftDGV.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurL.Text = debit.CurCode.ToString();

                        //odencekR update
                        txtPaidRightDGV.Text = (Convert.ToDecimal(txtPaidRightDGV.Text) - Convert.ToDecimal(sel.Total)).ToString();
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

        private void DataGridViewLeft_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
                txtSumLeftDGV.Text = CellSum().ToString();
        }

        //Getting The Total Sum of LGRID
        private double CellSum()
        {
            double sum = 0;
            for (int i = 0; i < dataGridViewLeft.Rows.Count; ++i)
            {
                double d;
                Double.TryParse(dataGridViewLeft.Rows[i].Cells[1].Value.ToString(), out d);
                sum += d;
            }
            return sum;
        }

        private void DataGridViewLeft_FilterStringChanged_1(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
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

                //Total Rows in Left Grid after filtering
                txtTotalLeftDGV.Text = LeftList.Count.ToString();
                //Sum in LeftGrid After Filtering//Getting the total value
                decimal sumL = 0.00m;
                for (int i = 0; i < dataGridViewLeft.Rows.Count; ++i)
                {
                    sumL += Convert.ToDecimal(dataGridViewLeft.Rows[i].Cells["Total"].Value);
                }
                txtSumLeftDGV.Text = sumL.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //Odenecek icin DatagridviewRight
        private void DataGridViewRight_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            decimal sumP = 0m;
            for (int counter = 0; counter < dataGridViewRight.Rows.Count; counter++)
            {
                if (dataGridViewRight.Rows[counter].Cells["Paid"].Value != null)
                {
                    // Verify that the cell value is not an empty string.
                    if (dataGridViewRight.Rows[counter]
                        .Cells["Paid"].Value.ToString().Length != 0)
                    {
                        Decimal res = Decimal.Parse(dataGridViewRight.Rows[counter].Cells["Paid"].Value.ToString());
                        Decimal total = Decimal.Parse(dataGridViewRight.Rows[counter].Cells["Total"].Value.ToString());
                        if (res > total || res < 0)
                        {
                            if (res > total)
                            {
                                MessageBox.Show("Borcunuzdan daha fazla ödeme yapamazsınız!. Borcunuzu geçmeyen bir ödeme giriniz.", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sumP = total;
                            }
                            else if (res < 0)
                            {
                                MessageBox.Show("Ödenecek tutar sıfırdan küçük olamaz!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                sumP = total;
                            }

                        }
                        else
                        {
                            sumP += res;
                            txtPaidRightDGV.Text = sumP.ToString();

                        }

                    }
                }
            }

        }

        private void DataGridViewRight_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewTextBoxCell cell = dataGridViewRight[dataGridViewRight.Columns["Paid"].Index, e.RowIndex] as DataGridViewTextBoxCell;

            if (cell != null)
            {
                decimal odenmekIstenen;
                var success = Decimal.TryParse(dataGridViewRight.Rows[e.RowIndex].Cells["Paid"].EditedFormattedValue.ToString(), out odenmekIstenen);
                decimal odenmesigereken;
                Decimal.TryParse(dataGridViewRight.Rows[e.RowIndex].Cells["Total"].Value.ToString(), out odenmesigereken);
                if (success)
                {
                    decimal sifirkontrolu = 0m;
                    if (odenmekIstenen > odenmesigereken || odenmekIstenen <= sifirkontrolu)
                    {
                        if (odenmekIstenen > odenmesigereken)
                        {
                            dataGridViewRight.Rows[e.RowIndex].ErrorText = $"Ödenecek tutar, Ödenmesi gereken'den dafa fazla olamaz!.\nÖdenecek tutarı tekrar giriniz!";
                            e.Cancel = true;
                        }
                        if (odenmekIstenen <= sifirkontrolu)
                        {
                            dataGridViewRight.Rows[e.RowIndex].ErrorText = $"Sıfırdan daha büyük bir değer giriniz!";
                            e.Cancel = true;
                        }


                    }
                    else
                    {
                        e.Cancel = false;
                        dataGridViewRight.Rows[e.RowIndex].Cells["Paid"].Value = String.Format("{0:0,00}", odenmekIstenen.ToString());
                    }

                }
                else if (!success)
                {
                    if (string.IsNullOrEmpty(dataGridViewRight.Rows[e.RowIndex].Cells["Paid"].EditedFormattedValue.ToString()))
                    {
                        dataGridViewRight.Rows[e.RowIndex].ErrorText = $"Boş geçilemez!";
                        e.Cancel = true;
                    }
                }

            }
        }

        private void DataGridViewRight_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dataGridViewRight.CurrentCell.ColumnIndex == dataGridViewRight.Columns["Paid"].Index)
            {
                //DGVRightEdit.Columns["Paid"].
                //extBox textBox = new TextBox();
                if (e.Control is TextBox && e.Control != null)
                {

                    e.Control.KeyPress += delegate (Object Mysender, KeyPressEventArgs kk)
                    {
                        if (!char.IsDigit(kk.KeyChar) && !char.IsControl(kk.KeyChar) && kk.KeyChar != ',')
                        {
                            kk.Handled = true;
                        }
                    };
                }

                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.ContextMenuStrip = new ContextMenuStrip();
                    tb.KeyDown -= TextBox_KeyDown;
                    tb.KeyDown += TextBox_KeyDown;
                }
            }
        }

        void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.C | e.KeyCode == Keys.V) | e.KeyCode == Keys.X | e.KeyCode == Keys.A)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void DataGridViewRight_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Clear the row error in case the user presses ESC.
            dataGridViewRight.Rows[e.RowIndex].ErrorText = String.Empty;
        }


        private void DataGridViewRight_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            decimal sumedup = 0m;

            for (int i = 0; i < dataGridViewRight.Rows.Count; i++)
            {
                sumedup += decimal.Parse(dataGridViewRight.Rows[i].Cells["Paid"].Value.ToString());
            }

            txtPaidRightDGV.Text = sumedup.ToString();
        }



        private void DataGridViewRight_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            decimal sumedup = 0m;

            for (int i = 0; i < dataGridViewRight.Rows.Count; i++)
            {
                sumedup += decimal.Parse(dataGridViewRight.Rows[i].Cells["Paid"].Value.ToString());
            }

            txtPaidRightDGV.Text = sumedup.ToString();
        }


        private void DataGridViewRight_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            decimal sumedup = 0m;

            for (int i = 0; i < dataGridViewRight.Rows.Count; i++)
            {
                sumedup += decimal.Parse(dataGridViewRight.Rows[i].Cells["Paid"].Value.ToString());
            }

            txtPaidRightDGV.Text = sumedup.ToString();
        }



        private void DataGridViewLeft_SortStringChanged_1(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
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
                MessageBox.Show("Hata: \n" + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Button_unloadfilters_Click(object sender, EventArgs e)
        {
            dataGridViewLeft.CleanFilterAndSort();
        }

        private void Package_Load(object sender, EventArgs e)
        {

            var source = new BindingSource();
            FillLeftList();
            source.DataSource = LeftList;
            dataGridViewLeft.DataSource = source;
            //txtPaidRightDGV.Text = "0,00";

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
                string[] gosterilmeyecekodemeL = {
                                            "MecraType" , "Mecra" , "MarketingCompany" , "Customer" , "PlanCode" ,
                                            "InternetMainCategory","InternetSubCategory","DD1REF","DD2REF","DD3REF",
                                            "DD4REF","DD5REF","DD6REF","DD7REF","NotInPayTrans","NotInPayTransFrame"
                                            };
                foreach (var gostermeodeL in gosterilmeyecekodemeL)
                {
                    dataGridViewLeft.Columns[gostermeodeL].Visible = false;
                }
            }
            else if (detailSendingValue == 3) // Değer 3 ise Boyut Satırları Üzerinden ödeme yapılacaktır anlamına gelir.
            {
                //BOYUT HEADER LEFTGRID Dictionary
                var boyutHeaderL = new Dictionary<string, string>()
                {
                  { "MecraType","Mecra Türü"},{ "MarketingCompany","Pazarlama Şirketi"},{"Customer","Müşteri" },{ "PlanCode","Plan Kodu"},{"IBAN","IBAN" },
                  {"InternetMainCategory","İnternet Ana Kategori"}, {"InternetSubCategory","İnternet Alt Kategori" },
                };
                foreach (var boyutheadL in boyutHeaderL)
                {
                    dataGridViewLeft.Columns[boyutheadL.Key].HeaderText = boyutheadL.Value;
                    dataGridViewLeft.Columns[boyutheadL.Key].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                    dataGridViewLeft.Columns[boyutheadL.Key].ReadOnly = true;
                }
            }

            string[] gosterilmeyecekL = { "PayRef", "ClCardRef", "FicheRef", "ModuleNr", "TrCode", "IsPerson", "Branch",
                                           "TrType", "Paid", "GenExp1", "EmailAdres", "TrCode","TrCurr","TaxNr","TaxOffice",
                                           "DD1REF","DD2REF","DD3REF","DD4REF","DD5REF","DD6REF","DD7REF",
                                           "NotInPayTrans","NotInPayTransFrame" };
            foreach (var gostermeL in gosterilmeyecekL)
            {
                dataGridViewLeft.Columns[gostermeL].Visible = false;
            }

            var HeaderL = new Dictionary<string, string>()
            {
                { "DueDate", "Vade Tarihi" }, {"CurCode", "Döviz"}, {"Total","Tutar" }, {"ClCode","Cari Kod" }, {"ClDef","Cari Hesap Tanımı" }, {"IBAN","IBAN" },
                {"FicheDate","Fiş Tarihi"}, {"FicheNo","FicheNo"}, {"DoCode","Belge Numarası"}, { "NotInPayTransFrame","Active" }, { "GeneralBalance","Bakiye" },
                { "TLBalance","TL Bakiye" }, { "USDBalance","USD Bakiye" }, { "EUROBalance","EURO Bakiye" }, { "GBPBalance","GBP Bakiye" }
            };


            foreach (var headL in HeaderL)
            {
                dataGridViewLeft.Columns[headL.Key].HeaderText = headL.Value;
                dataGridViewLeft.Columns[headL.Key].ReadOnly = true;
            }

            string[] Autosized = { "Total", "ClCode", "ClDef", "IBAN", "DoCode", "CurCode" };
            foreach (var auto in Autosized)
            {
                dataGridViewLeft.Columns[auto].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

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


            #endregion

            var source2 = new BindingSource();
            source2.DataSource = RightList;
            dataGridViewRight.DataSource = source2;
            #region Right Grid Kolon Görünüm,Header Text ve Display Index Ayarları

            dataGridViewRight.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            dataGridViewRight.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridViewRight.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Regular);
            dataGridViewRight.EnableHeadersVisualStyles = false;

            //RGridde Gosterilmeyecekleri
            string[] gosterilmeyecekR = { "PayRef", "ClCardRef", "FicheRef", "ModuleNr", "TrCode", "IsPerson", "Branch",
                                           "TrType", "GenExp1", "EmailAdres", "TrCode","TrCurr","TaxNr","TaxOffice",
                                           "DD1REF","DD2REF","DD3REF","DD4REF","DD5REF","DD6REF","DD7REF",
                                           "NotInPayTrans","NotInPayTransFrame" };

            foreach (var gostermeR in gosterilmeyecekR)
            {
                dataGridViewRight.Columns[gostermeR].Visible = false;
            }
            dataGridViewRight.Columns["CurCode"].HeaderText = "Döviz";

            var gosterilecekRHeader = new Dictionary<string, string>()
            {
                { "Paid", "Ödenecek" }, { "Total", "Ödenmesi Gereken" },{ "DueDate", "Vade Tarihi"},{ "ClDef", "Cari Hesap Tanımı" },{"IBAN","IBAN" },
                {"ClCode","Cari Kod" },{"FicheDate","Fiş Tarihi"},{"FicheNo","Fiş Numarası"},{"DoCode","Belge Numarası"},{"MecraType","Mecra Türü"},
                { "MarketingCompany","Pazarlama Şirketi"},{"Customer","Müşteri"},{"PlanCode","Plan Kodu"},{"InternetMainCategory","İnternet Ana Kategori"},
                {"InternetSubCategory","İnternet Alt Kategori" }, { "GeneralBalance","Bakiye" },
                { "TLBalance","TL Bakiye" }, { "USDBalance","USD Bakiye" }, { "EUROBalance","EURO Bakiye" }, { "GBPBalance","GBP Bakiye" } 
            };

            foreach (var gosterRHead in gosterilecekRHeader)
            {
                dataGridViewRight.Columns[gosterRHead.Key].HeaderText = gosterRHead.Value;
                if (dataGridViewRight.Columns[gosterRHead.Key].HeaderText != "Ödenecek")
                {
                    dataGridViewRight.Columns[gosterRHead.Key].ReadOnly = true;
                }

            }
            dataGridViewRight.Columns["Paid"].HeaderCell.Style.BackColor = Color.Red;

            string[] AutosizeR = {
                                   "Total", "ClCode", "ClDef", "IBAN", "DoCode", "CurCode", "MecraType", "Mecra",
                                   "MarketingCompany", "Customer", "PlanCode", "InternetMainCategory","InternetSubCategory" };
            foreach (var autoR in AutosizeR)
            {
                dataGridViewRight.Columns[autoR].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }

            //MiddleCenter Align  alligned for Right Grid
            Dictionary<string, DataGridView> RGCentered = new Dictionary<string, DataGridView>();
            DataGridView dgr = dataGridViewRight;
            string[] strRight = { "Paid", "CurCode" };
            foreach (var str in strRight)
            {
                RGCentered.Add(str, dgr);
                foreach (var ab in RGCentered)
                {
                    ab.Value.Columns[ab.Key].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }



            if (detailSendingValue == 2) // Ödeme Satırları Üzerinden
            {
                string[] gosterilmeyecekodeme = {
                                            "MecraType" , "Mecra" , "MarketingCompany" , "Customer" , "PlanCode" ,
                                            "InternetMainCategory","InternetSubCategory","DD1REF","DD2REF","DD3REF",
                                            "DD4REF","DD5REF","DD6REF","DD7REF","NotInPayTrans","NotInPayTransFrame"
                                            };

                foreach (var gostermeode in gosterilmeyecekodeme)
                {
                    dataGridViewRight.Columns[gostermeode].Visible = false;
                }

            }
            #endregion

            //Getting the total columns in 
            txtTotalLeftDGV.Text = dataGridViewLeft.Rows.Count.ToString();

            txtTotalRightDGV.Text = "0";

            //Getting the total value
            decimal sumL = 0.00m;
            for (int i = 0; i < dataGridViewLeft.Rows.Count; ++i)
            {
                sumL += Convert.ToDecimal(dataGridViewLeft.Rows[i].Cells["Total"].Value);
                //Getting Currency Code for Left Grid
                labelCurL.Text = dataGridViewLeft.Rows[i].Cells["CurCode"].Value.ToString();
            }
            txtSumLeftDGV.Text = sumL.ToString();

            //Getting the total columns in RGRID

            decimal sumR = 0.00m;
            for (int i = 0; i < dataGridViewRight.Rows.Count; ++i)
            {
                sumR += Convert.ToDecimal(dataGridViewRight.Rows[i].Cells["Total"].Value);
            }
            txtSumRightDGV.Text = sumR.ToString();


            ////Getting the total columns for the Paid in PacketPreparation Right
            decimal sumPaidR = 0.00m;
            for (int i = 0; i < dataGridViewRight.Rows.Count; ++i)
            {
                sumPaidR += Convert.ToDecimal(dataGridViewRight.Rows[i].Cells["Paid"].Value);
            }
            txtPaidRightDGV.Text = sumPaidR.ToString();

        }


        void FillLeftList()
        {
            try
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
                                    if (debit.IsPerson == 0)
                                        debit.IsPerson = 0;
                                    else
                                        debit.IsPerson = Convert.ToInt32(dr["ISPERSON"].ToString());
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

                                    #region Genel Bakiye
                                    debit.GeneralBalance = dr["YPB_BAK"].ToString();
                                    if (Convert.ToDecimal(debit.GeneralBalance) < 0)
                                    {
                                        debit.GeneralBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.GeneralBalance), 2).ToString());
                                        debit.GeneralBalance = debit.GeneralBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDecimal(debit.GeneralBalance) > 0)
                                        debit.GeneralBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.GeneralBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region TL Bakiye
                                    debit.TLBalance = dr["TL_BAK"].ToString();
                                    if (Convert.ToDecimal(debit.TLBalance) < 0)
                                    {
                                        debit.TLBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.TLBalance), 2).ToString());
                                        debit.TLBalance = debit.TLBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDecimal(debit.TLBalance) > 0)
                                        debit.TLBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.TLBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region USD Bakiye
                                    debit.USDBalance = Convert.ToDouble(dr["USD_BAK"]).ToString();
                                    if (Convert.ToDouble(debit.USDBalance) < 0)
                                    {
                                        debit.USDBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.USDBalance), 2).ToString());
                                        debit.USDBalance = debit.USDBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDouble(debit.USDBalance) > 0)
                                        debit.USDBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.USDBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region EURO Bakiye
                                    debit.EUROBalance = Convert.ToDouble(dr["EUR_BAK"]).ToString();
                                    if (Convert.ToDouble(debit.EUROBalance) < 0)
                                    {
                                        debit.EUROBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.EUROBalance), 2).ToString());
                                        debit.EUROBalance = debit.EUROBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDouble(debit.EUROBalance) > 0)
                                        debit.EUROBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.EUROBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region GBP Bakiye
                                    debit.GBPBalance = Convert.ToDouble(dr["GBP_BAK"]).ToString();
                                    if (Convert.ToDouble(debit.GBPBalance) < 0)
                                    {
                                        debit.GBPBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.GBPBalance), 2).ToString());
                                        debit.GBPBalance = debit.GBPBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDouble(debit.GBPBalance) > 0)
                                        debit.GBPBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.GBPBalance), 2).ToString()) + " (B)";
                                    #endregion

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
                                    if (debit.IsPerson == 0)
                                        debit.IsPerson = 0;
                                    else
                                        debit.IsPerson = Convert.ToInt32(dr["ISPERSON"].ToString());
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

                                    #region Genel Bakiye
                                    debit.GeneralBalance = dr["YPB_BAK"].ToString();
                                    if (Convert.ToDecimal(debit.GeneralBalance) < 0)
                                    {
                                        debit.GeneralBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.GeneralBalance), 2).ToString());
                                        debit.GeneralBalance = debit.GeneralBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDecimal(debit.GeneralBalance) > 0)
                                        debit.GeneralBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.GeneralBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region TL Bakiye
                                    debit.TLBalance = dr["TL_BAK"].ToString();
                                    if (Convert.ToDecimal(debit.TLBalance) < 0)
                                    {
                                        debit.TLBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.TLBalance), 2).ToString());
                                        debit.TLBalance = debit.TLBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDecimal(debit.TLBalance) > 0)
                                        debit.TLBalance = String.Format("{0:C}", Math.Round(decimal.Parse(debit.TLBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region USD Bakiye
                                    debit.USDBalance = Convert.ToDouble(dr["USD_BAK"]).ToString();
                                    if (Convert.ToDouble(debit.USDBalance) < 0)
                                    {
                                        debit.USDBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.USDBalance), 2).ToString());
                                        debit.USDBalance = debit.USDBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDouble(debit.USDBalance) > 0)
                                        debit.USDBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.USDBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region EURO Bakiye
                                    debit.EUROBalance = Convert.ToDouble(dr["EUR_BAK"]).ToString();
                                    if (Convert.ToDouble(debit.EUROBalance) < 0)
                                    {
                                        debit.EUROBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.EUROBalance), 2).ToString());
                                        debit.EUROBalance = debit.EUROBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDouble(debit.EUROBalance) > 0)
                                        debit.EUROBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.EUROBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    #region GBP Bakiye
                                    debit.GBPBalance = Convert.ToDouble(dr["GBP_BAK"]).ToString();
                                    if (Convert.ToDouble(debit.GBPBalance) < 0)
                                    {
                                        debit.GBPBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.GBPBalance), 2).ToString());
                                        debit.GBPBalance = debit.GBPBalance.Replace("-", "") + " (A)";
                                    }
                                    else if (Convert.ToDouble(debit.GBPBalance) > 0)
                                        debit.GBPBalance = String.Format("{0:C}", Math.Round(double.Parse(debit.GBPBalance), 2).ToString()) + " (B)";
                                    #endregion

                                    LeftList.Add(debit);
                                }
                            }
                            conn.Close();
                        }
                    }
                }

                #region Daha önce oluşturulan paket satırlarının sol gride gelmesini engelleyen kod bloğu           
                using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
                {
                    CommandText = "SELECT PD.* FROM  AYZ_PW_PACKET_DETAIL AS PD  " +
                                  "\nINNER JOIN AYZ_PW_PACKET AS P ON P.ID = PD.PACKETID " +
                                  "\nWHERE P.STATUS NOT IN(" + (int)Helper.PacketStatus.Rejected + ")"; // reddedilen statüdeki paketler hariç tüm paketleri getir
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
            catch (Exception ex)
            {
                MessageBox.Show("Hata:\n", ex.Message);
            }

        }

        private void BtnRight_Click(object sender, EventArgs e)
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
                    debit.GeneralBalance = drv.Cells["GeneralBalance"].Value.ToString();
                    debit.TLBalance = drv.Cells["TLBalance"].Value.ToString();
                    debit.USDBalance = drv.Cells["USDBalance"].Value.ToString();
                    debit.EUROBalance = drv.Cells["EUROBalance"].Value.ToString();
                    debit.GBPBalance = drv.Cells["GBPBalance"].Value.ToString();
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
                        string[] strboyutlular = { "MecraType" , "Mecra" , "MarketingCompany" , "Customer" , "PlanCode" ,
                                            "InternetMainCategory","InternetSubCategory"};
                        foreach (var strboyut in strboyutlular)
                        {
                            debit.MecraType = drv.Cells[strboyut].Value.ToString();
                        }
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
                    txtTotalLeftDGV.Text = (Convert.ToInt32(txtTotalLeftDGV.Text) - select.Count).ToString();
                    txtTotalRightDGV.Text = (Convert.ToInt32(txtTotalRightDGV.Text) + select.Count).ToString();

                    //Adding Selected Left Total to Right and Removing from Left
                    foreach (var sel in select)
                    {
                        txtSumLeftDGV.Text = (Convert.ToDecimal(txtSumLeftDGV.Text) - sel.Total).ToString();
                        txtSumRightDGV.Text = (Convert.ToDecimal(txtSumRightDGV.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurR.Text = debit.CurCode.ToString();
                        //odencekR update
                        txtPaidRightDGV.Text = (Convert.ToDecimal(txtPaidRightDGV.Text) + Convert.ToDecimal(sel.Total)).ToString();

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

        private void BtnLeft_Click(object sender, EventArgs e)
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
                    debit.GeneralBalance = drv.Cells["GeneralBalance"].Value.ToString();
                    debit.TLBalance = drv.Cells["TLBalance"].Value.ToString();
                    debit.USDBalance = drv.Cells["USDBalance"].Value.ToString();
                    debit.EUROBalance = drv.Cells["EUROBalance"].Value.ToString();
                    debit.GBPBalance = drv.Cells["GBPBalance"].Value.ToString();
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
                    txtTotalRightDGV.Text = (Convert.ToInt32(txtTotalRightDGV.Text) - select.Count).ToString();
                    txtTotalLeftDGV.Text = (Convert.ToInt32(txtTotalLeftDGV.Text) + select.Count).ToString();

                    //Adding Selected Rightt Total to Left and Removing from Right
                    foreach (var sel in select)
                    {

                        txtSumRightDGV.Text = (Convert.ToDecimal(txtSumRightDGV.Text) - sel.Total).ToString();
                        txtSumLeftDGV.Text = (Convert.ToDecimal(txtSumLeftDGV.Text) + sel.Total).ToString();
                        //Getting the Currency Code
                        labelCurL.Text = debit.CurCode.ToString();
                        //odencekR update
                        txtPaidRightDGV.Text = (Convert.ToDecimal(txtPaidRightDGV.Text) - Convert.ToDecimal(sel.Paid)).ToString();

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

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            var source = new BindingSource();
            source.DataSource = FilteredList;
            dataGridViewLeft.DataSource = source;

            LeftList = FilteredList;
        }

        private void BtnCreatePackage_Click(object sender, EventArgs e)
        {
            decimal sumRequire = RightList.Sum(x => x.Total);                                      // Ödenmesi Gereken
            decimal sumPaid = RightList.Sum(x => x.Paid);                                          // Ödenecek Tutar        
            int? bankOutAccID = (int?)cmbOutAccountInfo.SelectedValue;
            //string bankAccountNo = "";
            string bankCode = "";
            //string kurusAccount = "";
            string bankName = "";
            int bankref = 0;
            string tigerBankAccountCode = "";

            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    if (RightList.Count > 0 && bankOutAccID != null)
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
                                    "\n '" + txtPacketExp.Text.Replace("'", "''") + "'," +
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
                                    "\n '" + GetCurrency(currencyValue) + "', " +
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
                                                "\nINTERNET_SUB_CATEGORY," +
                                                "\nYPB_BAK," +
                                                "\nTL_BAK," +
                                                "\nUSD_BAK," +
                                                "\nEUR_BAK," +
                                                "\nGBP_BAK" +
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
                                                "\n'" + item.InternetSubCategory + "'," +
                                                "\n'" + item.GeneralBalance + "'," +
                                                "\n'" + item.TLBalance + "'," +
                                                "\n'" + item.USDBalance + "'," +
                                                "\n'" + item.EUROBalance + "'," +
                                                "\n'" + item.GBPBalance + "'" +
                                                "\n)";
                            komut.ExecuteNonQuery();
                        }
                        MessageBox.Show("Paket başarılı bir şekilde kaydedildi!", "Paket Oluşturma Ekranı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SavePacketFilters(PacketId);
                        Helper.PacketHistorySave(PacketId, "Yeni Paket", "Paket Oluşturuldu.");
                        this.Hide();
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                    }
                    else if (RightList.Count == 0)
                    {
                        MessageBox.Show("Pakete eklenmiş bir ödeme yoktur!", "UYARI!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (bankOutAccID == null)
                    {
                        MessageBox.Show("Banka Çıkış Hesabını Seçiniz!", "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Mesaj", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private string GetCurrency(int currencyValue)
        {
            string CurCode = "";
            if (currencyValue != 0)
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
