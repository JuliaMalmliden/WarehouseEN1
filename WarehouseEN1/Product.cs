using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    class Product
    {
        private int productID;
        private string productName;
        private double productPrice;
        private int productStock;
        private DateTime nextRestock; 
        public int ProductID { get { return productID; } set { productID = value; } }
        public string ProductName { get { return productName; } set { productName = value; } }
        public double ProductPrice { get { return productPrice; } set { productPrice = value; } }
        public int ProductStock { get { return productStock; } set { productStock = value; } }
        public DateTime NextRestock { get { return nextRestock; } set { nextRestock = value; } }


        public Product()
        {

        }
        public Product(int id, string nm, double pr, int stk, DateTime ns)
        {
            ProductID = id; 
            ProductName = nm;
            ProductPrice = pr;
            ProductStock = stk;
            NextRestock = ns; 

        }
        public override string ToString()
        {
            return ProductName + "(" + ProductPrice + ")";
        }
        public bool PriceIsValid()
        {
            return ProductPrice >= 0 && ProductPrice <= 9999;
        }



    }
}
