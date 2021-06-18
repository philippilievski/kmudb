using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerDatabaseApplication
{
    public partial class ShowOrdersForm : Form
    {
        public ShowOrdersForm()
        {
            InitializeComponent();
        }

        private void ShowOrdersForm_Load(object sender, EventArgs e)
        {
            DatabaseClass database = new DatabaseClass();
            database.dt = database.fillOrdersData();
            dataGridShowOrders.DataSource = database.dt;
        }
    }
}
