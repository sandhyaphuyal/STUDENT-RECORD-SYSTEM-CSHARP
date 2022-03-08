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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        bool selected = false;
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N12RONL;Initial Catalog=studentfinale;Integrated Security=True");
        private void Form4_Load(object sender, EventArgs e)
        {
            displayData();
            // TODO: This line of code loads data into the 'studentDataSet.Table_1' table. You can move, or remove it, as needed.
            //this.telephoneTableAdapter.Fill(this.studentDataSet.Table_1);
        }
        //selected = false;
        private void displayData()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }

            string q = "Select  * from Table_1";
            SqlDataAdapter sda = new SqlDataAdapter(q, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
            string student_id = this.textBox2.Text;

            string query = "Select  * from Table_27 where id=" + student_id;
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                string FATHER_NAME = textBox3.Text;
                string MOTHER_NAME = textBox4.Text;
                string FATHERS_CONTACTNO = textBox5.Text;
                string MOTHERS_CONTACTNO = textBox6.Text;
                string MOTHERS_OCCUPATION = textBox7.Text;
                string FATHERS_OCCUPATION = textBox8.Text;

                string q = "INSERT INTO Table_1(student_id,FATHER_NAME, MOTHER_NAME,FATHERS_CONTACTNO,MOTHERS_CONTACTNO, MOTHERS_OCCUPATION, FATHERS_OCCUPATION) values ('" + student_id + "','" + FATHER_NAME + "','" + MOTHER_NAME + "','" + FATHERS_CONTACTNO + "','" + MOTHERS_CONTACTNO + "','" + MOTHERS_OCCUPATION + "','" + FATHERS_OCCUPATION + "')";
                SqlCommand command = new SqlCommand(q, sqlConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("saved");
                displayData();
            }
            else
            {
                MessageBox.Show("Student ID doesn't exists.");
            }
            sqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ID"].Value);
                sqlConnection.Open();
                string q = "DELETE from Table_1 where ID='" + ID + "'";
                SqlCommand command = new SqlCommand(q, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                displayData();
                MessageBox.Show("deleted");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            string ID = this.textBox2.Text;

            string STUDENT_NAME = textBox2.Text;

            string FATHER_NAME = textBox3.Text;
            string MOTHER_NAME = textBox4.Text;
            string FATHERS_CONTACTNO = textBox5.Text;
            string MOTHERS_CONTACTNO = textBox6.Text;
            string FATHERS_OCCUPATION = textBox7.Text;
            string MOTHERS_OCCUPATION = textBox8.Text;
            string q = "Update Table_1 set   FATHER_NAME='" + FATHER_NAME + "',MOTHER_NAME='" + MOTHER_NAME + "',FATHERS_CONTACTNO='" + FATHERS_CONTACTNO + "', FATHERS_OCCUPATION='" + FATHERS_OCCUPATION + "', MOTHERS_OCCUPATION='" + MOTHERS_OCCUPATION + "'where student_id='" + ID + "'";

            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("RECORD UPDATED SUCCESSFULLY!!!");
            sqlConnection.Close();
            displayData();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox5_Leave(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_keypress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)/*&&(e.KeyChar!!='.')*/)
            {
                e.Handled = true;
            }
        }
    }
}
   