using System.Linq;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Тема: LINQ To Objects
 Завдання 1:
 Дано цілочисельну послідовність. Витягти з неї всі позитивні числа, відсортувавши їх по зростанню.
 Завдання 2:
 Дано колекцію цілих чисел. Знайти кількість позитивних двозначних елементів, а також їх середнє арифметичне.
 Завдання 3:
 Дано цілочисельну колекцію, яка зберігає список років. Витягти з неї всі високосні роки, відсортувавши їх по зростанню.
 Завдання 4:
 Дано колекцію цілих чисел. Знайти максимальне парне значення.
 Завдання 5:
 Дано колекцію непустих рядків. Отримати колекцію рядків, додавши вкінець до кожної три знаки оклику.
 Завдання 6:
 Дано певний символ і строкова колекція. Отримати колекцію строк, які мають відповідний символ.
 Завдання 7:
 Дано колекцію непустих рядків. Згрупувати всі елементи по кількості символів.
  */
            //завдання 1
            List<int> list = new List<int>() { -1,9,43,89};
            if (list.Count > 0)
            {
                var positiveNumbers = list.Where(n => n > 0).OrderBy(n => n);
                foreach (var number in positiveNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            
            //завдання 2
            List<int> numbers = new List<int>() { 23,32,56,76,7};
            if (numbers.Count > 0)
            {
                var twodigitpositivenumbers = numbers.Where(n => n > 9 && n < 100);
                int count = twodigitpositivenumbers.Count();
                double average = twodigitpositivenumbers.Average();
                Console.WriteLine($"Count = {count}");
                Console.WriteLine($"average = {average}");
            }
            //завдання 3
            List<int> years = new List<int>() { 2021,2022,2023,2020,2019};
            var res = years.Where(y => y % 4 == 0 && y % 100 != 0);
            foreach (var year in res)
            {
                Console.WriteLine(year);
            }

            //завдання 4
            List<int> numbers1 = new List<int>() { 5,7,9,12,34,76656};
            if (numbers1.Count % 2 == 0)
            {
                var answer = numbers1.Max();
                Console.WriteLine($"Max number = {answer}");
            }
            //завдання 5
            List<string> strings = new List<string>() { "hello", "world", "C#", "c++", "pythin" };
            var modifiedStrings =  "!!!";
            var ras = strings.Select(word=>word+=modifiedStrings);
            foreach (var s in ras) 
            {
                Console.WriteLine(s);
            }
            //завдання 6
            char ch = 'a';
            List<string> words = new List<string> { "apple", "banana", "cherry", "plum", "avocado" };
            var result = words.Where(word => word.Contains(ch)).ToList();
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
            //завдання 7
            List<string> stringa = new List<string>() { "hello", "world", "C#", "c++", "pythin" };
            var groupedStrings = stringa.GroupBy(s => s.Length);
            foreach (var group in groupedStrings)
            {
                Console.WriteLine($"stringa with length {group.Key}:");
                foreach (var str in group)
                {
                    Console.WriteLine(str);
                }
            }
        }
    }
}
