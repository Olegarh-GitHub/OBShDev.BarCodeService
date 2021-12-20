using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Models.Entities.Base;

namespace WPFFourthLaboratory.DAL.Models.Entities
{
    public class Product : Entity
    {
        public Product() { }
        public Product(string name, string description, Country country, Producer producer)
        {
            Name = name;
            Description = description;
            Country = country;
            Producer = producer;
        }

        public override string ToString()
        {
            return Name;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }
        
        public Producer Producer { get; set; }
        public int ProducerId { get; set; }
    }
}