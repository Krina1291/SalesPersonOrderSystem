using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesOrderDAL;
using SalesOrderEntities;
using SalesOrderExceptions;
using SalesOrderManager;

namespace SalesOrderClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string date, cname, spname;
            double amount;
            Console.WriteLine("Enter Order date (ddmmyyyy");
            date= Console.ReadLine();
            Console.WriteLine("Enter Order Amount:");
            amount = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Customer Name:");
            cname = Console.ReadLine();
            Console.WriteLine("Enter Sales Person Name:");
            spname = Console.ReadLine();

            int choice;
            Console.WriteLine("1. Add Orders\n2. Display Orders\n3.Exit");
            Console.WriteLine("Enter the choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }
}
