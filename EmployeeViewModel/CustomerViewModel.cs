using Park.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.ViewModel
{
   public class CustomerViewModel
   {
       public long ID { get; set; }
       public string Name { get; set; }
       public string Email { get; set; }
       public string Phone { get; set; }
       public Nullable<DateTime> DOB { get; set; }
       public Nullable<long> CityId { get; set; }
       public Nullable<long> CountryId { get; set; }
       public Nullable<long> StateId { get; set; }
       public string ProfileImageURL { get; set; }
       public Nullable<bool> IsDeleted { get; set; }

       public string CityName { get; set; }
       //public virtual City City { get; set; }
    }
}
