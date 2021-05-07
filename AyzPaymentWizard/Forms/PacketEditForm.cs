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
using System.Linq.Dynamic;
using System.Reflection;
using System.Runtime.Serialization;

namespace AyzPaymentWizard.Forms
{
    public partial class PacketEditForm : Form
    {
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        int PacketId;
        bool Review = false;

        List<Debit> PacketEditsLeftList = new List<Debit>();
        List<Debit> PacketEditsRightList = new List<Debit>();
        List<Debit> PacketDetailList = new List<Debit>();
        List<Debit> FilteredList = new List<Debit>();

        public PacketEditForm()
        {
            InitializeComponent();
        }
        public PacketEditForm(int packetId, bool review)
        {
            PacketId = packetId;
            Review = review;
            InitializeComponent();
        }

        #region Her Pakete Özel, Ön Filtre Değerlerini Tutan Değişkenler       
        int detailSendingValue = -1, branchValue = -1, voucherType = -1, currencyValue = -1, clientCodeFiltreType = -1;
        List<DateTime> expiryDateList = new List<DateTime>(); List<DateTime> invoiceDateList = new List<DateTime>();
        string clientSpecialCode = "", clientSpecialCode2 = "", clientCodeBeg = "", clientCodeEnd = ""; bool replaceDueDateAndTodayDate;
        List<int> mecraTypeList = new List<int>(); List<int> mecraList = new List<int>();
        List<int> marketingCompantList = new List<int>();
        List<int> customerList = new List<int>();
        List<int> planCodeList = new List<int>(); List<int> internetMainCategory = new List<int>();
        List<int> internetSubCategory = new List<int>();
        DateTime payBegDate, payEndDate, invBegDate, invEndDate;
        #endregion                         

        private void btnPLeft_Click(object sender, EventArgs e)
        {
            for (int i = DGVLeftEdit.Rows.Count - 1; i >= 0; i--)
            {
                
                DataGridViewRow drv = DGVLeftEdit.Rows[i];
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
                    debit.NotInPayTrans = Helper.NotInPayTrans(debit.PayRef);
                    if (debit.NotInPayTrans == false)
                        debit.NotInPayTransFrame = "DELETED";
                    else if (debit.NotInPayTrans)
                        debit.NotInPayTransFrame = "MEVCUT";
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
                    PacketEditsRightList.Add(debit);
                    var select = PacketEditsLeftList.Where(x => x.PayRef == debit.PayRef).ToList();
                    PacketEditsLeftList.Remove(select[0]);
                }
            }

            var source = new BindingSource();
            source.DataSource = PacketEditsRightList;
            DGVRightEdit.DataSource = source;


            var source2 = new BindingSource();
            source2.DataSource = PacketEditsLeftList;
            DGVLeftEdit.DataSource = source2;
        }

        private void btnPRight_Click(object sender, EventArgs e)
        {
            for (int i = DGVRightEdit.Rows.Count - 1; i >= 0; i--)
            {
                
                DataGridViewRow drv = DGVRightEdit.Rows[i];
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
                    debit.NotInPayTrans = Helper.NotInPayTrans(debit.PayRef);
                    if (debit.NotInPayTrans == false)
                        debit.NotInPayTransFrame = "DELETED";
                    else if (debit.NotInPayTrans)
                        debit.NotInPayTransFrame = "MEVCUT";
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
                    PacketEditsLeftList.Add(debit);
                    var select = PacketEditsRightList.Where(x => x.PayRef == debit.PayRef).ToList();
                    PacketEditsRightList.Remove(select[0]);

                }
            }

