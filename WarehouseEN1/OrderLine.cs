using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    /// <summary>
    /// This class is the mold for creating an orderline.
    /// The orderline purpose is to define what properties an orderline have to have and to protect the integrity of these.
    /// The orderline is a part of the order and exist to facilitate the processing of orders. 
    /// </summary>
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
