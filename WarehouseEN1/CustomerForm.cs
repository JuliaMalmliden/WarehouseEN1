﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WarehouseEN1
{
    /// <summary>
    /// This class handle all the interaction with the use of the CustomerForm.
    /// The Customerform purpose is to add, edit and display customer.
    /// </summary>
    public partial class CustomerList : Form
    {

        int selectedCustomer;
        private string customerName;
        private string email;
        private string phone;
        private ProductCatalogue prodCatalogue;
        private CustomerCatalogue custCatalogue;
        private OrderCatalogue orderCatalogue;      
        private List<Customer> Displaylist;
        public CustomerList(ProductCatalogue prodCatalogue, CustomerCatalogue customerCatalogue, OrderCatalogue orderCatalogue)
        {
            this.custCatalogue = customerCatalogue;
            this.prodCatalogue = prodCatalogue;
            this.orderCatalogue = orderCatalogue; 
            
            InitializeComponent();

            custCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();

            Displaylist = new List<Customer>();

        }
        /// <summary>
        /// This method writes the Customerlist to the list visual to the user. 
        /// </summary>
        private void RefreshListboxContents()
        {
            CustomerDisplayListBox.Items.Clear();
            CustomerListBox.Items.Clear();
            try
            {
                IEnumerable<Customer> query = from customer in custCatalogue.Customers
                                              select customer;
                foreach (Customer customer in query)
                {
                    CustomerListBox.Items.Add(customer);
                }
            }
            catch (CustomerExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method checks for what index is selected in the list of customers.
        /// It also prints the properties of the selected item in the textboxes. 
        /// </summary>
        private void CustomerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCustomer = CustomerListBox.SelectedIndex;
            Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);
            try
            {
                CustomerName.Text = cust.Name;
                CustomerNumber.Text = cust.PhoneN.ToString();
                CustomerEmail.Text = cust.EMail;
            }
            catch (CustomerExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// This method retrieves the information from the textboxes.
        /// </summary>
        private void GetTextBox()
        {
            try
            {                
                customerName = CustomerName.Text;
                phone = CustomerNumber.Text;
                email = CustomerEmail.Text;
            }
            catch (CustomerExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// This method adds a newly created customer.
        /// </summary>
        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            GetTextBox();
            try
            {
                custCatalogue.AddCustomer(customerName, phone, email);

            }
            catch (CustomerExceptions ex)
            {
               MessageBox.Show(ex.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// This method saves the changes made to an previously added customer.
        /// </summary>
        private void CustomerUpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                GetTextBox();
                Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);
                int custID = cust.CustomerID;

                custCatalogue.UpdateCustomer(custID, customerName, phone, email);
            }
            catch (CustomerExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method Display the previous orders of a selected customer.
        /// </summary>
        private void PreviousOrdersButton_Click(object sender, EventArgs e)
        {
                   GetTextBox();
                   CustomerDisplayListBox.Items.Clear();
            try
            {
                Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);
                int custID = cust.CustomerID;

                IEnumerable<Order> query = from ord in orderCatalogue.Orders
                                           where ord.Customer.CustomerID == cust.CustomerID  
                                           && (ord.OrderDate - DateTime.Now).TotalDays >30
                                           select ord;


                foreach (Order ord in query)
                {
                    CustomerDisplayListBox.Items.Add(ord);
                }
            }
            catch (CustomerExceptions ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// This method Display the recent orders of a selected customer.
        /// </summary>
        private void RecentOrdersButton_Click(object sender, EventArgs e)
        {
            GetTextBox();
            CustomerDisplayListBox.Items.Clear();
            try
            {

                Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);
                int custID = cust.CustomerID;

                IEnumerable<Order> query = from ord in orderCatalogue.Orders
                                           where ord.Customer.CustomerID == cust.CustomerID
                                           && (ord.OrderDate - DateTime.Now).TotalDays <= 30
                                           select ord;


                foreach (Order ord in query)
                {
                    CustomerDisplayListBox.Items.Add(ord);
                }
            }
            catch (CustomerExceptions ex)
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
        private void ProductPageC_CheckedChanged(object sender, EventArgs e)
        {

            ProductForm Productform = new ProductForm(prodCatalogue, custCatalogue, orderCatalogue);
            Productform.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the orderform.
        /// </summary>
        private void OrderPageC_CheckedChanged(object sender, EventArgs e)
        {

            OrderForm Orderfrom = new OrderForm(prodCatalogue, custCatalogue, orderCatalogue);
            Orderfrom.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the NewOrderform.
        /// </summary>
        private void MakeNewOrderPageC_CheckedChanged(object sender, EventArgs e)
        {

            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, custCatalogue);
            NewOrderform.Show();
            this.Hide();
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
    }
}
