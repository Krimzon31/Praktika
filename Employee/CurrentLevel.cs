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
    public partial class CurrentLevel : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres", "310504", "EmployeeDB");

        private NpgsqlConnection connection;
        private string sql;
        private NpgsqlCommand command;
        private DataTable dataTable;
        private int rowIndex = -1;

        public CurrentLevel()
        {
            InitializeComponent();
        }

        private void CurrentLevel_Load(object sender, EventArgs e)
        {
            connection = new NpgsqlConnection(connstring);
            Select();
        }
        private void Select()
        {
            try
            {
                connection.Open();
                sql = @"select * from cl_select()";
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

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                sql = @"select * from cl_insert(:_currentlevel, :_updatedate, :_employee_id, :_skill_id)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_currentlevel", int.Parse(txtCurrentLevel.Text));
                command.Parameters.AddWithValue("_updatedate", DateTime.Parse(dtDateUpdate.Text));
                command.Parameters.AddWithValue("_employee_id", int.Parse(txtEmployeeId.Text));
                command.Parameters.AddWithValue("_skill_id", int.Parse(txtSkillId.Text));

                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Insert current level successfully");
                    rowIndex = -1;
                    sql = @"select * from cl_select()";
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

        private void Delete_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose entry to delete");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from cl_delete(:_cl_id)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_cl_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_cl_id"].Value.ToString()));
                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Delete entry successfully");
                    rowIndex = -1;
                    sql = @"select * from cl_select()";
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

        private void Update_Click(object sender, EventArgs e)
        {
            if (rowIndex < 0)
            {
                MessageBox.Show("Please choose task to update");
                return;
            }
            try
            {
                connection.Open();
                sql = @"select * from ts_update(:_cl_id, :_currentlevel, :_updatedate, :_employee_id, :_skill_id)";
                command = new NpgsqlCommand(sql, connection);
                command.Parameters.AddWithValue("_cl_id", int.Parse(dataGridView.Rows[rowIndex].Cells["_cl_id"].Value.ToString()));
                command.Parameters.AddWithValue("_currentlevel", int.Parse(txtCurrentLevel.Text));
                command.Parameters.AddWithValue("_updatedate", DateTime.Parse(dtDateUpdate.Text));
                command.Parameters.AddWithValue("_employee_id", int.Parse(txtEmployeeId.Text));
                command.Parameters.AddWithValue("_skill_id", int.Parse(txtSkillId.Text));


                if ((int)command.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Update tasks successfully");
                    rowIndex = -1;
                    sql = @"select * from cl_select()";
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

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                rowIndex = e.RowIndex;
                txtCurrentLevel.Text = dataGridView.Rows[e.RowIndex].Cells["_currentlevel"].Value.ToString();
                dtDateUpdate.Text = dataGridView.Rows[e.RowIndex].Cells["_updatedate"].Value.ToString();
                txtEmployeeId.Text = dataGridView.Rows[e.RowIndex].Cells["_employee_id"].Value.ToString();
                txtSkillId.Text = dataGridView.Rows[e.RowIndex].Cells["_skill_id"].Value.ToString();
            }
        }
    }
}
