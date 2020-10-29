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
    /// This class is a list of orders and orderfunctions.
    /// The ordercatalogue contain functions related to the order objects. 
    /// </summary>
    public class OrderCatalogue : IOrderCatalogue
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
        /// <summary>
        /// This method check for null and calls the event.
        /// </summary>
        private void RaiseCatalogueChanged() 
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }
        /// <summary>
        /// This method keeps track of the current orderID.
        /// </summary>
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
        /// <summary>
        /// This method writes down the orderlist to a JSON-file, and uses the file as the programs database for the orderinformation.
        /// </summary>
        private void WriteOrdersToFile()
        {
            string contents = JsonSerializer.Serialize(Orders);
            File.WriteAllText(filename, contents);
        }
        /// <summary>
        /// This method extract the orderlist from the JASON-file, and splits the list into orders. 
        /// </summary>
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
                var cid = order.Customer.CustomerID;   
                order.Customer = customerCatalogue.Customers.Single(c => c.CustomerID == cid);

                foreach (OrderLine ol in order.Items)
                {
                    var pid = ol.OrderedProduct.ProductID;
                    ol.OrderedProduct = productCatalogue.Products.Single(p => p.ProductID == pid);
                }
            }
        }
        /// <summary>
        /// This method recieves the information it needs to create an object of sort order and saves it to the orderlist, it also saves it to the "database". 
        /// </summary>
        public void AddOrder(Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted) 
        {
            currentOrderID++;


                Order order = new Order(currentOrderID, customer, deliveryaddress, orderlist, date, paymentcompleted);
                Orders.Add(order);
                WriteOrdersToFile();
                RaiseCatalogueChanged();

        }
        /// <summary>
        /// This method checks for the orderes that can be dispatched and dispatches them. 
        /// </summary>
        public void BatchProcessOrders()
        {
            var orders = Orders.Where(o => !o.Dispatched && o.PaymentCompleted && o.Items.All(o => o.OrderedProduct.ProductStock >= o.Count));
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
        /// <summary>
        /// This method displayed the previous orderes of a customer. 
        /// </summary>
        public void DisplayPreviousOrers(Customer cust)
        {
            IEnumerable<Order> query = from ord in Orders
                                       where ord.Customer.CustomerID == cust.CustomerID
                                       select ord;

        }

    }
}
