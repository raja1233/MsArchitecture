using Park.Data.Configurations;
using Park.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Park.Data
{
    public class ParkContext : DbContext
    {
        public ParkContext()
            : base("AngularAssignment")
        {
            Database.SetInitializer<ParkContext>(null);
        }

        #region Entity Sets
        public IDbSet<Customer> CustomerSet { get; set; }
        public IDbSet<Country> CountrySet { get; set; }
        public IDbSet<State> StateSet { get; set; }
        public IDbSet<City> CitySet { get; set; } 

        #endregion

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new CountryConfiguration());
            modelBuilder.Configurations.Add(new StateConfiguration());
            modelBuilder.Configurations.Add(new CityConfiguration()); 
        }
    }
}
