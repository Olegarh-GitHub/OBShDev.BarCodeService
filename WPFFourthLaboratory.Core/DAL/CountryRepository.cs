using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class CountryRepository : Repository<Country>
    {
        public CountryRepository(ApplicationContext context) : base(context) { }
    }
}