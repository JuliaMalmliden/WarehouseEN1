using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarehouseEN1
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() //WEEEEYWEEEEYY
        {
            ProductCatalogue prodCatalogue = new ProductCatalogue();
            CustomerCatalogue customerCatalogue = new CustomerCatalogue(); //orderCatalogue
            OrderCatalogue orderCatalogue = new OrderCatalogue(customerCatalogue, prodCatalogue);


            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ProductForm(prodCatalogue, customerCatalogue, orderCatalogue));

           /* var currentTime = DateTime.Now;
            currentTime.ToShortDateString();
            Console.WriteLine(currentTime.ToShortDateString());
            */
        }

    }
}
