using System;

namespace WarehouseEN1
{
    public class ProductExceptions:Exception
    {
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
