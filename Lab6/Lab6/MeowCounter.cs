using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowCount
{
    /// <summary>
    /// Подсчет количества мяуканий
    /// </summary>
    public class MeowCounter : Meowable.I_Meowable
    {
        private readonly Meowable.I_Meowable cat;
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
        public MeowCounter(Meowable.I_Meowable cat)
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
}
