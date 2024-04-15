using OrderAcceptApp.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace OrderAcceptApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static OrderacceptdatabaseContext context { get; set; } = new OrderacceptdatabaseContext();
    }

}
