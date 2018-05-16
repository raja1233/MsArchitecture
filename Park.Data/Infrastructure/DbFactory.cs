using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        ParkContext dbContext;

        public ParkContext Init()
        {
            return dbContext ?? (dbContext = new ParkContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
