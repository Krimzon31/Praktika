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
using System.Xml.Linq;

namespace Employee
{
    public partial class Skills : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres", "310504", "EmployeeDB");

        private NpgsqlConnection connection;
        private string sql;
        private NpgsqlCommand command;
        private DataTable dataTable;
        private int rowIndex = -1;
        public Skills()
        {
            InitializeComponent();
        }

        private void Skills_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(connstring);
            Select();
        }

        private void Select()
        {
            try
            {
                connection.Open();
                sql = @"select * from sk_select()";
                command = new NpgsqlCommand(sql, connection);
                dataTable = new DataTable();
                dataTable.Load(command.ExecuteReader());
                connection.Close();
                dataGridView.DataSource = null;
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                txtName.Text = dataGridView.Rows[e.RowIndex].Cells["_sk_name"].Value.ToString();
                txtDescription.Text = dataGridView.Rows[e.RowIndex].Cells["_description"].Value.ToString();
                txtMandatorySing.Text = dataGridView.Rows[e.RowIndex].Cells["_mandatorysing"].Value.ToString();
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                sql = @"select * from sk_insert(:_sk_name, :_description, :_mandatorysing)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_sk_name", txtName.Text);
                command.Parameters.AddWithValue("_description", txtDescription.Text);
                command.Parameters.AddWithValue("_mandatorysing", txtMandatorySing.Text);
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Insert skill successfully");
                    rowIndex = -1;
                    sql = @"select * from sk_select()";
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
            connection.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose skill to update");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from sk_update(:_sk_id, :_sk_name, :_description, :_mandatorysing)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_sk_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_sk_id"].Value.ToString()));
                command.Parameters.AddWithValue("_sk_name", txtName.Text);
                command.Parameters.AddWithValue("_description", txtDescription.Text);
                command.Parameters.AddWithValue("_mandatorysing", txtMandatorySing.Text);

                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Update tasks successfully");
                    rowIndex = -1;
                    sql = @"select * from sk_select()";
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

        private void delete_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose skill to delete");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from sk_delete(:_sk_id)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_sk_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_sk_id"].Value.ToString()));
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Delete skill successfully");
                    rowIndex = -1;
                    sql = @"select * from sk_select()";
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
