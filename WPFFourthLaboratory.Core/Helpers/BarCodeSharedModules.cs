using System.Collections.Generic;
using System.Windows.Media;
using WPFFourthLaboratory.DAL.Models.BarCode;

namespace WPFFourthLaboratory.DAL.Helpers
{
    public static class BarCodeSharedModules
    {
        public static BarCodeModule GetGenericSeparator()
        {
            var stripes = new List<BarCodeStripe>()
            {
                new BarCodeStripe(1, color: Colors.Black),
                new BarCodeStripe(1, color: Colors.White),
                new BarCodeStripe(1, color: Colors.Black),
            };
            return new BarCodeModule(stripes);
        }

        public static BarCodeModule GetMiddleSeparator()
        {
            var stripes = new List<BarCodeStripe>()
            {
                new BarCodeStripe(1, color: Colors.White),
                new BarCodeStripe(1, color: Colors.Black),
                new BarCodeStripe(1, color: Colors.White),
                new BarCodeStripe(1, color: Colors.Black),
                new BarCodeStripe(1, color: Colors.White),
            };
            return new BarCodeModule(stripes);
        }

        public static BarCodeModule GetEmptyZone()
        {
            var stripes = new List<BarCodeStripe>()
            {
                new BarCodeStripe(4, color: Colors.White)
            };
            return new BarCodeModule(stripes);
        }
    }
}