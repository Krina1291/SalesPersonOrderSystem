using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                    try
                    {
                        dao.AddOrder(order, cname, spname);
                        Console.WriteLine("Order Details Added Successfully");
                    }
                    catch (InvalidOrderAmountException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidCustomerNameException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (InvalidSalesPersonNameException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        
                    }
                    break;
                case 2:
                    try
                    {
                        Console.Write("Enter SalesPerson Name:");
                        string name = Console.ReadLine();
                        var lstorders = dao.DisplayDetails(name);


                        foreach (var e in lstorders)
                        {
                            Console.WriteLine($"{e.order_date}\t{e.Order_id}\t{e.Amount}\t{e.cust_id}\t{e.salesperson_id}");
                        }
                    }
                    catch (InvalidSalesPersonNameException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (NoOrdersFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
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

            // Order Exception Cases

            if (order.Amount <= 0)
            {
                throw new InvalidOrderAmountException("Invalid amount, must be greater than 0");
            }

            /*  DateTime dDate;
            if (DateTime.TryParse(order.order_date.ToString(), out dDate))
            {
                String.Format("{0:dd/MM/yyyy}", dDate);
                Console.WriteLine("Invalid");
            }*/
            var rst4 = dbCtx.Customers.Where(c => c.Name == cname).ToList();

            if (rst4.Count() == 0)
            {
                throw new InvalidCustomerNameException("Customer name does not exist");
            }

            var rst5 = dbCtx.SalesPersons.Where(s => s.Name == sname).ToList();

            if (rst5.Count() == 0)
            {
                throw new InvalidSalesPersonNameException("Sales person name does not exist");
            }



            order.salesperson_id =  dbCtx.SalesPersons
                                     .Where(e => e.Name == sname)
                                     .Select(o => o.ID).FirstOrDefault();

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
                                     .Where(e => e.Name == name).OrderBy(o => o.ID)
                                     .Select(o => o.ID).FirstOrDefault();
            var id2 = dbCtx.Orders
                                     .Where(e => e.salesperson_id == id).ToList();
            var id1 = dbCtx.SalesPersons
                                     .Where(e => e.Name == name);
            if (id1.Count() == 0)
            {
                throw new NoOrdersFoundException("Sales person name does not exist");
            }
            if (id2.Count() == 0)
            {
                throw new NoOrdersFoundException("No orders found for this sales person");
            }
            else
            {
                var result = dbCtx.Orders.Where(e=>e.salesperson_id==id).ToList();
                return result;
            }
        }
    }
}
