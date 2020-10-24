using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    class PackingRobot : WarehouseRobot
    {
        public int OrderID { get; private set; }
        public PackingRobot(int orderid) : base(orderid)
        {
            OrderID = orderid;

        }
        public override void ProcessOrder(Order anOrder)
        {
            anOrder.ChangeState("Packed");
        }
    }
}
