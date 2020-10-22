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
    public partial class Form1 : Form
    {
        int selectedProduct;
        private int productID;
        private string productName;
        private double productPrice;
        private int productStock;
        private DateTime productRestock;
        private ProductCatalogue prodCatalogue;
        private List<Product> Displaylist; 
        
        public Form1(ProductCatalogue prodCatalogue)
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


        private void ProdNametextBox_TextChanged(object sender, EventArgs e)
        {
            productName = ProdNametextBox.Text; 
        }

        private void ProductPriceTextbox_TextChanged(object sender, EventArgs e)
        {
            productPrice = Convert.ToDouble(ProductPricetextbox.Text); 
        }

        private void ProductStocktextBox_TextChanged(object sender, EventArgs e)
        {
            productStock = Convert.ToInt32(ProductStocktextBox.Text); 
        }

        private void ProNextRestocktextBox_TextChanged(object sender, EventArgs e)
        {
             
        }

        private void ProductAddButton_Click(object sender, EventArgs e)
        {
            productRestock = Convert.ToDateTime(ProNextRestocktextBox.Text);

            Product prod = new Product(productID, productName, productPrice, productStock, productRestock);

            prodCatalogue.AddProduct(prod);

        }

        private void ProductEditButton_Click(object sender, EventArgs e)
        {
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            string name = prd.ProductName;

            prodCatalogue.RemoveProduct(name);

            Product prod = new Product(productID, productName, productPrice, productStock, productRestock);
            prodCatalogue.AddProduct(prod);

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

        private void ProductPageP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CustomerPageP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void OrderPageP_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ProductDisplayList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
