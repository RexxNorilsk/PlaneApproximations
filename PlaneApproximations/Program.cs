using System;
using System.IO;

namespace PlaneApproximations
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(@"input.txt"))
            {
                string[] lines = File.ReadAllLines(@"input.txt");
                double[,] arr = new double[lines.Length, lines[0].Split(' ').Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] temp = lines[i].Split(' ');
                    for (int j = 0; j < temp.Length; j++)
                        arr[i, j] = Convert.ToDouble(temp[j]);
                }

                double[] result = Calculate(arr);
                Console.WriteLine("Результат: ");
                for (int i = 0; i < result.Length; i++)
                {
                    Console.WriteLine(result[i]);
                }
            }
            else {
                Console.WriteLine("Файл input.txt не обнаружен!");
            }
        }

        static double[] Calculate(double[,] arr)
        {
            int xm = arr.GetLength(0);
            int ym = arr.GetLength(1);

            double[,] a = new double[3,3];
            double[] b = new double[3];

            //a1
            for (int i = 0; i < xm; i++)
                a[0, 0] += arr[i,0]* arr[i, 0];
            //a2
            for (int i = 0; i < xm; i++)
                a[1, 0] += arr[i, 0]*arr[i, 1];
            //b1
            a[0, 1] = a[1, 0];
            //a3
            for (int i = 0; i < xm; i++)
                a[2, 0] += arr[i, 0];
            //c1
            a[0, 2] = a[2, 0];
            //b2
            for (int i = 0; i < xm; i++)
                a[1, 1] += arr[i, 1]* arr[i, 1];
            //b3
            for (int i = 0; i < xm; i++)
                a[2, 1] += arr[i, 1];
            //c2
            a[1, 2] = a[2, 1];
            //c3
            a[2, 2] = xm;
            
            //d1
            for (int i = 0; i < xm; i++)
                b[0] += arr[i, 0]* arr[i, 2];
            for (int i = 0; i < xm; i++)
                b[1] += arr[i, 1]* arr[i, 2];
            for (int i = 0; i < xm; i++)
                b[2] += arr[i, 2];
            Console.WriteLine("Сформированная СЛАУ: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(j==0 ? "" + a[i, j] : " "+a[i,j]);
                }
                Console.WriteLine(" "+b[i]);
            }


            return Gauss.Solve(a, b);
        }
    }
}
