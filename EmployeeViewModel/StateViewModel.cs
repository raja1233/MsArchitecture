using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.ViewModel
{
  public  class StateViewModel
  {
      public long ID { get; set; }
      public long CountryId { get; set; }
      public string StateName { get; set; } 
      public Nullable<bool> IsDeleted { get; set; } 

      public string CountryName { get; set; }
    }
}
