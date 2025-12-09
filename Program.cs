using System;
using System.Collections.Generic;
using System.Linq;

// Задание 1------------------------------------------------------------------------

/// <summary>
/// Интерфейс для объектов, способных мяукать
/// </summary>
public interface I_Meowable
{
    /// <summary>
    /// Мяукнуть один раз
    /// </summary>
    void Meow();
}

/// <summary>
/// Бродяий кот
/// </summary>
public class StrayCat : I_Meowable
{
    /// <summary>
    /// Имя бродячего кота
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Создает нового бродячего кота
    /// </summary>
    /// <param name="name">Имя бродячего кота</param>
    /// <exception cref="ArgumentException">Выводится, если имя пустое</exception>
    public StrayCat(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя кота не может быть пустым");
        }
        Name = name;
    }

    /// <summary>
    /// Возвращает строковое представление бродячего кота
    /// </summary>
    /// <returns>Строка в формате "Кот: Имя"</returns>
    public override string ToString()
    {
        return $"Кот: {Name}";
    }

    /// <summary>
    /// Вывод одного мяукания
    /// </summary>
    public void Meow()
    {
        Console.WriteLine($"{Name}: Мяу!");
    }

    /// <summary>
    /// Мяукает n количество раз
    /// </summary>
    /// <param name="n">Количество повторений мяукания</param>
    public void Meow(int n)
    {
        if (n <= 0)
        {
            Console.WriteLine($"{Name}: Не мяукал");
            return;
        }

        if (n == 1)
        {
            Meow();
            return;
        }

        // Количество мяуканий с дефисом 
        string meowChain = string.Join("-", new string[n - 1].Select(_ => "мяу"));
        // Итоговый результат
        Console.WriteLine($"{Name}: мяу-{meowChain}!");
    }
}

/// <summary>
/// Домашний кот
/// </summary>
public class Cat : I_Meowable
{
    /// <summary>
    /// Имя домашнего кота
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Создает нового домашнего кота
    /// </summary>
    /// <param name="name">Имя домашнего кота</param>
    /// <exception cref="ArgumentException">Выбрасывается, если имя пустое или состоит только из пробелов</exception>
    public Cat(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Имя кота не может быть пустым");
        }
        Name = name;
    }

    /// <summary>
    /// Возвращает строковое представление домашнего кота
    /// </summary>
    /// <returns>Строка в формате "Кот: Имя"</returns>
    public override string ToString()
    {
        return $"Кот: {Name}";
    }

    /// <summary>
    /// Мяукает один раз
    /// </summary>
    public void Meow()
    {
        Console.WriteLine($"{Name}: Мяу!");
    }

    /// <summary>
    /// Мяукает n раз
    /// </summary>
    /// <param name="n">Количество мяуканий". Если n ≤ 0, кот не мяукал</param>
    public void Meow(int n)
    {
        if (n <= 0)
        {
            Console.WriteLine($"{Name}: Не мяукал");
            return;
        }

        if (n == 1)
        {
            Meow();
            return;
        }

        // Количество мяуканий с дефисом 
        string meowChain = string.Join("-", new string[n - 1].Select(_ => "мяу"));
        // Итоговый результат
        Console.WriteLine($"{Name}: мяу-{meowChain}!");
    }
}

/// <summary>
/// Класс для мяукания нексольких котов за раз
/// </summary>
public class Funs
{
    /// <summary>
    /// Заставляет всех котов мяукнуть
    /// </summary>
    /// <param name="meowableObjects">Коллекция объектов, реализующих I_Meowable</param>
    public static void MeowsCare(IEnumerable<I_Meowable> meowableObjects)
    {
        Console.WriteLine();
        int counter = 1;

        foreach (var obj in meowableObjects)
        {
            Console.Write($"{counter}. {obj.GetType().Name}: ");
            obj.Meow();
            counter++;
        }

        Console.WriteLine();
    }

    /// <summary>
    /// Для удобства вызова MeowsCare без создания массива
    /// </summary>
    /// <param name="meowableObjects">Массив объектов, реализующих I_Meowable</param>
    public static void MeowsCare(params I_Meowable[] meowableObjects)
    {
        MeowsCare((IEnumerable<I_Meowable>)meowableObjects);
    }
}

/// <summary>
/// Подсчет количества мяуканий
/// </summary>
public class MeowCounter : I_Meowable
{
    private readonly I_Meowable cat;
    private int meowCount;

    /// <summary>
    /// Количество мяуканий
    /// </summary>
    public int MeowCount => meowCount;

