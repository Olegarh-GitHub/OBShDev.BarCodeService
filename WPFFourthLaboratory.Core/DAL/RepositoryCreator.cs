using WPFFourthLaboratory.DAL.Interfaces;
using WPFFourthLaboratory.DAL.Models.Entities;
using WPFFourthLaboratory.DAL.Models.Entities.Base;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class RepositoryCreator
    {
        private readonly ApplicationContext _context = new ApplicationContext();

        public IRepository<Country> CountryRepository { get; }
        public IRepository<Goods> GoodsRepository { get; }
        public IRepository<Producer> ProducerRepository { get; }

        public RepositoryCreator()
        {
            CountryRepository = new CountryRepository(_context);
            GoodsRepository = new GoodsRepository(_context);
            ProducerRepository = new ProducerRepository(_context);
        }
    }
}