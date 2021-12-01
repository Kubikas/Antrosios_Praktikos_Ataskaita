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
    public partial class MainStudento : Form
    {
        public MainStudento()
        {
            InitializeComponent();
        }

        STUDENT student = new STUDENT();
        DESTYTOJAS destytojas = new DESTYTOJAS();
        private void MainStudento_Load(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT `dalykas` FROM `destytojas`"));
            fillGrid(new MySqlCommand("SELECT `pazimys` FROM `destytojas`"));
        }

        public void fillGrid1(MySqlCommand command)
        {
            dataGridViewDalykas.ReadOnly = true;
            dataGridViewDalykas.RowTemplate.Height = 40;
            //dataGridViewDalykas.Width = 400;
            dataGridViewDalykas.DataSource = student.getStudents(command);

        }
        public void fillGrid(MySqlCommand command)
        {
            dataGridViewPazimys.ReadOnly = true;
            dataGridViewPazimys.RowTemplate.Height = 40;
            //dataGridViewPazimys.Width = 200;
            dataGridViewPazimys.DataSource = student.getStudents(command);

        }
    }
}
