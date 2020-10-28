using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace WarehouseEN1
{
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
        private int cid;    //test


        public NewOrderForm(ProductCatalogue prodCatalogue, OrderCatalogue orderCatalogue, CustomerCatalogue customerCatalogue)
        {
            this.prodCatalogue = prodCatalogue;
            this.orderCatalogue = orderCatalogue;
            this.customerCatalogue = customerCatalogue; 
            InitializeComponent();

            prodCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();

            Productlist = new List<Product>();
            Cart = new List<OrderLine>();
        }

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
            }
            catch (Exception ex)
            {
                throw new OrderExceptions("Did not manage to execute because of: ", ex);

            }
            try
            {
                IEnumerable<OrderLine> query2 = from item in Cart
                                                select item;
                foreach (OrderLine item in query2)
                {
                    CartList.Items.Add(item.OrderedProduct.ProductName.ToString() + " (" + item.Count + " st) ");
                }
            }
           catch(Exception ex)
            {
                throw new OrderExceptions("Did not manage to execute because of: ", ex);

            }



        }
        private void ClearAllFields()
        {
            CostumerTextBox.Text = ""; 
            AddressTextBox.Text = "";
            if (PayRadioButton.Checked)
            {
                PayRadioButton.Checked = false;
            }
            Cart.Clear();
            RefreshListboxContents();
        }
        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = ProductList.SelectedIndex;
        }

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
            catch (Exception ex)
            {
                throw new OrderExceptions("Did not manage to execute because of: ", ex);
                // MessageBox.Show("Did not manage to execute because of: "+ ex);
            }

        }
        private void TotalCostLable_Click(object sender, EventArgs e)
        {
            TotalCostLable.Text = (Convert.ToDouble(TotalCostLable.Text) + prd.ProductPrice* amount).ToString();

            //var Total = Cart.Sum(); 
            //TotalCostLable.Text = 
        }
   
        private void PayRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            if (PayRadioButton.Checked == true) 
            {paymentCompleted = true; } 
            else 
            { paymentCompleted = false;}

        }

        private void PlaceOrderButton_Click(object sender, EventArgs e)
        {  try
            {
                int c = Convert.ToInt32(CostumerTextBox.Text);
               
                IEnumerable<Customer> query2 = from cus in customerCatalogue.Customers
                                               where cus.CustomerID == c
                                               select cus;
                foreach (Customer cus in query2)
                {
                    cust = cus;
                }

                dateOfOrder = DateTime.Now;
                address = AddressTextBox.Text;
                orderCatalogue.AddOrder(cust, address, Cart, dateOfOrder, paymentCompleted);
                MessageBox.Show("Order placed, thank you for buying your things at KJ´s!");
                ClearAllFields(); 

            }
            catch(Exception ex)
            {
                throw new OrderExceptions("Did not manage to execute because of: ", ex);

            }
        }

        private void DeleteOrderButton_Click(object sender, EventArgs e)
        {
            Cart.Clear();
            RefreshListboxContents(); 
        }




        private void ProductPageN_CheckedChanged(object sender, EventArgs e)
        {
            ProductForm Productform = new ProductForm(prodCatalogue, customerCatalogue, orderCatalogue);
            Productform.Show();
            this.Hide();
        }

        private void CustomerPageN_CheckedChanged(object sender, EventArgs e)
        {
            CustomerList CustomerList = new CustomerList(prodCatalogue, customerCatalogue, orderCatalogue);
            CustomerList.Show();
            this.Hide();
        }

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
