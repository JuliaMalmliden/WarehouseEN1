using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    /// <summary>
    /// This interface gives you a picture of all the public properties of the OrderCatalogue
    /// </summary>
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
