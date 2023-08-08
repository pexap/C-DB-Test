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

namespace Database_SQL_Test
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Documents\\Code\\Database SQL Test\\Database SQL Test\\Database.mdf\";Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("Insert into Employees values (@ID, @Name, @Age)", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@Name", textBox2.Text);
            command.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            command.ExecuteNonQuery(); 

            connection.Close();
            MessageBox.Show("Successfully Saved");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Documents\\Code\\Database SQL Test\\Database SQL Test\\Database.mdf\";Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("Update Employees set Name = @Name, Age = @Age where ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@Name", textBox2.Text);
            command.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Documents\\Code\\Database SQL Test\\Database SQL Test\\Database.mdf\";Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("Delete Employees where ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Documents\\Code\\Database SQL Test\\Database SQL Test\\Database.mdf\";Integrated Security=True");
            connection.Open();

            SqlCommand command = new SqlCommand("Select * from Employees", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }
}
