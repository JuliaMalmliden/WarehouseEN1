using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WarehouseEN1
{
    public class Product
    {
        private int productID;
        private string productName;
        private double productPrice;
      //  private DateTime productStock;
       // private DateTime nextRestock; 

        private int productStock;
        private string nextRestock; 
        public int ProductID { get { return productID; } set { productID = value; } }
        public string ProductName 
        { 
            get { return productName; } 
            set 
            { if(value == null || value == "") 
                { } 
                productName = value; 
            } 
        
        }
        public double ProductPrice 
        { 
            get { return productPrice; } 
            set 
            { if (value == null)
                {

                }
                productPrice = value; 
            } 
        }
        public int ProductStock //DateTime ProductStock
        { 
            get { return productStock; } 
            set 
            {
                if (value == null)
                {

                }
                productStock = value; 
            } 
        }
        public string NextRestock //DateTime NextRestock 
        { 
            get { return nextRestock; } 
            set 
            { nextRestock = value; } 
        }


        public Product()
        {

        }
        public Product(int id, string nm, double pr, int stk, string ns)     //DateTime stk, DateTime ns)
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


    }
}
