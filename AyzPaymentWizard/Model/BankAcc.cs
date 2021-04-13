using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzPaymentWizard.Model
{
    public class BankAcc
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BankAccountNo { get; set; }
        public string TigerBankAccountNo { get; set; }
        public int BankRef { get; set; }
        public int BankAccRef { get; set; }
        public int FirmNr { get; set; }
        public int Currency { get; set; }
    }
}
