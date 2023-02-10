using Elbrus_region.Entities;
using Elbrus_region.Windows;
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
    /// Логика взаимодействия для Uslugi.xaml
    /// </summary>
    public partial class PageUslugi : Page
    {
        Sotrudniki sotrudniki1 = new Sotrudniki();
        public PageUslugi(Sotrudniki sotrudniki)
        {
            InitializeComponent();
            var uslugi = GoraEntities.GetContext().Uslugi.ToList();
            LViewUslugi.ItemsSource = uslugi;
            DataContext = this;

            txtAllAmount.Text = uslugi.Count().ToString();

            sotrudniki1 = sotrudniki;

            UpdateData();

            User();
        }

        private void User()
        {
            if (sotrudniki1 != null)
                txtFullname.Text = sotrudniki1.FIO.ToString();
            else txtFullname.Text = "Гость";
        }

        public string[] SortingList { get; set; } =
        {
            "Без сортировки",
                "Стоимость по возрастанию",
                "Стоимость по убыванию"
        };

        public string[] FilterList { get; set; } =
        {
            "Все диапазоны",
                "100 - 550 рублей",
                "560 - 1100 рублей",
                "1200 и более рублей"
        };

        private void UpdateData()
        {
            var result = GoraEntities.GetContext().Uslugi.ToList();

            if (cmbSorting.SelectedIndex == 1)
                result = result.OrderBy(p => p.stoimost_uslugi).ToList();
            if (cmbSorting.SelectedIndex == 2)
                result = result.OrderByDescending(p => p.stoimost_uslugi).ToList();

            if (cmbFilter.SelectedIndex == 1)
                result = result.Where(p => p.stoimost_uslugi >= 100 && p.stoimost_uslugi <= 550).ToList();
            if (cmbFilter.SelectedIndex == 2)
                result = result.Where(p => p.stoimost_uslugi >= 560 && p.stoimost_uslugi <= 1100).ToList();
            if (cmbFilter.SelectedIndex == 3)
                result = result.Where(p => p.stoimost_uslugi >= 1200).ToList();

            result = result.Where(p => p.usluga.ToLower().Contains(txtSearch.Text.ToLower())).ToList();

            LViewUslugi.ItemsSource = result;

            txtResultAmount.Text = result.Count().ToString();
        }

        private void txtSearch_SelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateData();
        }

        private void cmbSorting_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        List<Uslugi> orderUsluga = new List<Uslugi>();

        private void btnAddUsluga_Click(object sender, RoutedEventArgs e)
        {
            orderUsluga.Add(LViewUslugi.SelectedItem as Uslugi);

            if(orderUsluga.Count > 0)
            {
                btnOrder.Visibility = Visibility.Visible;
            }
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow order = new OrderWindow(orderUsluga, sotrudniki1);
            order.ShowDialog();
        }

        

    }
}
