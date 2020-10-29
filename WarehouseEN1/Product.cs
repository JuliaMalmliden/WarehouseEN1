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
                {
                    throw new ProductExceptions("Product name cannot be null or empty.");
                } 
                productName = value; 
            } 
        }
        public double ProductPrice 
        { 
            get { return productPrice; } 
            set 
            { if (productPrice == null || productPrice <= 0 )
                {
                    throw new ProductExceptions("Product price cannot be negative or 0.");

                }
                productPrice = value; 
            } 
        }
        public int ProductStock //DateTime ProductStock
        { 
            get { return productStock; } 
            set 
            {
                if (productStock == null)
                {
                    throw new ProductExceptions("Product Stock cannnot be empty");
                }
                productStock = value; 
            } 
        }
        public DateTime NextRestock //DateTime NextRestock 
        { 
            get { return nextRestock; } 
            set 
            {
                if (firstAvailableDate <= DateTime.Now)
                {
                    throw new OrderExceptions("Date format incorrect, cannot be earlier than of current date.");
                }
                else
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
                nextRestock = value; } 
        }
        public DateTime FirstAvailableDate
        {
            get { return firstAvailableDate; }
            set
            {
                if (firstAvailableDate <= DateTime.Now)
                {
                    throw new OrderExceptions("Date format incorrect, cannot be earlier than of current date.");
                }
                else
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
                firstAvailableDate = value;
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
        /// <summary>
        /// This method converts the single object to a string. 
        /// </summary>
        public override string ToString()
        {   
            return  "ID: " + ProductID + "    Name:  " + ProductName + "(" + ProductPrice + " kr)" + "   Stock: " +ProductStock + "     Next restock: "+ NextRestock;
        }


    }
}
