using System;

namespace AyzPaymentWizard.Model
{
    public class LOG_FILE
    {
        public int ID { get; set; }
        public DateTime LOG_DATETIME { get; set; }
        public string STATE { get; set; }
        public string LOG_NAME { get; set; }
        public string LOG_EXP { get; set; }
        public int PACKETID { get; set; }
        //public int LOG_CREATE_USERID { get; set; }
        public string LOG_CREATE_USERNAME { get; set; }
    }
}
