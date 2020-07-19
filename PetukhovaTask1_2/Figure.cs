using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2
{
    ///<summary>
    ///Базовый класс фигура.
    ///</summary>
    public abstract class Figure
    {
        /// <summary>
        /// Название фигуры
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Создать новый экземпляр фигуры
        /// </summary>
        /// <param name="name"></param>
        public Figure (string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Метод для нахождения периметра фигуры
        /// </summary>
        /// <returns>Периметр фигуры</returns>
        public abstract double Perimeter();

        /// <summary>
        /// Метод для нахождения площади фигуры
        /// </summary>
        /// <returns>Площадь фигуры</returns>
        public abstract double Area();
    }
}
