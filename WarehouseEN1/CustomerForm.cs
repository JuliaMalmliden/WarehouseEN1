using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
        }


        private void CustomerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void CustomerDisplayListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CustomerAddButton_Click(object sender, EventArgs e)
        {

        }

        private void CustomerUpdateButton_Click(object sender, EventArgs e)
        {

        }

        private void PreviousOrdersButton_Click(object sender, EventArgs e)
        {

        }

        private void RecentOrdersButton_Click(object sender, EventArgs e)
        {

        }

        private void ProductPageC_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            ProductForm Productform = new ProductForm(prodCatalogue);
            Productform.Show();
            this.Hide();
        }

        private void OrderPageC_CheckedChanged(object sender, EventArgs e)
        {
            OrderForm Orderfrom = new OrderForm();
            Orderfrom.Show();
            this.Hide();
        }
    }
}
