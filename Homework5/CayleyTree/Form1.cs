using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CayleyTree
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        public int Degree1 { get; set; }
        public int Degree2 { get; set; }
        public double Per1 { get; set; }
        public double Per2 { get; set; }
        public double Leng { get; set; }
        public int N { get; set; }

        BindingSource pens = new BindingSource();


        public Form1()
        {
            InitializeComponent();
            Degree1 = 30; Degree2 = 20; Per1 = 0.6; Per2 = 0.7; Leng = 100; N = 10;
            pens.Add(new { Name = "黑色", Value = Pens.Black });
            pens.Add(new { Name = "绿色", Value = Pens.Green });
            pens.Add(new { Name = "红色", Value = Pens.Red });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = pens;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Value";

            txtDegree1.DataBindings.Add("Text", this, "Degree1");
            txtDegree2.DataBindings.Add("Text", this, "Degree2");
            txtPer1.DataBindings.Add("Text", this, "Per1");
            txtPer2.DataBindings.Add("Text", this, "Per2");
            txtLength.DataBindings.Add("Text", this, "Leng");
            txtN.DataBindings.Add("Text", this, "N");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.panel2.CreateGraphics();
            graphics.Clear(panel2.BackColor);
            drawCayleyTree(N, panel2.Width / 2, panel2.Height - 20, Leng, -Math.PI / 2);
        }

        void drawCayleyTree(int n,
                double x0, double y0, double leng, double th)
        {
            if (n == 0) return;
            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);
            double x2 = x1 - leng / 2 * Math.Cos(th);
            double y2 = y1 - leng / 2 * Math.Sin(th);
            graphics.DrawLine((Pen)comboBox1.SelectedValue,
               (int)x0, (int)y0, (int)x1, (int)y1);

            drawCayleyTree(n - 1, x1, y1, Per1 * leng, th + Degree1 * Math.PI / 180);
            drawCayleyTree(n - 1, x2, y2, Per2 * leng, th - Degree2 * Math.PI / 180);
        }

    }
}
