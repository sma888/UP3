using System.Windows;
using TradeApp.ViewModel;

namespace TradeApp.View
{
    /// <summary>
    /// Логика взаимодействия для GoodsWindow.xaml
    /// </summary>
    public partial class GoodsWindow : Window
    {
        public GoodsWindow()
        {
            InitializeComponent();
            this.DataContext = new GoodsWindowViewModel();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as GoodsWindowViewModel).Add_Click();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as GoodsWindowViewModel).DeleteItem(sender, e);
        }
    }
}
