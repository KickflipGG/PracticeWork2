using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для PageTask5.xaml
    /// </summary>
    public partial class PageTask5 : Page
    {
        private Random _rnd = new Random();

        public PageTask5()
        {
            InitializeComponent();
        }

        private void btnGenerateAndSort_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(tbRows.Text.Trim(), out int n) || n <= 0 ||
                !int.TryParse(tbCols.Text.Trim(), out int m) || m <= 0)
            {
                MessageBox.Show("Введите корректные положительные размеры матрицы N и M.",
                                "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int[,] matrix = new int[n, m];
            int[] linear = new int[n * m];
            int idx = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int val = _rnd.Next(-10, 11);
                    matrix[i, j] = val;
                    linear[idx++] = val;
                }
            }

            // Вывод исходной матрицы
            dgInitial.ItemsSource = ConvertToDataTable(matrix, n, m).DefaultView;

            // Минимум и максимум
            tbMin.Text = linear.Min().ToString();
            tbMax.Text = linear.Max().ToString();

            // Сортировка по возрастанию
            int[] asc = linear.OrderBy(x => x).ToArray();
            int[,] ascMatrix = ReconstructMatrix(asc, n, m);
            dgAscending.ItemsSource = ConvertToDataTable(ascMatrix, n, m).DefaultView;

            // Сортировка по убыванию
            int[] desc = linear.OrderByDescending(x => x).ToArray();
            int[,] descMatrix = ReconstructMatrix(desc, n, m);
            dgDescending.ItemsSource = ConvertToDataTable(descMatrix, n, m).DefaultView;
        }

        private int[,] ReconstructMatrix(int[] flat, int n, int m)
        {
            int[,] result = new int[n, m];
            int k = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    result[i, j] = flat[k++];
                }
            }
            return result;
        }

        private DataTable ConvertToDataTable(int[,] matrix, int n, int m)
        {
            DataTable dt = new DataTable();
            for (int j = 0; j < m; j++)
            {
                dt.Columns.Add($"Col{j}", typeof(int));
            }

            for (int i = 0; i < n; i++)
            {
                DataRow row = dt.NewRow();
                for (int j = 0; j < m; j++)
                {
                    row[j] = matrix[i, j];
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}

