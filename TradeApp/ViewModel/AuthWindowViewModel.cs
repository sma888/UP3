using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TradeApp.Core.Functions;
using System.Windows;
using TradeApp.View;

namespace TradeApp.ViewModel
{
    public class AuthWindowViewModel:BaseViewModel
    {
        private string _password;
        private string _login;

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public void Verif()
        {
            var verif = new Verificate();
            bool res = verif.Check(Login, Password);
            if (res)
            {
                MessageBox.Show("Авторизация прошла успешно", "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
                var goodsWindow = new GoodsWindow();
                goodsWindow.Show();
                foreach(Window window in Application.Current.Windows)
                {
                    if(window is AuthWindow)
                    {
                        window.Close();
                    }
                }
            }
            else MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Stop);
        }
    }
}
