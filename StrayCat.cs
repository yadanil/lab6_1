using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stray
{
    /// <summary>
    /// Бродяий кот
    /// </summary>
    public class StrayCat : Meowable.I_Meowable
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
}
