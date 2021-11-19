using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using WPFFourthLaboratory.DAL.Helpers;

namespace WPFFourthLaboratory.DAL.Models.Base
{
    public abstract class BarCode : StackPanel
    {
        public BarCode()
        {
            Orientation = Orientation.Horizontal;
        }
        
        public string Code { get; set; }
        public List<int[]> Blocks { get; set; }
        protected readonly BarCodeStripeWidthMapper Mapper = new BarCodeStripeWidthMapper();
        public abstract List<BarCodeModule> GetModules();
        
        protected void Draw()
        {
            var modules = GetModules();
            foreach (var module in modules)
            {
                Children.Add(module);
            }
        }
    }
}