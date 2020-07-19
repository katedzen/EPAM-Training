using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2
{
    /// <summary>
    /// Тип четырёхугольник.
    /// </summary>
    class Quadrangle : Figure
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }
        public double Side4 { get; set; }

        /// <summary>
        /// Создание четырёхугольника по длинам сторон.
        /// </summary>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        /// <param name="s4"></param>
        public Quadrangle (string name, double s1, double s2, double s3, double s4) : base(name)
        {
            Side1 = s1;
            Side2 = s2;
            Side3 = s3;
            Side4 = s4;
        }

        /// <summary>
        /// Создание четырёхугольника по координатам вершин.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        /// <param name="x4"></param>
        /// <param name="y4"></param>
        public Quadrangle (string name,
                           double x1, double y1,
                           double x2, double y2,
                           double x3, double y3,
                           double x4, double y4) : base(name)
        {
            Side1 = GetDistance(x1, y1, x2, y2);
            Side2 = GetDistance(x3, y3, x2, y2);
            Side3 = GetDistance(x3, y3, x4, y4);
            Side4 = GetDistance(x4, y4, x1, y1);
        }

        /// <summary>
        /// Расчет периметра четырёхугольника.
        /// </summary>
        /// <returns>Периметр четырёхугольника.</returns>
        public override double Perimeter()
        {
            return Side1 + Side2 + Side3+ Side4;
        }

        /// <summary>
        /// Расчет площади четырёхугольника.
        /// </summary>
        /// <returns>Площадь четырёхугольника.</returns>
        public override double Area()
        {
            double p = this.Perimeter() / 2;

            return Math.Sqrt((p - Side1) * (p - Side2) * (p - Side3) * (p - Side4));
        }

        /// <summary>
        /// Получает строковое представление четырёхугольника.
        /// </summary>
        /// <returns>Строковое представление четырёхугольника.</returns>
        public override string ToString()
        {
            return $"{this.Name} - ({this.Side1}, {this.Side2}, {this.Side3}, {this.Side4})";
        }

        /// <summary>
        /// Если передаваемый объект типа Четырёхугольник,
        /// то сравниваются их стороны. В случае, если они равны, то равны и фигуры.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Если четырёхугольники равны - true,
        /// во всех остальных случаях - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Quadrangle quadrangle2)
            {
                if (this.Side1 == quadrangle2.Side1
                    && this.Side2 == quadrangle2.Side2
                    && this.Side3 == quadrangle2.Side3
                    && this.Side3 == quadrangle2.Side4)
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
