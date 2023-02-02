using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee
{
    public partial class EmployeeF : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres", "310504", "EmployeeDB");

        private NpgsqlConnection connection;
        private string sql;
        private NpgsqlCommand command;
        private DataTable dataTable;
        private int rowIndex = -1;

        public EmployeeF()
        {
            InitializeComponent();
        }

        private void EmployeeF_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(connstring);
            Select();
        }
        private void Select()
        {
            try
            {
                connection.Open();
                sql = @"select * from em_select()";
                command = new NpgsqlCommand(sql, connection);
                dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                connection.Close();
                dataGridView.DataSource = null;
                dataGridView.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                connection.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                textSurname.Text = dataGridView.Rows[e.RowIndex].Cells["_surname"].Value.ToString();
                textName.Text = dataGridView.Rows[e.RowIndex].Cells["_em_name"].Value.ToString();
                textPatronimic.Text = dataGridView.Rows[e.RowIndex].Cells["_patronymic"].Value.ToString();
                textDateOfBirth.Text = dataGridView.Rows[e.RowIndex].Cells["_dateofbirth"].Value.ToString();
                textPost.Text = dataGridView.Rows[e.RowIndex].Cells["_post"].Value.ToString();
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                sql = @"select * from em_insert(:_surname, :_name, :_patronimic, :_dateofbirth, :_post)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_surname", textSurname.Text);
                command.Parameters.AddWithValue("_name", textName.Text);
                command.Parameters.AddWithValue("_patronimic", textPatronimic.Text);
                command.Parameters.AddWithValue("_dateofbirth", DateTime.Parse(textDateOfBirth.Text));
                command.Parameters.AddWithValue("_post", textPost.Text);

                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Insert student successfully");
                    rowIndex = -1;
                    sql = @"select * from em_select()";
                    command = new NpgsqlCommand(sql, connection);
                    dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dataTable;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("Insert fail. Error: " + ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose employee to update");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from em_update(:_id, :_surname, :_name, :_patronimic, :_dateofbirth, :_post)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_id"].Value.ToString()));
                command.Parameters.AddWithValue("_surname", textSurname.Text);
                command.Parameters.AddWithValue("_name", textName.Text);
                command.Parameters.AddWithValue("_patronimic", textPatronimic.Text);
                command.Parameters.AddWithValue("_dateofbirth", DateTime.Parse(textDateOfBirth.Text));
                command.Parameters.AddWithValue("_post", textPost.Text);

                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Update student successfully");
                    rowIndex = -1;
                    sql = @"select * from em_select()";
                    command = new NpgsqlCommand(sql, connection);
                    dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dataTable;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("Update fail. Error: " + ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose employee to delete");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from em_delete(:_id)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_id"].Value.ToString()));
                if((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Delete tasks successfully");
                    rowIndex = -1;
                    sql = @"select * from em_select()";
                    command = new NpgsqlCommand(sql, connection);
                    dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dataTable;
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("Delete fail. Error: " + ex.Message);
            }
        }

    }
}
