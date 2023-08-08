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
            datagrid_update();
        }

        SqlConnection connection = new SqlConnection("Data Source=(LocalDB)" +
            "\\MSSQLLocalDB;AttachDbFilename=\"D:\\Documents\\Code\\Database SQL Test" +
            "\\Database SQL Test\\Database.mdf\";Integrated Security=True");
        SqlCommand command = new SqlCommand();

        void datagrid_update()
        {
            connection.Open();

            command = new SqlCommand("Select * from Employees", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
        }

        private void btn_insert(object sender, EventArgs e)
        {
            connection.Open();

            command = new SqlCommand("Insert into Employees values (@ID, @Name, @Age)", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@Name", textBox2.Text);
            command.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            command.ExecuteNonQuery(); 

            connection.Close();
            datagrid_update();
        }

        private void btn_update(object sender, EventArgs e)
        {
            connection.Open();

            command = new SqlCommand("Update Employees set Name = @Name, Age = @Age where ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@Name", textBox2.Text);
            command.Parameters.AddWithValue("@Age", int.Parse(textBox3.Text));
            command.ExecuteNonQuery();

            connection.Close();
            datagrid_update();
        }

        private void btn_delete(object sender, EventArgs e)
        {
            connection.Open();

            command = new SqlCommand("Delete Employees where ID = @ID", connection);
            command.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            command.ExecuteNonQuery();

            connection.Close();
            datagrid_update();
        }

        private void btn_search(object sender, EventArgs e)
        {
            connection.Open();

            command = new SqlCommand("Select * from Employees", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable= new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            connection.Close();
            datagrid_update();
        }
    }
}
