using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesOrderDAL
{
    public class OrderDetails
    {
        public string OrderDate { get; set; }
        public string CustName { get; set; }
        public string SalePersonName { get; set; }
        public double OrderAmount { get; set; }

        OrderDetails(string orderdate,double orderamount, string custname, string salepname)
        {
            this.OrderDate = orderdate;
            this.OrderAmount = orderamount;
            this.CustName = custname;
            this.SalePersonName = salepname;
        }

        public void Display()
        {

        }
    }
}
