using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFFourthLaboratory.DAL.Models.BarCode
{
    public class BarCodeModule : StackPanel
    {
        private readonly List<BarCodeStripe> _stripes;

        public BarCodeModule()
        {
            Orientation = Orientation.Horizontal;
            _stripes = new List<BarCodeStripe>();
        }

        public BarCodeModule(List<BarCodeStripe> stripes)
        {
            Orientation = Orientation.Horizontal;
            _stripes = stripes;
            
            Draw();
        }

        protected void AddStripe(BarCodeStripe stripe)
        {
            _stripes.Add(stripe);
        }

        protected void Draw()
        {
            Children.Clear();
            foreach (var stripe in _stripes)
            {
                Children.Add(stripe);
            }
        }
    }
}