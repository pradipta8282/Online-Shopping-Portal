using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Cart
    {
        public int Cid { get; set; }
        public string Customerid { get; set; }
        public string Productid { get; set; }
        public string Productname { get; set; }
        public int Qty { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public DateTime Orderdate { get; set; }

        public virtual Customerinfo Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}
