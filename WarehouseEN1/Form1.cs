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
        
        public Form1(ProductCatalogue prodCatalogue)
        {
            this.prodCatalogue = prodCatalogue;
            InitializeComponent();

            prodCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();
        }


        private void RefreshListboxContents()
        {
            ProductList.Items.Clear();
            foreach (Product p in prodCatalogue.Products)
            {
                ProductList.Items.Add(p);
            }
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProduct = ProductList.SelectedIndex;
        }

        private void ProdIDtextBox_TextChanged(object sender, EventArgs e)
        {
            productID = Convert.ToInt32(ProdIDtextBox.Text); 
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

        }

        private void OutOfStockButton_Click(object sender, EventArgs e)
        {

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
    }
}
