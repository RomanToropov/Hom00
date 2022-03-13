using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    internal class Program
    {
        delegate void method();
        static void Main(string[] args)
        {

            string[] items = { "Задание 1", "Задание 2", "Задание 3", "Задание 4", "Задание 5", "Задание 6", "Задание 7", "Выход" };
            method[] methods = new method[] { Method1, Method2, Method3, Method4, Method5, Method6, Method7, Exit };
            ConsoleMenu menu = new ConsoleMenu(items);
            int menuResult;
            do
            {
                menuResult = menu.PrintMenu();
                methods[menuResult]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult != items.Length - 1);
        }

        static void Method1()
        {
            Console.Clear();
            int num = 0;
            Console.Write("Введите число в диапазоне от 1 до 100: ");
            num = Int32.Parse(Console.ReadLine());
            if (num < 1 || num > 100) Console.WriteLine($"Ошибка: число {num} не входит в диапозон от 1 до 100");
            else if (num % 3 == 0 && num % 5 == 0) Console.WriteLine("Fizz Buzz");
            else if (num % 3 == 0) Console.WriteLine("Fizz");
            else if (num % 5 == 0) Console.WriteLine("Buzz");
            else Console.WriteLine(num);
        }
        static void Method2()
        {
            Console.Clear();
            int proc = 1;
            double num = 0;
            Console.Write("Введите число: ");
            num = Double.Parse(Console.ReadLine());
            Console.Write("Введите процент: ");
            proc = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"{proc}% от числа {num} = {(num / 100) * proc}");
        }
        static void Method3()
        {
            int num = 0;
            for (int i = 0; i < 4; i++)
            {
                Console.Clear();
                Console.Write($"Введите {4 - i} число: ");
                num = num * 10 + Int32.Parse(Console.ReadLine());
            }
            Console.WriteLine($"Получилось число {num}");
        }
        static void Method4()
        {
            Console.Clear();
            Console.Write("Введите число: ");
            int num = Int32.Parse(Console.ReadLine());
            if (num < 100000 || num > 999999) Console.WriteLine("вы ввели не шестизначное число");
            else
            {
                Console.WriteLine($"Введите номера разрядов для обмена цифр: ");
                int raz1 = Int32.Parse(Console.ReadLine());
                int raz2 = Int32.Parse(Console.ReadLine());

                int chislo1 = 0;
                int del = 10;

                if (raz1 == 6) chislo1 = num % 10;
                else
                {
                    for (int i = 0; i < (6 - raz1); i++)
                    {
                        chislo1 = num / del;
                        del *= 10;
                    }
                    chislo1 = chislo1 % 10;
                    del = 10;
                }

                int chislo2 = 0;

                if (raz2 == 6) chislo2 = num % 10;
                else
                {
                    for (int i = 0; i < (6 - raz2); i++)
                    {
                        chislo2 = num / del;
                        del *= 10;
                    }
                    chislo2 = chislo2 % 10;
                }

                Console.WriteLine(chislo1);
                Console.WriteLine(chislo2);
                del = 100000;
                for (int i = 0; i < 6; i++)
                {
                    if (i == raz1 - 1)
                    {
                        Console.Write(chislo2);
                        num = num % del;
                        del /= 10;
                    }
                    else if (i == raz2 - 1)
                    {
                        Console.Write(chislo1);
                        num = num % del;
                        del /= 10;
                    }
                    else if (i == 5) Console.Write(num);
                    else
                    {
                        Console.Write(num / del);
                        num %= del;
                        del /= 10;
                    }
                }
            }
            Console.WriteLine();
        }
        static void Method5()
        {
             Console.WriteLine("Введите номер месяца");
             int month = int.Parse(Console.ReadLine());

             switch (month)
             {
                 case 12:
                 case 1:
                 case 2:
                     Console.WriteLine("зима");
                     break;
                 case 3:
                 case 4:
                 case 5:
                     Console.WriteLine("весна");
                     break;
                 case 6:
                 case 7:
                 case 8:
                     Console.WriteLine("лето");
                     break;
                 case 9:
                 case 10:
                 case 11:
                     Console.WriteLine("осень");
                     break;
                 default:
                     Console.WriteLine("Неверный ввод");
                     break;
             }
        }
        static void Method6()
        {
            method[] methods1 = new method[] { MethodTemp, MethodTemp1, ExitTemp };
            string[] items = { "Перевод из цельсия в фаренгейт", "Перевод из фаренгейта в цельсий", "Выход" };
            ConsoleMenu menu1 = new ConsoleMenu(items);
            int menuResult1;
            do
            {
                menuResult1 = menu1.PrintMenu();
                methods1[menuResult1]();
                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
            } while (menuResult1 != items.Length - 1);

            void MethodTemp()
            {
                Console.Clear();
                double C = 0;
                Console.Write("Введите температуру в цельсиях: ");
                C = Double.Parse(Console.ReadLine());
                Console.WriteLine($"{C}С = {C * 1.8 + 32}F");
            }
            void MethodTemp1()
            {
                Console.Clear();
                double F = 0, fraction = (double)5 / 9;
                Console.Write("Введите температуру в фаренгейтах: ");
                F = Double.Parse(Console.ReadLine());
                Console.WriteLine($"{F}F = {(F - 32) * fraction}C");
            }
            void ExitTemp()
            {
                Console.WriteLine("Выход!");
            }
        }
        static void Method7()
        {
            Console.Clear();
            int min = 0, max = 0;
            Console.Write("Введите минимальное значение диапазона: ");
            min = Int32.Parse(Console.ReadLine());
            Console.Write("Введите максимальное значение диапазона: ");
            max = Int32.Parse(Console.ReadLine());
            if (min > max)
            {
                int buffer = min;
                min = max;
                max = buffer;
            }
            for (int i = min; i <= max; i++)
            {
                if (i % 2 == 0) Console.Write($"{i} ");
            }
            Console.WriteLine();
        }
        static void Exit()
        {
            Console.WriteLine("Приложение заканчивает работу!");
        }
    }


    class ConsoleMenu
    {
        string[] menuItems;
        int counter = 0;
        public ConsoleMenu(string[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public int PrintMenu()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (counter == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menuItems[i]);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                        Console.WriteLine(menuItems[i]);

                }
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow)
                {
                    counter--;
                    if (counter == -1) counter = menuItems.Length - 1;
                }
                if (key.Key == ConsoleKey.DownArrow)
                {
                    counter++;
                    if (counter == menuItems.Length) counter = 0;
                }
            }
            while (key.Key != ConsoleKey.Enter);
            return counter;
        }
    }
}