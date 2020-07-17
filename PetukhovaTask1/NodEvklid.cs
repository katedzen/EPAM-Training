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
    /// Тип, содержащий несколько вариаций алгоритма Евклида для вычисления НОД
    /// </summary>
    public class NodEvklid
    {
        ///<summary>
        ///Метод, реализующий для вычисления НОД
        ///двух целых чисел алгоритм Евклида.
        ///</summary>
        ///<param name="arg1"></param>
        ///<param name="arg2"></param>
        /// <param name="timeSimpleEvklidAlive"></param>
        ///<returns>НОД, затраченное на расчет время.</returns>        
        public static int EvklidAlg(int arg1, int arg2, out long timeSimpleEvklidAlive)
        {
            CheckParameters(arg1, arg2);

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            while (arg1 != arg2)
            {
                if (arg1 > arg2)
                {
                    int tmp = arg1;
                    arg1 = arg2;
                    arg2 = tmp;
                }

                arg2 -= arg1;                
            }

            stopwatch.Stop();

            timeSimpleEvklidAlive = stopwatch.ElapsedTicks;

            return arg1;
        }


        /// <summary>
        /// Метод, реализующий для вычисления НОД
        /// двух целых чисел расширенный алгоритм Евклида.
        /// </summary>
        /// <param name="args"></param>
        /// <param name="timeManyArgsEvklidAlive"></param>
        /// <returns>НОД, затраченное на расчет время.</returns>
        public static int EvklidAlg(int[] args)
        {
            CheckParameters(args);

            int i = 1;
            int d = args[0];

            args = SortArgs(args);

            do
            {
                d = EvklidAlg(d, args[i],out long timeForArgsEvklidAlive);
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
        /// <param name="timeBinaryEvklidAlive"></param>
        /// <returns>НОД, затраченное на расчет время.</returns>
        public static int BinaryEvklidAlg(int arg1, int arg2, out long timeBinaryEvklidAlive)
        {
            CheckParameters(arg1, arg2);

            int result = 1;
            int tmp;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            if (arg1 == 0)
            {
                stopwatch.Stop();
                timeBinaryEvklidAlive = stopwatch.ElapsedTicks;
                return arg2;
            }                

            if (arg2 == 0 || arg1 == arg2)
            {
                stopwatch.Stop();
                timeBinaryEvklidAlive = stopwatch.ElapsedTicks;
                return arg1;
            }

            if (arg1 == 1 || arg2 == 1)
            {
                stopwatch.Stop();
                timeBinaryEvklidAlive = stopwatch.ElapsedTicks;
                return 1;
            }

            while (arg1 != 0 || arg2 != 0)
            {
                if (arg1 % 2 == 0 && arg2 % 2 == 0)
                {
                    result *= 2;
                    arg1 /= 2;
                    arg2 /= 2;
                    continue;
                }
                if (arg1 % 2 == 0 && arg2 % 2 != 0)
                {
                    arg1 /= 2;
                    continue;
                }
                if (arg1 % 2 != 0 && arg2 % 2 == 0)
                {
                    arg2 /= 2;
                    continue;
                }
                if (arg1 > arg2)
                {
                    tmp = arg1;
                    arg1 = arg2;
                    arg2 = tmp;
                }
                tmp = arg1;
                arg1 = (arg2 - arg1) / 2;
                arg2 = tmp;                                               
            }

            if (arg1 == 0)
            {
                stopwatch.Stop();
                timeBinaryEvklidAlive = stopwatch.ElapsedTicks;
                return result * arg2;
            }
            else
            {
                stopwatch.Stop();
                timeBinaryEvklidAlive = stopwatch.ElapsedTicks;
                return result * arg1;
            }
        }


        /// <summary>
        /// Метод принимает два аргумента
        /// для сравнения времени нахождения их НОД 
        /// двумя доступными способами.
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns>Время выполнения алгоритмов в порядке убывания</returns>
        public static List<long> CompareAlgorithmTime(int arg1, int arg2)
        {
            EvklidAlg(arg1, arg2, out long timeEvklid);

            BinaryEvklidAlg(arg1, arg2, out long timeBinaryEvklid);

            if (timeEvklid >= timeBinaryEvklid)
                return new List<long>() { timeEvklid, timeBinaryEvklid };
            else
                return new List<long>() { timeBinaryEvklid, timeEvklid };
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


        /// <summary>
        /// Метод проверяет аргументы,
        /// в случае, если один из них равен 0,
        /// создаёт исключение
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        private static void CheckParameters( int arg1, int arg2)
        {
            if (arg1 == 0 || arg2 ==0)
                throw new ArgumentException();
        }


        /// <summary>
        /// Метод проверяет массив,
        /// в случае, если один из аргументов в массиве равен 0,
        /// создаёт исключение
        /// </summary>
        /// <param name="args"></param>
        private static void CheckParameters(int[] args)
        {
            foreach (int arg in args)
                if (arg == 0)
                    throw new ArgumentException();
        }
    }   
}
