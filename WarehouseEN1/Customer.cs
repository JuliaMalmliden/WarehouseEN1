using System;
using System.Collections.Generic;
using System.Text;

namespace WarehouseEN1
{
    private int customerID;
    private string fname;      //first name
    private string lname;   //last name
    private string eMail;
   
    public string CustomerID { get { return customerID; } set { customerID = value; } }
    public string Fname { get { return fname; } set { fname = value; } }
    public string Lname { get { return lname; } set { lname = value; } }
    public string EMail { get { return eMail; } set { eMail = value; } }
    //DOB ?

    class Customer
    {
        Customer() { }

        Customer(int id, string fn, string ln, string em)
        {
            CustomerID = id;
            Fname= fn;
            Lname = ln;
            EMail = em;
        }
        public override string ToString()
        {
            return "ID: " + CustomerID + "    FirstName:  " + Fname + "LastName"+ Lname+"   Email: " + eMail;

        }
   

    }

}