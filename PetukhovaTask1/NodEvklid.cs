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
    public class NodEvklid
    {
        ///<summary>
        ///Метод, реализующий для вычисления НОД
        ///двух целых чисел алгоритм Евклида.
        ///</summary>
        ///<param name="arg1"></param>
        ///<param name="arg2"></param>
        /// <param name="timeSimpleEvklidAlive"></param>
        ///<returns>НОД двух целых чисел, затраченное на расчет время.</returns>        
        public static int EvklidAlg(int arg1, int arg2, out long timeSimpleEvklidAlive)
        {
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

        ///<summary>
        ///Метод, реализующий для вычисления НОД
        ///трёх целых чисел алгоритм Евклида.
        ///</summary>
        ///<param name="arg1"></param>
        ///<param name="arg2"></param>
        ///<param name="arg3"></param>
        ///<returns>НОД трёх целых чисел.</returns>  
        public static int EvklidAlg(int arg1, int arg2, int arg3)
        {
            return EvklidAlg(EvklidAlg(arg1, arg2, out long timeAlive), arg3, out timeAlive);                
        }

        ///<summary>
        ///Метод, реализующий для вычисления НОД
        ///четырёх целых чисел алгоритм Евклида.
        ///</summary>
        ///<param name="arg1"></param>
        ///<param name="arg2"></param>
        ///<param name="arg3"></param>
        ///<param name="arg4"></param>
        ///<returns>НОД четырёх целых чисел.</returns> 
        public static int EvklidAlg(int arg1, int arg2, int arg3, int arg4)
        {
            return EvklidAlg(EvklidAlg(arg1, arg2, arg3), arg4, out long timeAlive);
        }

        ///<summary>
        ///Метод, реализующий для вычисления НОД
        ///пяти целых чисел алгоритм Евклида.
        ///</summary>
        ///<param name="arg1"></param>
        ///<param name="arg2"></param>
        ///<param name="arg3"></param>
        ///<param name="arg4"></param>
        ///<param name="arg5"></param>
        ///<returns>НОД пяти целых чисел.</returns>
        public static int EvklidAlg(int arg1, int arg2, int arg3, int arg4, int arg5)
        {
            return EvklidAlg(EvklidAlg(arg1, arg2, arg3, arg4), arg5, out long timeAlive);
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
        public static long[] CompareAlgorithmTime(int arg1, int arg2)
        {
            EvklidAlg(arg1, arg2, out long timeEvklid);

            BinaryEvklidAlg(arg1, arg2, out long timeBinaryEvklid);

            if (timeEvklid >= timeBinaryEvklid)
                return new long[] { timeEvklid, timeBinaryEvklid };
            else
                return new long[] { timeBinaryEvklid, timeEvklid };
        }        
    }   
}
