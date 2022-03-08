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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application deals with adding,editing,searching and deleting students records!!!","About Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Application is developed by Sandhya Phuyal,Himsikha Bhandari,Bishakha Pradhan and Sakschi Nakarmi!!", "About Developer", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
