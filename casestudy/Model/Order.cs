using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Order
    {
        public int Orderid { get; set; }
        public DateTime Orderdate { get; set; }
        public string Customerid { get; set; }
        public int Orderamnt { get; set; }
        public string Emailid { get; set; }
        public int Orderstat { get; set; }

        public virtual Customerinfo Customer { get; set; }
    }
}
