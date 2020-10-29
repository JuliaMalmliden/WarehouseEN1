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
    /// <summary>
     /// This class handle all the interaction with the use of the ProductForm.
     /// The Productform purpose is to add, edit and display products to the warehouse-employees point of view. 
     /// </summary>
    public partial class ProductForm : Form
    {
        int selectedProduct;
        private string productName;
        private double productPrice;
        private int productStock;
        private DateTime productRestock; 
        private ProductCatalogue prodCatalogue;
        private CustomerCatalogue customerCatalogue;
        private OrderCatalogue orderCatalogue; 
        public List<Product> Displaylist; 
        
        public ProductForm(ProductCatalogue prodCatalogue, CustomerCatalogue customerCatalogue, OrderCatalogue orderCatalogue)
        {
            this.prodCatalogue = prodCatalogue;
            this.customerCatalogue = customerCatalogue;
            this.orderCatalogue = orderCatalogue; 
            InitializeComponent();

            prodCatalogue.CatalogueChanged += RefreshListboxContents;
            RefreshListboxContents();

            Displaylist = new List<Product>();
            
        }

        /// <summary>
        /// This method writes the productlist to the list visual to the user. 
        /// </summary>
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
            catch(Exception ex )
            {
                throw new ProductExceptions("Did not manage to execute because of: ", ex);

            }
        }
        /// <summary>
        /// This method checks for what index is selected in the list of products.
        /// It also prints the properties of the selected item in the textboxes. 
        /// </summary>
        private void ProductList_SelectedIndexChanged(object sender, EventArgs e)
        {

            selectedProduct = ProductList.SelectedIndex;
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            
            ProdNametextBox.Text = prd.ProductName;
            ProductPricetextbox.Text = prd.ProductPrice.ToString();
            ProductStocktextBox.Text = prd.ProductStock.ToString();     
            ProNextRestocktextBox.Text = prd.NextRestock.ToString();    
        }
        /// <summary>
        /// This method retrieves the information from the textboxes.
        /// </summary>
        private void GetTextBox()
        {
            try
            {
                productName = ProdNametextBox.Text;
                productPrice = Convert.ToDouble(ProductPricetextbox.Text);
                productStock = Convert.ToInt32(ProductStocktextBox.Text);
                productRestock = Convert.ToDateTime(ProNextRestocktextBox.Text);
                
            }
            catch (Exception ex)
            {
               // throw new ProductExceptions("Did not manage to execute because of: ", ex);
                MessageBox.Show("Did not manage to execute because of: " + ex);
            }

        }
        /// <summary>
        /// This method adds a newly created product.
        /// </summary>
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
        }
        /// <summary>
        /// This method saves the changes made to an previously added product.
        /// </summary>
        private void ProductEditButton_Click(object sender, EventArgs e)
        {
            GetTextBox(); 
            Product prd = prodCatalogue.Products.ElementAt(selectedProduct);
            int prdID = prd.ProductID; 
            prodCatalogue.EditProduct(prdID, productName, productPrice, productStock, productRestock); 


        }
        /// <summary>
        /// This method display the products that are out of stock.
        /// </summary>
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
        /// <summary>
        /// This method Display the product that are to be re-stocked first out of the products. 
        /// </summary>
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
        /// <summary>
        /// This method takes the user to the Customerform.
        /// </summary>
        private void CustomerPageP_CheckedChanged(object sender, EventArgs e)
        {
            CustomerList CustomerList = new CustomerList(prodCatalogue, customerCatalogue, orderCatalogue); //only cust before
            CustomerList.Show();
            this.Hide();

        }
        /// <summary>
        /// This method takes the user to the Orderform.
        /// </summary>
        private void OrderPageP_CheckedChanged(object sender, EventArgs e)
        {
            OrderForm Orderfrom = new OrderForm(prodCatalogue, customerCatalogue, orderCatalogue);
            Orderfrom.Show();
            this.Hide();
        }
        /// <summary>
        /// This method takes the user to the NewOrderform.
        /// </summary>
        private void MakeNewOrderPageP_CheckedChanged(object sender, EventArgs e)
        {

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
