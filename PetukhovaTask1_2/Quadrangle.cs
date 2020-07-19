using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2
{
    /// <summary>
    /// Тип четырёхугольник
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
    }
}
