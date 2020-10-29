﻿using System;
using System.Collections.Generic;

namespace WarehouseEN1
{    /// <summary>
     /// This class is the mold for creating an order.
     /// The order purpose is to define what properties an order have to have and to protect the integrity of these. 
     /// </summary>
    public class Order
    {

        private int orderNumber;
        private Customer customer;        
        private DateTime orderDate; 
        private String deliveryAddress;
        private bool paymentCompleted;
        private bool paymentRefunded;
        private bool dispatched; 
        private List<OrderLine> items;


        public int OrderNumber { get { return orderNumber; } set { orderNumber = value; } }
        public Customer Customer { get {return customer; } set { customer = value; } }

        public DateTime OrderDate  { get { return orderDate; }  set { orderDate = value; } }
        public string DeliveryAddress { get { return deliveryAddress; } set { deliveryAddress = value; } }
        public bool PaymentCompleted { get { return paymentCompleted; } set { paymentCompleted = value; } }
        public bool PaymentRefunded { get { return paymentRefunded; } set { paymentRefunded = value; } }
        public bool Dispatched { get { return dispatched; } set { dispatched = value; } }        
        public List<OrderLine> Items { get { return items; } set { items = value; } }

        public Order()
        { 
        }
        public Order(int on, Customer c, string da, List<OrderLine> i, DateTime date, bool pc)
        {
            OrderNumber = on;
            Customer = c;            
            OrderDate = date;
            deliveryAddress = da;      
            paymentCompleted = pc;
            paymentRefunded = false;
            dispatched = false; 
            Items = i;

        }
        public override string ToString()
        {   
            return "ID:" + OrderNumber + " Name: " + Customer.Name + " Date order was placed: " + OrderDate + " Deliveryaddress: " + DeliveryAddress+ " Payment completed:" + paymentCompleted + " Payment refunded:" + PaymentRefunded +" Dispatched: " + Dispatched;
       
        }
        public void RefundPayment()
        {
            paymentRefunded = true; 
        }
        public void DispatchOrder()
        {
            dispatched = true; 
        }


    }
}
