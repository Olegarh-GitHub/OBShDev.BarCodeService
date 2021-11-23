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
        private readonly RepositoryCreator _repositoryCreator = new RepositoryCreator();

        public MainWindow()
        {
            InitializeComponent();

            var producer = new Producer(690641, "ПАО \"Нижнекамск-Нефтехим\"");

            producer = _repositoryCreator.ProducerRepository.Create(producer);
            var country = _repositoryCreator.CountryRepository.Read().FirstOrDefault();
            
            var goods = new Goods("Покрышки от КамАЗ-5320", "Покрышки резиновые КАМА от грузовика КамАЗ", country, producer);
            _repositoryCreator.GoodsRepository.Create(goods);

            var readedGoods = _repositoryCreator.GoodsRepository.Read().FirstOrDefault();
            
            var code = new EAN13BarCodeService().GenerateBarCode(readedGoods); //"978020137962"
            
            var barCode = new EAN13BarCode(code);
            Grid.Children.Add(barCode);
        }
    }
}