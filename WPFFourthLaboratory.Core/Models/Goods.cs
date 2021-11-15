using System;
using System.Text;
using WPFFourthLaboratory.DAL.Interfaces;

namespace WPFFourthLaboratory.DAL.Models
{
    public class Goods : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }
        
        public Producer Producer { get; set; }
        public int ProducerId { get; set; }
    }
}