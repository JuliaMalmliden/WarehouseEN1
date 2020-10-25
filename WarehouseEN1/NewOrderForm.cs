using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public partial class NewOrderForm : Form
    {
        public NewOrderForm()
        {
            InitializeComponent();
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProductAmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {

        }

        private void CartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TotalCostLable_Click(object sender, EventArgs e)
        {

        }

        private void CostumerTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {

        }

        private void ProductPageN_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            ProductForm Productform = new ProductForm(prodCatalogue);
            Productform.Show();
            this.Hide();
        }

        private void CustomerPageN_CheckedChanged(object sender, EventArgs e)
        {
            CustomerCatalogue custCatalogue = new CustomerCatalogue();
            CustomerList CustomerList = new CustomerList(custCatalogue);
            CustomerList.Show();
            this.Hide();
        }

        private void OrderPageN_CheckedChanged(object sender, EventArgs e)
        {
            OrderForm Orderfrom = new OrderForm();
            Orderfrom.Show();
            this.Hide();
        }

        private void NewOrderForm_Load(object sender, EventArgs e)
        {

        }
    }
}
