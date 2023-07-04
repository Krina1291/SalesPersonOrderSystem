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
            IDataAccess dao = new IDataAccess();
            

            int choice;
            Console.WriteLine("1. Add Orders\n2. Display Orders\n3.Exit");
            Console.WriteLine("Enter the choice");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Order order = new Order();
                    
                    string cname, spname;
                    order.order_date = DateTime.Now.Date;
                    //  Console.WriteLine("Enter Order date (ddmmyyyy");
                    // date = Console.ReadLine();
                    Console.WriteLine("Enter Order Amount:");
                    order.Amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Customer Name:");
                    cname = Console.ReadLine();
                    Console.WriteLine("Enter Sales Person Name:");
                    spname = Console.ReadLine();
                    
                    
                    dao.AddOrder(order,cname,spname);
                    Console.WriteLine("Order Details Added Successfully");
                    break;
                case 2:
                    Console.Write("Enter SalesPerson Name:");
                    string name = Console.ReadLine();
                    var lstorders = dao.DisplayDetails(name);
                    

                    foreach (var e in lstorders)
                    {
                        Console.WriteLine($"{e.order_date}\t{e.Order_id}\t{e.Amount}\t{e.cust_id}\t{e.salesperson_id}");
                    }


                    break;
                case 3:
                    break;
                default:
                    break;
            }
        }
    }

    class IDataAccess
    {
        public void AddOrder(Order order,string cname,string sname)
        {



            var dbCtx = new ORDERDBEntities();

            order.salesperson_id =  dbCtx.SalesPersons
                                     .Where(e => e.Name == sname)
                                     .Select(o => o.ID).FirstOrDefault();
            /* order.salesperson_id = Convert.ToInt32(dbCtx.Customers
                                   .Where(e => e.Name == cname)
                                   .Select(o => o.ID));*/
            order.cust_id = dbCtx.Customers
                .Where(e => e.Name == cname)
                .Select(o => o.ID).FirstOrDefault();

            dbCtx.Orders.Add(order);


            dbCtx.SaveChanges();
        }


       
        public List<Order> DisplayDetails (string name)
        {
            var dbCtx = new ORDERDBEntities();
            var id = dbCtx.SalesPersons
                                     .Where(e => e.Name == name)
                                     .Select(o => o.ID).FirstOrDefault();
            if (id != 0)
            {
                
                
                var result = dbCtx.Orders.Where(e=>e.salesperson_id==id).ToList();
                

                return result;
            }
            else
            {
                throw new Exception("SalesPerson does not exist");
            }
        }
    }
}
