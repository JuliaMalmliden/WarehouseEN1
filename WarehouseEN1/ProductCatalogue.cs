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
        public ProductCatalogue()
        {
            filename = "Products.JSON";
            ReadProductsFromFile();
        }

        /// <summary>
        /// Private function to call the event in order to avoid repeating the null check.
        /// </summary>
        private void RaiseCatalogueChanged()
        {
            if (CatalogueChanged != null)
                CatalogueChanged();
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

        public void AddProduct(Product p)
        {
            Products.Add(p);
            WriteProductsToFile();
            RaiseCatalogueChanged();
        }

         Product FindProduct(string name)
        {
            foreach (Product p in Products)
                if (p.ProductName == name)
                    return p;
            return null;
        }

        public bool RemoveProduct(string name)
        {
            Product p = FindProduct(name);
            if (p == null)
                return false;
            if (Products.Remove(p))
            {
                WriteProductsToFile();
               // RaiseCatalogueChanged();
                return true;
            }
            else return false;
        }

        public bool RenameProduct(string name, string newName)
        {
            Product p = FindProduct(name);
            if (p == null)
                return false;
            p.ProductName = newName;
            WriteProductsToFile();
           // RaiseCatalogueChanged();
            return true;
        }

        public bool UpdateProductPrice(string name, double price)
        {
            Product p = FindProduct(name);
            if (p == null)
                return false;
            p.ProductPrice = price;
            WriteProductsToFile();
           // RaiseCatalogueChanged();
            return true;
        }





        //public double GetTotalPrice()
        //{
          //  return products.Sum(p => p.Price);
        //}


    }
}
