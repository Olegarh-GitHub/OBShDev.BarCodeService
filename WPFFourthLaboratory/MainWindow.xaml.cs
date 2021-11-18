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
            var service = new BarCodeService();
            var mapper = new BarCodeStripeWidthMapper();
            var barCode = service.GenerateBarCode("978020137962");
            MessageBox.Show(service.CheckBarCode(barCode).ToString());
            MessageBox.Show(barCode.Blocks[0] + " " + barCode.Blocks[1] + " " + barCode.Blocks[2]);
            MessageBox.Show(barCode.ToString());
            var d = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                
            };

            var firstDigit = barCode.Blocks[0];
            var firstBlock = barCode.Blocks[1];
            var secondBlock = barCode.Blocks[2];
            var blocks = mapper.GetBlock(int.Parse(firstDigit));
            
            // left empty zone
            var emptyZone = GetStripe(4, Colors.White);

            d.Children.Add(emptyZone);

            foreach (var stripe in GetGenericSeparator())
                d.Children.Add(stripe);

            
            // first block
            for (var i = 0; i < blocks.Length; i++)
            {
                var digit = int.Parse(firstBlock[i].ToString());
                var block = blocks[i];
                var stripeWidths = mapper.GetWidths(block, digit);
                for (var j = 0; j < stripeWidths.Length; j++)
                {
                    var stripeWidth = stripeWidths[j];
                    var color = j % 2 == 0 ? Colors.White : Colors.Black;
                    var stripe = GetStripe(stripeWidth, color);
                    d.Children.Add(stripe);
                }
            }
            
            foreach (var stripe in GetMiddleSeparator())
                d.Children.Add(stripe);
            
            // second block

            for (var i = 0; i < secondBlock.Length; i++)
            {
                var digit = int.Parse(secondBlock[i].ToString());
                var stripeWidths = mapper.GetWidths(3, digit);
                for (var j = 0; j < stripeWidths.Length; j++)
                {
                    var stripeWidth = stripeWidths[j];
                    var color = j % 2 == 0? Colors.Black : Colors.White;
                    var stripe = GetStripe(stripeWidth, color);
                    d.Children.Add(stripe);
                }
            }
            
            foreach (var stripe in GetGenericSeparator())
                d.Children.Add(stripe);
            
            // right empty zone
            var rightEmptyZone = GetStripe(4, Colors.White);

            d.Children.Add(rightEmptyZone);

            Grid.Children.Add(d);
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