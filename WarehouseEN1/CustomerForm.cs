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
    public partial class CustomerList : Form
    {

        int selectedCustomer;
        private string customerName;
        private string email;
        private string phone;
        private CustomerCatalogue custCatalogue;
        private List<Customer> Displaylist;

        public CustomerList(CustomerCatalogue custCatalogue)
        {
            this.custCatalogue = custCatalogue;
            InitializeComponent();

            custCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();

            Displaylist = new List<Customer>();

        }
        public CustomerList ()  // complains in product form without
            {}
        private void RefreshListboxContents()
        {
            CustomerDisplayListBox.Items.Clear();
            CustomerListBox.Items.Clear();
            foreach (Customer c in custCatalogue.Customers)
            {
                CustomerListBox.Items.Add(c);
            }
        }


        private void CustomerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = CustomerListBox.SelectedIndex;
            Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);

            CustomerName.Text = cust.Name;
            CustomerEmail.Text = cust.EMail;
            CustomerNumber.Text = cust.PhoneN.ToString();     // have dates in type DateTime. prd.ProductStock.ToShortString(); 
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
        private void GetTextBox()
        {
            try
            {
                customerName = CustomerName.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Did not manage to execute because of: " + ex);
            }
            try
            {
                phone = CustomerNumber.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Did not manage to execute because of: " + ex);
            }
            try
            {
                email = CustomerEmail.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Did not manage to execute because of: " + ex);
            }
        }

        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            GetTextBox();

            if (custCatalogue.AddCustomer(customerName, phone, email) == false)
            {
                MessageBox.Show("Adding failed, please try again. See to that all fields are filled in correctly.");
            }
        }

        private void CustomerUpdateButton_Click(object sender, EventArgs e)
        {
            GetTextBox();
            Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);
            int custID = cust.CustomerID;
            custCatalogue.UpdateCustomer(custID, customerName, phone, email);
            
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
