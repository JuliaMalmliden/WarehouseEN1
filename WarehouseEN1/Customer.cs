using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace WarehouseEN1
{
    /// <summary>
    /// This class is the mold for creating a customer.
    /// The customer purpose is to define what properties a customer have to have and to protect the integrity of these. 
    /// </summary>
    public class Customer
    {
        private int customerID;
        private string name;
        private string eMail;
        private string phoneN;
        public int CustomerID { get { return customerID; } set { customerID = value; } }
        private int  count;

        Customer() { }

        public Customer(int id, string name, string pn, string em)
        {
            CustomerID = id;
            Name = name;
            EMail = em;
            PhoneN = pn;
        }
        /// <summary>
        /// This method ¨validate the name. 
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (value == null || value == "")
                {
                   throw new CustomerExceptions("Name cannot be null or empty");
                }
                else
                    name = value;
            }
        }
        /// <summary>
        /// This method validate the email. 
        /// </summary>
        public string EMail
        {
            get { return eMail; }
            set
            {
                if (value != null)
                {
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] == '@' || value[i] == '.')
                        {
                            count++;
                        }
                    }
                }
                if (count !=2 || value == " ")
                {
                    throw new CustomerExceptions("Invalid email, please try again.");
                }
                else
                    eMail = value;

            }
        }
        /// <summary>
        /// This method validate the phonenumber. 
        /// </summary>
        public string PhoneN
        {
            get { return phoneN; }
            set
            {
                if (value == null || value == " " || value.Length <10)
                {
                    throw new CustomerExceptions("Invalid phone number.");
                }
                else
                    phoneN = value;
            }
        }
        /// <summary>
        /// This method converts the single object to a string. 
        /// </summary>
        public override string ToString()
        {
            return "ID: " + CustomerID + "  Name:  " + Name  + "  Phone number:  " + phoneN + "   Email: " + eMail;

        }


    }

}