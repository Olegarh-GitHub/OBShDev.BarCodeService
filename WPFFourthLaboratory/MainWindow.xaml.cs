using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFFourthLaboratory.DAL.DAL;
using WPFFourthLaboratory.DAL.Helpers;
using WPFFourthLaboratory.DAL.Interfaces;
using WPFFourthLaboratory.DAL.Models;
using WPFFourthLaboratory.DAL.Models.BarCode;
using WPFFourthLaboratory.DAL.Models.Entities;
using WPFFourthLaboratory.DAL.Services;

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
            Test();
            var goods = GetGood(2);

            var code = new EAN13BarCodeService().GenerateBarCode(goods); //"978020137962"
            
            var barCode = new EAN13BarCode(code);
            Grid.Children.Add(barCode);
        }

        private void Test()
        {
            var goods = new Goods()
            {
                Description = "Тестовый",
                Name = "Тест"
            };

            var producer = new Producer() {Code = 223432, Name = "ПАО \"Оргсинтез\""};
            var country = new Country() {Name = "Российская Федерация", Code = 469};

            goods.Producer = producer;
            goods.Country = country;



            using (var context = new ApplicationContext())
            {
                context.Countries.Add(country);
                context.Producers.Add(producer);
                context.Goods.Add(goods);

                context.SaveChanges();

                goods.SetCode();
                context.Entry(goods).State = EntityState.Modified;
                
                context.Goods.AddOrUpdate(goods);
                context.SaveChanges();
            }
        }

        private Goods GetGood(int id)
        {
            Goods goods;
            
            using (var context = new ApplicationContext())
            {
                goods = context.Goods.Include("Country").Include("Producer").FirstOrDefault(x => x.Id == id);
            }

            return goods;
        }
    }
}