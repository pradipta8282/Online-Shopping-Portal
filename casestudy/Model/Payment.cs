using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Payment
    {
        public string Paymentid { get; set; }
        public string Transactionid { get; set; }
        public string Customerid { get; set; }
        public string Paymentdate { get; set; }
        public string Penalty { get; set; }

        public virtual Customerinfo Customer { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
