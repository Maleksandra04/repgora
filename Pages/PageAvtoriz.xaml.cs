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
    /// Логика взаимодействия для PageAvtoriz.xaml
    /// </summary>
    public partial class PageAvtoriz : Page
    {
        private int countUnsuccessful = 0;
        public PageAvtoriz()
        {
            InitializeComponent();
            txtCaptcha.Visibility = Visibility.Hidden;
            textBlockCaptcha.Visibility = Visibility.Hidden;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            Sotrudniki sotrudniki = new Sotrudniki();

            sotrudniki = GoraEntities.GetContext().Sotrudniki.Where(p => p.login == login && p.password == password).FirstOrDefault();
            int userCount = GoraEntities.GetContext().Sotrudniki.Where(p => p.login == login && p.password == password).Count();

            if (countUnsuccessful < 1)
            {
                if (userCount > 0)
                {
                    MessageBox.Show("Вы вошли как  " + sotrudniki.Roli.role1.ToString() + " " + sotrudniki.FIO.ToString());
                    LoadForm(sotrudniki.Roli.role1.ToString(), sotrudniki);
                }
                else
                {
                    MessageBox.Show("Вы ввели неверно логин или пароль");
                    countUnsuccessful = countUnsuccessful + 1;
                    if (countUnsuccessful > 0)
                        GenerateCapcha();
                }
            }

            else
            {
                if (userCount > 0 && textBlockCaptcha.Text == txtCaptcha.Text)
                {
                    MessageBox.Show("Вы вошли как  " + sotrudniki.Roli.role1.ToString() + " " + sotrudniki.FIO.ToString());
                    LoadForm(sotrudniki.Roli.role1.ToString(), sotrudniki);
                }
                else
                {
                    MessageBox.Show("Введите данные заново!");
                }
            }
        }

        private void LoadForm(string _role, Sotrudniki sotrudnik)
        {
            switch (_role)
            {
                case "Продавец":
                    NavigationService.Navigate(new Page_Prodavec(sotrudnik));
                    break;
                case "Старший смены":
                    NavigationService.Navigate(new Page_Starchiy(sotrudnik));
                    break;
                case "Администратор":
                    NavigationService.Navigate(new Admin(sotrudnik));
                    break;
            }

        }

        private void GenerateCapcha()
        {
            txtCaptcha.Visibility = Visibility.Visible;
            textBlockCaptcha.Visibility = Visibility.Visible;

            Random random = new Random();
            int randmNum = random.Next(0, 3);

            switch(randmNum)
            {
                case 1:
                    textBlockCaptcha.Text = "j267a";
                    textBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    txtCaptcha.Visibility = Visibility.Visible;
                    textBlockCaptcha.Visibility = Visibility.Visible;
                    break;
                case 2:
                    textBlockCaptcha.Text = "6guDa";
                    textBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    txtCaptcha.Visibility = Visibility.Visible;
                    textBlockCaptcha.Visibility = Visibility.Visible;
                    break;
                case 3:
                    textBlockCaptcha.Text = "56fk7";
                    textBlockCaptcha.TextDecorations = TextDecorations.Strikethrough;
                    txtCaptcha.Visibility = Visibility.Visible;
                    textBlockCaptcha.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
