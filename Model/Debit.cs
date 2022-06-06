using System;

namespace AyzPaymentWizard.Model
{
    public class Debit                          // Borçlu Olunan Cari Hesapların Bilgilerini Tutar.
    {
        public int PayRef { get; set; }         // LG_XXX_XX_PAYTRANS tablosunun Logicalref'i
        public int ClCardRef { get; set; }      // Cari Hesap Kartının LogicalRef'i
        public int FicheRef { get; set; }       // INVOICE Logicalref'i
        public int ModuleNr { get; set; }       // Hareketin hangi tablodan geldiğini söyler. 4: Fatura, 5: cari hesap, 6: çek/senet, 7: banka, 10:kasa hareketi 
        public DateTime DueDate { get; set; }   // Vade Bitiş Tarihini Tutar
        public int TrCode { get; set; }         // İlgili Fiş Türü
        public decimal Total { get; set; }      // Ödenmesi gereken Tutar
        public decimal Paid { get; set; }       // Ödenecek Tutar
        public string CurCode { get; set; }     // Borçlu Olunan Kur Tipini tutar. Örn: TL
        public int TrCurr { get; set; }         // Borçlu Olunan Kur Type'nin Logo'daki değerini tutar. Örn: TL için 0, USD için 1'dir.
        public string ClCode { get; set; }      // Cari Hesap Kodunu tutar.
        public string ClDef { get; set; }       // Cari Hesap'ın Unvanını tutar.
        public string GeneralBalance { get; set; }   // Genel Bakiye: Tüm Döviz Türlerinin TL Karşılığının Toplamını gösterir.        
        public int IsPerson { get; set; }      // Borçlu Olunan Kişi mi Kurum mu Bilgisini tutar.
        public string TaxNr { get; set; }      // Vergi Numarasını tutar.
        public string TaxOffice { get; set; }  // Vergi Dairesini Tutar.
        public string IBAN { get; set; }       // IBAN
        public string EmailAdres { get; set; } // Mail
        public DateTime FicheDate { get; set; }// Fiş Tarihini Tutar
        public string FicheNo { get; set; }    // Fiş Numarasını Tutar.
        public string DoCode { get; set; }     // Belge Numarasını Tutar
        public string TrType { get; set; }     // Fiş Tipini Tutar. Örn: Alım Faturası
        public string GenExp1 { get; set; }    // Açıklama
        public int Branch { get; set; }        // İş yerinin Code'unu tutar. Örn: 0 ise Carat Medya için Merkez İşyeri demektir.        

        #region Boyut Properties        
        public string MecraType { get; set; }               // Mecra Türü
        public string Mecra { get; set; }
        public string MarketingCompany { get; set; }        // Pazarlama Şirketi
        public string Customer { get; set; }                // Müşteri
        public string PlanCode { get; set; }                // Plan Kodu
        public string InternetMainCategory { get; set; }    // Internet Ana Kategori
        public string InternetSubCategory { get; set; }     // Internet Alt Kategori
        public int DD1REF { get; set; }                     // Mecra Türü Boyutu ID
        public int DD2REF { get; set; }                     // Mecra Boyutu ID
        public int DD3REF { get; set; }                     // Pazarlama Şirketi Boyutu ID
        public int DD4REF { get; set; }                     // Müşteri Boyutu ID
        public int DD5REF { get; set; }                     // Plan Kodu Boyutu ID
        public int DD6REF { get; set; }                     // Internet Ana Kategori Boyutu ID
        public int DD7REF { get; set; }                     // Internet Alt Kategori Boyutu ID

        #endregion
        public bool NotInPayTrans { get; set; }// PayTrans LG_XXX_XX_PAYTRANS tablosunda kayıdın hala olup olmadığını kontrol eder.
        public string NotInPayTransFrame { get; set; } // NotInPayTrans'ın frame'dir.        

        public string TLBalance { get; set; }       // TL Bakiye
        public string USDBalance { get; set; }      // USD Bakiye
        public string EUROBalance { get; set; }     // EURO Bakiye
        public string GBPBalance { get; set; }      // GBP Bakiye

    }
}
