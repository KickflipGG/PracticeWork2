using PracticeWork2.Pages;
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

namespace PracticeWork2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    // Комментарий

    /// dfkkdfkdf


    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrmMain.Navigate(new PageMenu());
        }

        private void btnBack_click(object sender, RoutedEventArgs e)
        {
            if (FrmMain.CanGoBack) { FrmMain.GoBack(); }
        }

        private void FrmMain_ContentRendered(object sender, EventArgs e)
        {
            btnBack.Visibility = FrmMain.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

    }
}
