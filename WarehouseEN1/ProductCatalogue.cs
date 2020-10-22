using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    public class ProductCatalogue
    {
        public delegate void ProductChangeHandler();
        public List<Product> Products { get; set; }
        private string filename;
        public event ProductChangeHandler CatalogueChanged;
        public int currentProdID; 
        public ProductCatalogue()
        {
            filename = "Products.JSON";
            ReadProductsFromFile();

            CurrentProductID(); 
        }

        /// <summary>
        /// Private function to call the event in order to avoid repeating the null check.
        /// </summary>
        private void RaiseCatalogueChanged()
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

        public void AddProduct(String productName, double productPrice, int productStock, DateTime productRestock)
        {
            currentProdID++;
            try
            {
                Product prod = new Product(currentProdID, productName, productPrice, productStock, productRestock); 
                Products.Add(prod);
                WriteProductsToFile();
                RaiseCatalogueChanged();
            }
            catch
            {

            }
            
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




        //public double GetTotalPrice()
        //{
          //  return products.Sum(p => p.Price);
        //}


    }
}
