using System.Collections.Generic;
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
            MessageBox.Show(barCode.ToString());
            var d = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                Height = 200,
            };
            
            foreach (var widths in service.GetWidths(barCode))
            {
                for (var i = 0; i < widths.Length; i++)
                {
                    var color = i % 2 == 0 ? Colors.White : Colors.Black;
                    var stripe = GetStripe(widths[i], color);

                    d.Children.Add(stripe);
                }
            }

            Grid.Children.Add(d);
        }

        private TextBlock GetStripe(int width, Color color)
        {
            var stripe = new TextBlock()
            {
                Width = width,
                Height = 75,
                Background = new SolidColorBrush(color)
            };

            return stripe;
        }
    }
}