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

        // private void RaiseProductCatalogueChanged()
        //{
        //  if (CatalogueChanged != null)
        //     CatalogueChanged();
        //  }
        public void AddProduct(Product p)
        {
            products.Add(p);
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
                //RaiseCatalogueChanged();
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
            //RaiseCatalogueChanged();
            return true;
        }

        public bool UpdateProductPrice(string name, double price)
        {
            Product p = FindProduct(name);
            if (p == null)
                return false;
            p.ProductPrice = price;
            //RaiseCatalogueChanged();
            return true;
        }

        public IEnumerable<Product> AllProducts()
        {
            return products;
        }

        public double GetTotalPrice()
        {
            return products.Sum(p => p.Price);
        }


        private void WriteProductsToFile()
        {
            string contents = JsonSerializer.Serialize(products);
            File.WriteAllText("products.JSON", contents);
        }

        private void ReadProductsFromFile()
        {
            if (File.Exists("products.JSON"))
            {
                string fileContents = File.ReadAllText("products.JSON");
                products = JsonSerializer.Deserialize<List<Product>>(fileContents);
            }
            else products = new List<Product>();
        }

    }
}
