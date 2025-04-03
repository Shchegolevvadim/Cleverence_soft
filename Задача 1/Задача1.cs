// Дана строка, содержащая n маленьких букв латинского алфавита. Требуется реализовать
// алгоритм компрессии этой строки, замещающий группы последовательно идущих
// одинаковых букв формой "sc" (где "s" – символ, "с" – количество букв в группе), а также
// алгоритм декомпрессии, возвращающий исходную строку по сжатой.
// Если буква в группе всего одна – количество в сжатой строке не указываем, а пишем её
// как есть.
// Пример:
// Исходная строка: aaabbcccdde
// Сжатая строка: a3b2c3d2e

using System;
using System.Text;
using System.IO;
using System.IO.Compression;

Console.WriteLine("Введите строку для компрессии: ");
string s = Console.ReadLine();
static string CompressStr(string s)
{
    StringBuilder builder = new StringBuilder();
    for (int begin = 0; begin < s.Length; )
    {
        int end = begin + 1;
        while (end < s.Length && s[begin] == s[end])
            ++end;
        if (end - begin > 1)
        {
            builder.Append(s[begin]).Append(end - begin);
        }
        else
        {
            builder.Append(s, begin, end - begin);
        }
        begin = end;
    }
    return builder.ToString();
}
Console.WriteLine(CompressStr(s));

// Вариант для декомпрессии строки:

Console.WriteLine("Введите строку для декомпрессии: ");
string d = Console.ReadLine();
static string deCompressStr(string d)
{StringBuilder builder = new StringBuilder();
    int i = 0;
    for(int begin = 0; begin < d.Length;)
    {
        int end = begin + 1;

        int number = 0;
        while (end < d.Length && d[begin] == d[end])
            end++;
        if (Convert.ToInt32(d[end]) > 1)
        {
        number = Convert.ToInt32(d[end]);
            for (int j = 0; j < number - 48; j++)
            {
                builder.Append(d[begin]);
            }
        }
        begin = end + 1;
    }
    return builder.ToString();
}
Console.WriteLine(deCompressStr(d));