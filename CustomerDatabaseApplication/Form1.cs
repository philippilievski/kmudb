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

namespace CustomerDatabaseApplication
{
    public partial class Form1 : Form
    {
        public string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog= KundendatenbankKMU; Integrated Security =true";
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Diese Methode wird beim laden der Form ausgeführt und schreibt
         * die Daten des DataTables in das DataGridView
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            DatabaseClass database = new DatabaseClass();
            database.dt = database.fillCustomerData();
            ShowData.DataSource = database.dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerForm addValues = new CustomerForm();
            addValues.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            order.ShowDialog();
        }

        private void btnShowOrders_Click(object sender, EventArgs e)
        {
            ShowOrdersForm showOrdersForm = new ShowOrdersForm();
            showOrdersForm.ShowDialog();
        }
    }
}
