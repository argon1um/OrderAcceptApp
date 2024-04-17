using OrderAcceptApp.Models;
using OrderAcceptApp.Util;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

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
            string address = "http://localhost:58214";
            var txt = descr.Text;
            var response = new HttpClient().PostAsJsonAsync($"{address}/predict", txt).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                
                MessageBox.Show($"Запрос отправлен в {content} отдел", "Уведомление");

                App.context.Requests.Add(new Request{
                    RequsetId = App.context.Requests.Count()+1,
                    RequestDate = DateOnly.FromDateTime(DateTime.Now),
                    RequestTheme = theme.Text,
                    RequestDecsription = descr.Text,
                    UserId = authuser.UserId,
                    ServiceId = service.SelectedIndex,
                    Response = content
                });
                App.context.SaveChanges();

            }
            PageManager.frame.Navigate(new UserCabPage(authuser));
        }
    }
}
