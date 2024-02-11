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
using System.Windows.Shapes;

namespace MusicShop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        private IConfiguration _configuration;
        public Registration()
        {
            InitializeComponent();
            DataContext = this;
            _configuration= BuildConfiguration();
        }
        private IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private void Register(object sender, RoutedEventArgs e)
        {

            var newUser = new RegistereduserEntity
            {
                Name = login.Text,
                Password = pass.Text,
            };

            using var context = new MusicShopContext(_configuration);
            context.AddUser(newUser);

            MessageBox.Show("Вы зарегистрированы");
            this.Close();
        }
    }
}
