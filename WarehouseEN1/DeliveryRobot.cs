using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    class DeliveryRobot : WarehouseRobot
    {
        public int OrderID { get; private set; }
        public DeliveryRobot(int orderid) : base(orderid)
        {
            OrderID = orderid;

        }
        public override void ProcessOrder(Order anOrder)
        {
            anOrder.ChangeState("Delivered");
        }
    }
}
