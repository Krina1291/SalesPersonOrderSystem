using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

using System.IO;

 

namespace SalesOrderExceptions

{

    public class OrderException

    {

    }



    public class InvalidOrderAmountException : Exception

    {

        public InvalidOrderAmountException(string errMsg) : base(errMsg)

        {



        }

    }



    public class InvalidCustomerNameException : Exception

    {

        public InvalidCustomerNameException(string errMsg) : base(errMsg)

        {



        }

    }



    public class InvalidSalesPersonNameException : Exception

    {

        public InvalidSalesPersonNameException(string errMsg) : base(errMsg)

        {



        }

    }



    public class NoOrdersFoundException : Exception

    {

        public NoOrdersFoundException(string errMsg) : base(errMsg)

        {



        }

    }



    public static class ErrorLogger

    {

        public static void LogError(Exception ex)

        {

            //log the error in txt file

            string fileName = "C:\\Users\\Krina.Patel\\Desktop\\.NET_Project\\SalesPersonOrderSystem\\Logs\\errors.txt";



            string str = "------------------------------------------";

            str += "Error Description: " + ex.Message;

            str += "Date and Time: " + DateTime.Now.ToString();

            str += "StackTrace: " + ex.StackTrace;



            if (File.Exists(fileName))

            {

                File.AppendAllText(fileName, str);

            }

            else

            {

                File.Create(fileName);

            }

        }

    }



}