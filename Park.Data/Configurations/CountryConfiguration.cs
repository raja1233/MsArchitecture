using Park.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data.Configurations
{
    public class CountryConfiguration : EntityBaseConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("bigint") ;
            Property(x => x.CountryName).HasColumnName(@"CountryName").IsRequired().HasColumnType("nvarchar").HasMaxLength(500);
            Property(x => x.CountryCode).HasColumnName(@"CountryCode").IsRequired().HasColumnType("nvarchar").HasMaxLength(50); 
        }
    }
}
