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
    public partial class PageTask3 : Page
    {
        private Random _rnd = new Random();

        public PageTask3()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int n = _rnd.Next(6, 12);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = _rnd.Next(-30, 31);
            }
            tbArrayInput.Text = string.Join(" ", arr);
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] nums = tbArrayInput.Text.Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                if (nums.Length < 3)
                {
                    MessageBox.Show("Массив должен содержать не менее 3 чисел.", "Ошибка",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Array.Sort(nums);
                int n = nums.Length;

                // Вариант 1: три наибольших числа
                long prod1 = (long)nums[n - 1] * nums[n - 2] * nums[n - 3];
                // Вариант 2: два наименьших (отрицательных) и одно наибольшее
                long prod2 = (long)nums[0] * nums[1] * nums[n - 1];

                if (prod1 >= prod2)
                {
                    tbResult.Text = $"Числа: {nums[n - 1]}, {nums[n - 2]}, {nums[n - 3]}\nМаксимальное произведение: {prod1}";
                }
                else
                {
                    tbResult.Text = $"Числа: {nums[0]}, {nums[1]}, {nums[n - 1]}\nМаксимальное произведение: {prod2}";
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные целые числа через пробел.", "Ошибка ввода",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
