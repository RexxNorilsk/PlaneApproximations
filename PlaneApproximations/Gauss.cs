using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneApproximations
{
    static class Gauss
    {
        public static double[] Solve(double[,] a, double[] b)
        {
            double s = 0;
            int n = b.GetLength(0); ; 
            double[] x = new double[n];

            for (int k = 0; k < n - 1; k++)
            {
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        a[i, j] = a[i, j] - a[k, j] * (a[i, k] / a[k, k]);
                    }
                    b[i] = b[i] - b[k] * a[i, k] / a[k, k];
                }
            }
            for (int k = n - 1; k >= 0; k--)
            {
                s = 0;
                for (int j = k + 1; j < n; j++)
                    s = s + a[k, j] * x[j];
                x[k] = (b[k] - s) / a[k, k];
            }
            return x;
        }
    }
}
