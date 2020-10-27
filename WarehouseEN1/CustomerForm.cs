﻿using System;
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
     ///   private OrderCatalogue ordCatalogue;
        private List<Customer> Displaylist;
        //Customer customer;
        public CustomerList(CustomerCatalogue custCatalogue, OrderCatalogue ordCatalogue) //Customer cust) //new cust
        {
           // this.ordCatalogue = ordCatalogue;
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
            try
            {
                IEnumerable<Customer> query = from customer in custCatalogue.Customers
                                                select customer;
                foreach (Customer customer in query)
                {
                    CustomerListBox.Items.Add(customer);
                }
            }
            catch (Exception ex)
            {

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
            GetTextBox();
            CustomerDisplayListBox.Items.Clear();
            try
            {
                Customer customer = custCatalogue.Customers.ElementAt(selectedCustomer);

              //  IEnumerable<Order> query = from ord in ordCatalogue.Orders
                //                             where ord.Customer == customer
                  //                            select ord;
              /*  foreach (Order ord in query)
                {
                    CustomerDisplayListBox.Items.Add(ord);
                }*/
            }
            catch (Exception ex)
            {

            }
               
          //  IEnumerable<order> query = from order in OrderCatalogue.Orders
            //                           where Customer == selectedCustomer
              //                            select customer;
        //    foreach (Customer customer in query)
        //    {
        //        CustomerListBox.Items.Add(customer);
        //    }
        //}
        //    catch (Exception ex)
        //    {

        //    }

    // var oldest = customer.Customer.OrderBy(b => b.Name).Take(10).SelectMany(b => b.Authors).Distinct();

    // ShowInAuthors(authors);
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
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue custCatalogue = new CustomerCatalogue();
            OrderCatalogue orderCatalogue = new OrderCatalogue(custCatalogue, prodCatalogue);
            OrderForm Orderfrom = new OrderForm(orderCatalogue);
            Orderfrom.Show();
            this.Hide();
        }

        private void MakeNewOrderPageC_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue customerCatalogue = new CustomerCatalogue();
            OrderCatalogue orderCatalogue = new OrderCatalogue(customerCatalogue, prodCatalogue);
            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, customerCatalogue);
            NewOrderform.Show();
            this.Hide();
        }
    }
}
