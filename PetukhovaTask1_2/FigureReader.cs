using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1_2
{
    public class FigureReader
    {
        public FigureBase[] figures;
        /// <summary>
        /// Конструктор класса. Принимает путь к текстовому файлу,
        /// обрабатывает данные и заполняет массив типа FigureBase. 
        /// </summary>
        /// <param name="path">Путь к тхт файлу.</param>
        public FigureReader(string path)
        {
            var textLines = File.ReadLines(path);
            string[] lineArray = new string[textLines.Count()];

            int i = 0;
            foreach (var line in textLines) 
            {
                lineArray[i] = line;
                i++;
            }
                
            figures = new FigureBase[lineArray.Length];

            for (i = 0; i < lineArray.Length; i++)
            {
                string[] sFigure = lineArray[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (sFigure.Length == 3)
                {
                    string name = sFigure[0];

                    sFigure[1].Trim(new char[] { '(', ')' });
                    string[] point = sFigure[1].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    if(Double.TryParse(point[0], out double x1) && Double.TryParse(point[1], out double y1))
                        if (sFigure[2].Contains("("))
                        {
                            sFigure[2].Trim(new char[] { '(', ')' });
                            point = sFigure[2].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (Double.TryParse(point[0], out double x2) && Double.TryParse(point[1], out double y2))
                                figures[i] = (FigureBase)new Circle(name, x1, y1, x2, y2);
                        }
                    else if (Double.TryParse(sFigure[2], out double r))
                            figures[i] = (FigureBase)new Circle(name, x1, y1, r);
                }
                else if (sFigure.Length == 4)
                {
                    string name = sFigure[0];

                    if (sFigure[1].Contains("("))
                    {
                        double[] x = new double[3];
                        double[] y = new double[3];

                        for (i = 1, j = i - 1; i < sFigure.Length; i++)
                        {                            
                            sFigure[i].Trim(new char[] { '(', ')' });
                            string[] point = sFigure[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (Double.TryParse(point[0], out x[i - 1]) && Double.TryParse(point[1], out y[i - 1]))
                                continue;
                        }

                        figures[i] = (FigureBase)new Triangle(name, x[0], y[0], x[1], y[1], x[2], y[2]);
                    }
                    else if (Double.TryParse(sFigure[1], out double side1) && Double.TryParse(sFigure[2], out double side2) && Double.TryParse(sFigure[3], out double side3))
                        figures[i] = (FigureBase)new Triangle(name, side1, side2, side3);
                }
                else if (sFigure.Length == 5)
                {
                    string name = sFigure[0];
                    int j = 0;

                    if (sFigure[1].Contains("("))
                    {
                        double[] x = new double[4];
                        double[] y = new double[4];

                        for (i = 1, j = i - 1; i < sFigure.Length; i++)
                        {
                            sFigure[i].Trim(new char[] { '(', ')' });
                            string[] point = sFigure[i].Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                            if (Double.TryParse(point[0], out x[i - 1]) && Double.TryParse(point[1], out y[i - 1]))
                                continue;
                        }

                        figures[i] = (FigureBase)new Quadrangle(name, points[0], points[1], points[2], points[3], points[4], points[5], points[6], points[7]);
                    }
                    else if (Double.TryParse(sFigure[1], out double side1) && Double.TryParse(sFigure[2], out double side2)
                        && Double.TryParse(sFigure[3], out double side3) && Double.TryParse(sFigure[5], out double side4))
                            figures[i] = (FigureBase)new Quadrangle(name, side1, side2, side3, side4);
                }
            }
        }

        /// <summary>
        /// Метод поиска в массиве фигур, равных данной.
        /// </summary>
        /// <returns>Список фигур, равных данной.</returns>
        public List<FigureBase> FindEqualsFigures()
        {
            List<FigureBase> equalsFigures = new List<FigureBase>();

            foreach (FigureBase figure in figures)
                if (this.Equals(figure))
                    equalsFigures.Add(figure);

            return equalsFigures;
        }




    }
        
}

