using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Entities
{
     public class City:IEntityBase
    {
         public City()
         {
             this.Customers = new HashSet<Customer>();
         
         }
        public long ID { get; set; }
        public long StateId { get; set; }
        public string CityName { get; set; } 

        public Nullable<bool> IsDeleted { get; set; }

        public virtual State State { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
