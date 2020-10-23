using System;
using System.Collections.Generic;

namespace WarehouseEN1
{
    public class Order
    {

        private int orderNumber;
        private int customerID;
        private String orderAddress;
        private List<Product> orderList;
        private Customer customer; 


        public int OrderNumber { get { return orderNumber; } set { orderNumber = value; } }
        public int CustomerID { get { return customerID; } set { customerID = value; } }
        public string OrderAddress { get { return orderAddress; } set { orderAddress = value; } }
        public List<Product> OrderList { get { return orderList; } set { orderList = value; } }
        public string State { get; private set; }
        public Customer cUstomer { get {return customer; } set { customer = value; } }

        public Order() 
        { 
        }
        public Order(int on, int cid, string oa, List<Product> ol, string s, Customer c)
        {
            OrderNumber = on;
            CustomerID = cid;
            OrderAddress = oa;
            OrderList = ol;
            State = s;
            cUstomer = c; 

        }
        public void ChangeState(string aState)
        {
            if (aState == "Packed" || aState == "Dispatched" || aState == "Delivered")
            {
                State = aState;
            }
        }


    }
}