            var source = new BindingSource();
            source.DataSource = PacketEditsRightList;
            DGVRightEdit.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = PacketEditsLeftList;
            DGVLeftEdit.DataSource = source2;
        }

        private void DGVLeftEdit_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DGVLeftEdit.SortString) == true)
                    return;

                var sortStr = DGVLeftEdit.SortString.Replace("[", "").Replace("]", "");

                if (string.IsNullOrEmpty(DGVLeftEdit.FilterString) == true)
                {
                    // the grid is not filtered!
                    PacketEditsLeftList = PacketEditsLeftList.OrderBy(sortStr).ToList();
                    DGVLeftEdit.DataSource = PacketEditsLeftList;
                }
                else
                {
                    // the grid is filtered!
                    PacketEditsLeftList = PacketEditsLeftList.OrderBy(sortStr).ToList();
                    DGVLeftEdit.DataSource = PacketEditsLeftList;
                }

                //textBox_sort.Text = sortStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
        }

        private void DGVLeftEdit_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DGVLeftEdit.FilterString))
                {
                    PacketEditsLeftList.Clear();
                    var source = new BindingSource();
                    FillLeftList();
                    source.DataSource = PacketEditsLeftList;
                    DGVLeftEdit.DataSource = source;
                }
                else
                {
                    IEnumerable<Debit> enumerable = PacketEditsLeftList.AsEnumerable();
                    PacketEditsLeftList = FilterAndSortDataStr(enumerable, DGVLeftEdit.FilterString, DGVLeftEdit.SortString);
                }
                DGVLeftEdit.DataSource = PacketEditsLeftList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: \n" + ex.Message);
            }
            //try
            //{
            //    if (string.IsNullOrEmpty(DGVLeftEdit.FilterString) == true)
            //    {
            //        PacketEditsLeftList.Clear();
            //        var source = new BindingSource();
            //        FillLeftList();
            //        source.DataSource = PacketEditsLeftList;
            //        DGVLeftEdit.DataSource = source;
            //    }
            //    else
            //    {
            //        var listfilter = FilterStringConverter(DGVLeftEdit.FilterString);

            //        PacketEditsLeftList = PacketEditsLeftList.Where(listfilter).ToList();

            //        DGVLeftEdit.DataSource = PacketEditsLeftList;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Hata: \n" + ex.Message);
            //}
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

        //private string FilterStringConverter(string filter)
        //{
        //    string newColFilter = "";

        //    filter = filter.Replace("(", "").Replace(")", "");

        //    var colFilterList = filter.Split(new string[] { "AND" }, StringSplitOptions.None);

        //    string andOperator = "";

        //    foreach (var colFilter in colFilterList)
        //    {
        //        newColFilter += andOperator;

        //        var colName = "";

        //        // Step 1: BOOLEAN Check 
        //        if (colFilter.Contains(" IN ") == false && colFilter.Split('=').Length == 2)
        //        {
        //            // if the filter string is in the form "ColumnName=value". example = "(InAlarm != null && (InAlarm == true))";
        //            colName = colFilter.Split('=')[0];
        //            var booleanVal = colFilter.Split('=')[1];

        //            newColFilter += $"({colName} != null && ({colName} == {booleanVal}))";

        //            continue;
        //        }

        //        // Step 2: NUMBER (int/decimal/double/etc) and STRING Check
        //        if (colFilter.Contains(" IN ") == true)
        //        {
        //            var temp1 = colFilter.Trim().Split(new string[] { "IN" }, StringSplitOptions.None);

        //            colName = GetStringBetweenChars(temp1[0], '[', ']');

        //            var filterValsList = temp1[1].Split(',');

        //            newColFilter += string.Format("({0} != null && (", colName);

        //            string orOperator = "";

        //            foreach (var filterVal in filterValsList)
        //            {
        //                double tempNum = 0;
        //                if (Double.TryParse(filterVal, out tempNum))
        //                    newColFilter += string.Format("{0} {1} = {2}", orOperator, colName, filterVal.Trim());
        //                else
        //                    newColFilter += string.Format("{0} {1}.Contains({2})", orOperator, colName, filterVal.Trim());

        //                orOperator = " OR ";
        //            }

        //            newColFilter += "))";
        //        }

        //        // Step 3: DATETIME Check
        //        if (colFilter.Contains(" LIKE ") == true && colFilter.Contains("Convert[") == true)
        //        {
        //            // first of all remove the cast
        //            var colFilterNoCast = colFilter.Replace("Convert", "").Replace(", 'System.String'", "");

        //            var filterValsList = colFilterNoCast.Trim().Split(new string[] { "OR" }, StringSplitOptions.None);

        //            colName = GetStringBetweenChars(filterValsList[0], '[', ']');

        //            newColFilter += string.Format("({0} != null && (", colName);

        //            string orOperator = "";

        //            foreach (var filterVal in filterValsList)
        //            {
        //                var v = GetStringBetweenChars(filterVal, '%', '%');

        //                newColFilter += string.Format("{0} {1}.Date = DateTime.Parse('{2}')", orOperator, colName, v.Trim());

        //                orOperator = " OR ";
        //            }

        //            newColFilter += "))";
        //        }

        //        andOperator = " AND ";
        //    }

        //    return newColFilter.Replace("'", "\"");
        //}

        //private string GetStringBetweenChars(string input, char startChar, char endChar)
        //{
        //    string output = input.Split(startChar, endChar)[1];
        //    return output;
        //}

        private void PacketEditForm_Load(object sender, EventArgs e)
        {
            FillLeftList();

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

                cmbOutAccountInfoEdit.DataSource = tbl;
                cmbOutAccountInfoEdit.DisplayMember = "TITLE";
                cmbOutAccountInfoEdit.ValueMember = "ID";
            }

            if (Review == true)
            {
                btnRightPacketEdit.Enabled = false;
                btnLeftPacketEdit.Enabled = false;
                btnEditPacket.Enabled = false;
                txtPacketEditExp.Enabled = false;
                cmbOutAccountInfoEdit.Enabled = false;
            }

            #region Packet Edit Left Gridinin Kolon Görünüm,Header Text ve Display Index Ayarları
            DGVLeftEdit.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            DGVLeftEdit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVLeftEdit.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Regular);
            DGVLeftEdit.EnableHeadersVisualStyles = false;

            if (detailSendingValue == 2) // Değer 2 ise Ödeme Satırları Üzerinden ödeme yapılacaktır anlamına gelir. Bu yüzden boyut kolonlarını göstermicem.
            {
                DGVLeftEdit.Columns["MecraType"].Visible = false;
                DGVLeftEdit.Columns["Mecra"].Visible = false;
                DGVLeftEdit.Columns["MarketingCompany"].Visible = false;
                DGVLeftEdit.Columns["Customer"].Visible = false;
                DGVLeftEdit.Columns["PlanCode"].Visible = false;
                DGVLeftEdit.Columns["InternetMainCategory"].Visible = false;
                DGVLeftEdit.Columns["InternetSubCategory"].Visible = false;
                DGVLeftEdit.Columns["DD1REF"].Visible = false;
                DGVLeftEdit.Columns["DD2REF"].Visible = false;
                DGVLeftEdit.Columns["DD3REF"].Visible = false;
                DGVLeftEdit.Columns["DD4REF"].Visible = false;
                DGVLeftEdit.Columns["DD5REF"].Visible = false;
                DGVLeftEdit.Columns["DD6REF"].Visible = false;
                DGVLeftEdit.Columns["DD7REF"].Visible = false;
                DGVLeftEdit.Columns["NotInPayTrans"].Visible = false;
                DGVLeftEdit.Columns["NotInPayTransFrame"].Visible = false;
            }
            else if (detailSendingValue == 3) // Değer 3 ise Boyut Satırları Üzerinden ödeme yapılacaktır anlamına gelir.
            {
                DGVLeftEdit.Columns["MecraType"].HeaderText = "Mecra Türü";
                DGVLeftEdit.Columns["MarketingCompany"].HeaderText = "Pazarlama Şirketi";
                DGVLeftEdit.Columns["Customer"].HeaderText = "Müşteri";
                DGVLeftEdit.Columns["PlanCode"].HeaderText = "Plan Kodu";
                DGVLeftEdit.Columns["InternetMainCategory"].HeaderText = "İnternet Ana Kategori";
                DGVLeftEdit.Columns["InternetSubCategory"].HeaderText = "İnternet Alt Kategori";
                DGVLeftEdit.Columns["MecraType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGVLeftEdit.Columns["Mecra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGVLeftEdit.Columns["MarketingCompany"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGVLeftEdit.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGVLeftEdit.Columns["PlanCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGVLeftEdit.Columns["InternetMainCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                DGVLeftEdit.Columns["InternetSubCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
            DGVLeftEdit.Columns["PayRef"].Visible = false;
            DGVLeftEdit.Columns["ClCardRef"].Visible = false;
            DGVLeftEdit.Columns["FicheRef"].Visible = false;
            DGVLeftEdit.Columns["ModuleNr"].Visible = false;
            DGVLeftEdit.Columns["TrCode"].Visible = false;
            DGVLeftEdit.Columns["IsPerson"].Visible = false;
            DGVLeftEdit.Columns["Branch"].Visible = false;
            DGVLeftEdit.Columns["TrType"].Visible = false;
            DGVLeftEdit.Columns["Paid"].Visible = false;
            DGVLeftEdit.Columns["GenExp1"].Visible = false;
            DGVLeftEdit.Columns["EmailAdres"].Visible = false;
            DGVLeftEdit.Columns["TrCode"].Visible = false;
            DGVLeftEdit.Columns["TrCurr"].Visible = false;
            DGVLeftEdit.Columns["TaxNr"].Visible = false;
            DGVLeftEdit.Columns["TaxOffice"].Visible = false;
            DGVLeftEdit.Columns["DD1REF"].Visible = false;
            DGVLeftEdit.Columns["DD2REF"].Visible = false;
            DGVLeftEdit.Columns["DD3REF"].Visible = false;
            DGVLeftEdit.Columns["DD4REF"].Visible = false;
            DGVLeftEdit.Columns["DD5REF"].Visible = false;
            DGVLeftEdit.Columns["DD6REF"].Visible = false;
            DGVLeftEdit.Columns["DD7REF"].Visible = false;
            DGVLeftEdit.Columns["NotInPayTrans"].Visible = false;
            DGVLeftEdit.Columns["NotInPayTransFrame"].Visible = false;
            DGVLeftEdit.Columns["DueDate"].HeaderText = "Vade Tarihi";
            DGVLeftEdit.Columns["CurCode"].HeaderText = "Döviz";
            DGVLeftEdit.Columns["Total"].HeaderText = "Tutar";
            DGVLeftEdit.Columns["ClCode"].HeaderText = "Cari Kod";
            DGVLeftEdit.Columns["ClDef"].HeaderText = "Cari Hesap Tanımı";
            DGVLeftEdit.Columns["FicheDate"].HeaderText = "Fiş Tarihi";
            DGVLeftEdit.Columns["FicheNo"].HeaderText = "Fiş Numarası";
            DGVLeftEdit.Columns["DoCode"].HeaderText = "Belge Numarası";
            DGVLeftEdit.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVLeftEdit.Columns["ClCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVLeftEdit.Columns["ClDef"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVLeftEdit.Columns["IBAN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVLeftEdit.Columns["DoCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVLeftEdit.Columns["CurCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVLeftEdit.Columns["FicheDate"].Width = 75;
            DGVLeftEdit.Columns["FicheNo"].Width = 90;

            //Middle Center Alignment of DGVLEFTEDIT
            Dictionary<string, DataGridView> LGCenteredEd = new Dictionary<string, DataGridView>();
            DataGridView dgl = DGVLeftEdit;
            string[] strLeft = { "CurCode", "Total" };
            foreach (var str in strLeft)
            {
                LGCenteredEd.Add(str, dgl);
                foreach (var LC in LGCenteredEd)
                {
                    LC.Value.Columns[LC.Key].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            //form.DGVLeftEdit.Columns["CurCode"].DisplayIndex = 1; HANGİ COLUMNDA Göstermek istersek bu şekilde yapabiliriz.
            #endregion

            #region Packet Edit Right Grid Kolon Görünüm,Header Text ve Display Index Ayarları

            DGVRightEdit.ColumnHeadersDefaultCellStyle.BackColor = Color.DarkGray;
            DGVRightEdit.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            DGVRightEdit.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9.75F, FontStyle.Regular);
            DGVRightEdit.EnableHeadersVisualStyles = false;

            DGVRightEdit.Columns["NotInPayTrans"].ValueType = typeof(string);
            DGVRightEdit.Columns["PayRef"].Visible = false;
            DGVRightEdit.Columns["ClCardRef"].Visible = false;
            DGVRightEdit.Columns["FicheRef"].Visible = false;
            DGVRightEdit.Columns["ModuleNr"].Visible = false;
            DGVRightEdit.Columns["TrCode"].Visible = false;
            DGVRightEdit.Columns["GenExp1"].Visible = false;
            DGVRightEdit.Columns["TrType"].Visible = false;            
            DGVRightEdit.Columns["EmailAdres"].Visible = false;
            DGVRightEdit.Columns["IsPerson"].Visible = false;
            DGVRightEdit.Columns["CurCode"].HeaderText = "Döviz";
            DGVRightEdit.Columns["Branch"].Visible = false;
            DGVRightEdit.Columns["TaxNr"].Visible = false;
            DGVRightEdit.Columns["TaxOffice"].Visible = false;
            DGVRightEdit.Columns["TrCurr"].Visible = false;
            DGVRightEdit.Columns["DD1REF"].Visible = false;
            DGVRightEdit.Columns["DD2REF"].Visible = false;
            DGVRightEdit.Columns["DD3REF"].Visible = false;
            DGVRightEdit.Columns["DD4REF"].Visible = false;
            DGVRightEdit.Columns["DD5REF"].Visible = false;
            DGVRightEdit.Columns["DD6REF"].Visible = false;
            DGVRightEdit.Columns["DD7REF"].Visible = false;
            DGVRightEdit.Columns["NotInPayTrans"].Visible = false;
            DGVRightEdit.Columns["Paid"].HeaderText = "Ödenecek";
            DGVRightEdit.Columns["Paid"].HeaderCell.Style.BackColor = Color.Red;
            DGVRightEdit.Columns["Total"].HeaderText = "Ödenmesi Gereken";
            DGVRightEdit.Columns["DueDate"].HeaderText = "Vade Tarihi";
            DGVRightEdit.Columns["ClDef"].HeaderText = "Cari Hesap Tanımı";
            DGVRightEdit.Columns["ClCode"].HeaderText = "Cari Kod";
            DGVRightEdit.Columns["FicheDate"].HeaderText = "Fiş Tarihi";
            DGVRightEdit.Columns["FicheNo"].HeaderText = "Fiş Numarası";
            DGVRightEdit.Columns["DoCode"].HeaderText = "Belge Numarası";
            DGVRightEdit.Columns["MecraType"].HeaderText = "Mecra Türü";
            DGVRightEdit.Columns["MarketingCompany"].HeaderText = "Pazarlama Şirketi";
            DGVRightEdit.Columns["Customer"].HeaderText = "Müşteri";
            DGVRightEdit.Columns["PlanCode"].HeaderText = "Plan Kodu";
            DGVRightEdit.Columns["InternetMainCategory"].HeaderText = "İnternet Ana Kategori";
            DGVRightEdit.Columns["InternetSubCategory"].HeaderText = "İnternet Alt Kategori";
            DGVRightEdit.Columns["NotInPayTransFrame"].HeaderText = "Active";

            DGVRightEdit.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["ClCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["ClDef"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["IBAN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["DoCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["CurCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["MecraType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["Mecra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["MarketingCompany"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["Customer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["PlanCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["InternetMainCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            DGVRightEdit.Columns["InternetSubCategory"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            // Center Align of Columns of RGCenteredEd
            Dictionary<string, DataGridView> RGCenteredEd = new Dictionary<string, DataGridView>();
            DataGridView dgr = DGVRightEdit;
            string[] strRight = { "CUrCode", "Paid" };
            foreach (var str in strRight)
            {
                RGCenteredEd.Add(str, dgr);
                foreach (var LC in RGCenteredEd)
                {
                    LC.Value.Columns[LC.Key].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }

            if (detailSendingValue == 2) // Ödeme Satırları Üzerinden
            {
                DGVRightEdit.Columns["MecraType"].Visible = false;
                DGVRightEdit.Columns["Mecra"].Visible = false;
                DGVRightEdit.Columns["MarketingCompany"].Visible = false;
                DGVRightEdit.Columns["Customer"].Visible = false;
                DGVRightEdit.Columns["PlanCode"].Visible = false;
                DGVRightEdit.Columns["InternetMainCategory"].Visible = false;
                DGVRightEdit.Columns["InternetSubCategory"].Visible = false;
                DGVRightEdit.Columns["DD1REF"].Visible = false;
                DGVRightEdit.Columns["DD2REF"].Visible = false;
                DGVRightEdit.Columns["DD3REF"].Visible = false;
                DGVRightEdit.Columns["DD4REF"].Visible = false;
                DGVRightEdit.Columns["DD5REF"].Visible = false;
                DGVRightEdit.Columns["DD6REF"].Visible = false;
                DGVRightEdit.Columns["DD7REF"].Visible = false;
                DGVRightEdit.Columns["NotInPayTrans"].Visible = false;
            }
            #endregion
        }

        void FillLeftList()
        {
            #region Paket filtre değerlerini AYZ_PW_FILTER_VALUES'dan alma
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    CommandText = "SELECT * FROM AYZ_PW_FILTER_VALUES WHERE USERNR = " + Helper.USERID + " AND FIRMNR = " + Helper.FIRMNR + " AND PACKETID = " + PacketId + "";
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
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Hata: " + ex.Message.ToString());
                }

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
            #endregion

            #region Düzenlenecek Paketin Sol Grid İçin Ödeme Listesini Getiren İşlemler
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                if (detailSendingValue == 2)
                {
                    using (SqlCommand cmd = new SqlCommand("AYZ_SP_PW_PAYTRANS", conn))
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
                                PacketEditsLeftList.Add(debit);
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
                                PacketEditsLeftList.Add(debit);
                            }
                        }
                        conn.Close();
                    }
                }
            }
            #endregion

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
                var select = PacketEditsLeftList.Where(x => x.PayRef == item.PayRef).ToList();
                if (select.Count > 0)
                    PacketEditsLeftList.Remove(select[0]);
            }
            #endregion

            #region PACKETEDIT Formunun Sol Gridin içinin doldurulması            
            var source = new BindingSource();
            source.DataSource = PacketEditsLeftList;
            DGVLeftEdit.DataSource = source.DataSource;
            #endregion

            #region PACKETEDIT Formunun Sağ Gridinin içinin Doldurulması
            PacketEditsRightList.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT * FROM AYZ_PW_PACKET_DETAIL WHERE PACKETID = " + PacketId + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                if (detailSendingValue == 2)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Debit debit = new Debit();
                            debit.PayRef = Convert.ToInt32(dr["PAYTRANSREF"].ToString());
                            debit.ClCardRef = Convert.ToInt32(dr["CLIENTREF"].ToString());
                            debit.FicheRef = Convert.ToInt32(dr["FICHEREF"].ToString());
                            debit.ModuleNr = Convert.ToInt32(dr["MODULENR"].ToString());
                            debit.DueDate = dr["DUE_DATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["DUE_DATE"]);
                            debit.TrCode = Convert.ToInt32(dr["TRCODE"].ToString());
                            debit.Total = Convert.ToDecimal(dr["AMOUNT_REQUIRED"].ToString());
                            debit.Paid = Convert.ToDecimal(dr["AMOUNT_PAID"].ToString());
                            debit.CurCode = dr["CURRCODE"].ToString();
                            debit.TrCurr = dr["TRCURR"].ToString() == "" ? 0 : Convert.ToInt32(dr["TRCURR"].ToString());
                            debit.ClCode = dr["CL_CODE"].ToString();
                            debit.ClDef = dr["CLIENTNAME"].ToString();
                            debit.IsPerson = dr["ISPERSON"].ToString() == "" ? 0 : Convert.ToInt32(dr["ISPERSON"].ToString());
                            debit.TaxNr = dr["CL_TAXNR"].ToString();
                            debit.TaxOffice = dr["CL_TAXOFFICE"].ToString();
                            debit.IBAN = dr["IBAN"].ToString();
                            debit.EmailAdres = dr["CL_EMAIL"].ToString();
                            debit.FicheDate = dr["FICHEDATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["FICHEDATE"]);
                            debit.FicheNo = dr["FICHENO"].ToString();
                            debit.DoCode = dr["DOCODE"].ToString();
                            debit.TrType = dr["TRTYPE"].ToString();
                            debit.GenExp1 = dr["GENEXP1"].ToString();
                            debit.Branch = dr["BRANCH"].ToString() == "" ? 0 : Convert.ToInt32(dr["BRANCH"].ToString());
                            // Burada PayRef'lerin LG_XXX_XX_PAYTRANS tablosunda hala olup olmadığınına göre NotInPayTrans Özelliğinin ataması yapılır.
                            debit.NotInPayTrans = Helper.NotInPayTrans(debit.PayRef);
                            if (debit.NotInPayTrans == false)
                                debit.NotInPayTransFrame = "DELETED";
                            else if (debit.NotInPayTrans)
                                debit.NotInPayTransFrame = "MEVCUT";

                            PacketEditsRightList.Add(debit);
                        }
                    }
                    conn.Close();
                }
                else if (detailSendingValue == 3)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Debit debit = new Debit();
                            debit.PayRef = Convert.ToInt32(dr["PAYTRANSREF"].ToString());
                            debit.ClCardRef = Convert.ToInt32(dr["CLIENTREF"].ToString());
                            debit.FicheRef = Convert.ToInt32(dr["FICHEREF"].ToString());
                            debit.ModuleNr = Convert.ToInt32(dr["MODULENR"].ToString());
                            debit.DueDate = dr["DUE_DATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["DUE_DATE"]);
                            debit.TrCode = Convert.ToInt32(dr["TRCODE"].ToString());
                            debit.Total = Convert.ToDecimal(dr["AMOUNT_REQUIRED"].ToString());
                            debit.Paid = Convert.ToDecimal(dr["AMOUNT_PAID"].ToString());
                            debit.CurCode = dr["CURRCODE"].ToString();
                            debit.TrCurr = dr["TRCURR"].ToString() == "" ? 0 : Convert.ToInt32(dr["TRCURR"].ToString());
                            debit.ClCode = dr["CL_CODE"].ToString();
                            debit.ClDef = dr["CLIENTNAME"].ToString();
                            debit.IsPerson = dr["ISPERSON"].ToString() == "" ? 0 : Convert.ToInt32(dr["ISPERSON"].ToString());
                            debit.TaxNr = dr["CL_TAXNR"].ToString();
                            debit.TaxOffice = dr["CL_TAXOFFICE"].ToString();
                            debit.IBAN = dr["IBAN"].ToString();
                            debit.EmailAdres = dr["CL_EMAIL"].ToString();
                            debit.FicheDate = dr["FICHEDATE"].ToString() == "" ? Convert.ToDateTime("01.01.0001") : Convert.ToDateTime(dr["FICHEDATE"]);
                            debit.FicheNo = dr["FICHENO"].ToString();
                            debit.DoCode = dr["DOCODE"].ToString();
                            debit.TrType = dr["TRTYPE"].ToString();
                            debit.GenExp1 = dr["GENEXP1"].ToString();
                            debit.Branch = dr["BRANCH"].ToString() == "" ? 0 : Convert.ToInt32(dr["BRANCH"].ToString());
                            #region Boyutlu Satırların Propertysleri
                            debit.MecraType = dr["MECRA_TYPE"].ToString();
                            debit.Mecra = dr["MECRA"].ToString();
                            debit.MarketingCompany = dr["MARKETING_COMPANY"].ToString();
                            debit.Customer = dr["CUSTOMER"].ToString();
                            debit.PlanCode = dr["PLAN_CODE"].ToString();
                            debit.InternetMainCategory = dr["INTERNET_MAIN_CATEGORY"].ToString();
                            debit.InternetSubCategory = dr["INTERNET_SUB_CATEGORY"].ToString();
                            debit.DD1REF = Convert.ToInt32(dr["DD1REF"].ToString());
                            debit.DD2REF = Convert.ToInt32(dr["DD2REF"].ToString());
                            debit.DD3REF = Convert.ToInt32(dr["DD3REF"].ToString());
                            debit.DD4REF = Convert.ToInt32(dr["DD4REF"].ToString());
                            debit.DD5REF = Convert.ToInt32(dr["DD5REF"].ToString());
                            debit.DD6REF = Convert.ToInt32(dr["DD6REF"].ToString());
                            debit.DD7REF = Convert.ToInt32(dr["DD7REF"].ToString());
                            #endregion
                            // Burada PayRef'lerin LG_XXX_XX_PAYTRANS tablosunda hala olup olmadığınına göre NotInPayTrans Özelliğinin ataması yapılır.
                            debit.NotInPayTrans = Helper.NotInPayTrans(debit.PayRef);
                            if (debit.NotInPayTrans == false)
                            {
                                debit.NotInPayTransFrame = "DELETED";
                            }
                            else if (debit.NotInPayTrans)
                            {
                                debit.NotInPayTransFrame = "MEVCUT";
                            }

                            PacketEditsRightList.Add(debit);
                        }
                    }
                    conn.Close();
                }

                var source2 = new BindingSource();
                source.DataSource = PacketEditsRightList;
                DGVRightEdit.DataSource = source.DataSource;
            }
            #endregion

            #region Paket Açıklamasını Getiren Kodlar
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                string note = "";
                CommandText = "SELECT NOTE FROM AYZ_PW_PACKET WHERE ID = " + PacketId + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        note = dr["NOTE"].ToString();
                    }
                }
                txtPacketEditExp.Text = note;
            }
            #endregion

            #region Paket Ödeme Çıkış Hesabını Getiren Kodlar
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT ACCOUNTOUTID FROM AYZ_PW_PACKET WHERE ID = " + PacketId + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int accOutId = 0;
                while (dr.Read())
                {
                    accOutId = Convert.ToInt32(dr["ACCOUNTOUTID"].ToString());
                }
                conn.Close();

                DataTable tbl = new DataTable();
                CommandText = "SELECT * FROM AYZ_PW_BANKACCOUNT";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();

                tbl.Load(dr);

                cmbOutAccountInfoEdit.DataSource = tbl;
                cmbOutAccountInfoEdit.DisplayMember = "TITLE";
                cmbOutAccountInfoEdit.ValueMember = "ID";

                int i = 0;
                dr = komut.ExecuteReader();
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["ID"].ToString()) == accOutId)
                    {
                        cmbOutAccountInfoEdit.SelectedItem = cmbOutAccountInfoEdit.Items[i];
                    }
                    i++;
                }
            }
            #endregion

        }

        private void btnRightPacketEdit_Click(object sender, EventArgs e)
        {
            for (int i = DGVLeftEdit.Rows.Count - 1; i >= 0; i--)
            {
                DGVLeftEdit.SelectAll();
                DataGridViewRow drv = DGVLeftEdit.Rows[i];                
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
                    debit.NotInPayTrans = Helper.NotInPayTrans(debit.PayRef);
                    if (debit.NotInPayTrans == false)
                        debit.NotInPayTransFrame = "DELETED";
                    else if (debit.NotInPayTrans)
                        debit.NotInPayTransFrame = "MEVCUT";
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
                    PacketEditsRightList.Add(debit);
                    var select = PacketEditsLeftList.Where(x => x.PayRef == debit.PayRef).ToList();
                    PacketEditsLeftList.Remove(select[0]);
                }
            }

            var source = new BindingSource();
            source.DataSource = PacketEditsRightList;
            DGVRightEdit.DataSource = source;


            var source2 = new BindingSource();
            source2.DataSource = PacketEditsLeftList;
            DGVLeftEdit.DataSource = source2;
        }

        private void btnLeftPacketEdit_Click(object sender, EventArgs e)
        {
            for (int i = DGVRightEdit.Rows.Count - 1; i >= 0; i--)
            {
                DGVRightEdit.SelectAll();
                DataGridViewRow drv = DGVRightEdit.Rows[i];
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
                    debit.NotInPayTrans = Helper.NotInPayTrans(debit.PayRef);
                    if (debit.NotInPayTrans == false)
                        debit.NotInPayTransFrame = "DELETED";
                    else if (debit.NotInPayTrans)
                        debit.NotInPayTransFrame = "MEVCUT";
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
                    PacketEditsLeftList.Add(debit);
                    var select = PacketEditsRightList.Where(x => x.PayRef == debit.PayRef).ToList();
                    PacketEditsRightList.Remove(select[0]);

                }
            }

            var source = new BindingSource();
            source.DataSource = PacketEditsRightList;
            DGVRightEdit.DataSource = source;

            var source2 = new BindingSource();
            source2.DataSource = PacketEditsLeftList;
            DGVLeftEdit.DataSource = source2;
        }                

        private void btnFiltreRecoveryPacketEdit_Click(object sender, EventArgs e)
        {
            PacketEditsLeftList.RemoveRange(0, PacketEditsLeftList.Count);
            FillLeftList();
            //sağ taraftaki kayıtları sol tarafa ekleme
            foreach (var item in PacketEditsRightList)
            {
                PacketEditsLeftList.Add(item);
            }
            var source = new BindingSource();
            source.DataSource = PacketEditsLeftList;
            DGVLeftEdit.DataSource = source;

            // Filtreyi sıfırla yaptığımız zaman sağ dataGridView'daki satırların silinmesi gerekir.
            PacketEditsRightList.RemoveRange(0, PacketEditsRightList.Count);
            var source2 = new BindingSource();
            source2.DataSource = PacketEditsRightList;
            DGVRightEdit.DataSource = source2;
        }

        private void btnEditPacket_Click(object sender, EventArgs e)
        {            
            decimal sumRequire = PacketEditsRightList.Sum(x => x.Total);                                                       // Ödenmesi Gereken
            decimal sumPaid = PacketEditsRightList.Sum(x => x.Paid);                                                           // Ödenecek Tutar   

            // ilk önce AYZ_PW_PACKET_DETAIL Tablosundaki mevcut paket id'li değerler silinecek.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    CommandText = "DELETE FROM AYZ_PW_PACKET_DETAIL WHERE PACKETID = " + PacketId + " ";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Hata: " + ex.Message.ToString());
                }
            }
            // 2. aşama olarak AYZ_PW_PACKET tablosundaki mevcut paket id'li kayıt'ın değerleri güncellenecek.
            // Hangi değerler güncellenecek:
            //      1. TOTAL_REQUIRED
            //      2. TOTAL_PAID
            //      3. ModifiedBy
            //      4. ModifiedDate
            //      5. ModifiedTime
            //      6. Note
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    CommandText = "UPDATE AYZ_PW_PACKET " +
                              "\nSET MODIFIED_BY = " + Helper.USERID + ", " +
                              "\nMODIFIED_NAME = '" + Helper.USERNAME + "', " +
                              "\nMODIFIED_DATE = CONVERT(DATE, GETDATE(), 104), " +
                              "\nMODIFIED_TIME = " + Helper.GetTime() + ", " +
                              "\nTOTAL_REQUIRED = " + sumRequire.ToString().Replace(',', '.') + ", " +
                              "\nTOTAL_PAID = " + sumPaid.ToString().Replace(',', '.') + ", " +
                              "\nNOTE = '" + txtPacketEditExp.Text + "', " +
                              "\nACCOUNTOUTID = '" + cmbOutAccountInfoEdit.SelectedValue + "' " +
                              "\nWHERE ID = " + PacketId + " ";
                    komut.CommandText = CommandText;
                    komut.Connection = conn;
                    conn.Open();
                    komut.ExecuteNonQuery();
                    conn.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Hata: " + ex.Message.ToString());
                }
            }

            // 3. Aşama olarak sağ griddeki yeni değerler AYZ_PW_PACKET_DETAIL tablosuna yazılacak.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                try
                {
                    if (PacketEditsRightList.Count > 0)
                    {
                        foreach (var item in PacketEditsRightList)
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
                            komut.Connection = conn;
                            conn.Open();
                            komut.ExecuteNonQuery();
                            conn.Close();
                        }
                        MessageBox.Show("Paket başarılı bir şekilde güncellendi...!", "Paket Güncelleme Ekranı");
                        this.Hide();
                        Anasayfa form = (Anasayfa)Application.OpenForms["Anasayfa"];
                        form.FillPacketList();
                    }
                    else if (PacketEditsRightList.Count == 0)
                    {
                        MessageBox.Show("Pakete eklenmiş bir ödeme yoktur!", "UYARI!");
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Hata: " + ex.Message.ToString());
                }

            }
        }

        private void DGVRightEdit_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewCell cell = DGVRightEdit.Rows[e.RowIndex].Cells["NotInPayTrans"];
            string value = cell.Value == null ? string.Empty : cell.Value.ToString();
            bool foo = false;
            if (value != "")
                foo = Convert.ToBoolean(value);

            if (foo)
            {
                //DGVRightEdit.Rows[e.RowIndex].Cells["NotInPayTransFrame"].Style.BackColor = Color.Green;
                //DGVRightEdit.Rows[e.RowIndex].Cells["NotInPayTransFrame"].Style.ForeColor = Color.White;
                DGVRightEdit.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                DGVRightEdit.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

            }
            else if (foo == false)
            {
                //DGVRightEdit.Rows[e.RowIndex].Cells["NotInPayTransFrame"].Style.BackColor = Color.Red;
                //DGVRightEdit.Rows[e.RowIndex].Cells["NotInPayTransFrame"].Style.ForeColor = Color.White;
                DGVRightEdit.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                DGVRightEdit.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }
    }
}
