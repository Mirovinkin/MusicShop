using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicShop.Contexts;
using MusicShop.Entities;
using MusicShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicShop
{
    /// <summary>
    /// Логика взаимодействия для Logged_in.xaml
    /// </summary>
    public partial class Logged_in : Window, INotifyPropertyChanged
    {
        public Logged_in()
        {
            InitializeComponent();
            DataContext = this;
            IConfiguration configuration = BuildConfiguration();
            LoadData(configuration);
        }

        private List<PlatesOnSale> _dataLoad;
        public List<PlatesOnSale> DataLoad
        {
            get { return _dataLoad; }
            set
            {
                if (_dataLoad != value)
                {
                    _dataLoad = value;
                    OnPropertyChanged(nameof(DataLoad));
                }
            }
        }

        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        private void LoadData(IConfiguration configuration)
        {
            var context = new MusicShopContext(configuration);
            var platesSales = new List<PlatesOnSale>();
            foreach (var item in context.Plates.Include(b => b.Sales)) 
            {
                platesSales.Add(new PlatesOnSale
                {
                    PlateName=item.PlateName,
                    Price=item.Price,
                    TrackNumber=item.TrackNumber,
                });
            }
            foreach (var item in context.Sales)
            {
                platesSales.Add(new PlatesOnSale
                {
                    SalesDate=item.SalesDate,
                });
            }

            DataLoad = platesSales;

        }
        private void Edit_Data_Button(object sender, RoutedEventArgs e)
        {
            var editDataWindow = new Edit_data();
            editDataWindow.Show();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
