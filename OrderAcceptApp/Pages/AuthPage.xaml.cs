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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            
            InitializeComponent();
        }

        private void signin_Click(object sender, RoutedEventArgs e)
        {
            User checkuser = null;
            string password = passwordpb.Password.ToString();
            string login = logintextbox.Text;
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля", "Ошибка");
            }
            else if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                foreach (User user in App.context.Users.ToList())
                {
                    checkuser = App.context.Users.ToList().FirstOrDefault(x => x.UserLogin == login && x.UserPassword == password);
                    
                }
                if (checkuser != null)
                {
                    MessageBox.Show($"Добро пожаловать, {checkuser.UserName} {checkuser.UserSurname} {checkuser.UserPatronymic}", "Уведомление");
                    App.Current.MainWindow.Title = ($"{checkuser.UserName} {checkuser.UserSurname} {checkuser.UserPatronymic}");
                    PageManager.frame.Navigate(new UserCabPage(checkuser));
                }

                if (checkuser == null)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка");
                }
            }
        }
    }
}

