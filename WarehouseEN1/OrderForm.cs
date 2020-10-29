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
    /// <summary>
    /// This class handle all the interaction with the use of the OrderForm.
    /// The orderform purpose is to deal with the orders from the warehouse-point of view. 
    /// </summary>
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
        /// <summary>
        /// This method writes the orderlist to the list visual to the user. 
        /// </summary>
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
            catch (OrderExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method process the orderes ready to be dispatched. 
        /// </summary>
        private void BatchProcessButton_Click(object sender, EventArgs e)
        {
            try
            {
                orderCatalogue.BatchProcessOrders();
                RefreshListboxContents();
            }
            catch (OrderExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method displayed the dispatched orderes.. 
        /// </summary>
        private void DispatchedOrdersButton_Click(object sender, EventArgs e) 
        {
            OrderDisplayList.Items.Clear();
            try
            {
                IEnumerable<Order> query = (from order in orderCatalogue.Orders
                                            where order.Dispatched == true
                                            select order);
               foreach (Order order in query)
               {
                     OrderDisplayList.Items.Add(order);
               }
            }
            catch (OrderExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method displayes the pending orderes. 
        /// </summary>
        private void PendingOrdersButton_Click(object sender, EventArgs e)
        {
            OrderDisplayList.Items.Clear();
            try
            {

                IEnumerable<Order> orders = (from order in orderCatalogue.Orders
                                            where order.Dispatched == false
                                            select order);

                foreach (Order order in orders)
                {
                    OrderDisplayList.Items.Add(" OrderID: " + order.OrderNumber + " Customer information: " + order.Customer.EMail + ", " + order.Customer.PhoneN + " Order First Available: " + order.FirstAvailableDate);
                }


                RefreshListboxContents();
            }
            catch (OrderExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method takes the user to the productform.
        /// </summary>
        private void ProductPageRBTN_CheckedChanged(object sender, EventArgs e)
        { 
            ProductForm Productform = new ProductForm(prodCatalogue,  customerCatalogue,  orderCatalogue);
            Productform.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the customerform.
        /// </summary>
        private void CustomerPageORBTN_CheckedChanged(object sender, EventArgs e)
        {
            CustomerList CustomerList = new CustomerList(prodCatalogue, customerCatalogue, orderCatalogue);
            CustomerList.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the NewOrderform.
        /// </summary>
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
