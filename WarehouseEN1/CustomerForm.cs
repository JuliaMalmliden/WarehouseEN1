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
        private ProductCatalogue prodCatalogue;
        private CustomerCatalogue custCatalogue;
        private OrderCatalogue orderCatalogue;      
        private List<Customer> Displaylist;
        //Customer customer;
        public CustomerList(ProductCatalogue prodCatalogue, CustomerCatalogue customerCatalogue, OrderCatalogue orderCatalogue) //Customer cust) //new cust
        {
            this.custCatalogue = customerCatalogue;
            this.prodCatalogue = prodCatalogue;
            this.orderCatalogue = orderCatalogue; 
            
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
                throw new CustomerExceptions("Did not manage to execute because of: ", ex);

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
                throw new CustomerExceptions("Did not manage to execute because of: ", ex);
            }
            try
            {
                phone = CustomerNumber.Text;

            }
            catch (Exception ex)
            {
                throw new CustomerExceptions("Did not manage to execute because of: ", ex);
            }
            try
            {
                email = CustomerEmail.Text;

            }
            catch (Exception ex)
            {
                throw new CustomerExceptions("Did not manage to execute because of: ", ex);
            }
        }

        private void CustomerAddButton_Click(object sender, EventArgs e)
        {
            GetTextBox();
            try
            {
                custCatalogue.AddCustomer(customerName, phone, email);
            }
            catch (Exception ex)
            {

                throw new CustomerExceptions("Adding failed, please try again. See to that all fields are filled in correctly.", ex);
            }
        }

        private void CustomerUpdateButton_Click(object sender, EventArgs e)
        {
            GetTextBox();
            Customer cust = custCatalogue.Customers.ElementAt(selectedCustomer);
            int custID = cust.CustomerID;
            custCatalogue.UpdateCustomer(custID, customerName, phone, email);
            
        }
        /*more than a month old*/
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
            catch (Exception ex)
            {
                throw new CustomerExceptions("Did not manage to execute because of: ", ex);

            }

        }

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
            catch (Exception ex)
            {
                throw new CustomerExceptions("Did not manage to execute because of: ", ex);

            }


        }

        private void ProductPageC_CheckedChanged(object sender, EventArgs e)
        {

            ProductForm Productform = new ProductForm(prodCatalogue, custCatalogue, orderCatalogue);
            Productform.Show();
            this.Hide();
        }

        private void OrderPageC_CheckedChanged(object sender, EventArgs e)
        {

            OrderForm Orderfrom = new OrderForm(prodCatalogue, custCatalogue, orderCatalogue);
            Orderfrom.Show();
            this.Hide();
        }

        private void MakeNewOrderPageC_CheckedChanged(object sender, EventArgs e)
        {

            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, custCatalogue);
            NewOrderform.Show();
            this.Hide();
        }
    }
}
