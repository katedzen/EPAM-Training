using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetukhovaTask1
{
    /// <summary>
    /// Тип, реализующий алгоритм Евклида для вычисления НОД
    /// </summary>
    class NodEvklid
    {
        

        ///<summary>
        ///Метод, реализующий для вычисления НОД
        ///двух целых чисел алгоритм Евклида.
        ///</summary>
        ///<param name="arg1"></param>
        ///<param name="arg2"></param>
        ///<returns>НОД</returns>        
        public static int EvklidAlg(int arg1, int arg2)
        {
            int numb1;
            int numb2;

            if (arg1 >= arg2)
            {
                numb1 = arg1;
                numb2 = arg2;
            }
            else
            {
                numb1 = arg2;
                numb2 = arg1;
            }

            int d = numb1 % numb2;

            do
            {
                if (d == 0)
                    return numb2;
                else
                {
                    numb1 = numb2;
                    numb2 = d;
                    d = numb1 % numb2;
                }
            }
            while (d != 0);

            return numb2;
        }


        /// <summary>
        /// Метод, реализующий для вычисления НОД
        /// двух целых чисел расширенный алгоритм Евклида.
        /// </summary>
        /// <param name="args"></param>
        /// <returns>НОД</returns>
        public static int EvklidAlg(int[] args)
        {
            int i = 1;
            int d = args[0];

            args = SortArgs(args);

            do
            {
                d = EvklidAlg(d, args[i]);
                i++;
            }
            while (i != args.Length);

            return d;
        }

        /// <summary>
        /// Метод, реализующий для вычисления НОД
        /// двух целых чисел бинарный алгоритм Евклида.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <param name="timeAlive"></param>
        /// <returns>НОД, затраченное на расчет время.</returns>
        public static int BinaryEvklidAlg(int arg1, int arg2, out long timeAlive)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            if (arg1 == 0)
            {
                stopwatch.Stop();
                timeAlive = stopwatch.ElapsedTicks;
                return arg2;
            }                

            if (arg2 == 0 || arg1 == arg2)
            {
                stopwatch.Stop();
                timeAlive = stopwatch.ElapsedTicks;
                return arg1;
            }

            if (arg1 == 1 || arg2 == 1)
            {
                stopwatch.Stop();
                timeAlive = stopwatch.ElapsedTicks;
                return 1;
            }

            if (arg1 % 2 == 0 && arg2 % 2 == 0)
                return 2 * BinaryEvklidAlg(arg1 / 2, arg2 / 2, out timeAlive);

            if (arg1 % 2 == 0 && arg2 % 2 != 0)
                return 2 * BinaryEvklidAlg(arg1 / 2, arg2, out timeAlive);

            if (arg1 % 2 != 0 && arg2 % 2 == 0)
                return 2 * BinaryEvklidAlg(arg1, arg2 / 2, out timeAlive);

            if (arg1 % 2 != 0 && arg2 % 2 != 0)
                return 2 * BinaryEvklidAlg(arg1, arg2, out timeAlive);

            if (arg1 < arg2)
                return BinaryEvklidAlg((arg2 - arg1) / 2, arg1, out timeAlive);
            else return BinaryEvklidAlg((arg1 - arg2) / 2, arg2, out timeAlive);

            
        }

        /// <summary>
        /// Метод сортировки входного массива
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Отсортированный по возрастанию массив</returns>
        private static int[] SortArgs(int[] args)
        {
            for (int i = 0; i > args.Length - 1; i++)
            {
                for (int j = i + 1; j < args.Length; j++)
                {
                    if (args[i] < args[j])
                    {
                        int tmp = args[i];
                        args[i] = args[j];
                        args[j] = tmp;
                    }
                }
            }

            return args;
        }
    }   
}
