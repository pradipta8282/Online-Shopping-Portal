using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Transaction
    {
        public Transaction()
        {
            Payments = new HashSet<Payment>();
        }

        public string Transactionid { get; set; }
        public string Custid { get; set; }
        public string Productid { get; set; }
        public string Productname { get; set; }
        public string Branchid { get; set; }
        public int? Qty { get; set; }
        public DateTime? Transdate { get; set; }

        public virtual Branch Branch { get; set; }
        public virtual Customerinfo Cust { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
