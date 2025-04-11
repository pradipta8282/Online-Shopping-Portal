using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class City
    {
        public City()
        {
            Branches = new HashSet<Branch>();
        }

        public string Cityid { get; set; }
        public string Cityname { get; set; }
        public string Countryid { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
