using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Windows;

namespace LibMas
{
    public class libmas
    {
        /// <summary>
        /// Генерация массива
        /// </summary>
        /// <param name="size"></param>
        /// <param name="array2"></param>

        public static void masGenerate(int m, int n, out int[,] array2)
        {
            int[,] array = new int[m, n];
            Random rnd = new Random();

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rnd.Next(1, 20);
                }
            }
            array2 = array;
        }

        /// <summary>
        /// Открытие массива из текстового файла
        /// </summary>
        /// <param name="file"></param>
        /// <param name="array2"></param>
        public static void masOpen(String file, out int[,] array2)
        {
            StreamReader fileObj = new StreamReader(file);

            int len0 = Convert.ToInt32(fileObj.ReadLine());
            int len1 = Convert.ToInt32(fileObj.ReadLine());

            int[,] mas = new Int32[len0, len1];


            for (int i = 0; i < mas.GetLength(0); i++)
            {
                for (int j = 0; j < mas.GetLength(1); j++)
                {
                    mas[i, j] = Convert.ToInt32(fileObj.ReadLine());
                }
            }
            fileObj.Close();
            array2 = mas;


        }

        /// <summary>
        /// Сохранение массива в текстовый файл
        /// </summary>
        /// <param name="file"></param>
        /// <param name="array"></param>
        public static void masSave(String file, int[,] array)
        {
            StreamWriter fileObj = new StreamWriter(file);

            fileObj.WriteLine(array.GetLength(0));
            fileObj.WriteLine(array.GetLength(1));

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    fileObj.WriteLine(array[i, j]);

                }

                

            }
            fileObj.Close();
        }
    }
}
