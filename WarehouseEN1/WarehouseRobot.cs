using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    abstract class WarehouseRobot
    {
        public int OrderID { get; private set; }
        public WarehouseRobot(int orderid)
        {
            OrderID = orderid;
        }
        public abstract void ProcessOrder(Order o);
    }
}
