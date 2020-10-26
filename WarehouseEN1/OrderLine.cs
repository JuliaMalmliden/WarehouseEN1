using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    public class OrderLine
    {
        private Product orderedProduct;
        private int count;

        public Product OrderedProduct { get { return orderedProduct; } set { orderedProduct = value; } }
        public int Count { get { return count; } set { count = value; } }

        public OrderLine()
        {

        }
        public OrderLine(Product p, int c)
        {
            OrderedProduct = p; 
            Count = c; 
        }
    }
}
