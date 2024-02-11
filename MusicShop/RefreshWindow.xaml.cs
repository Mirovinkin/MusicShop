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

namespace MusicShop
{
    /// <summary>
    /// Логика взаимодействия для RefreshWindow.xaml
    /// </summary>
    public partial class RefreshWindow : Window
    {
        private IConfiguration _configuration;
        public RefreshWindow()
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

        private async void Refresh(object sender, RoutedEventArgs e)
        {
            /*await Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    var query = $"UPDATE public.plates\r\n\tSET plate_name=@n1, " +
                                                    $"price=@n2, track_number=@n3\r\n\t" +
                                                    $"WHERE (plate_name LIKE '@n4' AND price=@n5 AND WHERE track_number=@n6)";
                    using var connection = new NpgsqlConnection(_connection);
                    connection.Open();
                    var command = new NpgsqlCommand(query, connection);
                    command.Parameters.AddWithValue("n1", tbr1.Text);
                    command.Parameters.AddWithValue("n2", Convert.ToInt32(tbr2.Text));
                    command.Parameters.AddWithValue("n3", Convert.ToInt32(tbr3.Text));
                    command.Parameters.AddWithValue("n4", Convert.ToInt32(tb1.Text));
                    command.Parameters.AddWithValue("n5", );
                    command.Parameters.AddWithValue("n6", Convert.ToInt32(tb3.Text));
                    command.ExecuteNonQuery();
                });
            });*/
            using var context = new MusicShopContext(_configuration);
            var plateTitle = tb1.Text;
            var plateDelete = context.Plates.SingleOrDefault(p => p.PlateName == plateTitle);
            if (plateDelete != null)
            {
                context.Plates.Remove(plateDelete);
                context.SaveChanges();
            }
            var refPlate = new PlateEntity
            {
                PlateName = tbr1.Text,
                Price = Convert.ToDecimal(tbr2.Text),
                TrackNumber = Convert.ToInt32(tbr3.Text)
            };
            context.AddPlate(refPlate);
            MessageBox.Show("Данные обновлены");
        }
    }
}
