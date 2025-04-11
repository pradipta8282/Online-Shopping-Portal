using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Branch
    {
        public Branch()
        {
            Transactions = new HashSet<Transaction>();
        }

        public string Branchid { get; set; }
        public string Branchname { get; set; }
        public string Cityid { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
