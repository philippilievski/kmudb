using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatabaseApplication
{
    class Order
    {
        public List<int> productIDs { get; set; }
        public List<int> productAmounts { get; set; }

        public int customerID { get; set; }
        public int productID { get; set; }
        public int productAmount { get; set; }
        public string productTitle { get; set; }
        public int orderID { get; set; }
        public int orderPosition { get; set; }
        public DateTime orderDate { get; set; }


        public string streetShip { get; set; }
        public int housenumberShip { get; set; }
        public int plzShip { get; set; }
        public string cityShip { get; set; }
        public string countryShip { get; set; }
        public string countryIDShip { get; set; }


        public string streetInv { get; set; }
        public int housenumberInv { get; set; }
        public int plzInv { get; set; }
        public string cityInv { get; set; }
        public string countryInv { get; set; }
        public string countryIDInv { get; set; }



        public int adressIDShip { get; set; }
        public int adressIDInv { get; set; }

        public int paymentTermID { get; set; }
        public int orderStatusID { get; set; }
    }
}
