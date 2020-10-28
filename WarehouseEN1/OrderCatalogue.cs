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
        public bool AddOrder(Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted) //string productRestock)//Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted) //string productRestock)
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

                //customer
                Order order = new Order(currentOrderID, customer, deliveryaddress, orderlist, date, paymentcompleted);
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
            //IEnumerable<Order> query = from order in Orders
            //                           where order.Dispatched == false
            //                           select order;
            //foreach (Order order in query)
            //{
            //    NonDispatchedorders.Add(order);
            //}

            //foreach (Order order in NonDispatchedorders)
            //{
            //    for(int i = 0; i < order.Items.Count; i++)
            //    {
            //       orderLine i in order(i)
            //    }
            //}
            //IEnumerable<Product> query2 = from p in productCatalogue.Products
            //                                 where p.ProductStock == 0
            //                                 select p;

            //foreach (Order order in NonDispatchedorders)
            //{
            //    foreach(Product orderedproduct in order.Items)

            //}
            //List<DateTime> dates = new List<DateTime>();
            //foreach (order o in nondispatchedorders)
            //{
            //    dates.add(o.orderdate);
            //}
            //datetime mindate = dates.min();
            //ienumerable<order> query3 = from order in nondispatchedorders
            //                            where order.orderdate == mindate
            //                            select order;


            //ienumerable<product> query = from prod in prodcatalogue.products
            //                             where prod.nextrestock == mindate
            //                             select prod;


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
