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
using PracticeWork2.Pages;

namespace PracticeWork2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageMenu.xaml
    /// </summary>
    public partial class PageMenu : Page
    {
        public PageMenu()
        {
            InitializeComponent();
        }
        private void btnTask1_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new PageTask1());
        private void btnTask2_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new PageTask2());
        private void btnTask3_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new PageTask3());
        private void btnTask4_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new PageTask4());
        private void btnTask5_Click(object sender, RoutedEventArgs e) => NavigationService?.Navigate(new PageTask5());
    }
}

