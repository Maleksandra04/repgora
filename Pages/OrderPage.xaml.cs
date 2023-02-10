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
using Elbrus_region.Entities;
using Elbrus_region.Pages;
using Elbrus_region.Windows;

namespace Elbrus_region.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        List<Uslugi> uslugiList = new List<Uslugi>();
        Sotrudniki sotrudniki2 = new Sotrudniki();

        public OrderPage(List<Uslugi> orderUsluga, Sotrudniki sotrudniki1)
        {
            InitializeComponent();
            DataContext = this;
            uslugiList = orderUsluga;
            LViewOrder.ItemsSource = uslugiList;



            sotrudniki2 = sotrudniki1;
            txtOformil.Text = sotrudniki2.FIO.ToString();

            cmbClient.ItemsSource = GoraEntities.GetContext().Client.ToList();
        }

        public string Total
        {
            get
            {
                var total = uslugiList.Sum(p => Convert.ToDouble(p.stoimost_uslugi));
                return total.ToString();
            }
        }

        private void btnOrderSave_Click(object sender, RoutedEventArgs e)
        {
            var uslugaID = uslugiList.Select(p => p.ID_uslugi).ToArray();
            Random rand = new Random();
            var date = DateTime.Now;

            if(cmbClient.SelectedItem == null)
            {
                MessageBox.Show("Выберите клиента!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            try
            {
                Zakaz newZakaz = new Zakaz()
                {
                    status_zakaza = 1,
                    data_zakaza = DateTime.Now,
                    time_zakaza = TimeSpan.Zero,
                    code_zakaz = rand.Next(450000, 500000),
                    code_client = cmbClient.SelectedValue.GetHashCode(),
                    time = rand.Next(30,300)
                };

                GoraEntities.GetContext().Zakaz.Add(newZakaz);
                
                for (int i = 0; i < uslugaID.Count(); i++)
                {
                    Sostav_uslugi newSostav_Uslugi = new Sostav_uslugi()
                    {
                        ID_zakaza = newZakaz.ID_zakaz,
                        ID_usluga = uslugaID[i]
                    };

                    GoraEntities.GetContext().Sostav_uslugi.Add(newSostav_Uslugi);

                }

                GoraEntities.GetContext().SaveChanges();
                MessageBox.Show("Заказ оформлен", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new OrderTicketPage(newZakaz, uslugiList));

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить этот элемент?", "Предупреждение", 
                MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                uslugiList.Remove(LViewOrder.SelectedItem as Uslugi);
            LViewOrder.ItemsSource = null;
            LViewOrder.ItemsSource = uslugiList;

        }
    }
}
