using DocumentFormat.OpenXml.Office2010.Excel;
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
    public partial class FiltersForm : Form
    {
        Dictionary<int, string> checkListBoxMecraType = new Dictionary<int, string>();

        public FiltersForm()
        {
            InitializeComponent();

        }

        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";

        private void btnFiltreApply_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand();
            SqlDataReader dr;
            string CommandText = "";

            // Yeni Filtreleri kaydetmek için eski filtre verilerini temizleme işlemi yapılıyor.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "DELETE FROM AYZ_PW_FILTER_VALUES WHERE FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 1. DETAYLI GÖNDERİMDE SEÇİLİ OLAN GÖNDERİM TİPİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZICAM. DETAYLI GÖNDERİNİN TYPE_'ı 0.            
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cmbPaymentType.SelectedItem;
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.DetailSendig) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 2. OLARAK ÖNCE İŞLEM DÖVİZİNDE SEÇİLİ OLAN KUR VARSA ONLARI AYZ_PW_FILTER_VALUES TABLOSUNA YAZICAM. İŞLEM DÖVİZİNİN TYPE_'ı 1.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cmbCurrency.SelectedItem;
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.Currency) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // USERNR login olan kullanıcının ID'si.
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 3. OLARAK VADE TARİHLERİNİ  AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM.
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ExpiryDate) + "', '" + expiryDateBegin.Value.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ExpiryDate) + "', '" + expiryDateEnd.Value.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 4. OLARAK FATURA TARİHLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.InvoiceDate) + "', '" + invoiceDateBegin.Value.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.InvoiceDate) + "', '" + invoiceDateEnd.Value.ToString() + "', '2','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 5. OLARAK CARİ HESAP TİPİNİ ve DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cmbClFiltreType.SelectedItem;
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientCodeType) + "', '" + kvp.Key + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientCodeBeg) + "', '" + txtClientCodeBeg.Text + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();

                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientCodeEnd) + "', '" + txtClientCodeEnd.Text + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 6. OLARAK CARİ HESAP ÖZEL KODUNU AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientSpecialCode) + "', '" + txtClientSpecialCode.Text + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 7. OLARAK CARİ HESAP ÖZEL KODU 2 AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ClientSpecialCode2) + "', '" + txtClientSpecialCode2.Text + "', '4','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 8. OLARAK VADE TARİHİ GEÇMİŞ OLANLARI GÜNÜN TARİHİ İLE DEĞİŞTİRME DEĞERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR)VALUES('" + Convert.ToInt32(Helper.FilterType.ReplaceDueDateAndTodayDate) + "', '" + chkboxReplaceDate.Checked + "', '5','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 9. OLARAK FİŞ TÜRLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cmbVoucherType.SelectedItem;
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.VoucherType) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            // 10. OLARAK MECRA TÜRLERİNİN DEĞERLERİNİ AYZ_PW_FILTER_VALUES TABLOSUNA YAZIYORUM
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                for (int i = 0; i < checkedListBoxMecraType1.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxMecraType1.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.MecraType) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                for (int i = 0; i < checkedListBoxMecra.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxMecra.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.Mecra) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                for (int i = 0; i < checkedListBoxMarketingCompany.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxMarketingCompany.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.MarketingCompany) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                for (int i = 0; i < checkedListBoxCustomer.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxCustomer.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.Customer) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                for (int i = 0; i < checkedListBoxPlanCode.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxPlanCode.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.PlanCode) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                for (int i = 0; i < checkedListBoxInternetMainCategory.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxInternetMainCategory.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.InternerMainCategory) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                for (int i = 0; i < checkedListBoxInternetSubCategory.CheckedItems.Count; i++)
                {
                    KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)checkedListBoxInternetSubCategory.CheckedItems[i];
                    CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.InternetSubCategory) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')"; // FIRMNR ve USERNR'de daha sonra paremetrik olacak. USERNR login olan kullanıcının ID'si.
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
                KeyValuePair<int, string> kvp = (KeyValuePair<int, string>)cmbBranch.SelectedItem;
                CommandText = "INSERT INTO AYZ_PW_FILTER_VALUES(TYPE_,VALUE,VALUE_TYPE,FIRMNR,USERNR) VALUES('" + Convert.ToInt32(Helper.FilterType.Branch) + "','" + kvp.Key + "','1','" + Helper.FIRMNR + "','" + Helper.USERID + "')";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                komut.ExecuteNonQuery();
                conn.Close();
            }

            PacketPreparation form = new PacketPreparation();
            form.ShowDialog();
            this.Hide();
        }

        private void FiltersForm_Load(object sender, EventArgs e)
        {
            // DETAYLI GÖNDERİM Alanındaki Değerleri Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT DS.KEY_," +
                              "\nDS.VALUE," +
                              "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                              "\nFROM AYZ_PW_DETAIL_SENDIG DS " +
                              "\nLEFT JOIN AYZ_PW_FILTER_VALUES FV ON DS.KEY_ = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 0) AND (DS.FIRMNR = FV.FIRMNR) AND FV.USERNR = " + Helper.USERID + " AND FV.PACKETID IS NULL" +
                              "\nWHERE DS.FIRMNR = " + Helper.FIRMNR + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();

                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                while (dr.Read())
                {
                    comboSource.Add(Convert.ToInt32(dr["KEY_"].ToString()), dr["VALUE"].ToString());
                }
                conn.Close();
                cmbPaymentType.DataSource = new BindingSource(comboSource, null);
                cmbPaymentType.DisplayMember = "Value";
                cmbPaymentType.ValueMember = "Key";

                // Selected olanı atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        cmbPaymentType.SelectedIndex = i;
                    }
                    i++;
                }
                conn.Close();
            }

            // DÖVİZ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT 0 CURTYPE, 'TL' CURCODE, 0 SELECTED " +
                              "\nUNION " +
                              "\nSELECT CURTYPE,CURCODE, CASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                              "\nFROM L_CURRENCYLIST CL " +
                              "\nLEFT JOIN [dbo].[AYZ_PW_FILTER_VALUES] FV ON CL.CURTYPE = CAST(FV.VALUE AS SMALLINT) AND(FV.TYPE_ = 1)  " +
                              "\nAND (FV.USERNR = " + Helper.USERID + ") " +
                              "\nAND (CL.FIRMNR = FV.FIRMNR) AND FV.PACKETID IS NULL" +
                              "\nWHERE CL.FIRMNR = " + Helper.FIRMNR + " AND (CL.CURTYPE IN(1, 3, 11, 13, 14, 17, 20)) " +
                              "\nORDER BY CURTYPE";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                while (dr.Read())
                {
                    comboSource.Add(Convert.ToInt32(dr["CURTYPE"].ToString()), dr["CURCODE"].ToString());
                }
                conn.Close();
                cmbCurrency.DataSource = new BindingSource(comboSource, null);
                cmbCurrency.DisplayMember = "Value";
                cmbCurrency.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        cmbCurrency.SelectedIndex = i;
                    }
                    i++;
                }
                conn.Close();
            }

            // VADE TARİHİ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 2 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                List<string> dateList = new List<string>();
                while (dr.Read())
                {
                    dateList.Add(dr["VALUE"].ToString());
                }
                if (dateList.Count > 0)
                {
                    var date1 = Convert.ToDateTime(dateList[0].ToString());
                    var date2 = Convert.ToDateTime(dateList[1].ToString());
                    if (date1 > date2)
                    {
                        expiryDateBegin.Value = date2;
                        expiryDateEnd.Value = date1;
                    }
                    else
                    {
                        expiryDateBegin.Value = date1;
                        expiryDateEnd.Value = date2;
                    }
                }
            }

            // FATURA TARİHİ alanının değerlerini getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 3 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                List<string> dateList = new List<string>();
                while (dr.Read())
                {
                    dateList.Add(dr["VALUE"].ToString());
                }
                if (dateList.Count > 0)
                {
                    var date1 = Convert.ToDateTime(dateList[0].ToString());
                    var date2 = Convert.ToDateTime(dateList[1].ToString());
                    if (date1 > date2)
                    {
                        invoiceDateBegin.Value = date2;
                        invoiceDateEnd.Value = date1;
                    }
                    else
                    {
                        invoiceDateBegin.Value = date1;
                        invoiceDateEnd.Value = date2;
                    }
                }
            }

            // CARİ HESAP KODU alanının değerini getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT CA.KEY_, CA.VALUE, CASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                              "\nFROM AYZ_PW_CLIENT_ACCOUNT CA LEFT JOIN AYZ_PW_FILTER_VALUES FV ON CA.KEY_ = CAST(FV.VALUE AS SMALLINT) " +
                              "\nAND (FV.TYPE_ = 4) AND(CA.FIRMNR = FV.FIRMNR) AND FV.USERNR = " + Helper.USERID + " AND FV.PACKETID IS NULL" +
                              "\nWHERE CA.FIRMNR = " + Helper.FIRMNR + " ";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();

                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                while (dr.Read())
                {
                    comboSource.Add(Convert.ToInt32(dr["KEY_"].ToString()), dr["VALUE"].ToString());
                }
                conn.Close();
                cmbClFiltreType.DataSource = new BindingSource(comboSource, null);
                cmbClFiltreType.DisplayMember = "Value";
                cmbClFiltreType.ValueMember = "Key";


                // Selected olanı atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        cmbClFiltreType.SelectedIndex = i;
                    }
                    i++;
                }
                conn.Close();

                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 17 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                var deger = "";
                while (dr.Read())
                {
                    deger = dr["VALUE"].ToString();
                }
                txtClientCodeBeg.Text = deger;
                conn.Close();

                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 18 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                var deger2 = "";
                while (dr.Read())
                {
                    deger2 = dr["VALUE"].ToString();
                }
                txtClientCodeEnd.Text = deger2;
                conn.Close();

                #region Filtre Tipini Seçme Wizard
                if ((int)cmbClFiltreType.SelectedValue == 0)
                {
                    txtClientCodeBeg.Show();
                    txtClientCodeEnd.Hide();
                    lblClEnd.Hide();
                }
                else if ((int)cmbClFiltreType.SelectedValue == 1)
                {
                    txtClientCodeBeg.Show();
                    txtClientCodeEnd.Hide();
                    lblClEnd.Hide();
                }
                else
                {
                    txtClientCodeBeg.Show();
                    txtClientCodeEnd.Show();
                    lblClEnd.Show();
                }
                #endregion
            }

            // CARİ ÖZEL KODU alanının değerlerini getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 5 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                var deger = "";
                while (dr.Read())
                {
                    deger = dr["VALUE"].ToString();
                }
                txtClientSpecialCode.Text = deger;
            }

            // CARİ ÖZEL KODU 2 alanının değerlerini getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 6 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                var deger = "";
                while (dr.Read())
                {
                    deger = dr["VALUE"].ToString();
                }
                txtClientSpecialCode2.Text = deger;
            }

            // VADE TARİHİ GEÇMİŞ OlANLARI GÜNÜN TARİHİ İLE DEĞİŞTİR alanının değerlerini getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT VALUE FROM AYZ_PW_FILTER_VALUES WHERE TYPE_ = 7 AND FIRMNR = " + Helper.FIRMNR + " AND USERNR = " + Helper.USERID + " AND PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                bool deger = false;
                while (dr.Read())
                {
                    deger = Convert.ToBoolean(dr["VALUE"].ToString());
                }
                chkboxReplaceDate.Checked = Convert.ToBoolean(deger);
            }

            // FİŞ TÜRLERİ alanının değerlerini getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT CODE = VT.CODE," +
                              "\n DESCRIPTION = VT.DESCRIPTION," +
                              "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED" +
                              "\nFROM AYZ_PW_VOUCHER_TYPE VT LEFT JOIN[dbo].[AYZ_PW_FILTER_VALUES] FV ON VT.CODE = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 8) AND (FV.USERNR = " + Helper.USERID + ")" +
                              "\nAND (VT.FIRMNR = FV.FIRMNR) AND FV.PACKETID IS NULL" +
                              "\nWHERE VT.FIRMNR = " + Helper.FIRMNR + "";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                while (dr.Read())
                {
                    comboSource.Add(Convert.ToInt32(dr["CODE"].ToString()), dr["DESCRIPTION"].ToString());
                }
                conn.Close();
                cmbVoucherType.DataSource = new BindingSource(comboSource, null);
                cmbVoucherType.DisplayMember = "Value";
                cmbVoucherType.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        cmbVoucherType.SelectedIndex = i;
                    }
                    i++;
                }
                conn.Close();
            }

            // MECRA TÜRÜ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGREF," +
                                     "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_," +
                                     "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED" +
                                     "\nFROM LG_XT105 LG" +
                                     "\nLEFT JOIN [dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 9)" +
                                     "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ")" +
                                     "\nWHERE LG.TYPE_ = 1 AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                
                while (dr.Read())
                {
                    checkListBoxMecraType.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
<<<<<<< HEAD
                checkedListBoxMecraType.DataSource = new BindingSource(checkListBoxMecraType, null);
                checkedListBoxMecraType.DisplayMember = "Value";
                checkedListBoxMecraType.ValueMember = "Key";
=======

                checkedListBoxMecraType1.DataSource = new BindingSource(checkListBoxMecraType, null);
                checkedListBoxMecraType1.DisplayMember = "Value";
                checkedListBoxMecraType1.ValueMember = "Key";
>>>>>>> ac9df0acc8bae30a52726d3620e6e68134e1daca

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxMecraType1.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // MECRA Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGREF," +
                                     "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_," +
                                     "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED" +
                                     "\nFROM LG_XT105 LG" +
                                     "\nLEFT JOIN [dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 10)" +
                                     "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ")" +
                                     "\nWHERE LG.TYPE_ = 2 AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> checkListBoxMecra = new Dictionary<int, string>();
                while (dr.Read())
                {
                    checkListBoxMecra.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                checkedListBoxMecra.DataSource = new BindingSource(checkListBoxMecra, null);
                // checkedListBoxMecraType.Items.Insert(0,checked)
                checkedListBoxMecra.DisplayMember = "Value";
                checkedListBoxMecra.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxMecra.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // PAZARLAMA ŞİRKETİ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGICALREF, " +
                    "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_, " +
                    "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                    "\nFROM LG_" + Helper.FIRMANO + "_CLCARD LG " +
                    "\nLEFT JOIN [dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGICALREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 11)" +
                    "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ") " +
                    "\nWHERE LG.CODE LIKE 'S%' AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> checkListBoxMarketingCompany = new Dictionary<int, string>();
                while (dr.Read())
                {
                    checkListBoxMarketingCompany.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                checkedListBoxMarketingCompany.DataSource = new BindingSource(checkListBoxMarketingCompany, null);
                checkedListBoxMarketingCompany.DisplayMember = "Value";
                checkedListBoxMarketingCompany.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxMarketingCompany.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // MÜŞTERİ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGICALREF," +
                                "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_," +
                                "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED" +
                                "\nFROM LG_" + Helper.FIRMANO + "_CLCARD LG" +
                                "\nLEFT JOIN [dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGICALREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 12)" +
                                "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ")" +
                                "\nWHERE LG.CODE LIKE 'M%' AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> checkListBoxCustomer = new Dictionary<int, string>();
                while (dr.Read())
                {
                    checkListBoxCustomer.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                checkedListBoxCustomer.DataSource = new BindingSource(checkListBoxCustomer, null);
                checkedListBoxCustomer.DisplayMember = "Value";
                checkedListBoxCustomer.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxCustomer.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // PLAN KODU Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGREF, " +
                                "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_, " +
                                "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                                "\nFROM LG_XT105 LG " +
                                "\nLEFT JOIN[dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 13) " +
                                "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ") " +
                                "\nWHERE LG.TYPE_ = 5 AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> checkListBoxPlanCode = new Dictionary<int, string>();
                while (dr.Read())
                {
                    checkListBoxPlanCode.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                checkedListBoxPlanCode.DataSource = new BindingSource(checkListBoxPlanCode, null);
                checkedListBoxPlanCode.DisplayMember = "Value";
                checkedListBoxPlanCode.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxPlanCode.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // INTERNET ANA KATEGORİ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGREF, " +
                                "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_, " +
                                "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                                "\nFROM LG_XT105 LG " +
                                "\nLEFT JOIN[dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 14) " +
                                "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ") " +
                                "\nWHERE LG.TYPE_ = 6 AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> checkListBoxNetMainCategory = new Dictionary<int, string>();
                while (dr.Read())
                {
                    checkListBoxNetMainCategory.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                checkedListBoxInternetMainCategory.DataSource = new BindingSource(checkListBoxNetMainCategory, null);
                checkedListBoxInternetMainCategory.DisplayMember = "Value";
                checkedListBoxInternetMainCategory.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxInternetMainCategory.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // INTERNET ALT KATEGORİ Alanının Değerlerini Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGREF, " +
                                "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_, " +
                                "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                                "\nFROM LG_XT105 LG " +
                                "\nLEFT JOIN[dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 15) " +
                                "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ") " +
                                "\nWHERE LG.TYPE_ = 7 AND FV.PACKETID IS NULL";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                Dictionary<int, string> checkListBoxNetSubCategory = new Dictionary<int, string>();
                while (dr.Read())
                {
                    checkListBoxNetSubCategory.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                checkedListBoxInternetSubCategory.DataSource = new BindingSource(checkListBoxNetSubCategory, null);
                checkedListBoxInternetSubCategory.DisplayMember = "Value";
                checkedListBoxInternetSubCategory.ValueMember = "Key";

                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxInternetSubCategory.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }

            // BRANCH(iş yeri) Alanındaki Değerleri Getirme
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT " +
                              "\n -1 NR, 'Hepsi' [NAME], 0 SELECTED " +
                              "\nUNION " +
                              "\nSELECT NR, RIGHT('000' + CAST(NR AS VARCHAR(3)), 3) + ', ' + [NAME], CASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED " +
                              "\nFROM L_CAPIDIV CP" +
                              "\nLEFT JOIN[dbo].[AYZ_PW_FILTER_VALUES] FV " +
                              "\nON CP.NR = CAST(FV.VALUE AS SMALLINT) AND(FV.TYPE_ = 16)  AND(FV.FIRMNR = " + Helper.FIRMNR + ") " +
                              "\nAND(FV.USERNR = " + Helper.USERID + ") " +
                              "\nWHERE CP.FIRMNR = " + Helper.FIRMNR + " AND FV.PACKETID IS NULL " +
                              "\nORDER BY NR";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();

                Dictionary<int, string> comboSource = new Dictionary<int, string>();
                while (dr.Read())
                {
                    comboSource.Add(Convert.ToInt32(dr["NR"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();
                cmbBranch.DataSource = new BindingSource(comboSource, null);
                cmbBranch.DisplayMember = "Value";
                cmbBranch.ValueMember = "Key";

                // Selected olanı atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        cmbBranch.SelectedIndex = i;
                    }
                    i++;
                }
                conn.Close();
            }
        }

        private void cmbClFiltreType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if ((int)cmbClFiltreType.SelectedValue == 2)
            {
                txtClientCodeBeg.Show();
                txtClientCodeEnd.Show();
                lblClBegin.Show();
                lblClEnd.Show();
            }
            else if ((int)cmbClFiltreType.SelectedValue == 1)
            {
                txtClientCodeBeg.Show();
                txtClientCodeEnd.Hide();
                lblClBegin.Show();
                lblClEnd.Hide();
            }
            else
            {
                txtClientCodeBeg.Show();
                txtClientCodeEnd.Hide();
                lblClBegin.Show();
                lblClEnd.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxMecraType1.Items.Count; i++)
            {
                if (checkBoxMaceraType.Checked == true)
                {
                    checkedListBoxMecraType1.SetItemChecked(i, true);
                }
                else if (checkBoxMaceraType.Checked == false)
                {
                    checkedListBoxMecraType1.SetItemChecked(i, false);
                }
            }

        }

        private void checkBoxPazar_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBoxMarketingCompany.Items.Count; j++)
            {
                if (checkBoxPazar.Checked)
                {
                    checkedListBoxMarketingCompany.SetItemChecked(j, true);
                }
                else if (checkBoxPazar.Checked == false)
                {
                    checkedListBoxMarketingCompany.SetItemChecked(j, false);
                }
            }
        }

        private void checkBoxMacera_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBoxMecra.Items.Count; j++)
            {
                if (checkBoxMacera.Checked == true)
                {
                    checkedListBoxMecra.SetItemChecked(j, true);
                }
                else if (checkBoxMacera.Checked == false)
                {
                    checkedListBoxMecra.SetItemChecked(j, false);
                }
            }
        }

        private void checkBoxMusteri_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBoxCustomer.Items.Count; j++)
            {
                if (checkBoxMusteri.Checked == true)
                {
                    checkedListBoxCustomer.SetItemChecked(j, true);
                }
                else if (checkBoxMusteri.Checked == false)
                {
                    checkedListBoxCustomer.SetItemChecked(j, false);
                }
            }
        }

        private void checkBoxPlanKod_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBoxPlanCode.Items.Count; j++)
            {
                if (checkBoxPlanKod.Checked == true)
                {
                    checkedListBoxPlanCode.SetItemChecked(j, true);
                }
                else if (checkBoxPlanKod.Checked == false)
                {
                    checkedListBoxPlanCode.SetItemChecked(j, false);
                }
            }
        }

        private void checkBoxInAlKat_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBoxInternetSubCategory.Items.Count; j++)
            {
                if (checkBoxInAlKat.Checked == true)
                {
                    checkedListBoxInternetSubCategory.SetItemChecked(j, true);
                }
                else if (checkBoxInAlKat.Checked == false)
                {
                    checkedListBoxInternetSubCategory.SetItemChecked(j, false);
                }
            }

        }

        private void checkBoxIntAnaKat_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < checkedListBoxInternetMainCategory.Items.Count; j++)
            {
                if (checkBoxIntAnaKat.Checked == true)
                {
                    checkedListBoxInternetMainCategory.SetItemChecked(j, true);
                }
                else if (checkBoxIntAnaKat.Checked == false)
                {
                    checkedListBoxInternetMainCategory.SetItemChecked(j, false);
                }
            }

        }

        private void MecraTypeFilter_TextChanged(object sender, EventArgs e)
        {
            checkListBoxMecraType.Clear();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGREF = LG.LOGREF," +
                                     "\nNAME = LG.CODE + ' - ' + LG.DEFINITION_," +
                                     "\nCASE WHEN FV.VALUE IS NULL THEN 0 ELSE 1 END SELECTED" +
                                     "\nFROM LG_XT105 LG" +
                                     "\nLEFT JOIN [dbo].[AYZ_PW_FILTER_VALUES] FV ON LG.LOGREF = CAST(FV.VALUE AS SMALLINT) AND (FV.TYPE_ = 9)" +
                                     "\nAND (FV.USERNR = " + Helper.USERID + ") AND (FV.FIRMNR = " + Helper.FIRMNR + ")" +
                                     "\nWHERE LG.TYPE_ = 1 AND FV.PACKETID IS NULL AND LG.CODE LIKE '" +  txtMecraTypeFilter.Text + "%'";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();

                while (dr.Read())
                {
                    checkListBoxMecraType.Add(Convert.ToInt32(dr["LOGREF"].ToString()), dr["NAME"].ToString());
                }
                conn.Close();

                checkedListBoxMecraType1.DataSource = new BindingSource(checkListBoxMecraType, null);
                checkedListBoxMecraType1.DisplayMember = "Value";
                checkedListBoxMecraType1.ValueMember = "Key";


                // Selected olanları atama satırları
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["SELECTED"].ToString()) == 1)
                    {
                        checkedListBoxMecraType1.SetItemCheckState(i, CheckState.Checked);
                    }
                    i++;
                }
                conn.Close();
            }
        }
    }
}
