using System;
using System.Windows.Forms;

namespace QueueingForm
{
    public partial class CustomerView : Form
    {
        public CustomerView()
        {
            InitializeComponent();
        }

        private void CustomerView_Load(object sender, EventArgs e)
        {
            UpdateNowServing();
        }

        public void UpdateNowServing()
        {
            if (CashierClass.CashierQueue != null && CashierClass.CashierQueue.Count > 0)
            {
                lblNowServing.Text = CashierClass.CashierQueue.Peek();
            }
            else
            {
                lblNowServing.Text = "P - -----";
            }
        }
    }
}
