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
    public partial class Form1 : Form
    {
        private string connstring = String.Format("Server={0};Port={1};" +
            "User id={2};Password={3};Database={4};",
            "localhost", 5432, "postgres", "310504", "EmployeeDB");


        private NpgsqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }

        private void Employee_Click(object sender, EventArgs e)
        {
            EmployeeF Employee_form = new EmployeeF();
            Employee_form.Show();
        }

        private void Skill_Click(object sender, EventArgs e)
        {
            Skills skills_form = new Skills();
            skills_form.Show();
        }

        private void Task_Click(object sender, EventArgs e)
        {
            Tasks Tasks_form = new Tasks();
            Tasks_form.Show();
        }

        private void CurrentLevel_Click(object sender, EventArgs e)
        {
            CurrentLevel Current_Level = new CurrentLevel();
            Current_Level.Show();
        }
    }
}
