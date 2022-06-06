using System;

namespace AyzPaymentWizard.Model
{
    public class UserGroup
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool UserType { get; set; }
        public DateTime Date_ { get; set; }
    }
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int FirmNr { get; set; }
        public DateTime Date_ { get; set; }
        public string Email { get; set; }
    }
}
