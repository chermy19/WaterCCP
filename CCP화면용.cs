using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterCCP
{
    public partial class CCP화면용 : Form
    {
        double x;

        public CCP화면용()
        {
            InitializeComponent();
        }

        private void CCP화면용_Load(Object sender, EventArgs e)
        {
            button1.Text = "Start";
            timer1.Tick += timer1_Tick;
            timer1.Interval = 50;

            chart2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            chart2.Series[0].Points.AddXY(x, 3 * Math.Sin(5 * x) + 5 * Math.Cos(3 * x));

            if (chart2.Series[0].Points.Count > 100)
                chart2.Series[0].Points.RemoveAt(0);

            chart2.ChartAreas[0].AxisX.Minimum = chart2.Series[0].Points[0].XValue;
            chart2.ChartAreas[0].AxisX.Maximum = x;

            x += 0.1;
        }

        private void buttion1_Click(object sender, EventArgs e)
        {
            if(timer1.Enabled)
            {
                timer1.Stop();
                button1.Text = "Start";
            }
            else
            {
                timer1.Start();
                button1.Text = "Stop";
            }
        }
    }
}
