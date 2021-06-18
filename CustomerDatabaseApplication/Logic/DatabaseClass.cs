using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CustomerDatabaseApplication
{
    class DatabaseClass
    {
        public string connectionString { get; set; }
        public string query { get; set; }
        public DataTable dt { get; set; }
        public DatabaseClass()
        {
            query = "SELECT Customers.Salutation, Customers.Title, Customers.FirstName, Customers.LastName,Adresses.Street, Adresses.Housenumber, Adresses.fk_PLZ, Cities.CityInternational, " +
              "Countries.CountryInternational, Customers.DateOfBirth, Genders.Gender, Customers.UIDNumber, PaymentTerms.PaymentTermTitle, Customers.Discount, Bankdata.pk_BankID, Bankdata.IBAN, Bankdata.BIC FROM Customers " +
              "INNER JOIN Adresses ON Customers.fk_AdressID = Adresses.pk_AdressID " +
              "INNER JOIN Genders ON Customers.fk_GenderID = Genders.pk_GenderID " +
              "INNER JOIN Countries ON Countries.pk_CountryID = Adresses.fk_CountryID " +
              "INNER JOIN Cities ON Cities.pk_PLZ = Adresses.fk_PLZ " +
              "INNER JOIN Bankdata ON Bankdata.pk_BankID = Customers.fk_BankID " +
              "INNER JOIN PaymentTerms ON PaymentTerms.pk_PaymentTermID = Customers.fk_PaymentTermID";
            connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB; Initial Catalog= KundendatenbankKMU; Integrated Security =true";
        }


        /*
         * Diese Funktion ist dazu da die höchste Zahl im Primary key
         * Attribut der Tabelle Customers zu finden
         */
        public int findHighestCustomerID()
        {
            int highestCustomerID = 0;
            query = "SELECT MAX(CustomerID) FROM Customers;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        highestCustomerID = reader.GetInt32(0);
                        Console.WriteLine(highestCustomerID);
                    }
            }
            return highestCustomerID + 1;
        }

        /*
         * Diese Funktion ist dazu da die höchste Zahl im Primary key
         * Attribut der Tabelle Adresses zu finden
         */

        public int findHighestAdressID()
        {
            int highestAdressID = 0;
            query = "SELECT MAX(pk_AdressID) FROM Adresses;";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        highestAdressID = reader.GetInt32(0);
                        Console.WriteLine(highestAdressID);
                    }
            }
            return highestAdressID + 1;
        }
        /*
         * Diese Methode ist dazu da, den Primary keys eines Genders herauszufinden
         */
        public int getGenderID(string gender)
        {
            int genderID = 0;
            query = "SELECT pk_GenderID FROM Genders WHERE Gender = '" + gender + "';";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        genderID = reader.GetInt32(0);
                        Console.WriteLine(genderID);
                    }
            }
            return genderID;
        }

        /*
         * Diese Methode ist dazu da, den Primary keys eines Landes herauszufinden
         */
        public string getCountryIDFromCountry(string country)
        {
            string countryID = "";
            query = "SELECT pk_CountryID FROM Countries WHERE CountryInternational = '" + country + "';";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        countryID = reader.GetString(0);
                        Console.WriteLine(countryID);
                    }
            }
            return countryID;
        }

        /*
         * Diese Methode ist dazu da, bereits vorhandene Daten
         * aus der Datenbank auszulesen als DataTable zurückzugeben
         */
        public DataTable fillCustomerData()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable fillOrdersData()
        {
            query = "SELECT Customers.FirstName, Customers.LastName, Products.Title, Orders.OrderDate, " +
                "ProductType.TypeTitle, Orders.pk_OrderID,OrderPositions.Amount, " +
                "OrderPositions.Amount* Products.Price AS Total, Products.Tax, " +
                "Products.fk_Currency, Orderstatus.OrderStatusTitle " +
                "FROM Orders " +
                "INNER JOIN Customers ON Customers.CustomerID = Orders.fk_CustomerID " +
                "INNER JOIN OrderPositions ON OrderPositions.fk_OrderID = Orders.pk_OrderID " +
                "INNER JOIN Products ON Products.pk_ProductID = OrderPositions.fk_ProductID " +
                "INNER JOIN ProductType ON ProductType.pk_TypeID = Products.fk_ProductType " +
                "INNER JOIN Orderstatus ON Orderstatus.pk_OrderStatusID = Orders.fk_OrderStatusID ";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    sqlConnection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        /*
         * Diese Funktion gibt alle Namen der Countries zurück
         */
        public List<string> getCountries()
        {
            List<string> countries = new List<string>();
            query = "SELECT CountryInternational FROM Countries";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            countries.Add(reader.GetString(i));
                        }
                    }
            }
            return countries;
        }

        public List<int> getProductIDs()
        {
            List<int> productIDs = new List<int>();
            query = "SELECT pk_ProductID FROM Products";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            productIDs.Add(reader.GetInt32(i));
                        }
                    }
            }
            return productIDs;
        }

        public List<string> getNameFromCustomerID(int customerID)
        {
            List<string> name = new List<string>();
            query = "SELECT Firstname, Lastname FROM Customers WHERE CustomerID = " + customerID;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            name.Add(reader.GetString(i));
                            Console.WriteLine(reader.GetString(i));
                        }
                    }
            }
            return name;
        }

        public int getPaymentTermIDFromPaymentTermTitle(string paymentTerm)
        {
            int paymentTermID = 0;
            query = "SELECT pk_PaymentTermID FROM PaymentTerms WHERE PaymentTermTitle = '" + paymentTerm + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        paymentTermID = reader.GetInt32(0);
                    }
            }
            Console.WriteLine(paymentTermID);
            return paymentTermID;
        }

        public int getOrderStateIDFromOrderStateTitle(string orderStatus)
        {
            int orderStatusID = 0;
            query = "SELECT pk_OrderStatusID FROM Orderstatus WHERE OrderStatusTitle = '" + orderStatus + "'";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        orderStatusID = reader.GetInt32(0);
                    }
            }
            Console.WriteLine(orderStatusID);
            return orderStatusID;
        }

        public DataTable addProduct(DataTable productAmountTable, Order order, int index)
        {
            DataRow newRow = productAmountTable.NewRow();
            newRow["OrderID"] = order.orderID;
            newRow["OrderPosition"] = order.orderPosition;
            newRow["Product"] = order.productIDs[index];
            newRow["Amount"] = order.productAmounts[index];
            productAmountTable.Rows.Add(newRow);

            return productAmountTable;
        }

        public List<int> getZipCodes(string country)
        {
            List<int> zipCodes = new List<int>();
            query = "SELECT Cities.pk_PLZ FROM Cities INNER JOIN Countries ON Cities.pk_CountryIDCity = Countries.pk_CountryID " +
                "WHERE Countries.CountryInternational = '" + country + "' ";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            zipCodes.Add(reader.GetInt32(i));
                        }
                    }
            }
            return zipCodes;
        }

        public int getMaxOrderID()
        {
            int maxOrderID = 0;
            query = "SELECT MAX(pk_OrderID) FROM Orders";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        maxOrderID = reader.GetInt32(0);
                    }
            }
            return maxOrderID;
        }


        /*
         * Diese Funktion gibt alle Namen der Genders zurück
         */
        public List<string> getGenders()
        {
            List<string> genders = new List<string>();
            query = "SELECT Gender FROM Genders";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            genders.Add(reader.GetString(i));
                        }
                    }
            }
            return genders;
        }

        public List<int> getCustomerIDs()
        {
            List<int> customerIDs = new List<int>();
            query = "SELECT CustomerID from Customers";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            customerIDs.Add(reader.GetInt32(i));
                        }
                    }
            }
            return customerIDs;
        }

        public List<string> getPaymentTerms()
        {
            List<string> PaymentTerms = new List<string>();
            query = "SELECT PaymentTermTitle FROM PaymentTerms";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            PaymentTerms.Add(reader.GetString(i));
                        }
                    }
            }
            return PaymentTerms;
        }

        public List<string> getOrderStatusTitle()
        {
            List<string> OrderStatusTitle = new List<string>();
            query = "SELECT OrderStatusTitle FROM Orderstatus";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            OrderStatusTitle.Add(reader.GetString(i));
                        }
                    }
            }
            return OrderStatusTitle;
        }

        public void addCustomerToDatabase(Customer dataFromCustomer)
        {
            string insertBankdata = "INSERT INTO Bankdata VALUES (@bank,@iban,@bic)";
            string insertAdresses = "INSERT INTO Adresses VALUES (@adressID, @street, @housenumber, @plz, @countryID)";
            string insertCustomer = "INSERT INTO Customers VALUES (@customerID, @firstname, @lastname, @salutation, @title, @birthday, @discount," +
                "@uid, @paymentterms, @genderID, @fkbank, @fkadressID)";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertBankdata, sqlConnection);
                command.Parameters.AddWithValue("@bank", dataFromCustomer.bank);
                command.Parameters.AddWithValue("@iban", dataFromCustomer.iban);
                command.Parameters.AddWithValue("@bic", dataFromCustomer.bic);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                command.CommandText = insertAdresses;
                command.Parameters.AddWithValue("@adressID", dataFromCustomer.adressID);
                command.Parameters.AddWithValue("@street", dataFromCustomer.street);
                command.Parameters.AddWithValue("@housenumber", dataFromCustomer.housenumber);
                command.Parameters.AddWithValue("@plz", dataFromCustomer.plz);
                command.Parameters.AddWithValue("@countryID", dataFromCustomer.countryID);
                command.ExecuteNonQuery();

                command.CommandText = insertCustomer;
                command.Parameters.AddWithValue("@customerID", dataFromCustomer.customerID);
                command.Parameters.AddWithValue("@firstname", dataFromCustomer.firstname);
                command.Parameters.AddWithValue("@lastname", dataFromCustomer.lastname);
                command.Parameters.AddWithValue("@salutation", dataFromCustomer.salutation);
                command.Parameters.AddWithValue("@title", dataFromCustomer.title);
                command.Parameters.AddWithValue("@birthday", dataFromCustomer.birthday);
                command.Parameters.AddWithValue("@discount", dataFromCustomer.discount);
                command.Parameters.AddWithValue("@uid", dataFromCustomer.uid);
                command.Parameters.AddWithValue("@paymentterms", dataFromCustomer.paymentterms);
                command.Parameters.AddWithValue("@genderID", dataFromCustomer.genderID);
                command.Parameters.AddWithValue("@fkbank", dataFromCustomer.bank);
                command.Parameters.AddWithValue("@fkadressID", dataFromCustomer.adressID);
                command.ExecuteNonQuery();
            }
        }

        public void addOrderToDatabase(Order order, bool isChecked)
        {
            string insertOrder = "INSERT INTO Orders VALUES (@OrderID,@OrderDate," +
                "@OrderStatus,@PaymentTermID, @ShippingAdressID, @InvoiceAdressID, @CustomerID)";
            string insertAdressShip = "INSERT INTO Adresses VALUES (@adressIDShip, @streetShip, @housenumberShip, " +
                "@plzShip, @countryIDShip)";
            string insertAdressInv = "INSERT INTO Adresses VALUES (@adressIDInv, @streetInv, @housenumberInv, " +
                "@plzInv, @countryIDInv)";


            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertAdressShip, sqlConnection);
                command.Parameters.AddWithValue("@adressIDShip", order.adressIDShip);
                command.Parameters.AddWithValue("@streetShip", order.streetShip);
                command.Parameters.AddWithValue("@housenumberShip", order.housenumberShip);
                command.Parameters.AddWithValue("@plzShip", order.plzShip);
                command.Parameters.AddWithValue("@countryIDShip", order.countryIDShip);
                sqlConnection.Open();
                command.ExecuteNonQuery();

                if (isChecked == false)
                {
                    command.CommandText = insertAdressInv;
                    command.Parameters.AddWithValue("@adressIDInv", order.adressIDInv);
                    command.Parameters.AddWithValue("@streetInv", order.streetInv);
                    command.Parameters.AddWithValue("@housenumberInv", order.housenumberInv);
                    command.Parameters.AddWithValue("@plzInv", order.plzInv);
                    command.Parameters.AddWithValue("@countryIDInv", order.countryIDInv);
                    command.ExecuteNonQuery();

                    command.CommandText = insertOrder;
                    command.Parameters.AddWithValue("@OrderID", order.orderID);
                    command.Parameters.AddWithValue("@OrderDate", order.orderDate);
                    command.Parameters.AddWithValue("@OrderStatus", order.orderStatusID);
                    command.Parameters.AddWithValue("@PaymentTermID", order.paymentTermID);
                    command.Parameters.AddWithValue("@ShippingAdressID", order.adressIDShip);
                    command.Parameters.AddWithValue("@InvoiceAdressID", order.adressIDInv);
                    command.Parameters.AddWithValue("@CustomerID", order.customerID);
                    command.ExecuteNonQuery();
                }
                else
                {
                    command.CommandText = insertOrder;
                    command.Parameters.AddWithValue("@OrderID", order.orderID);
                    command.Parameters.AddWithValue("@OrderDate", order.orderDate);
                    command.Parameters.AddWithValue("@OrderStatus", order.orderStatusID);
                    command.Parameters.AddWithValue("@PaymentTermID", order.paymentTermID);
                    command.Parameters.AddWithValue("@ShippingAdressID", order.adressIDShip);
                    command.Parameters.AddWithValue("@InvoiceAdressID", order.adressIDShip);
                    command.Parameters.AddWithValue("@CustomerID", order.customerID);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void addProductsToDatabase(Order order)
        {
            string insertProducts = "INSERT INTO Products VALUES (@ProductID, @Title," +
                "@Price,@Tax, @Stockamount, @Currency, @ProductTypeID)";

            /*
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                foreach (int productID in order.productIDs)
                {
                    SqlCommand command = new SqlCommand(insertProducts, sqlConnection);
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@Title", order.);
                    command.Parameters.AddWithValue("@Price", order.housenumberShip);
                    command.Parameters.AddWithValue("@Tax", order.plzShip);
                    command.Parameters.AddWithValue("@Stockamount", order.countryIDShip);
                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
            */
        }
    }
}

