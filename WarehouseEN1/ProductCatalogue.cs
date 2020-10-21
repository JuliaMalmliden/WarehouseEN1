using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    class ProductCatalogue
    {
        private void WriteProductsToFile()
        {
            string contents = JsonSerializer.Serialize(products);
            File.WriteAllText("products.JSON", contents);//EDiT
        }
        private void ReadProductsFromFile()
        {
            if (File.Exists("products.JSON"))
            {
                string fileContents = File.ReadAllText(filename);
                products = JsonSerializer.Deserialize<List<Product>>(fileContents);
            }
            else products = new List<Product>();
        }

    }
}
