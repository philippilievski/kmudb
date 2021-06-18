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

namespace CustomerDatabaseApplication
{
    public partial class OrderForm : Form
    {
        bool checkBoxChecked = false;
        DatabaseClass databaseClass = new DatabaseClass();
        List<string> name = new List<string>();
        DataTable productAmountTable = new DataTable("Products");
        Order order = new Order();
        int index = 0;

        public OrderForm()
        {
            InitializeComponent();

        }
        private void OrderForm_Load(object sender, EventArgs e)
        {
            order.orderPosition = 0;
            order.orderID = databaseClass.getMaxOrderID() + 1;
            order.productIDs = new List<int>();
            order.productAmounts = new List<int>();
            DataColumn orderIDColumn = new DataColumn("OrderID", typeof(Int32));
            DataColumn orderPosColumn = new DataColumn("OrderPosition", typeof(Int32));
            DataColumn productColumn = new DataColumn("Product", typeof(Int32));
            DataColumn amountColumn = new DataColumn("Amount", typeof(Int32));

            productAmountTable.Columns.Add(orderIDColumn);
            productAmountTable.Columns.Add(orderPosColumn);
            productAmountTable.Columns.Add(productColumn);
            productAmountTable.Columns.Add(amountColumn);
            dataGridViewShowProducts.DataSource = productAmountTable;

            List<int> customerIDs = new List<int>();
            List<int> productIDs = new List<int>();
            List<string> countries = new List<string>();
            List<string> paymentTerms = new List<string>();
            List<string> orderStatusTitle = new List<string>();
            customerIDs = databaseClass.getCustomerIDs();
            productIDs = databaseClass.getProductIDs();
            countries = databaseClass.getCountries();
            paymentTerms = databaseClass.getPaymentTerms();
            orderStatusTitle = databaseClass.getOrderStatusTitle();
            foreach (int customerID in customerIDs)
            {
                cmbBoxCustomerID.Items.Add(customerID);
            }
            foreach (int productID in productIDs)
            {
                CmbBoxProduct.Items.Add(productID);
            }
            foreach(string country in countries)
            {
                cmbBoxCountryInvoiceAdr.Items.Add(country);
                cmbBoxCountryShipAdr.Items.Add(country);
            }
            foreach(string paymentterm in paymentTerms)
            {
                cmbBoxPaymentTerms.Items.Add(paymentterm);
            }
            foreach(string orderstatus in orderStatusTitle)
            {
                cmbBoxOrderStatus.Items.Add(orderstatus);
            }
        }

        private void checkBoxSameAsShippingAdr_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxChecked == false)
            {
                txtBoxCityInvoiceAdr.Enabled = false;
                cmbBoxZipCodeInvoiceAdr.Enabled = false;
                cmbBoxCountryInvoiceAdr.Enabled = false;
                numericUpDownHousenumberInvoiceAdr.Enabled = false;
                txtBoxStreetInvoiceAdr.Enabled = false;
                checkBoxChecked = true;
            }
            else
            {
                txtBoxCityInvoiceAdr.Enabled = true;
                cmbBoxZipCodeInvoiceAdr.Enabled = true;
                cmbBoxCountryInvoiceAdr.Enabled = true;
                numericUpDownHousenumberInvoiceAdr.Enabled = true;
                txtBoxStreetInvoiceAdr.Enabled = true;
                checkBoxChecked = false;
            }
        }

        private void cmbBoxCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            name = databaseClass.getNameFromCustomerID(Convert.ToInt32(cmbBoxCustomerID.Text));
            lblFirstName.Text = name[0];
            lblLastName.Text = name[1];
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtBoxAmount.Text))
            {
                MessageBox.Show("Bitte geben Sie die Anzahl der Produkte ein!");
            }
            else if(String.IsNullOrEmpty(CmbBoxProduct.Text))
            {
                MessageBox.Show("Bitte wählen Sie ein Produkt aus der Liste aus!");
            }
            else
            {
                order.productIDs.Add(Convert.ToInt32(CmbBoxProduct.Text));
                order.productAmounts.Add(Convert.ToInt32(txtBoxAmount.Text));
                order.orderPosition++;
                productAmountTable = databaseClass.addProduct(productAmountTable, order, index);
                index++;
                dataGridViewShowProducts.DataSource = productAmountTable;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.Update(productAmountTable);
                foreach (DataRow dataRow in productAmountTable.Rows)
                {
                    Console.WriteLine("Neuer Datensatz");
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        private void cmbBoxCountryShipAdr_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbBoxZipCodeShipAdr.Items.Clear();
            List<int> zipCodes = databaseClass.getZipCodes(cmbBoxCountryShipAdr.Text);
            foreach(int zipcode in zipCodes)
            {
                CmbBoxZipCodeShipAdr.Items.Add(zipcode);
            }
        }

        private void cmbBoxCountryInvoiceAdr_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbBoxZipCodeInvoiceAdr.Items.Clear();
            List<int> zipCodes = databaseClass.getZipCodes(cmbBoxCountryInvoiceAdr.Text);
            foreach (int zipcode in zipCodes)
            {
                cmbBoxZipCodeInvoiceAdr.Items.Add(zipcode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(cmbBoxCustomerID.Text))
            {
                MessageBox.Show("Bitte wählen Sie einen Kunden aus!");
            }
            else
            {
                order.customerID = Convert.ToInt32(cmbBoxCustomerID.Text);
                order.streetShip = txtBoxStreetShipAdr.Text;
                order.housenumberShip = Convert.ToInt32(numericUpDownHousenumberShipAdr.Value);
                order.plzShip = Convert.ToInt32(CmbBoxZipCodeShipAdr.Text);
                order.cityShip = txtBoxCityShipAdr.Text;
                order.countryShip = cmbBoxCountryShipAdr.Text;
                order.countryIDShip = databaseClass.getCountryIDFromCountry(order.countryShip);
                order.adressIDShip = databaseClass.findHighestAdressID();
                order.orderDate = DateTime.Now;    

                if (checkBoxSameAsShippingAdr.Checked)
                {
                    order.streetInv = order.streetShip;
                    order.housenumberInv = order.housenumberShip;
                    order.plzInv = order.plzShip;
                    order.cityInv = order.cityShip;
                    order.countryInv = order.countryShip;
                    order.countryIDInv = order.countryIDShip;
                    order.adressIDInv = order.adressIDShip + 1;
                }
                else
                {
                    order.streetInv = txtBoxStreetInvoiceAdr.Text;
                    order.housenumberInv = Convert.ToInt32(numericUpDownHousenumberInvoiceAdr.Value);
                    order.plzInv = Convert.ToInt32(cmbBoxZipCodeInvoiceAdr.Text);
                    order.cityInv = txtBoxCityInvoiceAdr.Text;
                    order.countryInv = cmbBoxCountryInvoiceAdr.Text;
                    order.countryIDInv = databaseClass.getCountryIDFromCountry(order.countryInv);
                    order.adressIDInv = databaseClass.findHighestAdressID() + 1;
                }

                order.paymentTermID = databaseClass.getPaymentTermIDFromPaymentTermTitle(cmbBoxPaymentTerms.Text);
                order.orderStatusID = databaseClass.getOrderStateIDFromOrderStateTitle(cmbBoxOrderStatus.Text);

                databaseClass.addOrderToDatabase(order, checkBoxSameAsShippingAdr.Checked);
                ShowOrdersForm showOrdersForm = new ShowOrdersForm();
                this.Close();
                showOrdersForm.Show();
            }
        }
    }
}
