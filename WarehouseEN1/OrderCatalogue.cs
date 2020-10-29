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

            foreach (Order order in Orders)
            {
                //  var cid = order.Customer.Name; //works with customer name, email, and phone. something wrong with id.
                //  order.Customer = customerCatalogue.Customers.Single(c => c.Name == cid);

                var cid = order.Customer.CustomerID;    //Name works
                order.Customer = customerCatalogue.Customers.Single(c => c.CustomerID == cid);

                foreach (OrderLine ol in order.Items)
                {
                    var pid = ol.OrderedProduct.ProductID;
                    ol.OrderedProduct = productCatalogue.Products.Single(p => p.ProductID == pid);
                }
            }
        }
        public void AddOrder(Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted) //string productRestock)//Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted) //string productRestock)
        {
            currentOrderID++;

                //for (int i = 0; i< customerCatalogue.Customers.Count; i++)
                //{
                //    int customerID = customerCatalogue.Customers.ElementAt(i).CustomerID; 
                //    if (customer == customerID)
                //    {
                //        c = customerCatalogue.Customers.ElementAt(i);
                //    }
                //}

                //customer
                Order order = new Order(currentOrderID, customer, deliveryaddress, orderlist, date, paymentcompleted);
                Orders.Add(order);
                WriteOrdersToFile();
                RaiseCatalogueChanged();

        }
        public void BatchProcessOrders()
        {
            var orders = Orders.Where(o => !o.Dispatched && o.PaymentCompleted && o.Items.All(o => o.OrderedProduct.ProductStock >= o.Count)); //o=> o.OrderedProduct.FirstAvailableDate <= DateTime.Now)// kan vara att datetime ska vara mindre 
            orders = orders.OrderByDescending(o => o.OrderDate);
            foreach(Order order in orders)
            {
                try
                {
                    foreach (OrderLine orderline in order.Items)
                    {
                        var pid = orderline.OrderedProduct.ProductID;
                        var count = orderline.Count;
                        var product = productCatalogue.Products.Single(p => p.ProductID == pid);
                        product.ProductStock -=  count;

                    }
                    order.DispatchOrder();
                }
                catch
                {

                }

            }

            RaiseCatalogueChanged();
            WriteOrdersToFile();
        }
        public void DisplayPreviousOrers(Customer cust)
        {
            IEnumerable<Order> query = from ord in Orders
                                       where ord.Customer.CustomerID == cust.CustomerID
                                       select ord;

        }

    }
}
