using WPFFourthLaboratory.DAL.Interfaces;

namespace WPFFourthLaboratory.DAL.Models
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public ushort Code { get; set; }
        public string Name { get; set; }
    }
}