    /// <summary>
    /// Добавляет счетчик мяуканий к коту
    /// </summary>
    /// <param name="cat">Кот мяукания которого нужно подсчитывать</param>
    /// <exception cref="ArgumentNullException">Выводится, если cat равен null</exception>
    public MeowCounter(I_Meowable cat)
    {
        this.cat = cat ?? throw new ArgumentNullException(nameof(cat));
        meowCount = 0;
    }

    /// <summary>
    /// Мяукание и увеличивает счетчик
    /// </summary>
    public void Meow()
    {
        cat.Meow();
        meowCount++;
    }

    /// <summary>
    /// Сбрасывает счетчик мяуканий
    /// </summary>
    public void ResetCounter()
    {
        meowCount = 0;
    }

    /// <summary>
    /// Возвращает строковое представление счетчика мяуканий
    /// </summary>
    /// <returns>Строка с информацией о подсчитываемом коте</returns>
    public override string ToString()
    {
        return $"Счетчик мяуканий для: {cat}";
    }
}
// Конец задания 1------------------------------------------------------------------------

// Задание 2------------------------------------------------------------------------------

/// <summary>
/// Представляет математическую дробь с целым числителем и знаменателем
/// </summary>
public class Fraction : IEquatable<Fraction>, ICloneable
{
    private int numerator;
    private int denominator;

    /// <summary>
    /// Создание дроби
    /// </summary>
    /// <param name="numerator">Числитель дроби</param>
    /// <param name="denominator">Знаменатель дроби</param>
    /// <exception cref="ArgumentException">Выбрасывается, если знаменатель равен нулю</exception>
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Знаменатель не может быть равен нулю.");

        this.numerator = numerator;
        this.denominator = denominator;

