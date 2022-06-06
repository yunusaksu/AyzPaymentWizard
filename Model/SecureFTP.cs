namespace AyzPaymentWizard.Model
{
    public class SecureFTP
    {
        public int ID { get; set; }
        public int BANKCODE { get; set; }
        public int FIRMNR { get; set; }
        public string HOSTNAME { get; set; }
        public string USERNAME { get; set; }
        public string PASSWORD { get; set; }
        public int PORT { get; set; }
        public string PAYMENTORDERLOGFOLDER { get; set; }        
        public string FOLDERPATH { get; set; }  // SFTP deki Ödeme Emirlerinin yollandığı klasörün yolu
        public string AKIBETFOLDERPATH { get; set; } // SFTP deki Ödeme Akibetlerinin okunduğu klasörün yolu
    }
}
