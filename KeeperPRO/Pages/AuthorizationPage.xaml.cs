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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        
        public AuthorizationPage()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Employee> employees =  App.db.Employee.ToList();
            NavigationService.Navigate(new Pages.ApplicationsPage());

            if (employees.Any(x => x.EmployeeCode == EmployeeIdTb.Text))
            {
                if(employees.Find(x => x.EmployeeCode == EmployeeIdTb.Text).EmployeePassword == EmployeePassPb.Password) 
                {
                    NavigationService.Navigate(new Pages.ApplicationsPage());
                }
                else
                {
                    MessageBox.Show("Не верный пароль");
                    NavigationService.Navigate(new Pages.ApplicationsPage());
                }
            }
        }
    }
}
