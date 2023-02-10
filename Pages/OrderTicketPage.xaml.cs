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
    /// Логика взаимодействия для OrderTicketPage.xaml
    /// </summary>
    public partial class OrderTicketPage : Page
    {
        List<Uslugi> uslugiList1 = new List<Uslugi>();

        public OrderTicketPage(Zakaz newZakaz, List<Uslugi> uslugiList)
        {
            InitializeComponent();
            uslugiList1 = uslugiList;
            DataContext = newZakaz;

            var result = "";
            foreach (var pl in uslugiList1)
            {
                result += (result == "" ? "" : ", ") + pl.usluga.ToString();
                txtProductList.Text = result.ToString();

                var total = uslugiList1.Sum(p => Convert.ToDouble(p.stoimost_uslugi));
                txtCost.Text = total.ToString() + "рублей";

            }
        }

        private void btnSaveDocument_Click(object sender, RoutedEventArgs e)
        {

            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = flowDoc;
                pd.PrintDocument(idp.DocumentPaginator, Title);
            }

        }
    }
}
