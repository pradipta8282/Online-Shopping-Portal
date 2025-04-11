using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public string CatgId { get; set; }
        public string CatgName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
