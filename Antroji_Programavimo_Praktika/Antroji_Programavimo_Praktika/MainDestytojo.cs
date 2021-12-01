using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Antroji_Programavimo_Praktika
{
    public partial class MainDestytojo : Form
    {
        public MainDestytojo()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();

        private void MainDestytojo_Load(object sender, EventArgs e)
        {
            fillGrid(new MySqlCommand("SELECT `id`, `vardas`, `pavarde`, `grupe`, `pazimys` FROM `studentas`"));
        }

        public void fillGrid(MySqlCommand command)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = student.getStudents(command);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT `id`, `vardas`, `pavarde`, `grupe`, `pazimys` FROM `studentas` WHERE CONCAT (`grupe`) LIKE'%" + textBoxGrupesPaieska.Text + "%'";
            MySqlCommand command = new MySqlCommand(query);
            fillGrid(command);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            PazimysForm forma = new PazimysForm();
            forma.textBoxIDa.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            forma.textBoxPazVardas.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            forma.textBoxPazPavarde.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            forma.textBoxPazGrupe.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            forma.textBoxPazimys.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();


            forma.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand command = new MySqlCommand("SELECT `id`, `vardas`, `pavarde`, `grupe`, `pazimys` FROM `studentas`");
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 40;
            dataGridView1.DataSource = student.getStudents(command);
            dataGridView1.AllowUserToAddRows = false;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){}
    }
}
