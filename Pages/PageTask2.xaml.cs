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
    public partial class PageTask2 : Page
    {
        public PageTask2()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string input_string = tbStringInput.Text;
            if (string.IsNullOrEmpty(input_string))
            {
                MessageBox.Show("Строка не должна быть пустой.", "Ошибка!",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int balance = 0;
            int errorPos = 0;

            for (int i = 0; i < input_string.Length; i++)
            {
                if (input_string[i] == '(')
                {
                    balance++;
                }
                else if (input_string[i] == ')')
                {
                    balance--;
                    if (balance < 0)
                    {
                        errorPos = i + 1; // номер позиции с единицы
                        break;
                    }
                }
            }

            if (errorPos != 0)
            {
                tbResult.Text = $"{errorPos} (ошибочная закрывающая скобка на позиции {errorPos})";
            }
            else if (balance > 0)
            {
                tbResult.Text = "-1 (не хватает закрывающих скобок)";
            }
            else
            {
                tbResult.Text = "0 (скобки расставлены правильно)";
            }
        }
    }
}
