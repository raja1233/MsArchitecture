using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Entities
{
    public class State : IEntityBase
    {
        public State()
        {
            this.Cities = new HashSet<City>(); 
        }
        public long ID { get; set; }
        public long CountryId { get; set; }
        public string StateName { get; set; } 

        public Nullable<bool> IsDeleted { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; } 
    }
}
