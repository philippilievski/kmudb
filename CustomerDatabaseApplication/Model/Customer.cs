using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerDatabaseApplication
{
    class Customer
    {
        public int customerID { get; set; }
        public string salutation { get; set; }
        public string title { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string street { get; set; }
        public int housenumber { get; set; }
        public int plz { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string countryID { get; set; }
        public int adressID { get; set; }
        public DateTime birthday { get; set; }
        public int genderID { get; set; }
        public string gender { get; set; }
        public int uid { get; set; }
        public string paymentterms { get; set; }
        public decimal discount { get; set; }
        public int bank { get; set; }
        public int iban { get; set; }
        public int bic { get; set; }
    }
}
