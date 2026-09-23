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
    /// <summary>
    /// Логика взаимодействия для PageTask4.xaml
    /// </summary>
    public partial class PageTask4 : Page
    {
        private Random _rnd = new Random();

        public PageTask4()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            int n = _rnd.Next(8, 14);
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = _rnd.Next(1, 40);
            }
            tbArrayInput.Text = string.Join(" ", arr);
        }

        private struct Segment
        {
            public int Start;
            public int End;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int[] arr = tbArrayInput.Text.Split(new[] { ' ', ',', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(int.Parse)
                                            .ToArray();

                if (arr.Length < 2)
                {
                    MessageBox.Show("Массив должен содержать минимум 2 элемента.", "Ошибка!",
                                    MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                var segments = new List<Segment>();
                int i = 0;
                while (i < arr.Length - 1)
                {
                    if (arr[i + 1] > arr[i])
                    {
                        int start = i;
                        while (i < arr.Length - 1 && arr[i + 1] > arr[i]) i++;
                        segments.Add(new Segment { Start = start, End = i });
                    }
                    else if (arr[i + 1] < arr[i])
                    {
                        int start = i;
                        while (i < arr.Length - 1 && arr[i + 1] < arr[i]) i++;
                        segments.Add(new Segment { Start = start, End = i });
                    }
                    else
                    {
                        i++;
                    }
                }

                tbCount.Text = segments.Count.ToString();

                if (segments.Count == 0)
                {
                    tbResult.Text = "Промежутков монотонности не обнаружено (все элементы равны).";
                    return;
                }

                if (segments.Count == 1)
                {
                    tbResult.Text = $"{string.Join(" ", arr)} (всего один промежуток, менять не с чем)";
                    return;
                }

                // Перестановка первого и последнего сегментов
                Segment first = segments[0];
                Segment last = segments[segments.Count - 1];

                var resList = new List<int>();

                // Добавляем последний участок вместо первого
                for (int idx = last.Start; idx <= last.End; idx++) resList.Add(arr[idx]);

                // Элементы между ними
                for (int idx = first.End + 1; idx < last.Start; idx++) resList.Add(arr[idx]);

                // Добавляем первый участок вместо последнего
                for (int idx = first.Start; idx <= first.End; idx++) resList.Add(arr[idx]);

                // Хвост массива, если остался
                for (int idx = last.End + 1; idx < arr.Length; idx++) resList.Add(arr[idx]);

                tbResult.Text = string.Join(" ", resList);
            }
            catch
            {
                MessageBox.Show("Введите корректный массив целых чисел.", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
