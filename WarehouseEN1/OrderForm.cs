using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public partial class OrderForm : Form
    {
        OrderCatalogue orderCatalogue; 
        public OrderForm(OrderCatalogue orderCatalogue)
        {
            this.orderCatalogue = orderCatalogue; 
            InitializeComponent();
        }
        private void RefreshListboxContents()
        {
            OrderList.Items.Clear();
            OrderDisplayList.Items.Clear();

            foreach (Order o in orderCatalogue.Orders)
            {
                OrderList.Items.Add(o);
            }
        }
        private void OrderList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BatchProcessButton_Click(object sender, EventArgs e)
        {
           // Sortera beställningar efter datum och tid.  
            //Reducera stock anpassat efter Order. 
           // Om alla produkter i en order är tillgängliga så ändras Orders "Dispatched" till true. 
        }

        private void DispatchedOrdersButton_Click(object sender, EventArgs e) 
        {
            IEnumerable<Order> query = from order in orderCatalogue.Orders
                                       where order.Dispatched == true select order;
                                      foreach (Order order in query)
                                      {
                                            OrderDisplayList.Items.Add(order);
                                      }
        }

        private void PendingOrdersButton_Click(object sender, EventArgs e)
        {

        }

        private void OrderDisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductPageRBTN_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            ProductForm Productform = new ProductForm(prodCatalogue);
            Productform.Show();
            this.Hide();
        }

        private void CustomerPageORBTN_CheckedChanged(object sender, EventArgs e)
        {
            /*CustomerList Customerform = new CustomerList();
            Customerform.Show();
            this.Hide();*/

            CustomerCatalogue custCatalogue = new CustomerCatalogue();
            CustomerList CustomerList = new CustomerList(custCatalogue);
            CustomerList.Show();
            this.Hide();
        }

        private void MakeNewOrderPage_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue customerCatalogue = new CustomerCatalogue();
            OrderCatalogue orderCatalogue = new OrderCatalogue(customerCatalogue);
            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, customerCatalogue);
            NewOrderform.Show();
            this.Hide();
        }
    }
}
