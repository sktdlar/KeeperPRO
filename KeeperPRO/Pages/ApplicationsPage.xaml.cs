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
    /// Логика взаимодействия для ApplicationsPage.xaml
    /// </summary>
    public partial class ApplicationsPage : Page
    {
        public ApplicationsPage()
        {
            InitializeComponent();
            ApplicationsDG.ItemsSource = App.db.AccessApplication.ToList();

        }
        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            Refresh();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AccessApplication application = ApplicationsDG.SelectedItem as AccessApplication;
            if(application != null) {
            if (application.StartTime is null)
            {
                application.StartTime = DateTime.Now;
                App.db.SaveChanges();
                Refresh();
                System.Media.SystemSounds.Beep.Play();
            }
            else
            {
                MessageBox.Show("Данные уже записаны или введены некорректно");
            }
            }
        }
        private void Refresh()
        {
            IEnumerable<AccessApplication> accessApplications = App.db.AccessApplication.ToList();
            if (DateSortCb.SelectedIndex != 0)
            {


                if (DateSortCb.SelectedIndex == 1)
                {
                    accessApplications = accessApplications.Where(x => x.Date == null || DateTime.Today.Subtract((DateTime)x.Date).Days < 3);
                }
                else if (DateSortCb.SelectedIndex == 2)
                {
                    accessApplications = accessApplications.Where(x => DateTime.Today.Subtract((DateTime)x.Date).Days < 14);

                }
                else if (DateSortCb.SelectedIndex == 3)
                {
                    accessApplications = accessApplications.Where(x => DateTime.Today.Subtract((DateTime)x.Date).Days < 30);

                }
            }
                if (TypeSortCb.SelectedIndex != 0)
                {
                    if (TypeSortCb.SelectedIndex == 1)
                    {
                        accessApplications = accessApplications.Where(x => x.Type == 1);
                    }
                    else if (TypeSortCb.SelectedIndex == 2)
                    {
                        accessApplications = accessApplications.Where(x => x.Type == 2);
                    }
                }
                if (DepartmentSortCb.SelectedIndex != 0)
                {
                    if (DepartmentSortCb.SelectedIndex == 1)
                    {
                        accessApplications = accessApplications.Where(x => x.Department == 1);
                    }
                    else if (DepartmentSortCb.SelectedIndex == 2)
                    {
                        accessApplications = accessApplications.Where(x => x.Department == 2);
                    }
                }
                if (SearchTb.Text != "")
                          {
                            accessApplications = accessApplications.Where(x => x.Passport.Contains(SearchTb.Text));
                          }
                
                ApplicationsDG.ItemsSource = accessApplications;
            }
        

        private void DateSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void TypeSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DepartmentSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();

        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh();

        }

        private void OutBtn_Click(object sender, RoutedEventArgs e)
        {

            AccessApplication application = ApplicationsDG.SelectedItem as AccessApplication;
            if(application != null) { 
            if (application.StartTime is null)
            {
                MessageBox.Show("Чел еще не зашел ты че");
            }
            else 
            { 
                if (application.EndTime is null)
                {
                   application.EndTime = DateTime.Now;
                   App.db.SaveChanges();
                   Refresh();
                }
                else
                {
                    MessageBox.Show("Данные уже записаны или введены некорректно.");
                }
            }
            }
        }

        private void AddNewApp_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddApplicationPage());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if(ApplicationsDG.SelectedItem != null) { 
            App.db.AccessApplication.Remove((AccessApplication)ApplicationsDG.SelectedItem);
            App.db.SaveChanges();
            Refresh();
            }
            else
            {
                MessageBox.Show("Не выбрана запись.");
            }
        }
    }
}

                
