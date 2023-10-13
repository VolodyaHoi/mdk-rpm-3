using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib_9
{
    public class lib9
    {
        /// <summary>
        /// Нахождение номера строки с наимбольшей суммой
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="sum"></param>
        /// <param name="num"></param>
        public static void production(int[,] matrix, out int sum, out int num)
        {
            
            int sum_row = 0;
            int max_num = 1;
            int row_id = 0;
            int[] array = new int[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++) // строка
            {
                for (int j = 0; j < matrix.GetLength(1); j++) // столбец
                {
                    sum_row = sum_row + matrix[i, j];
                }
                array[i] = sum_row;
                sum_row = 0;
            }

            for (int i = 0;i < array.Length - 1; i++)
            {
                if (array[i] < array[i + 1])
                {
                    max_num = array[i + 1];
                    row_id = i + 2;
                } 
                else 
                { 
                    max_num = array[i];
                    row_id = i + 1;
                }
            }
            sum = max_num;
            num = row_id;
                
        }
    }
}
