using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.DAL.Models.BarCode.Base;
using WPFFourthLaboratory.DAL.Models.Entities;

namespace WPFFourthLaboratory.DAL.Interfaces
{
    public interface IBarCodeService
    {
        string GenerateBarCode(Product product);
        string GenerateBarCode(string code);
        bool CheckBarCode(string code);
    }
}