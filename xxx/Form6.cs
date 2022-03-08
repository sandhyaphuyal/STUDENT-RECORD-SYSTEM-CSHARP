using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace xxx
{
    public partial class Form6 : Form
    {
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N12RONL;Initial Catalog=studentfinale;Integrated Security=True");
        int id;
        public Form6(int getid)
        {
            this.id = getid;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GENDER_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string q = "Select  * from Table_27 where id=" + id;
            SqlDataAdapter sda = new SqlDataAdapter(q, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

                textBox1.Text = dt.Rows[0]["ID"].ToString();
                textBox4.Text = dt.Rows[0]["ADDRESS"].ToString();
                textBox3.Text = dt.Rows[0]["GENDER"].ToString();
                textBox2.Text = dt.Rows[0]["NAME"].ToString();
                textBox5.Text = dt.Rows[0]["CONTACT"].ToString();
                textBox6.Text = dt.Rows[0]["DOB"].ToString();
                textBox7.Text = dt.Rows[0]["FACULTY"].ToString();
                textBox8.Text = dt.Rows[0]["EMAIL"].ToString();
                if (File.Exists(dt.Rows[0]["file_path"].ToString()))
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(dt.Rows[0]["file_path"].ToString());
                }

                q = "Select * from Table_1 where student_id=" + id;
                sda = new SqlDataAdapter(q, sqlConnection);
                dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    textBox13.Text = dt.Rows[0]["MOTHER_NAME"].ToString();
                    textBox14.Text = dt.Rows[0]["FATHER_NAME"].ToString();
                    textBox12.Text = dt.Rows[0]["FATHERS_CONTACTNO"].ToString();
                    textBox11.Text = dt.Rows[0]["MOTHERS_CONTACTNO"].ToString();
                    textBox10.Text = dt.Rows[0]["MOTHERS_OCCUPATION"].ToString();
                    textBox9.Text = dt.Rows[0]["FATHERS_OCCUPATION"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Record Not Found");
                this.Hide();
                Form3 main = new Form3();
                main.Show();

            }


            sqlConnection.Close();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
               // Bitmap bmp = new Bitmap(this.panel1.Width, this.panel1.Height);
              //  this.panel1.DrawToBitmap(bmp, new Rectangle(0, 0, this.panel1.Width, this.panel1.Height));
                //e.Graphics.DrawImage((Image)bmp, 0, 5);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += this.printDocument1_PrintPage;
            PrintDialog dlgSettings = new PrintDialog();
            dlgSettings.Document = doc;
            if (dlgSettings.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        
    }
}
