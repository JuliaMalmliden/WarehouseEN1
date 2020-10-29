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

        private void RaiseCatalogueChanged() //to check if a change was made and if so update the catalogue
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
        }

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


        private void WriteProductsToFile()
        {
            string contents = JsonSerializer.Serialize(Products);
            File.WriteAllText(filename, contents);
        }
        private void ReadProductsFromFile()
        {
            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                Products = JsonSerializer.Deserialize<List<Product>>(fileContents);
            }
            else Products = new List<Product>();
        }

       public void AddProduct(String productName, double productPrice, int productStock, DateTime productRestock) //string productRestock)
       {
            currentProdID++;
            
                Product prod = new Product(currentProdID, productName, productPrice, productStock, productRestock); 
                Products.Add(prod);
                WriteProductsToFile();
                RaiseCatalogueChanged();

       }

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
