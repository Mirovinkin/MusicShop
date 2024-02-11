using Microsoft.Extensions.Configuration;
using MusicShop.Contexts;
using MusicShop.Entities;
using Npgsql;
using System;
using System.Collections.Generic;
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
using System.Configuration;

namespace MusicShop
{
    /// <summary>
    /// Логика взаимодействия для Edit_data.xaml
    /// </summary>
    public partial class Edit_data : Window
    {
        private IConfiguration _configuration;
        public Edit_data()
        {
            InitializeComponent();
            this.DataContext = this;
            _configuration = BuildConfiguration();
        }

        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            var plate = new PlateEntity
            {
                PlateName = tb1.Text,
                Price = Convert.ToDecimal(tb2.Text),
                TrackNumber = Convert.ToInt32(tb3.Text)
            };

            var context = new MusicShopContext(_configuration);
            context.AddPlate(plate);
            MessageBox.Show("Данные добавлены");

        }

        private void Delete(object sender, RoutedEventArgs e)
        {

            using var context = new MusicShopContext(_configuration);
            var plateTitle = tb1.Text;
            var plateDelete = context.Plates.SingleOrDefault(p => p.PlateName == plateTitle);
            if (plateDelete != null)
            {
                context.Plates.Remove(plateDelete);
                context.SaveChanges();
            }

            MessageBox.Show("Пластинка удалена");
        }

        private void Refresh(object sender, RoutedEventArgs e)
        {
           var refreshWindow= new RefreshWindow();
            refreshWindow.Show();
        }
    }
    


}
