using System.Data.Entity;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public ApplicationContext() : base("Goods") { }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.SetInitializer<ApplicationContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}