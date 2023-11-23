namespace Test_Task.Tasks
{
    #region Task description
    /// <summary>
    /// Задача №3:
    /// Есть "сервер" в виде статического класса.
    /// У него есть переменная count (тип int) и два метода, которые позволяют эту переменную читать и писать: GetCount() и AddToCount(int value).
    /// К классу - "серверу" параллельно обращаются множество клиентов, которые в основном читают, но некоторые добавляют значение к count.
    /// </summary>
    #endregion

    public class Task3 // реализуем класс Server (в нашем примере он называется Task3 чтобы соответствовать номеру задачи согласно Т.З.)
    {
        private int count = 0;
        private readonly object lockObject = new object();

        public int GetCount()
        {
            // Разрешаем параллельное чтение:
            lock (lockObject)
            {
                return count;
            }
        }

        public void AddToCount(int value)
        {
            // Запрещаем одновременную запись:
            lock (lockObject)
            {
                Console.WriteLine($"Писатель {Thread.CurrentThread.ManagedThreadId} начал добавление {value} к count.");
                // Имитация долгой операции записи:
                Thread.Sleep(2000);
                count += value;
                Console.WriteLine($"Писатель {Thread.CurrentThread.ManagedThreadId} закончил добавление {value} к count.");
            }
        }
    }
}
