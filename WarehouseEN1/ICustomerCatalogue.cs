using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    public delegate void CustomerChangeHandler();
    interface ICustomerCatalogue
    {
        List<Customer> Customers { get; set; }
        event CustomerChangeHandler CatalogueChanged;
        void CurrentCustomerID(); 
        void AddCustomer(string name, string phone, string email); 
        bool RemoveCustomerID(int custID); 
        void UpdateCustomer(int custID, string name, string ph, string email); 
    }
}
