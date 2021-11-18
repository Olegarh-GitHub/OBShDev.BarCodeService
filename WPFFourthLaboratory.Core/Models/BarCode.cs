using System.Collections.Generic;

namespace WPFFourthLaboratory.DAL.Models
{
    public class BarCode
    {
        public string Code { get; set; }

        public override string ToString()
        {
            return $"{Code[0]} {Code.Substring(1,6)} {Code.Substring(7)}";
        }

        public List<string> Blocks =>
            new List<string>()
            {
                $"{Code[0]}",
                $"{Code.Substring(1, 6)}",
                $"{Code.Substring(7, 6)}"
            };
    }
}