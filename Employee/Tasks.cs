using Npgsql;
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

namespace Employee
{
    public partial class Tasks : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres", "310504", "EmployeeDB");

        private NpgsqlConnection connection;
        private string sql;
        private string sql1;
        private string sql2;
        private NpgsqlCommand command;
        private NpgsqlCommand command1;
        private NpgsqlCommand command2;
        private DataTable dataTable;
        private int rowIndex = -1;
        private int tc = 0;
        private int cl = 0;

        public Tasks()
        {
            InitializeComponent();
        }

        private void Tasks_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(connstring);
            Select();
        }
        private void Select()
        {
            try
            {
                connection.Open();
                sql = @"select * from ts_select()";
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
                txtName.Text = dataGridView.Rows[e.RowIndex].Cells["_ts_name"].Value.ToString();
                txtDescription.Text = dataGridView.Rows[e.RowIndex].Cells["_description"].Value.ToString();
                txtEmployeeId.Text = dataGridView.Rows[e.RowIndex].Cells["_employee_id"].Value.ToString();
                txtSkillId.Text = dataGridView.Rows[e.RowIndex].Cells["_skill_id"].Value.ToString();
                txtDateOfCreation.Text = dataGridView.Rows[e.RowIndex].Cells["_dateofcreation"].Value.ToString();
                txtStartDate.Text = dataGridView.Rows[e.RowIndex].Cells["_startdate"].Value.ToString();
                txtDateOfCompletion.Text = dataGridView.Rows[e.RowIndex].Cells["_dateofcompletion"].Value.ToString();
                txtCompletionSign.Text = dataGridView.Rows[e.RowIndex].Cells["_completionsign"].Value.ToString();
                txtTaskComplexity.Text = dataGridView.Rows[e.RowIndex].Cells["_taskcomplexity"].Value.ToString();
            }
        }

        private void insert_Click(object sender, EventArgs e)
        { 
            if (txtCompletionSign.Text == "yes" | txtCompletionSign.Text ==  "no") {
                try
                {
                    connection.Open();
                    sql = @"select * from ts_insert(:_ts_name, :_description, :_employee_id, :_skill_id, :_dateofcreation, :_startdate, :_dateofcompletion, :_completionsign, :_taskcomplexity)";
                    command = new NpgsqlCommand(sql, connection);
                    command.Parameters.AddWithValue("_ts_name", txtName.Text);
                    command.Parameters.AddWithValue("_description", txtDescription.Text);
                    command.Parameters.AddWithValue("_employee_id", int.Parse(txtEmployeeId.Text));
                    command.Parameters.AddWithValue("_skill_id", int.Parse(txtSkillId.Text));
                    command.Parameters.AddWithValue("_dateofcreation", DateTime.Parse(txtDateOfCreation.Text));
                    command.Parameters.AddWithValue("_startdate", DateTime.Parse(txtStartDate.Text));
                    command.Parameters.AddWithValue("_dateofcompletion", DateTime.Parse(txtDateOfCompletion.Text));
                    command.Parameters.AddWithValue("_completionsign", txtCompletionSign.Text);
                    command.Parameters.AddWithValue("_taskcomplexity", int.Parse(txtTaskComplexity.Text));
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("Insert fail. Error: " + ex.Message);
                }
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Insert task successfully");
                    rowIndex = -1;
                    sql = @"select * from ts_select()";
                    command = new NpgsqlCommand(sql, connection);
                    dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    connection.Close();
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = dataTable;
                }
            }
            else
            {
                MessageBox.Show("В поле _completionsign можно занасить только значения yes или no");
            }

        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose tasks to delete");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from ts_delete(:_ts_id)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_ts_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_ts_id"].Value.ToString()));
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Delete tasks successfully");
                    rowIndex = -1;
                    sql = @"select * from ts_select()";
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

        private void update_Click(object sender, EventArgs e)
        {
            if (txtCompletionSign.Text == "yes" | txtCompletionSign.Text == "no")
            {
                try
            {
                connection.Open();
                sql = @"select * from ts_update(:_ts_id, :_ts_name, :_description, :_employee_id, :_skill_id, :_dateofcreation, :_startdate, :_dateofcompletion, :_completionsign, :_taskcomplexity)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_ts_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_ts_id"].Value.ToString()));
                command.Parameters.AddWithValue("_ts_name", txtName.Text);
                command.Parameters.AddWithValue("_description", txtDescription.Text);
                command.Parameters.AddWithValue("_employee_id", int.Parse(txtEmployeeId.Text));
                command.Parameters.AddWithValue("_skill_id", int.Parse(txtSkillId.Text));
                command.Parameters.AddWithValue("_dateofcreation", DateTime.Parse(txtDateOfCreation.Text));
                command.Parameters.AddWithValue("_startdate", DateTime.Parse(txtStartDate.Text));
                command.Parameters.AddWithValue("_dateofcompletion", DateTime.Parse(txtDateOfCompletion.Text));
                command.Parameters.AddWithValue("_completionsign", txtCompletionSign.Text);
                command.Parameters.AddWithValue("_taskcomplexity", int.Parse(txtTaskComplexity.Text));
                else
                {
                    MessageBox.Show("not good");
                }

                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Update tasks successfully");
                    rowIndex = -1;
                    sql = @"select * from ts_select()";
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
            else
            {
                MessageBox.Show("В поле _completionsign можно занасить только значения yes или no");
            }
        }
    }
}
