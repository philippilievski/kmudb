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
    public partial class CustomerForm : Form
    {

        public CustomerForm()
        {
            InitializeComponent();
        }

        /*
         * Diese Methode wird ausgeführt wenn die Form geladen wird
         * Diese Methode holt sich die Daten aus der Datenbank und fügt diese in
         * Comboboxen ein
         */
        private void AddValues_Load(object sender, EventArgs e)
        {
            List<string> countries = new List<string>();
            List<string> genders = new List<string>();
            DatabaseClass databaseClass = new DatabaseClass();
            countries = databaseClass.getCountries();
            genders = databaseClass.getGenders();
            
            foreach (var country in countries)
            {
                cmbBoxCountry.Items.Add(country);
            }
            foreach(var gender in genders)
            {
                cmbBoxGender.Items.Add(gender);
            }
        }
        /*
         * Diese Methode wird ausgeführt wenn der Button Add geclickt wird
         * Diese Methode fügt die Daten aus den Eingabefeldern und Comboboxen
         * in die Felder der Klasse datafromcustomer ein
         */
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DatabaseClass databaseclass = new DatabaseClass();
            Customer dataFromCustomer = new Customer();
            dataFromCustomer.adressID = databaseclass.findHighestAdressID();
            dataFromCustomer.firstname = txtBoxFirstName.Text;
            dataFromCustomer.lastname = txtBoxLastName.Text;
            dataFromCustomer.salutation = txtBoxSalutation.Text;
            dataFromCustomer.street = txtBoxStreet.Text;
            dataFromCustomer.plz = Convert.ToInt32(txtBoxZipCode.Text);
            dataFromCustomer.housenumber = Convert.ToInt32(txtBoxHousenumber.Text);
            dataFromCustomer.title = txtBoxTitle.Text;
            dataFromCustomer.gender = cmbBoxGender.Text;
            dataFromCustomer.uid = Convert.ToInt32(txtBoxUIDNumber.Text);
            dataFromCustomer.paymentterms = txtBoxPaymentTerms.Text;
            dataFromCustomer.country = cmbBoxCountry.Text;
            dataFromCustomer.birthday = dateTimePickerBirthday.Value;
            dataFromCustomer.discount = Convert.ToDecimal(txtBoxDiscount.Text);
            dataFromCustomer.bank = Convert.ToInt32(txtBoxBank.Text);
            dataFromCustomer.bic = Convert.ToInt32(txtBoxBIC.Text);
            dataFromCustomer.iban = Convert.ToInt32(txtBoxIBAN.Text);
            dataFromCustomer.countryID = databaseclass.getCountryIDFromCountry(cmbBoxCountry.Text);
            dataFromCustomer.genderID = databaseclass.getGenderID(cmbBoxGender.Text);
            dataFromCustomer.customerID = databaseclass.findHighestCustomerID();

            databaseclass.addCustomerToDatabase(dataFromCustomer);
        }
    }
}
