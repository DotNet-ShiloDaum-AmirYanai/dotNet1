using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5780_01A_1037
{
    class Program
    {
        static Random r = new Random(DateTime.Now.Millisecond);
        private static int length = 20;
        static void Main(string[] args)
        {
            Rand_check();
            Console.ReadKey();
        }

        static void Rand_check()
        {
            //two arrays of random numbers
            int[] A = new int[length];
            int[] B = new int[length];
            int[] C = new int[length];
            for (int i = 0; i < 20; ++i)
            {
                //assign random values to A and B 
                //from 18(included) to 122(excluded)
                A[i] = r.Next(18, 122);
                B[i] = r.Next(18, 122);
                C[i] = (A[i] > B[i]) ? A[i] : B[i];
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0,3}", A[i]) + ' ');
            }
            Console.Write("\n");
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0,3}", B[i]) + ' ');
            }
            Console.Write("\n");
            for (int i = 0; i < length; i++)
            {
                Console.Write(string.Format("{0,3}", C[i]) + ' ');
            }
            Console.Write("\n");


        }
    }
}
