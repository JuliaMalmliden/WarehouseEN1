using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    /// <summary>
    /// This class is a list of product and productfunctions.
    /// The productCatalogue contain functions related to the product objects. 
    /// </summary>
    public class ProductCatalogue
    {
        public delegate void ProductChangeHandler();
        public List<Product> Products { get; set; }
        private string filename;
        public event ProductChangeHandler CatalogueChanged;
        public int currentProdID;
    
        
        //DateTime currentTime = new DateTime(2019, 1, 1);
        public ProductCatalogue()
        {
            filename = "Products.JSON";
            ReadProductsFromFile();

            CurrentProductID(); 
        }
        /// <summary>
        /// This method keeps the catalogue up to date.
        /// </summary>
        private void RaiseCatalogueChanged() 
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }
        /// <summary>
        /// This method keeps track of the productID.
        /// </summary>
        public void CurrentProductID()
        {
            if (Products.Count == 0)
            {
                currentProdID = 0;
            }
            else
            {
                currentProdID = Products.Count; 
            }
        }
        /// <summary>
        /// This method writes down the productlist to a JSON-file, and uses the file as the programs database for the productinformation.
        /// </summary>
        private void WriteProductsToFile()
        {
            string contents = JsonSerializer.Serialize(Products);
            File.WriteAllText(filename, contents);
        }
        /// <summary>
        /// This method extract the productlist from the JASON-file, and splits the list into products. 
        /// </summary>
        private void ReadProductsFromFile()
        {
            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                Products = JsonSerializer.Deserialize<List<Product>>(fileContents);
            }
            else Products = new List<Product>();
        }
        /// <summary>
        /// This method recieves the information it needs to create an object of sort product and saves it to the Productlist, it also saves it to the "database". 
        /// </summary>
        public void AddProduct(String productName, double productPrice, int productStock, DateTime productRestock) //string productRestock)
        {
            currentProdID++;
            
                Product prod = new Product(currentProdID, productName, productPrice, productStock, productRestock); 
                Products.Add(prod);
                WriteProductsToFile();
                RaiseCatalogueChanged();

        }
        /// <summary>
        /// This method recieves the new productinformation and finds the matching object based on ID and overrides the old information in the list and the database.
        /// </summary>
        public void EditProduct(int pID, String productName, double productPrice, int productStock, DateTime productRestock)
        {
               Product product = Products.Single(p => p.ProductID == pID);
            
                product.ProductName = productName;
                product.ProductPrice = productPrice;
                product.ProductStock = productStock;
                product.NextRestock = productRestock;

                 WriteProductsToFile();
                 RaiseCatalogueChanged();

        } 


    }
}
