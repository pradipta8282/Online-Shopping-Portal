using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Customerinfo
    {
        public Customerinfo()
        {
            Carts = new HashSet<Cart>();
            Orders = new HashSet<Order>();
            Payments = new HashSet<Payment>();
            Transactions = new HashSet<Transaction>();
        }

        public string Custid { get; set; }
        public string Custname { get; set; }
        public string Contactno { get; set; }
        public string Custemail { get; set; }
        public string Custcity { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
