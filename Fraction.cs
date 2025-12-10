using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frac
{
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
        /// Определяет, равны ли две дроби
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
        /// Определяет, не равны ли две дроби
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
}
