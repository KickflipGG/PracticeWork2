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

namespace PracticeWork2.Pages
{
    public partial class PageTask1 : Page
    {
        public PageTask1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbYearInput.Text.Trim(), out int year) && year > 0)
            {
                int century = (year - 1) / 100 + 1;
                tbResult.Text = $"{century} столетие";
            }
            else
            {
                MessageBox.Show("Введите корректное натуральное число больше 0.",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                tbResult.Text = string.Empty;
            }
        }
    }
}
