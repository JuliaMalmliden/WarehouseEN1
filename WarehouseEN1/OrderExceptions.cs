using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WarehouseEN1
{
    class OrderExceptions: Exception
    {
        public OrderExceptions(string message, Exception innerException)
            :base(message, innerException)
        {

        }
        public OrderExceptions(string message)
    : base(message)
        {

        }
    }
}
