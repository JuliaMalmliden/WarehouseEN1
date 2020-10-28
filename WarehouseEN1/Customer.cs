using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace WarehouseEN1
{
    public class Customer
    {
        private int customerID;
        private string name;      
        private string eMail;
        private string phoneN;

        public int CustomerID { get { return customerID; } set { customerID = value; } }
       // public string Name { get { return name; } set { name = value; } }
        public string EMail { get { return eMail; } set { eMail = value; } }
        public string PhoneN { get { return phoneN; } set { phoneN = value; } }

        Customer() { }

       public Customer(int id, string name, string em, string pn)
       {
            CustomerID = id;
            Name = name;
            EMail = em;
            PhoneN = pn;
       }
        public string Name
        {
            get { return name; }
            set
            {
               // if (string.IsNullOrWhiteSpace(value))
                //    throw new CustomerExceptions("Name cannot be null or empty.");
                //else
                    name = value;
            }
        }
        public override string ToString()
        {
            return "ID: " + CustomerID + "  Name:  " + Name  + "  Phone number:  " + phoneN + "   Email: " + eMail;

        }


    }

}