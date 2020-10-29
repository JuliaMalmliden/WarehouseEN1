using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    public delegate void ProductChangeHandler();
    interface IProductCatalogue
    {
        List<Product> Products { get; set; }
        event ProductChangeHandler CatalogueChanged;

        void CurrentProductID();
        void AddProduct(String productName, double productPrice, int productStock, DateTime productRestock);
        void EditProduct(int pID, String productName, double productPrice, int productStock, DateTime productRestock); 

    }
}
