using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void OrderList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BatchProcessButton_Click(object sender, EventArgs e)
        {

        }

        private void DispatchedOrdersButton_Click(object sender, EventArgs e)
        {

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
            OrderCatalogue orderCatalogue = new OrderCatalogue();
            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, customerCatalogue);
            NewOrderform.Show();
            this.Hide();
        }
    }
}
