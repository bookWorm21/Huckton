using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int i = 0;
        int[] coord = new int[36];
        public Form1()
        {
            
            
            for ( i = 0; i < coord.Length; i++)
            
                coord[i] = i + 1;
            i = 0;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random a = new Random();
            int A = a.Next(1, 7);
            Random b = new Random();
            int B = b.Next(1, 7);
            int dice = A + B;
            label1.Text = Convert.ToString(dice);
            i = i + dice;
            if (i < 36)
            {
                
                label2.Text = Convert.ToString(i);
            }
            else
            {
                i = - 35 + i;
                label2.Text = Convert.ToString(i);
            }
           
        }
    }
}
