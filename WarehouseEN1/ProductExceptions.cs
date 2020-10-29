using System;

namespace WarehouseEN1
{
    public class ProductExceptions:Exception
    {
        /// <summary>
        /// This class inherits from exception and will pass the message given in the constructor to the Exception class.
        /// The purpose with class is to be able to create our own exceptions which are relevant to our program.
        /// It is used for Product related exceptions.
        /// </summary>
        public ProductExceptions(string message, Exception innerException)
            :base(message, innerException)
        {

        }
        public ProductExceptions(string message)
            : base(message)
        {

        }
    }
}
