using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFFourthLaboratory.DAL.Models.Base
{
    public class BarCodeModule : StackPanel
    {
        protected List<BarCodeStripe> Stripes;

        public BarCodeModule()
        {
            Orientation = Orientation.Horizontal;
            Stripes = new List<BarCodeStripe>();
        }

        public BarCodeModule(List<BarCodeStripe> stripes)
        {
            Orientation = Orientation.Horizontal;
            Stripes = stripes;
            Draw();
        }

        protected void AddStripe(BarCodeStripe stripe)
        {
            Stripes.Add(stripe);
        }

        protected void Draw()
        {
            Children.Clear();
            foreach (var stripe in Stripes)
            {
                Children.Add(stripe);
            }
        }

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