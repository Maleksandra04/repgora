using Elbrus_region.Entities;
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

namespace Elbrus_region.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page_Starchiy.xaml
    /// </summary>
    public partial class Page_Starchiy : Page
    {
        Sotrudniki sotrudniki = new Sotrudniki();
        public Page_Starchiy(Sotrudniki sotrudnik)
        {
            InitializeComponent();
            vchodTx.Text = sotrudnik.FIO.ToString();
            Img.DataContext = "pack://application:,,,/Resources/" + sotrudnik.Image1;
            Img1.Text = (string)Img.DataContext;
            sotrudniki = sotrudnik;
        }

        private void UslugiBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageUslugi(sotrudniki));
        }
    }
}
