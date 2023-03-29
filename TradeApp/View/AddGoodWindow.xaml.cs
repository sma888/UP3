using System.Windows;
using TradeApp.ViewModel;

namespace TradeApp.View
{
    /// <summary>
    /// Логика взаимодействия для AddGoodWindow.xaml
    /// </summary>
    public partial class AddGoodWindow : Window
    {
        public AddGoodWindow(Goods SelectGood)
        {
            InitializeComponent();
            this.DataContext = new AddGoodWindowViewModel(SelectGood);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as AddGoodWindowViewModel).AddItem();
        }
    }
}
