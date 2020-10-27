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
        public List<Product> Displaylist; 
        
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
            try
            {
                IEnumerable<Product> query = from prod in prodCatalogue.Products
                                             select prod;
                foreach (Product prod in query)
                {
                    ProductList.Items.Add(prod);
                }
            }
            catch(Exception ex)
            {

            }
        }

        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedProduct = ProductList.SelectedIndex;
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            
            ProdNametextBox.Text = prd.ProductName;
            ProductPricetextbox.Text = prd.ProductPrice.ToString();
            ProductStocktextBox.Text = prd.ProductStock.ToString();     // have data in type int. prd.ProductStock.ToShortString(); 
            ProNextRestocktextBox.Text = prd.NextRestock.ToString();    // Have data in type DateTime  
        }

        private void GetTextBox()
        {
            try
            {
                productName = ProdNametextBox.Text;
            }
            catch (Exception ex)
            {
                throw new ProductExceptions("Did not manage to execute because of: ", ex);
               // MessageBox.Show("Did not manage to execute because of: "+ ex);
            }
            try
            {
                productPrice = Convert.ToDouble(ProductPricetextbox.Text);

            }
            catch (Exception ex)
            {
                throw new ProductExceptions("Did not manage to execute because of: ", ex);
                //MessageBox.Show("Did not manage to execute because of: " + ex);
            }
            try
            {
                productStock = Convert.ToInt32(ProductStocktextBox.Text);

            }
            catch (Exception ex)
            {
                throw new ProductExceptions("Did not manage to execute because of: ", ex);
                //MessageBox.Show("Did not manage to execute because of: " + ex);
            }
            try
            {

                productRestock = Convert.ToDateTime(ProNextRestocktextBox.Text);
                
            }
            catch (Exception ex)
            {
                throw new ProductExceptions("Did not manage to execute because of: ", ex);
                //MessageBox.Show("Did not manage to execute because of: " + ex);
            }


        }
        private void ProductAddButton_Click(object sender, EventArgs e)
        {
            GetTextBox();
            try
            {
                prodCatalogue.AddProduct(productName, productPrice, productStock, productRestock);
            }
            catch (Exception ex)
            {
                throw new ProductExceptions("Did not manage to execute because of: ", ex);

            }

            /*if (prodCatalogue.AddProduct(productName, productPrice, productStock, productRestock) == false)
            {
                MessageBox.Show("Adding failed, please try again. See to that all fields are filled in correctly."); 
            }*/

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
            RefreshListboxContents();
            Displaylist.Clear();

            IEnumerable<Product> query = from prod in prodCatalogue.Products
                                         where prod.ProductStock == 0
                                         select prod;
            foreach (Product prod in query)
            {
                ProductDisplayList.Items.Add(prod);
            }
 
        }

        private void NextRestockButton_Click(object sender, EventArgs e)
        {
            RefreshListboxContents();
            Displaylist.Clear();

            List<DateTime> Restockdates = new List<DateTime>(); 

            foreach (Product p in prodCatalogue.Products)
            {
                Restockdates.Add(p.NextRestock); 
            }
            DateTime minDate = Restockdates.Min();

            IEnumerable<Product> query = from prod in prodCatalogue.Products
                                         where prod.NextRestock == minDate
                                         select prod;
            foreach (Product prod in query)
            {
                ProductDisplayList.Items.Add(prod);
            }
        }

        private void CustomerPageP_CheckedChanged(object sender, EventArgs e)
        {
            /*CustomerList Customerform = new CustomerList();     //gives error, not enough arguments
            Customerform.Show();
            this.Hide(); */

            CustomerCatalogue custCatalogue = new CustomerCatalogue();
            CustomerList CustomerList = new CustomerList(custCatalogue);
            CustomerList.Show();
            this.Hide();

        }

        private void OrderPageP_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue custCatalogue = new CustomerCatalogue();
            OrderCatalogue orderCatalogue = new OrderCatalogue(custCatalogue, prodCatalogue);
            OrderForm Orderfrom = new OrderForm(orderCatalogue);
            Orderfrom.Show();
            this.Hide();
        }
        private void MakeNewOrderPageP_CheckedChanged(object sender, EventArgs e)
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue customerCatalogue = new CustomerCatalogue();
            OrderCatalogue orderCatalogue = new OrderCatalogue(customerCatalogue, prodCatalogue);
            NewOrderForm NewOrderform = new NewOrderForm(prodCatalogue, orderCatalogue, customerCatalogue);
            NewOrderform.Show();
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
