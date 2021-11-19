using System.Collections.Generic;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.Services;

namespace WPFFourthLaboratory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            // var service = new BarCodeService();
            var mapper = new BarCodeStripeWidthMapper();
            var barCode = new EAN13BarCode("9780201379624");
            Grid.Children.Add(barCode);
        }

        private TextBlock GetStripe(int width, Color color)
        {
            var stripe = new TextBlock()
            {
                Width = width*7,
                Height = 500,
                Background = new SolidColorBrush(color)
            };

            return stripe;
        }

        private List<TextBlock> GetGenericSeparator()
        {
            var result = new List<TextBlock>
            {
                GetStripe(1, Colors.Black), 
                GetStripe(1, Colors.White), 
                GetStripe(1, Colors.Black)
            };

            return result;
        }
        
        private List<TextBlock> GetMiddleSeparator()
        {
            var result = new List<TextBlock>
            {
                GetStripe(1, Colors.White),
                GetStripe(1, Colors.Black),
                GetStripe(1, Colors.White),
                GetStripe(1, Colors.Black),
                GetStripe(1, Colors.White)
            };

            return result;
        }
    }
}