using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public class CustomerCatalogue
    {
        public OrderCatalogue orderCatalogue;

        public delegate void ChangeHandler();
        public List<Customer> Customers { get; set; }
        private string filename;
        public event ChangeHandler CatalogueChanged;
        public int currentCustID;

        public CustomerCatalogue()
        {
          //  this.orderCatalogue = orderCatalogue;
            filename = "Customer.JSON";
            ReadCustomersFromFile();

            CurrentCustomerID();
        }
        //new 28/10 error in program /
        //public CustomerCatalogue()
        //{
        //}

        /// <summary>
        /// Private function to call the event in order to avoid repeating the null check.
        /// </summary>
        public void CurrentCustomerID()
        {
            if (Customers.Count == 0)
            {
                currentCustID = 0;
            }
            else
            {
                currentCustID = Customers.Count;
            }
        }
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

        public bool AddCustomer(string name, string phone,string email)
        {
            currentCustID++;
            try
            {
                Customer obj = new Customer(currentCustID, name, phone, email);
                Customers.Add(obj);
                WriteCustomersToFile();
                RaiseCatalogueChanged();
                return true;
            }
            catch
            {
                return false;
            }
        }

        Customer FindCustomer(string name) 
        {
            foreach (Customer obj in Customers)
                if (obj.Name == name)
                    return obj;
            return null;
        }
        Customer GetCustomerbyID(int id)		//DONT NEED THIS
        {
            foreach (Customer obj in Customers)
                if (obj.CustomerID == id)
                {
                    return obj;
                }

            return null; 
        }

        public bool RemoveCustomerID(int custID)		//safest to use id incase customers have the same name 
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
                return false;
            }

        }

        public bool UpdateCustomer(int custID, string name, string ph, string email) //maybe split to own functions for each
        {
                try
                {
                    Customer customer = Customers.Single(c => c.CustomerID == custID); //????whyyyyy
                                                                                       //Customer obj = FindCustomer(name);

                    customer.Name = name;
                    customer.EMail = email;
                    customer.PhoneN = ph;
                    WriteCustomersToFile();
                    RaiseCatalogueChanged();
                    return true;
                }
                catch
                {
                    return false;
                }
        }


    }
}
