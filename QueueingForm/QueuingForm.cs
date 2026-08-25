using System;
using System.Windows.Forms;

namespace QueueingForm
{
    public partial class Form1 : Form
    {
        private CashierClass cashier = new CashierClass();

        public Form1()
        {
            InitializeComponent();
            cashier = new CashierClass();

            InitializeComponent();
            cashier = new CashierClass();

            lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
            CashierClass.getNumberInQueue = lblQueue.Text;
            CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);

            CashierWindowQueueForm cashierWindow = new CashierWindowQueueForm();
            cashierWindow.Show();

            CustomerView customerWindow = new CustomerView();
            customerWindow.Show();
        }

        private void btnCashier_Click(object sender, EventArgs e)
        {
            lblQueue.Text = cashier.CashierGeneratedNumber("P - ");
            CashierClass.getNumberInQueue = lblQueue.Text;
            CashierClass.CashierQueue.Enqueue(CashierClass.getNumberInQueue);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
