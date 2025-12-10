using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCat
{
    /// <summary>
    /// Домашний кот
    /// </summary>
    public class Cat : Meowable.I_Meowable
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
}
