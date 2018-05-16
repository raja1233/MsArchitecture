using Park.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data.Configurations
{
    public class CityConfiguration : EntityBaseConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("bigint");
            Property(x => x.StateId).HasColumnName(@"StateId").IsOptional().HasColumnType("bigint");
            Property(x => x.CityName).HasColumnName(@"CityName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);  
        }
    }
}
