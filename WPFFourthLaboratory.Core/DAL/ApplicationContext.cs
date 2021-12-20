using System.Data.Entity;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public ApplicationContext() : base("Goods") { }
    }
}