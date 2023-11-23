namespace Test_Task.Tasks
{
    #region Task description
    /// <summary>
    /// Задача №2:
    /// Дана матрица целых чисел int[,] matrix размером MxN.Вернуть все её элементы развёрнутые в массив в спиральном порядке против часовой стрелки.
    /// 
    /// Пример №1:
    /// Входной параметр: int[,] matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
    /// Результирующий массив: [1, 4, 7, 8, 9, 6, 3, 2, 5]
    /// 
    /// Пример №2:
    /// Входной параметр: int[,] matrix = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
    /// Результирующий массив: [1, 5, 9, 10, 11, 12, 8, 4, 3, 2, 6, 7]
    /// </summary>
    #endregion

    public class Task2
    {
        public int[] SpiralOrder(int[,] matrix)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int[] result = new int[m * n];

            int top = 0, bottom = m - 1, left = 0, right = n - 1;
            int index = 0;

            while (top <= bottom && left <= right)
            {
                // Идем сверху вниз:
                for (int i = top; i <= bottom; i++)
                {
                    result[index++] = matrix[i, left];
                }
                left++;

                // Идем слева направо:
                for (int i = left; i <= right; i++)
                {
                    result[index++] = matrix[bottom, i];
                }
                bottom--;

                // Идем снизу вверх:
                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result[index++] = matrix[i, right];
                    }
                    right--;
                }

                // Идем справа налево:
                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        result[index++] = matrix[top, i];
                    }
                    top++;
                }
            }

            return result;
        }
    }
}

