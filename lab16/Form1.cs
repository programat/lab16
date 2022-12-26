using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Construction_16
{
    public partial class Form1 : Form
    {
        GraphPane graphPane1;
        public Form1()
        {
            InitializeComponent();
            
            Main();
        }

        void  Main()
        {
            graphPane1 = zedGraphControl1.GraphPane;
            double a = 0;
            double b = 0;
            PointPairList pplr = new PointPairList();
            LineItem liner = graphPane1.AddCurve("Lag curve", pplr, Color.Red, SymbolType.None);

            try
            {
                a = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            double y;
            for (double x = 1; x <= 3; x += 0.1)
            {
                y = a / x + Math.Sqrt(x*x - 1);
                PointPair ppr = new PointPair(x, y);
                pplr.Add(ppr);
            }
            zedGraphControl1.AxisChange();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphPane1 = zedGraphControl1.GraphPane;
            graphPane1.CurveList.Clear();
            double a = 0;
            double b = 0;

            PointPairList pplr = new PointPairList();
            PointPairList pplmin = new PointPairList();
            PointPairList pplmax = new PointPairList();

            try {
                a = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            double n_min = 0, n_max = 0, n = 0;
            double f = 1;
            double y = a / f + Math.Sqrt(f*f - 1); ;
            double y_min = y;
            double y_max = -y;

            for (double x = 1; x <= 3; x += 0.1)
            {
                y = a / x + Math.Sqrt(x*x - 1);
                PointPair ppr = new PointPair(x, y);
                pplr.Add(ppr);

                if (y <= y_min)
                {
                    y_min = y;
                    n_min = x;
                }
                if (y >= y_max)
                {
                    y_max = y;
                    n_max = x;
                }
                n++;

            }

            for(int i = 0; i < 2; i++)
            {
                pplmax.Add(n_max, y_max*i);
            }

            for (int i = 0; i < 2; i++)
            {
                pplmin.Add(n_min, y_min*i);
            }


            LineItem liner = graphPane1.AddCurve("Curve", pplr, Color.Black, SymbolType.None);
            LineItem liner_min = graphPane1.AddCurve("Min", pplmin, Color.SteelBlue, SymbolType.None);
            LineItem liner_max = graphPane1.AddCurve("MAx", pplmax, Color.DarkRed, SymbolType.None);

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
