using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    public class CustomerCatalogue
    {
        public delegate void ChangeHandler();
        public List<Customer> Customers { get; set; }
        private string filename;
        public event ChangeHandler CatalogueChanged;	
        public CustomerCatalogue()
        {
            filename = "Customer.JSON";
            ReadCustomersFromFile();
        }

        /// <summary>
        /// Private function to call the event in order to avoid repeating the null check.
        /// </summary>
        private void RaiseCatalogueChanged()
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }

        private void WriteCustomersToFile()
        {
            string contents = JsonSerializer.Serialize(Customers);
            File.WriteAllText(filename, contents);
        }
        private void ReadCustomersFromFile()
        {
            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                Customers = JsonSerializer.Deserialize<List<Customer>>(fileContents);
            }
            else Customers = new List<Customer>();
        }

        public void AddCustomer(Customer obj)
        {
            Customers.Add(obj);
            WriteCustomersToFile();
            RaiseCatalogueChanged();
        }

        Customer FindCustomer(string fname, string lname) 
        {
            foreach (Customer obj in Customers)
                if (obj.Fname == fname && obj.Lname == lname)
                    return obj;
            return null;
        }
        Customer GetCustomerbyID(int id)		//raise exeption if no customer
        {
            foreach (Customer obj in Customers)
                if (obj.CustomerID == id)
                {
                    return obj;
                }

            return null; 
        }

        public bool RemoveCustomer(int custID)		//safest to use id incase customers have the same name 
        {
            if (GetCustomerbyID(custID) != null)
            {
                Customer obj = GetCustomerbyID(custID);
                Customers.Remove(obj);
                WriteCustomersToFile();
                return true;
            }
			else
            {
				//raise exception
                return false;
            }

        }

        public bool UpdateCustomer(int custID, string fname, string lname, string email) //maybe split to own functions for each
        {
            if (GetCustomerbyID(custID) != null)
            {
                Customer obj = GetCustomerbyID(custID);
                obj.Fname = fname;
                obj.Lname = lname;
                obj.EMail = email;
                WriteCustomersToFile();
                return true;
            }
            else
            {
                //raise exception
                return false;
            }
        }





    }
}
