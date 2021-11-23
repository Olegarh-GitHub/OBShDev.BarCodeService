using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.DAL
{
    public class ProducerRepository : Repository<Producer>
    {
        public ProducerRepository(ApplicationContext context) : base(context) { }
    }
}