using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFFourthLaboratory.DAL.Models.BarCode.Base
{
    public abstract class BarCode : StackPanel
    {
        protected BarCode()
        {
            Orientation = Orientation.Horizontal;
            HorizontalAlignment = HorizontalAlignment.Center;
        }

        protected string Code { get; set; }

        protected abstract List<BarCodeModule> GetModules();
        
        protected void Draw()
        {
            Children.Clear();
            
            var modules = GetModules();
            foreach (var module in modules)
            {
                Children.Add(module);
            }
        }
    }
}