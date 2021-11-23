using System.Data.Entity;
using System.Linq;
using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class GoodsRepository : Repository<Goods>
    {
        public GoodsRepository(ApplicationContext context) : base(context) { }

        public override IQueryable<Goods> Read()
        {
            return base.Read()
                .Include(x => x.Country)
                .Include(x => x.Producer);
        }

        public override Goods Create(Goods obj)
        {
            obj.SetCode();
            
            return base.Create(obj);
        }
    }
}