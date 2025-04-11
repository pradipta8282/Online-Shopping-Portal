using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            Transactions = new HashSet<Transaction>();
        }

        public string Productid { get; set; }
        public string Productname { get; set; }
        public int? Productprice { get; set; }
        public string Producturl { get; set; }
        public string Categoryid { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
