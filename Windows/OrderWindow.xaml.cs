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
using Elbrus_region.Entities;
using Elbrus_region.Pages;



namespace Elbrus_region.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow(List<Uslugi> uslugi1, Sotrudniki sotrudniki1)
        {
            InitializeComponent();
            frmOrder.Navigate(new OrderPage(uslugi1, sotrudniki1));
        }
    }
}
