using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    public class OrderCatalogue
    {
        public delegate void OrderChangeHandler();
        public CustomerCatalogue customerCatalogue;
        public List<Order> Orders { get; set; }
        private string filename;
        public event OrderChangeHandler CatalogueChanged;
        public int currentOrderID;
        private Customer c;
        public OrderCatalogue(CustomerCatalogue customerCatalogue)
        {          
            this.customerCatalogue = customerCatalogue; 
            filename = "Order.JSON";
            ReadOrdersFromFile();

            CurrentOrderID();
        }
        private void RaiseCatalogueChanged() //to check if a change was made and if so update the catalogue
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }

        public void CurrentOrderID()
        {
            if (Orders.Count == 0)
            {
                currentOrderID = 0;
            }
            else
            {
                currentOrderID = Orders.Count;
            }
        }
        private void WriteOrdersToFile()
        {
            string contents = JsonSerializer.Serialize(Orders);
            File.WriteAllText(filename, contents);
        }
        private void ReadOrdersFromFile()
        {
            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                Orders = JsonSerializer.Deserialize<List<Order>>(fileContents);
            }
            else Orders = new List<Order>();
        }
        public bool AddOrder(Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted) //string productRestock)
        {
            currentOrderID++;
            try
            {
                //for (int i = 0; i< customerCatalogue.Customers.Count; i++)
                //{
                //    int customerID = customerCatalogue.Customers.ElementAt(i).CustomerID; 
                //    if (customer == customerID)
                //    {
                //        c = customerCatalogue.Customers.ElementAt(i);
                //    }
                //}


                Order order = new Order(currentOrderID, c, deliveryaddress, orderlist, date, paymentcompleted);
                Orders.Add(order);
                WriteOrdersToFile();
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
