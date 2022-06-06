using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyzPaymentWizard.Forms
{
    public partial class MyMessageBox : Form
    {
        static MyMessageBox newMessageBox;
        static string ButtonID;
        public MyMessageBox()
        {
            InitializeComponent();
        }
        public static string ShowBox(string Message)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.labelMsgTitle.Text = Message;
            newMessageBox.ShowDialog();
            return ButtonID;
        }
        public static string ShowBox(string Message,string Title)
        {
            newMessageBox = new MyMessageBox();
            newMessageBox.labelMsgTitle.Text = Title;
            newMessageBox.labelText.Text = Message;
            newMessageBox.ShowDialog();
            return ButtonID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ButtonID = "1";
            newMessageBox.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ButtonID = "2";
            newMessageBox.Dispose();
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            ToolTip showBtnToolTip = new ToolTip();
            showBtnToolTip.SetToolTip(btnCancel, "Kapat");
        }
    }
}
