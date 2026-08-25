using System;
using System.Collections;
using System.Windows.Forms;

namespace QueueingForm
{
    public partial class CashierWindowQueueForm : Form
    {
        private Timer timer1 = new Timer();

        public CashierWindowQueueForm()
        {
            InitializeComponent();
            SetupTimer();
        }

        private void SetupTimer()
        {
            timer1.Interval = 1000; 
            timer1.Tick += new EventHandler(timer1_tick);
            timer1.Start();
        }

        private void timer1_tick(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        public void DisplayCashierQueue(IEnumerable CashierList)
        {
            listCashierQueue.Items.Clear();
            foreach (Object obj in CashierList)
            {
                listCashierQueue.Items.Add(obj.ToString());
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue();
                DisplayCashierQueue(CashierClass.CashierQueue);

                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is CustomerView)
                    {
                        ((CustomerView)openForm).UpdateNowServing();
                    }
                }
            }
            else
            {
                MessageBox.Show("Wala nang tao sa pila!");
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue();

                DisplayCashierQueue(CashierClass.CashierQueue);

                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is CustomerView)
                    {
                        ((CustomerView)openForm).UpdateNowServing();
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wala nang tao sa pila!");
            }
        }

        private void CashierWindowQueueForm_Load(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }
    }
}
