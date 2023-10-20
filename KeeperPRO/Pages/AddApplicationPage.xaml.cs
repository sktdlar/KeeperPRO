using KeeperPRO.Components;
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

namespace KeeperPRO.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddApplicationPage.xaml
    /// </summary>
    public partial class AddApplicationPage : Page
    {
        public AddApplicationPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (PassportNumTb.Text.Trim().Length == 10) { 
                AccessApplication application = new AccessApplication() 
                {
                    Fname = FnameTb.Text,
                    Lname = LnameTb.Text,
                    Patronymic = Patronymic.Text,
                    Type = TypeCb.SelectedIndex + 1,
                    Department = DepartmentCb.SelectedIndex + 1,
                    Passport = PassportNumTb.Text.Trim(),
                    Date = DateTime.Now,
                };
                    App.db.AccessApplication.Add(application);
                    App.db.SaveChanges();
                    NavigationService.GoBack();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
