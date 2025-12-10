using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun
{
    /// <summary>
    /// Класс для мяукания нексольких котов за раз
    /// </summary>
    public class Funs
    {
        /// <summary>
        /// Заставляет всех котов мяукнуть
        /// </summary>
        /// <param name="meowableObjects">Коллекция объектов, реализующих I_Meowable</param>
        public static void MeowsCare(IEnumerable<Meowable.I_Meowable> meowableObjects)
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
        public static void MeowsCare(params Meowable.I_Meowable[] meowableObjects)
        {
            MeowsCare((IEnumerable<Meowable.I_Meowable>)meowableObjects);
        }
    }
}
