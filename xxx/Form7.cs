using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xxx
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        public SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-N12RONL;Initial Catalog=studentfinale;Integrated Security=True");
        string file_path;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 main = new Form3();
            main.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void save_Click(object sender, EventArgs e)
        {
            //  user = name1.Text;
            //  MessageBox.Show(user, "username");
            //  String kalu = studentidnumber.Text;
            //  MessageBox.Show(kalu, "id");
            //  fathername = fathersname1.Text;
            //  MessageBox.Show(fathername, "fathername");

            //String contact = contact1.Text;
            //  MessageBox.Show(contact1,"contact");`e


            sqlConnection.Open();
            int id;
            string  NAME = textBox2.Text;
            string ADDRESS = textBox4.Text;
            string EMAIL = textBox8.Text;
            DateTime DOB= Convert.ToDateTime(dateTimePicker1.Text);
        
            string ID= textBox1.Text;
            string CONTACT = textBox5.Text;
            string FACULTY = comboBox1.Text;
            string GENDER = " ";
            if (radioButton1.Checked == true)
            {
               GENDER = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                GENDER = radioButton2.Text;
            }
            string path = "";
            if (file_path != "" && file_path!=null)
            {
                path = Path.Combine(@"C:\Users\DELL\source\repos\xxx\xxx\Images\", Path.GetFileName(file_path));
                File.Copy(file_path, path, true);
            }
            string q = "INSERT INTO Table_27(ID,NAME,ADDRESS,EMAIL,DOB,CONTACT,FACULTY,GENDER,file_path) values ('" + ID + "','" + NAME + "','" + ADDRESS + "','" + EMAIL+ "','" + DOB + "','" + CONTACT+ "','"+FACULTY+"','"+GENDER+"','"+path+"')";


            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("saved");
            sqlConnection.Close();

            displayData();

        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dr == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                sqlConnection.Open();
                string q = "DELETE from Table_27 where id='" + id + "'";
                SqlCommand command = new SqlCommand(q, sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                displayData();
                MessageBox.Show("deleted");
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            displayData();
        }
        private void displayData()
        {
            sqlConnection.Open();
            string q = "Select  * from Table_27";
            SqlDataAdapter sda = new SqlDataAdapter(q, sqlConnection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            sqlConnection.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog()==DialogResult.OK)
            {
                file_path = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(file_path);
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells["FACULTY"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["EMAIL"].Value.ToString();
            string img_path = dataGridView1.CurrentRow.Cells["file_path"].Value.ToString();
            if (File.Exists(img_path))
            {
                pictureBox1.Image = Image.FromFile(img_path);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            
            string NAME = textBox2.Text;
            string ADDRESS = textBox4.Text;
            string EMAIL = textBox8.Text;
            DateTime DOB = Convert.ToDateTime(dateTimePicker1.Text);

            string ID = textBox1.Text;
            string CONTACT = textBox5.Text;
            string FACULTY = comboBox1.Text;
            string GENDER = " ";
            if (radioButton1.Checked == true)
            {
                GENDER = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                GENDER = radioButton2.Text;
            }




            string q = "Update Table_27 set  NAME='"+NAME+"',ADDRESS='"+ADDRESS+"',FACULTY='"+FACULTY+"',GENDER='"+GENDER+"',EMAIL='"+EMAIL+"',CONTACT='"+CONTACT+"' where ID='"+ID+"'";

            SqlCommand command = new SqlCommand(q, sqlConnection);
            command.ExecuteNonQuery();
            MessageBox.Show("RECORD UPDATED SUCCESSFULLY!!!");
            sqlConnection.Close();
            displayData();
           
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            Form6 form6 = new Form6(id);
            form6.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //bool n = isvalid_name(textBox2.Text);
            //bool c = isvalid_cnic(txtCnic.Text);
            //bool em = isvalid_EMAIL(textBox8.Text);

            //isvalid_webAddress(txtWebAdress.Text);
        }
       

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_Leave(object sender, EventArgs e)
        {
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!reg.IsMatch(textBox8.Text))
            {
                errorProvider1.SetError(textBox8,
                "Please enter valid email.");
                textBox8.Focus();
            }
            else
            {
                errorProvider1.SetError(textBox8, "");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox5_keypress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar)&&!char.IsDigit(e.KeyChar)/*&&(e.KeyChar!!='.')*/)
            {
                e.Handled = true;
            }
        }
    }
}
