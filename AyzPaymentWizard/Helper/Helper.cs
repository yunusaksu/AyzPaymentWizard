using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyzPaymentWizard
{
    public static class Helper
    {
        static SqlCommand komut = new SqlCommand();
        static SqlDataReader dr;
        static string CommandText = "";

        static public string LOGOUSERNAME { get; set; }
        static public string LOGOUSERPASS { get; set; }
        static public string FIRMANO { get { return LStr(FIRMNR.ToString(), 3); } }  // Sadece Logo tablolarında kullanılır.
        public static string USERNAME { get; set; }
        public static int USERID { get; set; }
        public static int FIRMNR { get; set; }                                       // FIRMANO'nun int halidir. FIRMANO yerine kullanılamaz.

        public enum FilterType
        {
            DetailSendig = 0,
            Currency = 1,
            ExpiryDate = 2,
            InvoiceDate = 3,
            ClientCodeType = 4,
            ClientSpecialCode = 5,
            ClientSpecialCode2 = 6,
            ReplaceDueDateAndTodayDate = 7,
            VoucherType = 8,
            MecraType = 9,
            Mecra = 10,
            MarketingCompany = 11,
            Customer = 12,
            PlanCode = 13,
            InternerMainCategory = 14,
            InternetSubCategory = 15,
            Branch = 16,
            ClientCodeBeg = 17,
            ClientCodeEnd = 18
        };

        public static int GetTime()
        {
            int time = DateTime.Now.Hour * 16777216 + DateTime.Now.Minute * 65536 + DateTime.Now.Second * 256;
            return time;
        }

        public enum PacketStatus
        {
            NewPacket = 0,
            Approved = 1,
            Rejected = 2,
            SentToBank = 3,
            AnswerReceivedBank = 4,
            SendToApproval = 5
        }
        public enum ArchiveStatus
        {
            Unarchived = 0,
            Archived = 1
        }

        public static bool NotInPayTrans(int payRef)
        {
            List<int> paytransIdList = new List<int>();
            using (SqlConnection conn = new SqlConnection(ConnectionHelper.ConnectionString))
            {
                CommandText = "SELECT LOGICALREF FROM LG_" + FIRMANO + "_01_PAYTRANS";
                komut.CommandText = CommandText;
                komut.Connection = conn;
                conn.Open();
                dr = komut.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        int id = Convert.ToInt32(dr["LOGICALREF"].ToString());
                        paytransIdList.Add(id);
                    }
                }

                bool foo = paytransIdList.Contains(payRef);
                return foo;
            }
        }
        public static string LStr(object val, int len)
        {
            string sVal = val.ToString();
            while (sVal.Length < len)
                sVal = "0" + sVal;
            return sVal.Substring(0, len);
        }
    }
}
