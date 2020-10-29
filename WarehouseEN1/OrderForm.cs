using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public partial class OrderForm : Form
    {
        private ProductCatalogue prodCatalogue;
        private CustomerCatalogue customerCatalogue;
        private OrderCatalogue orderCatalogue; 

        public OrderForm(ProductCatalogue prodCatalogue, CustomerCatalogue customerCatalogue, OrderCatalogue orderCatalogue)
        {
            this.customerCatalogue = customerCatalogue;
            this.prodCatalogue = prodCatalogue; 
            this.orderCatalogue = orderCatalogue; 
            InitializeComponent();

            RefreshListboxContents(); 
        }
        private void RefreshListboxContents()
        {
            OrderList.Items.Clear();
            OrderDisplayList.Items.Clear();

            try
            {
                IEnumerable<Order> query = from order in orderCatalogue.Orders
                                                select order;
                foreach (Order order in query)
                {
                    OrderList.Items.Add(order);
                }
            }
            catch (Exception ex)
            {
                throw new OrderExceptions("Did not manage to execute because of: ", ex);

            }

        }

        private void BatchProcessButton_Click(object sender, EventArgs e)
        {
            orderCatalogue.BatchProcessOrders();
            RefreshListboxContents();

            // Sortera beställningar efter datum och tid.(tänker att de tidigaste beställningarna ska hanteras först..?  
            //Reducera stock anpassat efter Order. 
            // Om alla produkter i en order är tillgängliga så ändras Orders "Dispatched" till true.

            //OrderDisplayList.Items.Clear();
            //try
            //{
            //    IEnumerable<Order> query = from order in orderCatalogue.Orders
            //                               where order.Dispatched == true
            //                               orderby order.OrderDate descending
            //                               //where order in orderLines  //hur ska få fram orderlines och kolla stock?
            //                               select order;
            //    foreach (Order order in query)
            //    {
            //        OrderDisplayList.Items.Add(order);
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw new OrderExceptions("Did not manage to execute because of: ", ex);
            //}


        }

        private void DispatchedOrdersButton_Click(object sender, EventArgs e) 
        {
            OrderDisplayList.Items.Clear();
            try
            {
                IEnumerable<Order> query = (from order in orderCatalogue.Orders
                                            where order.Dispatched == true
                                            select order);
                                             //.Union(from pro in prodCatalogue
                                             //       where pro.stock > 0
                                             //       select pro.nextRestock) ;
               foreach (Order order in query)
               {
                     OrderDisplayList.Items.Add(order);
               }
            }
            catch (Exception ex)
            {

                throw new OrderExceptions("Did not manage to execute because of: ", ex);
            }
       
        }
        /*Pending if no payment, not enough stock then dispatch will be false, othewise it's dispatched */
        private void PendingOrdersButton_Click(object sender, EventArgs e)
        {
            OrderDisplayList.Items.Clear();
            try
            {
                var orders = orderCatalogue.Orders.Where(o => !o.Dispatched && o.PaymentCompleted);

                foreach (Order order in orders)
                {
                    var customerinfo = order.Customer;  //need to show cutomer info
                    var orderid = order.OrderNumber;

                    foreach (OrderLine orderline in order.Items)
                    {
                        var nextAvilabelDate = orderline.OrderedProduct.FirstAvailableDate;

                        //var product = productCatalogue.Products.Single(p => p.ProductID == pid);
                    }

                }
                RefreshListboxContents();
            }
            catch (Exception ex)
            {

                throw new OrderExceptions("Did not manage to execute because of: ", ex);
            }
            //OrderDisplaylistan ska visa  "the earliest time the order can be dispatched"  --> FirstAvailable date
            //For Pending orders, display the list of customers and their contact information, along with the number of the pending order.

        }

        private void ProductPageRBTN_CheckedChanged(object sender, EventArgs e)
        { 
            ProductForm Productform = new ProductForm(prodCatalogue,  customerCatalogue,  orderCatalogue);
            Productform.Show();
            this.Hide();
        }

        private void CustomerPageORBTN_CheckedChanged(object sender, EventArgs e)
        {
            /*CustomerList Customerform = new CustomerList();
            Customerform.Show();
            this.Hide();*/
            CustomerList CustomerList = new CustomerList(prodCatalogue, customerCatalogue, orderCatalogue);
            CustomerList.Show();
            this.Hide();
        }

        private void MakeNewOrderPage_CheckedChanged(object sender, EventArgs e)
        {

            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, customerCatalogue);
            NewOrderform.Show();
            this.Hide();
        }
        private void OrderList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void OrderDisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
