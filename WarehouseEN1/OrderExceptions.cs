using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WarehouseEN1
{
    class OrderExceptions: Exception
    {
        /// <summary>
        /// This class inherits from exception and will pass the message given in the constructor to the Exception class.
        /// The purpose with class is to be able to create our own exceptions which are relevant to our program.
        /// It is used for Order related exceptions.
        /// </summary>
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
