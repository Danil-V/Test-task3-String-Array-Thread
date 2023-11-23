using System.Text;

namespace Test_Task.Tasks
{
    #region Task description
    /// <summary>
    /// Задача №1:
    /// Дана строка, содержащая n маленьких букв латинского алфавита.
    /// Требуется реализовать алгоритм компрессии этой строки, замещающий группы последовально идущих одинаковых букв формой "sc" (где "s"-символ, "c" - количество букв в группе).
    /// Также алгоритм декомпрессии, возвращающий исходную строку сжатой.
    /// Если буква в группе всего одна - количество в сжатой строке не указываем, а пишем её как есть.
    /// 
    /// Пример:
    /// Исходная строка: aaabbcccdde
    /// Сжатая строка: a3b2c3d2e
    /// </summary>
    #endregion

    public class Task1
    {
        public string CompressString(string s)
        {
            StringBuilder compressed = new StringBuilder();
            int count = 1;

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                    count++;
                else
                {
                    if (count == 1)
                        compressed.Append(s[i - 1]);
                    else
                        compressed.Append(s[i - 1] + count.ToString());

                    count = 1;
                }
            }

            // Обработка последнего символа и его количества
            if (count == 1)
                compressed.Append(s[s.Length - 1]);
            else
                compressed.Append(s[s.Length - 1] + count.ToString());

            return compressed.ToString();
        }

        public string DecompressString(string s)
        {
            StringBuilder decompressed = new StringBuilder();
            int i = 0;

            while (i < s.Length)
            {
                decompressed.Append(s[i]);

                if (i + 1 < s.Length && char.IsDigit(s[i + 1]))
                {
                    int count = int.Parse(s[i + 1].ToString());
                    decompressed.Append(new string(s[i], count - 1));
                    i += 2;
                }
                else
                    i++;
            }

            return decompressed.ToString();
        }
    }
}

