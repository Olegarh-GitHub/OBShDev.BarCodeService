using System.Windows.Media;
using WPFFourthLaboratory.DAL.Helpers;

namespace WPFFourthLaboratory.DAL.Models.BarCode
{
    public class BarCodeDigit : BarCodeModule
    {
        private readonly int _blockNumber;
        
        public BarCodeDigit(int digit, int blockNumber)
        {
            _blockNumber = blockNumber;
            var widths = BarCodeStripeWidthMapper.GetWidths(blockNumber, digit);
            for (var i = 0; i < widths.Length; i++)
            {
                var color = GetColor(i);
                var width = widths[i];
                var stripe = new BarCodeStripe(width, color: color);
                AddStripe(stripe);
            }

            Draw();
        }


        private Color GetColor(int position)
        {
            if (_blockNumber == 3)
            {
                return position % 2 == 0 ? Colors.Black : Colors.White;
            }

            return position % 2 == 0 ? Colors.White : Colors.Black;
        }
    }
}