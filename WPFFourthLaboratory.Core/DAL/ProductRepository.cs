using System.Data.Entity;
using System.Linq;
using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(ApplicationContext context) : base(context) { }

        public override IQueryable<Product> Read()
        {
            return base.Read()
                .Include(x => x.Country)
                .Include(x => x.Producer);
        }
    }
}