using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    class DispatchRobot : WarehouseRobot
    {
        public int OrderID { get; private set; }
        public DispatchRobot(int orderid) : base(orderid)
        {
            OrderID = orderid;

        }
        public override void ProcessOrder(Order anOrder)
            {
                anOrder.ChangeState("Dispatched");
            }
        }
}
