using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public class OrderCatalogue
    {
        public delegate void OrderChangeHandler();
        public CustomerCatalogue customerCatalogue;
        public ProductCatalogue productCatalogue;
        public List<Order> Orders { get; set; }
        private string filename;
        public event OrderChangeHandler CatalogueChanged;
        public int currentOrderID;
        private List<Order> NonDispatchedorders; 
        public OrderCatalogue(CustomerCatalogue customerCatalogue, ProductCatalogue productCatalogue)
        {          
            this.customerCatalogue = customerCatalogue;
            this.productCatalogue = productCatalogue; 
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
        public void BatchProcessOrders()
        {
            // Sortera beställningar efter datum och tid.(tänker att de tidigaste beställningarna ska hanteras först..?  
            //Reducera stock anpassat efter Order. 
            // Om alla produkter i en order är tillgängliga så ändras Orders "Dispatched" till true.
            IEnumerable<Order> query = from order in Orders
                                       where order.Dispatched == false
                                       select order;
            foreach (Order order in query)
            {
                NonDispatchedorders.Add(order);
            }
            //foreach(Order order in NonDispatchedorders)
            //{
            //  if(order.Items.Contains(Product.Stock == 0)
            //}
            List<DateTime> dates = new List<DateTime>();
            foreach (Order o in NonDispatchedorders)
            {
                dates.Add(o.OrderDate); 
            }
            DateTime minDate = dates.Min();
            IEnumerable<Order> query2 = from order in NonDispatchedorders
                                        where order.OrderDate == minDate
                                        select order; 
            

                                        //IEnumerable<Product> query = from prod in prodCatalogue.Products
                                        // where prod.NextRestock == minDate
                                        // select prod;


            WriteOrdersToFile();
        }

    }
}
