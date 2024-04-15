using OrderAcceptApp.Models;
using OrderAcceptApp.Util;
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

namespace OrderAcceptApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserCabPage.xaml
    /// </summary>
    public partial class UserCabPage : Page
    {
        public User authuser;
        public UserCabPage(User user)
        {
            InitializeComponent();
            string prevlog;
            string prevpass;
            authuser = user;   
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            login.Text = authuser.UserLogin;
            password.Password = authuser.UserPassword;
            mainlabel.Content = ($"{authuser.UserSurname} {authuser.UserName.Substring(0, 1).ToUpper()}. {authuser.UserPatronymic.Substring(0, 1).ToUpper()}."); 
            List<Request> result = new List<Request>();
            foreach (Request request in App.context.Requests.ToList());
            {
                result = App.context.Requests.ToList().Where(x => x.UserId == authuser.UserId).ToList();
            }
            OutPut.ItemsSource = result;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageManager.frame.Navigate(new AddOrderPage(authuser));
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            authuser.UserLogin = login.Text;
            authuser.UserPassword = password.Password.ToString();
            App.context.Update(authuser);
            App.context.SaveChanges();
            MessageBox.Show("Изменения сохранены");
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            login.Text = authuser.UserLogin;
            password.Password = authuser.UserPassword;
            MessageBox.Show("Изменения отменены");
        }
    }
}
