using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using TradeApp.View;

namespace TradeApp.ViewModel
{
    public class GoodsWindowViewModel : BaseViewModel
    {
        private ObservableCollection<Goods> _goods;
        private Goods _selectedGood;
        System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
        private void Timer()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (Goods.Count > 0)
            {
                Goods.Clear();
            }
            var result = DbSingletone.DbSingletone.Db.Goods.ToList();
            result.ForEach(elem => Goods?.Add(elem));
        }


        public Goods SelectedGood
        {
            get => _selectedGood;
            set
            {
                _selectedGood = value;
                OnPropertyChanged(nameof(SelectedGood));
            }
        }

        public ObservableCollection<Goods> Goods
        {
            get => _goods;
            set
            {
                _goods = value;
                OnPropertyChanged(nameof(Goods));
            }
        }

        public GoodsWindowViewModel()
        {
            Timer();
            Goods = new ObservableCollection<Goods>();
            var result = DbSingletone.DbSingletone.Db.Goods.ToList();
            result.ForEach(elem => Goods?.Add(elem));
        }

        public void Add_Click()
        {
            var addWind = new AddGoodWindow(_selectedGood);
            addWind.Show();
        }

        public void DeleteItem(object sender, EventArgs e)
        {

            if (!(SelectedGood is null))
            {
                using (var db = new TradeEntities())
                        {

                    var result = MessageBox.Show("Вы уверены, что хотите удалить данный элемент?" +
                        "Это действие невозможно отменить.", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        try
                        {
                            var entityForDelete = db.Goods.Where(elem => elem.Id == SelectedGood.Id).FirstOrDefault();

                            db.Goods.Remove(entityForDelete);

                            db.SaveChanges();

                            var result1 = DbSingletone.DbSingletone.Db.Goods.ToList();
                            result1.ForEach(elem => Goods?.Add(elem));

                            MessageBox.Show("Данные успешно удалены", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Информация", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }


        }
    }
}
