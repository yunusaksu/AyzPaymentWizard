using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzPaymentWizard.Model
{
    public class Packet
    {
        public int Id { get; set; }                         // Paket ID
        public int UserNr { get; set; }                     // Paketi Oluşturan Kullanıcının ID'si
        public int CreatedBy { get; set; }                  // Paketi Oluşturan Kullanıcının ID'sidir. USERNR ile aynı işlevdedir.
        public string CreatedByName { get; set; }           // Paketi Oluşturanın Adı
        public DateTime CreatedDate { get; set; }           // Paketin Oluşturulma Tarihi
        public int CreatedTime { get; set; }                // Paketin int türünde oluşturulma zamanı
        public string Note { get; set; }                    // Paket açıklaması
        public int ModifiedBy { get; set; }                 // Paketi güncelleyen kullanıcının ID'si
        public string ModifiedByName { get; set; }          // Paketi Güncelleyenin Adı
        public DateTime ModifiedDate { get; set; }          // Paketin Güncellenme Tarihi
        public int ModifiedTime { get; set; }               // Paketin Güncellenme Zamanı
        public decimal TotalRequired { get; set; }          // Toplam Ödenmesi Gereken Tutar
        public decimal TotalPaid { get; set; }              // Toplan Ödenecek Tutar    
        public string Currency { get; set; }                // Para Birimi
        public string ApprovalNote { get; set; }            // Onay Notu
        public int FirmNr { get; set; }                     // Paketin ait olduğu Logo Firma Numarası
        public int Status { get; set; }                     // Paketin Durumu
        public string StatusMask { get; set; }              // Paket Durumunun Maskıdır.
        public int Archived { get; set; }                   // Arşiv Durumu
        public int ApprovedBy { get; set; }                 // Paketi Onaylayan Kullacının ID'si
        public string ApprovierName { get; set; }           // Paketi Onaylayanın Adı
        public DateTime ApprovedDate { get; set; }          // Paketin Onaylanma Tarihi
        public int ApprovedTime { get; set; }               // Paketin Onaylanma Zamanı        
        public int BankId { get; set; }                     // Banka ID
        public int BankBranchId { get; set; }               // Banka Şube ID
        public string BankName { get; set; }                // Banka Adı
        public string TigerBankAccountCode { get; set; }    // Tiger Banka Hesabı Kodu
        public string TigerAccountCode { get; set; }        // Tiger Hesap Kodu
    }
}
