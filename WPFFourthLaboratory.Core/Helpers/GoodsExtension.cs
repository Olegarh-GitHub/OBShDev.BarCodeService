using System;
using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.Helpers
{
    public static class GoodsExtension
    {
        public static void SetCode(this Product product)
        {
            var result = "";
            for (var i = 0; i < 3 - product.Id.ToString().Length; i++)
                result += '0';
            
            result += product.Id.ToString();
            
            if (result.Length > 3)
                throw new ArgumentException();

            product.Code = result;
        }
    }
}