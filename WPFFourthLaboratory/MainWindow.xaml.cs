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
        private readonly IBarCodeService _barCodeService;

        public MainWindow()
        {
            InitializeComponent();
            
            // var code = new EAN13BarCodeService().GenerateBarCode(); //"978020137962"
            //
            // var barCode = new EAN13BarCode(code);
            // Grid.Children.Add(barCode);
            FillProductList();
            _barCodeService = new EAN13BarCodeService();
        }

        private void FillProductList()
        {
            var products = _repositoryCreator.GoodsRepository.Read().ToList();
            ProductComboBox.ItemsSource = products;
        }

        private void ProductComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var product = (Product) ProductComboBox.SelectedItem;
            DrawBarCode(product);
        }

        private void DrawBarCode(Product product)
        {
            BarCodeStripe.StripeWidth = 3;
            var code = _barCodeService.GenerateBarCode(product);
            var barCode = new EAN13BarCode(code);
            BarCodePanel.Children.Clear();
            BarCodePanel.Children.Add(barCode);
            BarCodeTextBlock.Text = barCode.ToString();
        }
    }
}