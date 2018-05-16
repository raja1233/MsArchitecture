using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.ViewModel
{
   public class CountryViewModel
    {
        public long ID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public Nullable<bool> IsDeleted { get; set; }
    }
}
