using System.Linq;
using WPFFourthLaboratory.DAL.Models.Entities.Base;

namespace WPFFourthLaboratory.DAL.Interfaces
{
    public interface IRepository<T> : IRepository
    where T : Entity
    {
        IQueryable<T> Read();
        T Create(T obj);
        T Update(T obj);
        bool Delete(T obj);
    }
    
    public interface IRepository { }
}