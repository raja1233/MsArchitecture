using Park.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data.Configurations
{
    public class StateConfiguration : EntityBaseConfiguration<State>
    {
        public StateConfiguration()
        {
            Property(x => x.ID).HasColumnName(@"ID").IsRequired().HasColumnType("bigint") ;
            Property(x => x.CountryId).HasColumnName(@"CountryId").IsRequired().HasColumnType("bigint");
            Property(x => x.StateName).HasColumnName(@"StateName").IsRequired().HasColumnType("nvarchar").HasMaxLength(100);  
        }
    }
}
