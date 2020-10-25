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
    public partial class NewOrderForm : Form
    {
        private ProductCatalogue prodCatalogue;
        private CustomerCatalogue customerCatalogue; 
        private OrderCatalogue orderCatalogue; 
        private List<Product> Productlist;
        private List<Product> Cart; 
        private int selectedProduct; 
        public NewOrderForm(ProductCatalogue prodCatalogue, OrderCatalogue orderCatalogue, CustomerCatalogue customerCatalogue)
        {
            this.prodCatalogue = prodCatalogue;
            this.orderCatalogue = orderCatalogue;
            this.customerCatalogue = customerCatalogue; 
            InitializeComponent();

            prodCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();

            Productlist = new List<Product>();
            Cart = new List<Product>();
        }

        private void RefreshListboxContents()
        {
            ProductList.Items.Clear();
            CartList.Items.Clear();
            foreach (Product p in prodCatalogue.Products)
            {
                ProductList.Items.Add(p);
            }
            if(Cart.Count() == 0) 
            {
            }
            else 
            {
                foreach(Product p in Cart)
                {
                    CartList.Items.Add(p); 
                }
            }
            
        }
        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = ProductList.SelectedIndex;
        }

        private void ProductAmountTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddToCartButton_Click(object sender, EventArgs e)
        {
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            int amount = Convert.ToInt32(ProductAmountTextBox.Text); 
            for(int i = 0; i < amount; i++)
            {
                Cart.Add(prd); 
            }
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
        private void PayRadioButton_CheckedChanged(object sender, EventArgs e)
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
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue customerCatalogue = new CustomerCatalogue();
            OrderCatalogue orderCatalogue = new OrderCatalogue(); 
            NewOrderForm NewOrderform = new NewOrderForm( prodCatalogue,  orderCatalogue,  customerCatalogue);
            NewOrderform.Show();
            this.Hide(); 
        }


    }
}
