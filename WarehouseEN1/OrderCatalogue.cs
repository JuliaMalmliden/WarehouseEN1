using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    class OrderCatalogue
    {
        public delegate void OrderChangeHandler();
        public List<Order> Orders { get; set; }
        private string filename;
        public event OrderChangeHandler CatalogueChanged;
        public int currentOrderID;

        private void RaiseCatalogueChanged() //to check if a change was made and if so update the catalogue
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }

        public void CurrentProductID()
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
        private void WriteProductsToFile()
        {
            string contents = JsonSerializer.Serialize(Orders);
            File.WriteAllText(filename, contents);
        }
        private void ReadProductsFromFile()
        {
            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                Orders = JsonSerializer.Deserialize<List<Order>>(fileContents);
            }
            else Orders = new List<Order>();
        }
        public bool AddOrder(Customer customer, string deliveryaddress, List<Product> orderlist, DateTime date, bool paymentcompleted) //string productRestock)
        {
            currentOrderID++;
            try
            {
                Order order = new Order(currentOrderID, customer, deliveryaddress, orderlist, date, paymentcompleted);
                Orders.Add(order);
                WriteProductsToFile();
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
