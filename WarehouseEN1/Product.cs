using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace WarehouseEN1
{
    public class Product
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
            return  "ID: " + ProductID + "    Name:  " + ProductName + "(" + ProductPrice + " kr)" + "   Stock: " +ProductStock + "     Next restock: "+ NextRestock;
        }
        public bool PriceIsValid()
        {
            return ProductPrice >= 0 && ProductPrice <= 9999;
        }


    }
}
