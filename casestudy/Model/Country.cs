using System;
using System.Collections.Generic;

#nullable disable

namespace casestudy.Model
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public string Countryid { get; set; }
        public string Countryname { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
