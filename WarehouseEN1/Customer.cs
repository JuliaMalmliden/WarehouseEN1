using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;


namespace WarehouseEN1
{
    public class Customer
    {
        private int customerID;
        private string name;
        private string eMail;
        private string phoneN;
        public int CustomerID { get { return customerID; } set { customerID = value; } }

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
                if (value == null || value == "")
                { }
                else
                    name = value;
            }
        }
        public string EMail
        {
            get { return eMail; }
            set 
            {
                //for (int i = 0; i < eMail.Length-1; i++)
                //{
                //    if (eMail[i] == '@' )
                //    {
                //       // i++,
                //    }
                       
                //}
                if (value == null || value == "")
                { }
                else
                { eMail = value; }

            }

        }

        public string PhoneN
        {
            get { return phoneN; }
            set
            {
                if (value == null || value == "")
                { }
                else
                    phoneN = value;
            }
        }
        public override string ToString()
        {
            return "ID: " + CustomerID + "  Name:  " + Name  + "  Phone number:  " + phoneN + "   Email: " + eMail;

        }


    }

}