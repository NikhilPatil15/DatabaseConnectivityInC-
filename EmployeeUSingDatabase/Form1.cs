using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EmployeeUSingDatabase
{
    public partial class Form1 : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-UATMUF1\\SQLEXPRESS;Initial Catalog=windowsForms;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void bind_data()
        {
            SqlCommand cmd = new SqlCommand("Select EmployeeID,FirstName,LastName,Salary from Emp_DB", connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd;
            DataTable table = new DataTable();
            table.Clear();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("arial",10,FontStyle.Bold);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bind_data();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd2 = new SqlCommand("Insert into Emp_DB(EmployeeID,FirstName,LastName,Salary) Values(@EmployeeID,@FirstName,@LastName,@Salary)", connection);
            cmd2.Parameters.AddWithValue("EmployeeID", int.Parse(textBox1.Text));
            cmd2.Parameters.AddWithValue("FirstName", textBox2.Text);
            cmd2.Parameters.AddWithValue("LastName", textBox3.Text);
            cmd2.Parameters.AddWithValue("Salary", int.Parse(textBox4.Text));

            connection.Open();
            cmd2.ExecuteNonQuery();
            connection.Close();

            bind_data();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand("Update Emp_DB Set FirstName = @FirstName, LastName=@LastName, Salary=@Salary Where EmployeeID = @EmployeeID",connection);
          
            cmd3.Parameters.AddWithValue("FirstName", textBox2.Text);
            cmd3.Parameters.AddWithValue("LastName", textBox3.Text);
            cmd3.Parameters.AddWithValue("Salary", int.Parse(textBox4.Text));
            cmd3.Parameters.AddWithValue("EmployeeID", int.Parse(textBox1.Text));

            connection.Open();
            cmd3.ExecuteNonQuery();
            connection.Close();

            bind_data();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd4 = new SqlCommand("Delete from Emp_DB where EmployeeID = @EmployeeID",connection);
            cmd4.Parameters.AddWithValue("EmployeeID", int.Parse(textBox1.Text));
            connection.Open();
            cmd4.ExecuteNonQuery();
            connection.Close();

            bind_data();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[index];
            textBox1.Text = row.Cells[0].Value.ToString();
            textBox2.Text = row.Cells[1].Value.ToString();
            textBox3.Text = row.Cells[2].Value.ToString();
            textBox4.Text = row.Cells[3].Value.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd5 = new SqlCommand("Select EmployeeID,FirstName,LastName,Salary from Emp_DB Where EmployeeID = @EmployeeID", connection);
            cmd5.Parameters.AddWithValue("EmployeeID", int.Parse(textBox5.Text));
            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = cmd5;
            DataTable table = new DataTable();
            table.Clear();
            dataAdapter.Fill(table);
            dataGridView1.DataSource = table;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 11, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.Font = new Font("arial", 10, FontStyle.Bold);
        }
    }
}
