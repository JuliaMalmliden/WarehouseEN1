using System;

namespace WarehouseEN1
{
    public class CustomerException : Exception 
    {
        public CustomerException(string message, Exception innerException)
            :base(message, innerException)
        {

        }

    }

}