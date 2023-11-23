using Test_Task.Tasks;

namespace Test_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task_1
            var task1 = new Task1();
            string originalString = "aaabbcccdde";
            string compressedString = task1.CompressString(originalString);
            string decompressedString = task1.DecompressString(compressedString);

            Console.WriteLine("Исходная строка: " + originalString);
            Console.WriteLine("Сжатая строка: " + compressedString);
            Console.WriteLine("Декомпрессированная строка: " + decompressedString);
            #endregion


            #region Task_2
            var task2 = new Task2();
            int[,] matrix1 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] matrix2 = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };

            int[] result1 = task2.SpiralOrder(matrix1);
            int[] result2 = task2.SpiralOrder(matrix2);

            Console.WriteLine("Результирующий массив (Пример 1): " + string.Join(", ", result1));
            Console.WriteLine("Результирующий массив (Пример 2): " + string.Join(", ", result2));
            #endregion


            #region Task_3
            var server = new Task3();

            var readerThread = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    int currentValue = server.GetCount();
                    Console.WriteLine($"Читатель {Thread.CurrentThread.ManagedThreadId} читает значение: {currentValue}");
                    Thread.Sleep(1000); // Имитация долгой операции чтения
                }
            });

            var writerThread = new Thread(() =>
            {
                for (int i = 0; i < 3; i++)
                {
                    server.AddToCount(10);
                    Thread.Sleep(3000); // Имитация долгой операции записи
                }
            });

            readerThread.Start();
            writerThread.Start();

            readerThread.Join();
            writerThread.Join();

            Console.WriteLine($"Итоговое значение count: {server.GetCount()}");
            #endregion
        }
    }
}