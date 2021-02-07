using System;
using System.Collections.Generic;
using System.Text;

namespace WinningProbability
{
    public static class Probability
    {
        public static int CountFactorial(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException();
            }

            int f = 1;
            for (int i = 1; i <= number; i++)
            {
                f *= i;
            }
            return f;
        }

        public static int CountCombinations(int k, int n)
        {
            if (k > n || k < 0)
            {
                throw new ArgumentException();
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            int c = 1;
            if (k > n - k)
            {
                for (int i = k + 1; i <= n; i++)
                {
                    c *= i;
                }
                return c / CountFactorial(n-k);
            }
            else
            {
                for (int i = n - k + 1; i <= n; i++)
                {
                    c *= i;
                }

                return c / CountFactorial(k);
            }
        }

        public static double CountBernoulliTrial(double p, int k, int n)
        {
            if (k > n || k < 0 || p < 0 || p > 1)
            {
                throw new ArgumentException();
            }
            return CountCombinations(k, n) * Math.Pow(p, k) * Math.Pow(1 - p, n - k);
        }

       
    }
}
