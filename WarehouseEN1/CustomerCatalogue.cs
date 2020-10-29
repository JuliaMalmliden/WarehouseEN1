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
        /// this methos keeps track of the current customerID.
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
         /// <summary>
        /// This method check for null and calls the event. 
        /// </summary>
        private void RaiseCatalogueChanged()
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }
        /// <summary>
        ///  This method writes down the Customerlist to a JSON-file, and uses the file as the programs database for the customerinformation.
        /// </summary>
        private void WriteCustomersToFile()
        {
            string contents = JsonSerializer.Serialize(Customers);
            File.WriteAllText(filename, contents);
        }
        /// <summary>
        /// This method extract the customerlist from the JASON-file, and splits the list into objects of customer. 
        /// </summary>
        private void ReadCustomersFromFile()
        {

            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                Customers = JsonSerializer.Deserialize<List<Customer>>(fileContents);
            }
            else Customers = new List<Customer>();
        }
        /// <summary>
        /// This method recieves the information it needs to create an object of sort customer and saves it to the customerlist, it also saves it to the "database". 
        /// </summary>
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
        /// <summary>
        /// This method recieves new customerinformation and finds the matching customerobject based on ID and overrides the old information in the list and the database.
        /// </summary>
        public void UpdateCustomer(int custID, string name, string ph, string email)
        {

            Customer customer = Customers.Single(c => c.CustomerID == custID); 

            customer.Name = name;
            customer.PhoneN = ph;
            customer.EMail = email;
            WriteCustomersToFile();
            RaiseCatalogueChanged();
            
        }


    }
}
