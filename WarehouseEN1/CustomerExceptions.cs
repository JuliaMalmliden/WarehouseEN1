using System;

namespace WarehouseEN1
{
    public class CustomerExceptions : Exception 
    {
        /// <summary>
        /// This class inherits from exception and will pass the message given in the constructor to the Exception class.
        /// The purpose with class is to be able to create our own exceptions which are relevant to our program.
        /// It is used for Customer related exceptions.
        /// </summary>
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