using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2
{
    /// <summary>
    /// Тип окружность.
    /// </summary>
    class Circle : FigureBase
    {
        public double CentrX { get; set; }
        public double CentrY { get; set; }
        public double Radius { get; set; }

        /// <summary>
        /// Создание окружности по координатам центра и радиусу.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="r"></param>
        public Circle(string name, double x1, double y1, double r) : base(name) 
        {
            CentrX = x1;
            CentrY = y1;
            Radius = r;
        }

        /// <summary>
        /// Создание окружности по координатам центра и координатам точки на окружности.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        public Circle (string name, double x1, double y1, double x2, double y2) : base(name) 
        {
            CentrX = x1;
            CentrY = x2;
            Radius = GetDistance(x1, y1, x2, y2);
        }

        /// <summary>
        /// Расчет длины окружности.
        /// </summary>
        /// <returns>Длина окружности.</returns>
        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }

        /// <summary>
        /// Расчет площади окружности.
        /// </summary>
        /// <returns>Площадь окружности.</returns>
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        /// <summary>
        /// Получает строковое представление окружности.
        /// </summary>
        /// <returns>Строковое представление окружности.</returns>
        public override string ToString()
        {
            return $"{this.Name} - (O({this.CentrX}, {this.CentrY}), {this.Radius})";
        }

        /// <summary>
        /// Если передаваемый объект типа Окружность,
        /// то сравниваются их радиусы. В случае, если они равны, то равны и фигуры.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Если окружности равны - true,
        /// во всех остальных случаях - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Circle circle2)
            {
                if (this.Radius == circle2.Radius)
                    return true;
            }
            else return false;

            return false;
        }

        /// <summary>
        /// Возвращает некоторое числовое значение,
        /// соответствующее площади данного объекта.
        /// </summary>
        /// <returns>Хэш-код для значения площади фигуры.</returns>
        public override int GetHashCode()
        {
            return this.Area().GetHashCode();
        }
    }
}
