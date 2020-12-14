using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicatePartTwo
{
    class Program
    {


        protected static Func<string[], int[]> Parser = strings =>
        {
            int[] ints = new int[strings.Length];
            for (var i = 0; i < strings.Length; i++)
            {
                ints[i] = int.Parse(strings[i]);
            }

            return ints;
        };

        public static void Task1()
        {
            Action<int[]> add = numbers =>
            {
                for (var i = 0; i < numbers.Length; i++)
                {
                    numbers[i]++;
                }
            };
            Action<int[]> multiply = ints =>
            {
                for (var i = 0; i < ints.Length; i++)
                {
                    ints[i] *= 2;
                }
            };
            Action<int[]> subtract = ints =>
             {
                 for (var i = 0; i < ints.Length; i++)
                 {
                     ints[i]--;
                 }
             };
            Action<int[]> print = numbers => Console.WriteLine(numbers);


            Func<string, Action<int[]>> complete = cmd =>
            {
                switch (cmd)
                {
                    case "add":
                        return add;
                    case "multiply":
                        return multiply;
                    case "subtract":
                        return subtract;
                    case "print":
                        return print;
                }

                return _ => { };
            };

            var line = Console.ReadLine();
            var strings = line.Split(' ');
            var numbers = Parser(strings);

            while ((line = Console.ReadLine()) != "end")
            {
                complete(line)(numbers);
            }
        }

        public static void Task2()
        {
            Func<int[], int[]> reverse = numbers => numbers.Reverse().ToArray();
            Func<int[], int, int[]> filterDivider = (numbers, devider) => numbers.Where(i => i % devider != 0).ToArray();
            Action<int[]> print = numbers => Console.WriteLine(numbers);

            var line = Console.ReadLine();
            var strings = line.Split(' ');
            var numbers = Parser(strings);
            int divider = int.Parse(Console.ReadLine());

            int[] array = reverse(numbers);
            filterDivider(array, divider);
            print(array);
        }

        public static void Task3()
        {
            Func<string[], int, string[]> filter = (str, number) => str.Where(s => s.Length <= number).ToArray();
            Action<string[]> print = strings => Console.WriteLine(strings);

            var line = Console.ReadLine();
            int number = int.Parse(line);

            line = Console.ReadLine();
            var names = line.Split(' ');
            string[] array = filter(names, number);
            print(array);
        }

        public static void Task4()
        {
           var comparer = Comparer<int>.Create((i, j) =>
            {
                if (i % 2 == 0 && j % 2 == 1) return -1;
                if (j % 2 == 0 && i % 2 == 1) return 1;
                return i.CompareTo(j);
            });

            var line = Console.ReadLine();
            var strings = line.Split(' ');
            var numbers = Parser(strings);
            Array.Sort(numbers, comparer);
            Console.WriteLine(string.Join(" ", numbers));
        }

        static void Main(string[] args)
        {
            Task2();
        }
    }
}
