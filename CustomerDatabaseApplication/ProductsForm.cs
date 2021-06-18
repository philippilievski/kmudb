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
    public partial class ProductsForm : Form
    {
        DatabaseClass databaseClass = new DatabaseClass();
        DataTable productAmountTable = new DataTable("Products");
        Order order = new Order();
        int index = 0;

        public ProductsForm()
        {
            InitializeComponent();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBoxAmount.Text))
            {
                MessageBox.Show("Bitte geben Sie die Anzahl der Produkte ein!");
            }
            else if (String.IsNullOrEmpty(CmbBoxProduct.Text))
            {
                MessageBox.Show("Bitte wählen Sie ein Produkt aus der Liste aus!");
            }
            else
            {
                order.productID = Convert.ToInt32(CmbBoxProduct.Text);
                order.productAmount = Convert.ToInt32(txtBoxAmount.Text);
                order.orderPosition++;
                order.productTitle = 
            }
        }
    }
}
