using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    class Program
    {
        //static random numbers generator
        static readonly Random r = new Random(DateTime.Now.Millisecond);
        //length of array to print
        private static readonly int length = 20;
        
        //purpose of main: generate two lists of random numbers
        //than choose the bigger number in each index and enter to a new list
        static void Main(string[] args)
        {
            Rand_check();
            //don't close console immidiately
            Console.ReadKey();
        }

        //generate two random lists and a list that 
        //contains the bigger element of the two lists
        static void Rand_check()
        {
            //two arrays of random numbers
            int[] A = new int[length];
            int[] B = new int[length];

            //third array to enter the bigger number in each index
            int[] C = new int[length];
            //loop to enter a number 'length' times
            for (int i = 0; i < length; ++i)
            {
                //assign random values to A and B 
                //from 18(included) to 122(excluded)
                A[i] = r.Next(18, 122);
                B[i] = r.Next(18, 122);

                //pick the bigger one of A[i] or B[i]
                C[i] = Math.Max(A[i], B[i]);
            }
            Print_lists(A, B, C);

        }

        //print all lists in desired format
        private static void Print_lists(int[] A, int[] B, int[] C)
        {
            //print A
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0,3}", A[i]) + ' ');
            }
            Console.Write("\n");

            //print B
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0,3}", B[i]) + ' ');
            }
            Console.Write("\n");

            //print C
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0,3}", C[i]) + ' ');
            }
            Console.Write("\n");
        }
    }
}
