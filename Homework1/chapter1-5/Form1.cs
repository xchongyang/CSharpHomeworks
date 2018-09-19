using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace chapter1_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt1 = textBox1.Text;
            string txt2 = textBox2.Text;
            string GetDoubNum = @"[+-]?\d+[\.]?\d*";
            string output1 = Regex.Match(txt1, GetDoubNum).Value;
            string output2 = Regex.Match(txt2, GetDoubNum).Value;
            double Num1 = double.Parse(output1);
            double Num2 = double.Parse(output2);
            double Productin = Num1 * Num2;
            string Pro = Productin.ToString();
            textBox3.Text = Pro;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