        NormalizeSign();
        Simplify();
    }

    /// <summary>
    /// Нормализует знак дроби
    /// </summary>
    private void NormalizeSign()
    {
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
    }

    /// <summary>
    /// Упрощает дробь, деля числитель и знаменатель на их наибольший общий делитель
    /// </summary>
    private void Simplify()
    {
        int gcd = GCD(Math.Abs(numerator), denominator);
        numerator /= gcd;
        denominator /= gcd;
    }

    /// <summary>
    /// Вычисляет наибольший общий делитель двух целых чисел
    /// </summary>
    /// <param name="a">Первое целое число</param>
    /// <param name="b">Второе целое число</param>
    /// <returns>Наибольший общий делитель a и b</returns>
    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    /// <summary>
    /// Возвращает строковое представление дроби в формате "числитель/знаменатель"
    /// </summary>
    /// <returns>Строковое представление дроби</returns>
    public override string ToString()
    {
        return $"{numerator}/{denominator}";
    }

    /// <summary>
    /// Складывает текущую дробь с другой дробью
    /// </summary>
    /// <param name="other">Дробь для сложения</param>
    /// <returns>Новая дробь - результат сложения</returns>
    public Fraction Add(Fraction other)
    {
        int newNumerator = this.numerator * other.denominator + other.numerator * this.denominator;
        int newDenominator = this.denominator * other.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Вычитает другую дробь из текущей дроби
    /// </summary>
    /// <param name="other">Дробь для вычитания</param>
    /// <returns>Новая дробь - результат вычитания</returns>
    public Fraction Subtract(Fraction other)
    {
        int newNumerator = this.numerator * other.denominator - other.numerator * this.denominator;
        int newDenominator = this.denominator * other.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Умножает текущую дробь на другую дробь
    /// </summary>
    /// <param name="other">Дробь для умножения</param>
    /// <returns>Новая дробь - результат умножения</returns>
    public Fraction Multiply(Fraction other)
    {
        int newNumerator = this.numerator * other.numerator;
        int newDenominator = this.denominator * other.denominator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Делит текущую дробь на другую дробь
    /// </summary>
    /// <param name="other">Дробь-делитель</param>
    /// <returns>Новая дробь - результат деления</returns>
    /// <exception cref="DivideByZeroException">Выбрасывается, если числитель делителя равен нулю</exception>
    public Fraction Divide(Fraction other)
    {
        if (other.numerator == 0)
            throw new DivideByZeroException("Деление на ноль.");

        int newNumerator = this.numerator * other.denominator;
        int newDenominator = this.denominator * other.numerator;
        return new Fraction(newNumerator, newDenominator);
    }

    /// <summary>
    /// Складывает текущую дробь с целым числом
    /// </summary>
    /// <param name="number">Целое число для сложения</param>
    /// <returns>Новая дробь - результат сложения</returns>
    public Fraction Add(int number)
    {
        return this.Add(new Fraction(number, 1));
    }

    /// <summary>
    /// Вычитает целое число из текущей дроби
    /// </summary>
    /// <param name="number">Целое число для вычитания</param>
    /// <returns>Новая дробь - результат вычитания</returns>
    public Fraction Subtract(int number)
    {
        return this.Subtract(new Fraction(number, 1));
    }

    /// <summary>
    /// Умножает текущую дробь на целое число
    /// </summary>
    /// <param name="number">Целое число для умножения</param>
    /// <returns>Новая дробь - результат умножения</returns>
    public Fraction Multiply(int number)
    {
        return this.Multiply(new Fraction(number, 1));
    }

    /// <summary>
    /// Делит текущую дробь на целое число
    /// </summary>
    /// <param name="number">Целое число-делитель</param>
    /// <returns>Новая дробь - результат деления</returns>
    /// <exception cref="DivideByZeroException">Выводится, если число равно нулю</exception>
    public Fraction Divide(int number)
    {
        if (number == 0)
            throw new DivideByZeroException("Деление на ноль.");
        return this.Divide(new Fraction(number, 1));
    }

    // Перегрузка операторов

    /// <summary>
    /// Оператор сложения двух дробей
    /// </summary>
    /// <param name="a">Первая дробь</param>
    /// <param name="b">Вторая дробь</param>
    /// <returns>Сумма дробей</returns>
    public static Fraction operator +(Fraction a, Fraction b) => a.Add(b);

    /// <summary>
    /// Оператор вычитания двух дробей
    /// </summary>
    /// <param name="a">Уменьшаемая дробь</param>
    /// <param name="b">Вычитаемая дробь</param>
    /// <returns>Разность дробей</returns>
    public static Fraction operator -(Fraction a, Fraction b) => a.Subtract(b);

    /// <summary>
    /// Оператор умножения двух дробей
    /// </summary>
    /// <param name="a">Первая дробь</param>
    /// <param name="b">Вторая дробь</param>
    /// <returns>Произведение дробей</returns>
    public static Fraction operator *(Fraction a, Fraction b) => a.Multiply(b);

    /// <summary>
    /// Оператор деления двух дробей
    /// </summary>
    /// <param name="a">Делимая дробь</param>
    /// <param name="b">Делитель дробь</param>
    /// <returns>Частное дробей</returns>
    public static Fraction operator /(Fraction a, Fraction b) => a.Divide(b);

    /// <summary>
    /// Оператор сложения дроби и целого числа
    /// </summary>
    /// <param name="a">Дробь</param>
    /// <param name="b">Целое число</param>
    /// <returns>Сумма дроби и числа</returns>
    public static Fraction operator +(Fraction a, int b) => a.Add(b);

    /// <summary>
    /// Оператор вычитания целого числа из дроби
    /// </summary>
    /// <param name="a">Дробь</param>
    /// <param name="b">Целое число</param>
    /// <returns>Разность дроби и числа</returns>
    public static Fraction operator -(Fraction a, int b) => a.Subtract(b);

    /// <summary>
    /// Оператор умножения дроби на целое число
    /// </summary>
    /// <param name="a">Дробь</param>
    /// <param name="b">Целое число</param>
    /// <returns>Произведение дроби и числа</returns>
    public static Fraction operator *(Fraction a, int b) => a.Multiply(b);

    /// <summary>
    /// Оператор деления дроби на целое число
    /// </summary>
    /// <param name="a">Дробь</param>
    /// <param name="b">Целое число</param>
    /// <returns>Частное дроби и числа</returns>
    public static Fraction operator /(Fraction a, int b) => a.Divide(b);

    /// <summary>
    /// Оператор сложения целого числа и дроби
    /// </summary>
    /// <param name="a">Целое число</param>
    /// <param name="b">Дробь</param>
    /// <returns>Сумма числа и дроби</returns>
    public static Fraction operator +(int a, Fraction b) => new Fraction(a, 1).Add(b);

    /// <summary>
    /// Оператор вычитания дроби из целого числа
    /// </summary>
    /// <param name="a">Целое число</param>
    /// <param name="b">Дробь</param>
    /// <returns>Разность числа и дроби</returns>
    public static Fraction operator -(int a, Fraction b) => new Fraction(a, 1).Subtract(b);

    /// <summary>
    /// Оператор умножения целого числа на дробь
    /// </summary>
    /// <param name="a">Целое число</param>
    /// <param name="b">Дробь</param>
    /// <returns>Произведение числа и дроби</returns>
    public static Fraction operator *(int a, Fraction b) => new Fraction(a, 1).Multiply(b);

    /// <summary>
    /// Оператор деления целого числа на дробь
    /// </summary>
    /// <param name="a">Целое число</param>
    /// <param name="b">Дробь</param>
    /// <returns>Частное числа и дроби</returns>
    public static Fraction operator /(int a, Fraction b) => new Fraction(a, 1).Divide(b);

    /// <summary>
    /// Определяет, равен ли указанный объект текущему объекту Fraction
    /// </summary>
    /// <param name="obj">Объект для сравнения с текущим объектом</param>
    /// <returns>true, если указанный объект равен текущему объекту, иначе — false</returns>
    public override bool Equals(object obj)
    {
        return Equals(obj as Fraction);
    }

    /// <summary>
    /// Определяет, равна ли указанная дробь текущей дроби
    /// </summary>
    /// <param name="other">Дробь для сравнения с текущей дробью</param>
    /// <returns>true, если указанная дробь равна текущей дроби, иначе — false</returns>
    public bool Equals(Fraction other)
    {
        // Проверка на null
        if (other is null)
            return false;

        // Проверка ссылаются ли на один и тот же объект
        if (ReferenceEquals(this, other))
            return true;

        // Две дроби равны, если их числители и знаменатели равны
        return this.numerator == other.numerator &&
               this.denominator == other.denominator;
    }

    /// <summary>
    /// Определяет, равны ли две указанные дроби
    /// </summary>
    /// <param name="left">Первая дробь для сравнения</param>
    /// <param name="right">Вторая дробь для сравнения</param>
    /// <returns>true, если дроби равны, иначе — false</returns>
    public static bool operator ==(Fraction left, Fraction right)
    {
        // Обработка null значений
        if (left is null)
            return right is null;

        return left.Equals(right);
    }

    /// <summary>
    /// Определяет, не равны ли две указанные дроби
    /// </summary>
    /// <param name="left">Первая дробь для сравнения</param>
    /// <param name="right">Вторая дробь для сравнения</param>
    /// <returns>true, если дроби не равны, иначе — false</returns>
    public static bool operator !=(Fraction left, Fraction right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Создает новый объект Fraction, который является копией текущего 
    /// </summary>
    /// <returns>Новый объект Fraction, являющийся копией текущего </returns>
    public object Clone()
    {
        // Создаем новую дробь с теми же значениями
        return new Fraction(numerator, denominator);
    }
}

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
                    Cat barsik = new Cat("Барсик");

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
                    Cat vasya = new Cat("Вася");
                    Cat pushok = new Cat("Пушок");
                    Cat filya = new Cat("Филя");
                    Cat sema = new Cat("Сёма");

                    // Бродячие коты
                    StrayCat myrzik = new StrayCat("Мурзик");
                    StrayCat snezok = new StrayCat("Снежок");
                    StrayCat ryzik = new StrayCat("Рыжик");
                    StrayCat bars = new StrayCat("Барс");

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
                                Funs.MeowsCare(vasya, pushok, filya, sema);
                                Funs.MeowsCare(myrzik, snezok, ryzik, bars);
                                break;

                            case 2:
                                Console.WriteLine();
                                Funs.MeowsCare(vasya, pushok, filya, sema);
                                break;

                            case 3:
                                Console.WriteLine();
                                Funs.MeowsCare(myrzik, snezok, ryzik, bars);
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

                    Cat musya = new Cat("Муся");
                    Cat kuzya = new Cat("Кузя");

                    MeowCounter count_musya = new MeowCounter(musya);
                    MeowCounter count_kuzya = new MeowCounter(kuzya);

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
                                Funs.MeowsCare(count_musya, count_kuzya);
                                break;

                            case 2:
                                Console.WriteLine();
                                Funs.MeowsCare(count_musya);
                                break;

                            case 3:
                                Console.WriteLine();
                                Funs.MeowsCare(count_kuzya);
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

                    Fraction f1 = new Fraction(1, 3);
                    Fraction f2 = new Fraction(2, 3);
                    Fraction f3 = new Fraction(1, -5);
                    Fraction f4 = new Fraction(-3, 4);
                    Fraction f5 = new Fraction(7, 2);
                    Fraction f6 = new Fraction(-1, 5);

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
                    Fraction clone = f1 as Fraction;

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