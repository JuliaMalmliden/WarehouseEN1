using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WarehouseEN1
{
    /// <summary>
    /// This class is the mold for creating a product.
    /// The product purpose is to define what properties an product have to have and to protect the integrity of these. 
    /// </summary>
    public class Product
    {
        private int productID;
        private string productName;
        private double productPrice;
        private int productStock;
        private DateTime nextRestock;
        private DateTime firstAvailableDate; 

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
        public DateTime NextRestock //DateTime NextRestock 
        { 
            get { return nextRestock; } 
            set 
            { nextRestock = value; } 
        }
        public DateTime FirstAvailableDate
        {
            get { return firstAvailableDate; }
            set
            {
                if (productStock == 0)
                {
                    firstAvailableDate = nextRestock;
                }
                else 
                {
                    firstAvailableDate = DateTime.Now; 
                }
            }
        }


        public Product()
        {

        }
        public Product(int id, string nm, double pr, int stk, DateTime  ns)  
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
