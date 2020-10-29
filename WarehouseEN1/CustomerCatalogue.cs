using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WarehouseEN1
{
    /// <summary>
    /// This class is a list of customers and customerfunctions.
    /// The customercatalogue contain functions related to the customer objects. 
    /// </summary>
    public class CustomerCatalogue
    {
        public OrderCatalogue orderCatalogue;

        public delegate void CustomerChangeHandler();
        public List<Customer> Customers { get; set; }
        private string filename;
        public event CustomerChangeHandler CatalogueChanged;
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

        public void AddCustomer(string name, string phone,string email)
        {
            currentCustID++;
            Customer obj = new Customer(currentCustID, name, phone, email);
            Customers.Add(obj);
            WriteCustomersToFile();
            RaiseCatalogueChanged();
            
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

        public bool RemoveCustomerID(int custID)
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

        public void UpdateCustomer(int custID, string name, string ph, string email)
        {

            Customer customer = Customers.Single(c => c.CustomerID == custID); 

            customer.Name = name;
            customer.EMail = email;
            customer.PhoneN = ph;
            WriteCustomersToFile();
            RaiseCatalogueChanged();
            
        }


    }
}
