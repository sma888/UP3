using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TradeApp.View;

namespace TradeApp.ViewModel
{
    public class AddGoodWindowViewModel : BaseViewModel
    {
        private string _articul;
        private string _productName;
        private int _unitId;
        private decimal _price;
        private int _maxDiscount;
        private int _manufacturer_id;
        private int _supplier_id;
        private int _category_id;
        private int _currentDiscount;
        private int _storageAmount;
        private string _description;
        private Goods _selectedGood;
        private Goods _goods;


        public Goods SelectedGood
        {
            get => _selectedGood;
            set
            {
                _selectedGood = value;
                OnPropertyChanged(nameof(SelectedGood));
            }
        }
        public Goods Goods
        {
            get => _goods;
            set
            {
                _goods = value;
                OnPropertyChanged(nameof(Goods));
            }
        }


        public string Articul
        {
            get => _articul;
            set
            {
                _articul = value;
                OnPropertyChanged(nameof(Articul));
            }
        }

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        public int Unit_id
        {
            get => _unitId;
            set
            {
                _unitId = value;
                OnPropertyChanged(nameof(Unit_id));
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public int MaxDiscount
        {
            get => _maxDiscount;
            set
            {
                _maxDiscount = value;
                OnPropertyChanged(nameof(MaxDiscount));
            }
        }

        public int Manufacturer_id
        {
            get => _manufacturer_id;
            set
            {
                _manufacturer_id = value;
                OnPropertyChanged(nameof(Manufacturer_id));
            }
        }

        public int Supplier_id
        {
            get => _supplier_id;
            set
            {
                _supplier_id = value;
                OnPropertyChanged(nameof(Supplier_id));
            }
        }
        public int Category_id
        {
            get => _category_id;
            set
            {
                _category_id = value;
                OnPropertyChanged(nameof(Category_id));
            }
        }

        public int CurrentDiscount
        {
            get => _currentDiscount;
            set
            {
                _currentDiscount = value;
                OnPropertyChanged(nameof(CurrentDiscount));
            }
        }

        public int StorageAmount
        {
            get => _storageAmount;
            set
            {
                _storageAmount = value;
                OnPropertyChanged(nameof(StorageAmount));
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }


        public void AddItem()
        {

            try
            {
                if (_selectedGood == null)
                {
                    _goods = new Goods();
                    _goods.Articul = _articul;
                    _goods.ProductName = _productName;
                    _goods.Manufacturer_id = _manufacturer_id;
                    _goods.Price = _price;
                    _goods.Supplier_id = _supplier_id;
                    _goods.Category_id = _category_id;
                    _goods.CurrentDiscount = _currentDiscount;
                    _goods.StorageAmount = _storageAmount;
                    _goods.Description = _description;
                    _goods.MaxDiscount = _maxDiscount;
                    _goods.Unit_id = _unitId;
                }
                else
                {
                    _goods = _selectedGood;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            try
            {

                DbSingletone.DbSingletone.Db.Goods.AddOrUpdate(_goods);
                DbSingletone.DbSingletone.Db.SaveChanges();
                MessageBox.Show("Данные сохранены!", "Сообщение");
            }
            catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        MessageBox.Show(err.ErrorMessage + "");
                    }
                }
            }

            foreach (Window wind in Application.Current.Windows)
            {
                if (wind is AddGoodWindow)
                {
                    wind.Close();
                }
            }

        }
    }
}
