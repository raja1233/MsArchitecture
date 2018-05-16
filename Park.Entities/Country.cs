using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Entities
{
    public class Country : IEntityBase
    {
        public Country()
        {
            this.States = new HashSet<State>(); 
        }

        public long ID { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; } 

        public Nullable<bool> IsDeleted { get; set; }

        public virtual ICollection<State> States { get; set; } 
    }
}
