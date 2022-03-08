using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xxx
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "project" && textBox2.Text == "******")
            {
                this.Hide();
                Form3 main = new Form3();
                main.Show();
            }
            else
            {
                MessageBox.Show("sorry!given information isnt correct!!!");
            }
        }
    }
}
