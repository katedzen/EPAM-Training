﻿using System;
using System.Collections.Generic;
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
        ///Метод вычисления НОД двух целых чисел
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
        /// Метод вычесления НОД массива целых чисел
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
