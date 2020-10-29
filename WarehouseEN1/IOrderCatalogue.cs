using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    public delegate void OrderChangeHandler();
    interface IOrderCatalogue
    {

       List<Order> Orders { get; set; }

       void CurrentOrderID(); 
       void AddOrder(Customer customer, string deliveryaddress, List<OrderLine> orderlist, DateTime date, bool paymentcompleted);
       void BatchProcessOrders();
       void DisplayPreviousOrers(Customer cust); 
        


    }
}
