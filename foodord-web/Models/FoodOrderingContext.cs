using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace foodord_web.Models
{
    public class FoodOrderingContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedFood> OrderedFoods { get; set; }

        public FoodOrderingContext() : base("FoodOrderingContext") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}