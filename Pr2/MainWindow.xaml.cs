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
using LibMas;
using Lib_9;
using Microsoft.Win32;
using System.IO;

namespace Pr2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] mas;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Generate(object sender, RoutedEventArgs e)
        {
            int m, n;
            int[,] matrix;
            bool isNum = int.TryParse(tb_M.Text, out m);
            bool isNum2 = int.TryParse(tb_N.Text, out n);
            if (isNum && isNum2)
            {
                LibMas.libmas.masGenerate(m, n, out matrix);
                mas = matrix;
                dg_Matrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            } else { MessageBox.Show("Кол-во строк или столбцов не корректны!"); }

        }

        private void btn_Open(object sender, RoutedEventArgs e)
        {
            String filename = tb_Save.Text + ".txt";
            dg_Matrix.ItemsSource = null;
            mas = null;
            LibMas.libmas.masOpen(filename, out int[,] matrix);
            mas = matrix;
            dg_Matrix.ItemsSource = VisualArray.ToDataTable(matrix).DefaultView;
            
        }

        private void btn_Save(object sender, RoutedEventArgs e)
        {
            String filename = tb_Save.Text + ".txt";

            LibMas.libmas.masSave(filename, mas);

            
        }

        private void btn_Clear(object sender, RoutedEventArgs e)
        {
            dg_Matrix.ItemsSource = null;
            mas = null;
        }

        private void btn_Prod(object sender, RoutedEventArgs e)
        {

            Lib_9.lib9.production(mas, out int sum, out int row);


            MessageBox.Show($"Наибольшая сумма в строке {row}. Значение суммы: {sum}");

        }

        private void btn_AllClear(object sender, RoutedEventArgs e)
        {
            tb_M.Text = "";
            tb_N.Text = "";
            tb_Save.Text = "";
            dg_Matrix.ItemsSource = null;
            mas = null;
        }

        private void btn_Exit(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btn_Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №3. Мансуров В. ИСП-31. Вариант №9");
        }

        private void click_Clear(object sender, MouseButtonEventArgs e)
        {
            tb_M.Text = "";
        }

        private void click_Clear2(object sender, MouseButtonEventArgs e)
        {
            tb_N.Text = "";
        }

        private void click_Clear3(object sender, MouseButtonEventArgs e)
        {
            tb_Save.Text = "";
        }
    }

}
