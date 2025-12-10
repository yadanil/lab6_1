using System;
using System.Collections.Generic;
using System.Linq;

// Задание 1------------------------------------------------------------------------







// Конец задания 1------------------------------------------------------------------------

// Задание 2------------------------------------------------------------------------------



// Начало основной функции------------------------------------------------------------------

/// <summary>
/// Основной класс
/// </summary>
class Lab6
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    /// <param name="args">Аргументы командной строки</param>
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите задание:");
            Console.WriteLine("1. Первое задание");
            Console.WriteLine("2. Второе задание");
            Console.WriteLine("3. Выйти");

            int task = 0;

            // Проверка формата ввода
            try
            {
                task = Convert.ToInt32(Console.ReadLine()); ;
            }
            catch (FormatException)
            {
                Console.WriteLine();
                Console.WriteLine("Нужно ввести число");
                Console.WriteLine();
            }

            if (task == 3)
            {
                break;
            }

            // Номер задания
            switch (task)
            {
                // Первое задание
                case 1:
                    Console.WriteLine();
                    Console.WriteLine("Первое задание");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Первая часть:");

                    // Первая часть--------------------------
                    // Создаем кота по имени "Барсик"
                    HomeCat.Cat barsik = new HomeCat.Cat("Барсик");

                    // Выводим текстовое представление кота
                    Console.WriteLine(barsik.ToString());

                    // Кот мяукает один раз
                    barsik.Meow();

                    // Кот мяукает три раза
                    barsik.Meow(3);

                    // Вторая часть--------------------------
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Вторая часть:");

                    // Домашние коты
                    HomeCat.Cat vasya = new HomeCat.Cat("Вася");
                    HomeCat.Cat pushok = new HomeCat.Cat("Пушок");
                    HomeCat.Cat filya = new HomeCat.Cat("Филя");
                    HomeCat.Cat sema = new HomeCat.Cat("Сёма");

                    // Бродячие коты
                    Stray.StrayCat myrzik = new Stray.StrayCat("Мурзик");
                    Stray.StrayCat snezok = new Stray.StrayCat("Снежок");
                    Stray.StrayCat ryzik = new Stray.StrayCat("Рыжик");
                    Stray.StrayCat bars = new Stray.StrayCat("Барс");

                    while (true)
                    {
                        task = -1;

                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Мяукнут все");
                        Console.WriteLine("2. Мяукнут домашние коты");
                        Console.WriteLine("3. Мяукнут бродячие коты");
                        Console.WriteLine("4. Продолжить");

                        try
                        {
                            task = Convert.ToInt32(Console.ReadLine()); ;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Нужно ввести число");
                            Console.WriteLine();
                        }

                        if (task == 4)
                        {
                            break;
                        }

                        switch (task)
                        {
                            case 1:
                                Console.WriteLine();
                                Fun.Funs.MeowsCare(vasya, pushok, filya, sema);
                                Fun.Funs.MeowsCare(myrzik, snezok, ryzik, bars);
                                break;

                            case 2:
                                Console.WriteLine();
                                Fun.Funs.MeowsCare(vasya, pushok, filya, sema);
                                break;

                            case 3:
                                Console.WriteLine();
                                Fun.Funs.MeowsCare(myrzik, snezok, ryzik, bars);
                                break;

                            case -1:
                                break;

                            default:
                                Console.WriteLine();
                                Console.WriteLine("Таких котов нет");
                                Console.WriteLine();
                                break;
                        }
                    }

                    // Третья часть--------------------------
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Третья часть:");

                    int choice = -1;

                    HomeCat.Cat musya = new HomeCat.Cat("Муся");
                    HomeCat.Cat kuzya = new HomeCat.Cat("Кузя");

                    MeowCount.MeowCounter count_musya = new MeowCount.MeowCounter(musya);
                    MeowCount.MeowCounter count_kuzya = new MeowCount.MeowCounter(kuzya);

                    while (true)
                    {
                        Console.WriteLine("Выберите действие:");
                        Console.WriteLine("1. Мяукнут все");
                        Console.WriteLine("2. Мяукнет Муся");
                        Console.WriteLine("3. Мяукнет Кузя");
                        Console.WriteLine("4. Выход");

                        try
                        {
                            choice = Convert.ToInt32(Console.ReadLine()); ;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Нужно ввести число");
                            Console.WriteLine();
                        }

                        if (choice == 4)
                        {
                            break;
                        }

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine();
                                Fun.Funs.MeowsCare(count_musya, count_kuzya);
                                break;

                            case 2:
                                Console.WriteLine();
                                Fun.Funs.MeowsCare(count_musya);
                                break;

                            case 3:
                                Console.WriteLine();
                                Fun.Funs.MeowsCare(count_kuzya);
                                break;

                            default:
                                Console.WriteLine("Таких котов нет");
                                break;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine($"Муся мяукнула {count_musya.MeowCount} раз");
                    Console.WriteLine($"Кузя мяукнул {count_kuzya.MeowCount} раз");

                    // Конец первого задания
                    break;

                // Второе задание
                case 2:
                    Console.WriteLine();
                    Console.WriteLine("Второе задание");
                    Console.WriteLine();

                    // Первая часть--------------------------
                    Console.WriteLine("Первая часть:");
                    Console.WriteLine();

                    Frac.Fraction f1 = new Frac.Fraction(1, 3);
                    Frac.Fraction f2 = new Frac.Fraction(2, 3);
                    Frac.Fraction f3 = new Frac.Fraction(1, -5);
                    Frac.Fraction f4 = new Frac.Fraction(-3, 4);
                    Frac.Fraction f5 = new Frac.Fraction(7, 2);
                    Frac.Fraction f6 = new Frac.Fraction(-1, 5);

                    Console.WriteLine($"Сложение {f1} и {f2}:");
                    Console.WriteLine(f1 + f2);
                    Console.WriteLine($"Вычитание {f4} из {f3}:");
                    Console.WriteLine(f3 - f4);
                    Console.WriteLine($"Умножение {f2} на {f5}:");
                    Console.WriteLine(f2 * f5);
                    Console.WriteLine($"Деление {f4} на {f5}:");
                    Console.WriteLine(f4 / f5);

                    Console.WriteLine();
                    Console.WriteLine("Результат f1 + f2 / f3 - 5:");
                    Console.WriteLine(f1 + f2 / f3 - 5);

                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();

                    // Вторая часть--------------------------
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Вторая часть:");
                    Console.WriteLine();

                    Console.WriteLine($"Сравнение {f3} и {f6}:");
                    Console.WriteLine(f3.Equals(f6));

                    Console.WriteLine($"Сравнение {f5} и {f6}:");
                    Console.WriteLine(f5.Equals(f6));

                    Console.WriteLine($"Сравнение {f1} и {f3}:");
                    Console.WriteLine(f1.Equals(f3));

                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();

                    // Третья часть--------------------------
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Третья часть:");
                    Console.WriteLine();

                    // Создание клона
                    Frac.Fraction clone = f1 as Frac.Fraction;

                    Console.WriteLine($"Клон равен {clone}, изначальная дробь равна {f1}");

                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter чтобы продолжить");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Такого задания нет");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}