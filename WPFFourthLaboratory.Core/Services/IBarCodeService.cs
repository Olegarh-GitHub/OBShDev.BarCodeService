using WPFFourthLaboratory.DAL.Models;

namespace WPFFourthLaboratory.DAL.Services
{
    public interface IBarCodeService
    {
        BarCode GenerateBarCode(Goods goods);

        bool CheckBarCode(BarCode barCode);
    }
}