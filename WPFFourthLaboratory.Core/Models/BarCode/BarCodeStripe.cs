using System.Windows.Controls;
using System.Windows.Media;

namespace WPFFourthLaboratory.DAL.Models.BarCode
{
    public class BarCodeStripe : TextBlock
    {
        public static int StripeWidth = 1;
        
        public BarCodeStripe(int width, int height = 75, Color color = default)
        {
            Width = width * StripeWidth;
            Height = height * StripeWidth;
            Background = new SolidColorBrush(color);
        }
    }
}