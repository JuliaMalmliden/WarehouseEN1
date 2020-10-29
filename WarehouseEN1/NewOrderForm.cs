using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WarehouseEN1
{
    /// <summary>
    /// This class handle all the interaction with the use of the NewOrderForm.
    /// The NewOrderform purpose is to deal with the orders from the customers-point of view, mainly to purchase products. 
    /// </summary>
    public partial class NewOrderForm : Form
    {
        private ProductCatalogue prodCatalogue;
        private CustomerCatalogue customerCatalogue; 
        private OrderCatalogue orderCatalogue; 
        private List<Product> Productlist;
        private List<OrderLine> Cart; 
        private int selectedProduct;
        private bool paymentCompleted; 
        private DateTime dateOfOrder;
        private Product prd;
        private int amount;
        private string address;
        private Customer cust; 

        public NewOrderForm(ProductCatalogue prodCatalogue, OrderCatalogue orderCatalogue, CustomerCatalogue customerCatalogue)
        {
            this.prodCatalogue = prodCatalogue;
            this.orderCatalogue = orderCatalogue;
            this.customerCatalogue = customerCatalogue; 
            InitializeComponent();

            prodCatalogue.CatalogueChanged += RefreshListboxContents;

            Productlist = new List<Product>();
            Cart = new List<OrderLine>(); 
            RefreshListboxContents();
        }
        /// <summary>
        /// This method writes the productlist and the content of the cart to the lists visual to the user. 
        /// </summary>
        private void RefreshListboxContents()
        {
            ProductList.Items.Clear();
            CartList.Items.Clear();
            try
            {
                IEnumerable<Product> query = from prod in prodCatalogue.Products
                                       select prod;
                foreach (Product prod in query)
                {
                    ProductList.Items.Add(prod);
                }

                if(Cart.Count == 0)
                {

                }
                else
                {
                    IEnumerable<OrderLine> query2 = from item in Cart
                                                    select item;
                    foreach (OrderLine item in query2)
                    {
                        CartList.Items.Add(item.OrderedProduct.ProductName.ToString() + " (" + item.Count + " st) ");
                    }
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
        /// This method clear all fields. 
        /// </summary>
        private void ClearAllFields()
        {
            try
            {
                CostumerTextBox.Text = "";
                AddressTextBox.Text = "";
                if (PayRadioButton.Checked)
                {
                    PayRadioButton.Checked = false;
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
            Cart.Clear();
            RefreshListboxContents();
        }
        /// <summary>
        /// This method checks for what index is selected in the list of products.
        /// </summary>
        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = ProductList.SelectedIndex;
        }
        /// <summary>
        /// This method checks for what index is selected in the list of products and what amount of the product is typed in.
        /// The product is then added to the cartlist and displayed in the cartlistbox.
        /// </summary>
        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            try
            {
                prd = prodCatalogue.Products.ElementAt(selectedProduct);
                amount = Convert.ToInt32(ProductAmountTextBox.Text);
                OrderLine orderLine = new OrderLine(prd, amount);
                Cart.Add(orderLine);
                ProductAmountTextBox.Clear();
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
        /// This method display the total cost of the chosen products
        /// </summary>
        private void TotalCostLable_Click(object sender, EventArgs e)
        {
            try
            {
            TotalCostLable.Text = (Convert.ToDouble(TotalCostLable.Text) + prd.ProductPrice* amount).ToString();

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
        private void PayRadioButton_CheckedChanged(object sender, EventArgs e)
        { 

        }
        /// <summary>
        /// This method creates a new order. Matches the customer to excisting customers and check if payment is completed.
        /// </summary>
        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                int c = Convert.ToInt32(CostumerTextBox.Text);
               
                IEnumerable<Customer> query2 = from cus in customerCatalogue.Customers
                                               where cus.CustomerID == c
                                               select cus;
                foreach (Customer cus in query2)
                {
                    cust = cus;
                }

                if (PayRadioButton.Checked == true)
                { paymentCompleted = true; }
                else
                { paymentCompleted = false; }

                dateOfOrder = DateTime.Now;
                address = AddressTextBox.Text;
                orderCatalogue.AddOrder(cust, address, Cart, dateOfOrder, paymentCompleted);
                MessageBox.Show("Order placed, thank you for buying your things at KJ´s!");
                ClearAllFields(); 
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
        /// This method delete the ongoing order.
        /// </summary>
        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            Cart.Clear();
            RefreshListboxContents(); 
        }
        /// <summary>
        /// This method takes the user to the productform.
        /// </summary>
        private void ProductPageN_CheckedChanged(object sender, EventArgs e)
        {
            ProductForm Productform = new ProductForm(prodCatalogue, customerCatalogue, orderCatalogue);
            Productform.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the customerform.
        /// </summary>
        private void CustomerPageN_CheckedChanged(object sender, EventArgs e)
        {
            CustomerList CustomerList = new CustomerList(prodCatalogue, customerCatalogue, orderCatalogue);
            CustomerList.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the Orderform.
        /// </summary>
        private void OrderPageN_CheckedChanged(object sender, EventArgs e)
        {
            OrderForm Orderfrom = new OrderForm(prodCatalogue, customerCatalogue, orderCatalogue);
            Orderfrom.Show();
            this.Hide();
        }
        private void CostumerTextBox_TextChanged(object sender, EventArgs e)
        {

        }       
        private void CartList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ProductAmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {

        }    
        private void NewOrderForm_Load(object sender, EventArgs e)
        {

        }


    }
}
