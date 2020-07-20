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
        FigureBase[] figures;
        public FigureReader(string path)
        {
            string[] lineArray = (string[])File.ReadLines(path);

            figures = new FigureBase[lineArray.Length];

            foreach (string s in lineArray)
            {
                string[] sFigure = s.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                if (sFigure.Length == 3)
                {
                    sFigure[1].Replace("(", "");


                }
                else if (sFigure.Length == 4)
                { }
                else if (sFigure.Length == 5)
                { }
            }
        }


    }
        
    }
}
