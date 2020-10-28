using System;

namespace WarehouseEN1
{
    public class CustomerExceptions : Exception 
    {
        public CustomerExceptions(string message, Exception innerException)
            :base(message, innerException)
        {

        }
        public CustomerExceptions(string message)
            :base (message)
       { 
            
       }


    }

}