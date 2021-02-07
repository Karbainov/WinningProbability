using System;
using System.Collections.Generic;
using System.Text;

namespace WinningProbability
{
    public class WinningCounter
    {

        public double OneGameWinningProbability { get; set; }
        public int MinimalGamesNumber { get; set; }
        public int PointsDelta { get; set; }
        public double Accuracy { get; set; } = 0.01d;

        public WinningCounter()
        {

        }

        public WinningCounter(double oneGameWinningProbability, int minimalGamesNumber, int pointsDelta)
        {
            if (oneGameWinningProbability > 1 || oneGameWinningProbability < 0 ||
                minimalGamesNumber < pointsDelta ||
                pointsDelta < 0 ||
                minimalGamesNumber <= 0)
            {
                throw new ArgumentException();
            }

            OneGameWinningProbability = oneGameWinningProbability;
            MinimalGamesNumber = minimalGamesNumber;
            PointsDelta = pointsDelta;
        }
        public double CountWinInMinimalGamesNumberProbability()
        {

            double probability = 0;
            double minWinsNumber = (double)(MinimalGamesNumber + PointsDelta) / 2;

            for (int i = MinimalGamesNumber; i >= minWinsNumber; i--)
            {
                probability += Probability.CountBernoulliTrial(OneGameWinningProbability, i, MinimalGamesNumber);
            }

            return probability;
        }
        public double CountGamesOutOfMinimalNumperProbability()
        {
            double probability = 0;

            for (int i = 1; i <= MinimalGamesNumber; i++)
            {
                if (Math.Abs(i - (MinimalGamesNumber - i)) < PointsDelta)
                {
                    probability += Probability.CountBernoulliTrial(OneGameWinningProbability, i, MinimalGamesNumber);
                }
            }

            return probability;
        }

        public double CountWinOutMinimalGamesNumberProbability()
        {
            double probability = 0;
            int i = MinimalGamesNumber + 1;
            double tmp;
            do
            {
                tmp = Probability.CountBernoulliTrial(OneGameWinningProbability, i - PointsDelta, i);
                probability += tmp;
                i++;
            }
            while (tmp > Accuracy);

            return probability;
        }

        public double Solve()
        {
           return CountWinInMinimalGamesNumberProbability()+CountGamesOutOfMinimalNumperProbability()*CountWinOutMinimalGamesNumberProbability();
        }
    }
}
