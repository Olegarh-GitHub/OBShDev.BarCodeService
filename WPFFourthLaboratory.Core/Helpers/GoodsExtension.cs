using System;
using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.Helpers
{
    public static class GoodsExtension
    {
        public static void SetCode(this Goods goods)
        {
            var result = "";
            for (var i = 0; i < 3 - goods.Id.ToString().Length; i++)
                result += '0';
            
            result += goods.Id.ToString();
            
            if (result.Length > 3)
                throw new ArgumentException();

            goods.Code = result;
        }
    }
}