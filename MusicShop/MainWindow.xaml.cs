using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using MusicShop.Contexts;
using MusicShop.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicShop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IConfiguration _configuration;
        public MainWindow()
        {
            InitializeComponent();
            _configuration = BuildConfiguration();
        }

        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void Log_In(object sender, RoutedEventArgs e)
        {

            using var context = new MusicShopContext(_configuration);
            var user = context.Registeredusers.FirstOrDefault();
            Logged_in logged_In = new Logged_in();
            logged_In.Show();
        }

        private void Register(object sender, RoutedEventArgs e)
        {
            var reg = new Registration();
            reg.Show();
        }
    }
}
