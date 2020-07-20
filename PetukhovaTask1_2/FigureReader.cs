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
        static string path;
        string[] linesFromFile = File.ReadLines(path).ToArray();

        public FigureReader(string path)
        {
            foreach (string line in linesFromFile)
            { }
        }
        
    }
}
