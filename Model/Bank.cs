namespace AyzPaymentWizard.Model
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; } // Banka Adı
        public string BranchName { get; set; } //Şube Adı
        public string FirmName { get; set; }   // Banka Nezdinde Firma Adı
        public string CustomerNo { get; set; } // Müşteri Numarası
        public int BankRef { get; set; }  //Logo Ref
        public int BankNr { get; set; }
        public int BranchNr { get; set; }                               
        public int FirmNr { get; set; }        // Firm N
        public int Status { get; set; }
    }
}
