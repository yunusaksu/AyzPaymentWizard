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

namespace AyzPaymentWizard.Forms
{
    public partial class DebitClosingForm : Form
    {
        List<PAYMENTOUTCOME> liste = new List<PAYMENTOUTCOME>();
        SqlCommand komut = new SqlCommand();
        SqlDataReader dr;
        string CommandText = "";
        int PacketID;

        public DebitClosingForm()
        {
            InitializeComponent();
        }

        public DebitClosingForm(int packetId)
        {
            InitializeComponent();
            PacketID = packetId;
        }

        private void DebitClosingForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                CommandText = "";
            }
        }
    }
}
