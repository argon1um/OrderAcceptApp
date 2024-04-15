using OrderAcceptApp.Models;
using OrderAcceptApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace OrderAcceptApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddOrderPage.xaml
    /// </summary>
    public partial class AddOrderPage : Page
    {
        public User authuser;
        public AddOrderPage(User user)
        {
            InitializeComponent();
            foreach(Service serv in App.context.Services.ToList())
            {
                service.Items.Add(serv.ServiceName);
            }
            authuser = user;
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            theme.Clear();
            descr.Clear();
            PageManager.frame.Navigate(new UserCabPage(authuser));
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var client = new HttpClient())
            { 
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8081/predict");
                request.Content = new StringContent($"{authuser.UserSurname}{service.SelectedItem.ToString()}{theme.Text}{descr.Text}", Encoding.UTF8);
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Запрос отправлен в(о) {content} отдел", "Уведомление");

                }
            }
            PageManager.frame.Navigate(new UserCabPage(authuser));
        }
    }
}
