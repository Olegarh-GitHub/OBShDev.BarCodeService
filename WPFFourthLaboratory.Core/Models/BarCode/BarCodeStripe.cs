using System.Windows.Controls;
using System.Windows.Media;

namespace WPFFourthLaboratory.DAL.Models.BarCode
{
    public class BarCodeStripe : TextBlock
    {
        public BarCodeStripe(int width, int height = 75, Color color = default)
        {
            Width = width * 10;
            Height = height * 10;
            Background = new SolidColorBrush(color);
        }
    }
}