using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2
{
    /// <summary>
    /// Тип треугольник.
    /// </summary>
    public class Triangle : FigureBase
    {
        public double Side1 { get; set; }
        public double Side2 { get; set; }
        public double Side3 { get; set; }

        /// <summary>
        /// Создание треугольника по длинам трёх сторон.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <param name="s3"></param>
        public Triangle (string name,double s1, double s2, double s3) : base (name)
        {
            Side1 = s1;
            Side2 = s2;
            Side3 = s3;
        }

        /// <summary>
        /// Создание треугольника по координатам вершин.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="x3"></param>
        /// <param name="y3"></param>
        public Triangle (string name,
                        double x1, double y1,
                        double x2, double y2,
                        double x3, double y3) : base(name)
        {
            Side1 = GetDistance(x1, y1, x2, y2);
            Side2 = GetDistance(x3, y3, x2, y2);
            Side3 = GetDistance(x3, y3, x1, y1);
        }

        /// <summary>
        /// Расчет периметра треугольника.
        /// </summary>
        /// <returns>Периметр треугольника.</returns>
        public override double Perimeter()
        {
            return Side1 + Side2 + Side3;
        }

        /// <summary>
        /// Расчет площади треугольника.
        /// </summary>
        /// <returns>Площадь треугольника.</returns>
        public override double Area()
        {
            double p = this.Perimeter() / 2;

            return Math.Sqrt(p * (p - Side1) * (p - Side2) * (p - Side3));
        }

        /// <summary>
        /// Получает строковое представление треугольника.
        /// </summary>
        /// <returns>Строковое представление треугольника.</returns>
        public override string ToString()
        {
            return $"{this.Name} - ({this.Side1}, {this.Side2}, {this.Side3})";
        }

        /// <summary>
        /// Если передаваемый объект типа Треугольник,
        /// то сравниваются их стороны. В случае, если они равны, то равны и треугольники.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Если треугольники равны - true,
        /// во всех остальных случаях - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Triangle triangle2)
            {
                if (this.Side1 == triangle2.Side1
                    && this.Side2 == triangle2.Side2
                    && this.Side3 == triangle2.Side3)
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
