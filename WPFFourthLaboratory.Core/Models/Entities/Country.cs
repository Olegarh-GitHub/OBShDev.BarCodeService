using System;
using WPFFourthLaboratory.DAL.Models.Entities.Base;

namespace WPFFourthLaboratory.DAL.Models.Entities
{
    public class Country : Entity
    {
        public Country() { }
        public Country(int code, string name)
        {
            if (code.ToString().Length > 4)
                throw new ArgumentException("У страны только 3 цифры в коде");

            Code = code;
            Name = name;
        }
        
        public int Code { get; set; }
        public string Name { get; set; }
    }
}