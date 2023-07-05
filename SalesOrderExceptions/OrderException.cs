using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

}
