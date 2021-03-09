using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cur
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private double rub = 100000;
        private double usd = 0;
        const double k = 0.05;
        private double rate = 0;
        int days = 0;
        Random random = new Random();
        int i = 1;

        private void btStart_Click(object sender, EventArgs e)
        {
            i = 1;
            rate = (double)edRate.Value;
            days = (int)edDays.Value;
            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, rate);
            timer1.Start();
        }

        private void btBuy_Click(object sender, EventArgs e)
        {
            if (rub >= getPrice())
            {
                rub -= getPrice();
                usd++;
                rubValue.Text = Math.Round(rub, 2).ToString();
                usdValue.Text = Math.Round(usd, 2).ToString();
            }
        }

        private void btSell_Click(object sender, EventArgs e)
        {
            if (usd > 0)
            {
                rub += getPrice();
                usd--;
                rubValue.Text = Math.Round(rub, 2).ToString();
                usdValue.Text = Math.Round(usd, 2).ToString();
            }
        }

        public double getPrice()
        {
            return rate;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            
            rate = rate * (1 + k * (random.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(i, rate);
            
            if (i >= days) {
                timer1.Stop();
            }
        }
    }
}
