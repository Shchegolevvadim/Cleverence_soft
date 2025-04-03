// Консольная программа для стандартизации лог-файлов
// Эта программа предназначена для обработки лог-файлов, содержащих записи в двух
// разных форматах. Цель программы –1  привести все записи к единому, стандартному виду,
// упрощая анализ и обработку логов.
// Необходимо преобразовать записи из входного лог-файла в единый формат и сохранить
// их в выходной файл.

using System;
using System.Globalization;
string path = "1 Logfile.txt";
string path3 = "problems.txt";
String s6 = "INFO";
bool ans6;
string readContent = File.ReadAllText(path);
ans6 = readContent.Contains(s6);
if (ans6 == false){
    File.WriteAllText(path3, readContent);
}

if (ans6){
// асинхронное чтение
    using (StreamReader reader = new StreamReader(path))
    {
        string? line;
    
        while ((line = await reader.ReadLineAsync()) != null)
        {
            Console.WriteLine(line);
            string path2 = "Выход.txt";
            using (StreamWriter writer = new StreamWriter(path2, true))
            {
            String str = line;
            String s1 = "Дата"; 
            String s2 = "Время";
            String s3 = "УровеньЛогирования";
            String s4 = "ВызвавшийМетод";
            String s5 = "Сообщение";
            bool ans;
            bool ans2;
            bool ans3;
            bool ans4;
            bool ans5;
            ans = str.Contains(s1);
            ans2 = str.Contains(s2);
            ans3 = str.Contains(s3);
            ans4 = str.Contains(s4);
            ans5 = str.Contains(s5);
            if (ans)
            {   
                string result = string.Empty;
                result = line.Remove(0, 6);
                string newresult = result.Replace(".","-");
                var parsedDate = DateTime.Parse(newresult);
                string formatted = parsedDate.ToString("yyyy-MM-dd");
                await writer.WriteLineAsync(formatted);
            }
            
            if (ans2)
            {
                string result = string.Empty;
                result = line.Remove(0, 7);
                await writer.WriteLineAsync(result);
            }
            if (ans3)
            {
                string result = string.Empty;
                result = line.Remove(0, 20);
                try{
                string newresult = string.Empty;
                newresult = result.Remove(4, 7);
                await writer.WriteLineAsync(newresult);
                string d = "DEFAULT";
                await writer.WriteLineAsync(d);
                }
                catch(ArgumentOutOfRangeException)
                {Console.WriteLine("второй вариант лога");
                await writer.WriteLineAsync(result);}
            }
            if (ans4)
            {
                string result = string.Empty;
                result = line.Remove(0, 16);
                await writer.WriteLineAsync(result);
            }
            if (ans5)
            {
                string result = string.Empty;
                result = line.Remove(0, 11);
                await writer.WriteLineAsync(result);
                string emp = string.Empty;
                await writer.WriteLineAsync(emp);
            }
            }
        }
}
}








