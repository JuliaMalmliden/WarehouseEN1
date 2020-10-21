using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    class ProductCatalogue
    { 

        List<Product> products = new List<Product>();

        private string filename;

        public void PersistentProductCatalogue()
        {
            filename = "Products.JSON";
            ReadProductsFromFile();
        }

        /// <summary>
        /// Private function to call the event in order to avoid repeating the null check.
        /// </summary>
        //private void RaiseCatalogueChanged()
        //{
            //if (CatalogueChanged != null)
           //     CatalogueChanged();
        //}

        private void WriteProductsToFile()
        {
            string contents = JsonSerializer.Serialize(products);
            File.WriteAllText(filename, contents);
        }
        private void ReadProductsFromFile()
        {
            if (File.Exists(filename))
            {
                string fileContents = File.ReadAllText(filename);
                products = JsonSerializer.Deserialize<List<Product>>(fileContents);
            }
            else products = new List<Product>();
        }

        //public event ChangeHandler CatalogueChanged;

        public void AddProduct(Product p)
        {
            products.Add(p);
            WriteProductsToFile();
            //RaiseCatalogueChanged();
        }

        public Product FindProduct(string name)
        {
            foreach (Product p in products)
                if (p.ProductName == name)
                    return p;
            return null;
        }

        public bool RemoveProduct(string name)
        {
            Product p = FindProduct(name);
            if (p == null)
                return false;
            if (products.Remove(p))
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

        public IEnumerable<Product> AllProducts()
        {
            return products;
        }

        //public double GetTotalPrice()
        //{
          //  return products.Sum(p => p.Price);
        //}


    }
}
