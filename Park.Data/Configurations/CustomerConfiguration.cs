using Park.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data.Configurations
{
    public class CustomerConfiguration : EntityBaseConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(u => u.Name).IsRequired().HasMaxLength(100);
            Property(u => u.Email).IsRequired().HasMaxLength(100);
            Property(u => u.Phone).IsRequired().HasMaxLength(50);
            Property(u => u.DOB).IsRequired();
            Property(c => c.CityId).IsRequired();
            Property(c => c.ProfileImageURL).IsRequired().HasMaxLength(1000); 
        }
    }
}
