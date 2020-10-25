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
        private DateTime orderDate; //added order date


        public int OrderNumber { get { return orderNumber; } set { orderNumber = value; } }
        public int CustomerID { get { return customerID; } set { customerID = value; } }
        public string OrderAddress { get { return orderAddress; } set { orderAddress = value; } }
        public List<Product> OrderList { get { return orderList; } set { orderList = value; } }
        public string State { get; private set; }
        public Customer Customer { get {return customer; } set { customer = value; } }
        public DateTime OrderDate  { get { return orderDate; }  set { orderDate = value; } }

        public Order() 
        { 
        }
        public Order(int on, int cid, string oa, List<Product> ol, Customer c, DateTime date)
        {
            OrderNumber = on;
            CustomerID = cid;
            OrderAddress = oa;
            OrderList = ol;
            State = "Ordered"; ;
            Customer = c;
            OrderDate = date;
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
