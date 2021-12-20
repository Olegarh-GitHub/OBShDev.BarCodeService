using System;
using WPFFourthLaboratory.DAL.Models.Entities.Base;

namespace WPFFourthLaboratory.DAL.Models.Entities
{
    public class Producer : Entity
    {
        public Producer() { }
        public Producer(int code, string name)
        {
            if (code.ToString().Length > 7)
                throw new ArgumentException("У производителя только 6 цифр в коде");

            Code = code;
            Name = name;
        }
        
        public int Code { get; set; }
        public string Name { get; set; }
    }
}