using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public partial class ProductForm : Form
    {
        int selectedProduct;
        private string productName;
        private double productPrice;
        private int productStock;
        private DateTime productRestock;
        private ProductCatalogue prodCatalogue;
        private List<Product> Displaylist; 
        
        public ProductForm(ProductCatalogue prodCatalogue)
        {
            this.prodCatalogue = prodCatalogue;
            InitializeComponent();

            prodCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();

            Displaylist = new List<Product>();
            
        }


        private void RefreshListboxContents()
        {
            ProductDisplayList.Items.Clear();
            ProductList.Items.Clear();
            foreach (Product p in prodCatalogue.Products)
            {
                ProductList.Items.Add(p);
            }
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = ProductList.SelectedIndex;
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            
            ProdNametextBox.Text = prd.ProductName;
            ProductPricetextbox.Text = prd.ProductPrice.ToString();
            ProductStocktextBox.Text = prd.ProductStock.ToString();
            ProNextRestocktextBox.Text = prd.NextRestock.ToString(); 
        }

        private void GetTextBox()
        {
            productName = ProdNametextBox.Text;
            productPrice = Convert.ToDouble(ProductPricetextbox.Text);
            productStock = Convert.ToInt32(ProductStocktextBox.Text);
            productStock = Convert.ToInt32(ProductStocktextBox.Text);
            productStock = Convert.ToInt32(ProductStocktextBox.Text);

        }
        private void ProductAddButton_Click(object sender, EventArgs e)
        {
            GetTextBox(); 
            productRestock = Convert.ToDateTime(ProNextRestocktextBox.Text);

            prodCatalogue.AddProduct(productName, productPrice, productStock, productRestock);

        }

        private void ProductEditButton_Click(object sender, EventArgs e)
        {
            GetTextBox(); 
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            int prdID = prd.ProductID; 
            prodCatalogue.EditProduct(prdID, productName, productPrice, productStock, productRestock); 


        }

        private void OutOfStockButton_Click(object sender, EventArgs e)
        {
            for(int i= 0 ; i < prodCatalogue.Products.Count; i++)
            { Product prd = prodCatalogue.Products.ElementAt(i); 
                if (prd.ProductStock == 0)
                {
                    Displaylist.Add(prd); 
                }
            }

            foreach (Product p in Displaylist)
            {
                ProductDisplayList.Items.Add(p);
            }
        }

        private void NextRestockButton_Click(object sender, EventArgs e)
        {

        }

        private void CustomerPageP_CheckedChanged(object sender, EventArgs e)
        {
            CustomerForm Customerform = new CustomerForm();
            Customerform.Show();
            this.Hide();
        }

        private void OrderPageP_CheckedChanged(object sender, EventArgs e)
        {
            OrderForm Orderfrom = new OrderForm();
            Orderfrom.Show();
            this.Hide();
        }

        private void ProductDisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }        
        
        private void ProdNametextBox_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void ProductPriceTextbox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ProductStocktextBox_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ProNextRestocktextBox_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void ProductpageLable_Click(object sender, EventArgs e)
        {

        }

        private void MenuLabel_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
