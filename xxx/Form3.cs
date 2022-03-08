using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace xxx
{
    public partial class Form3 : Form
    {
        string iID;
        string NAME;
        string GENDER;
        string CONTACT;
        string DOB;
        string EMAIL;
        string FACULTY;
        public Form3()
        {
            InitializeComponent();
        }
        bool selected = false;
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N12RONL;Initial Catalog=studentfinale;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'studentDataSet.Table_1' table. You can move, or remove it, as needed.
            //this.Table_27TableAdapter.Fill(this.studentDataSet.Table_27);

            //selected = false;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 main = new Form7();
            main.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form8 main = new Form8();
            main.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void search_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            this.Hide();
            Form6 main = new Form6(id);
            main.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 main = new Form4();
            main.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
