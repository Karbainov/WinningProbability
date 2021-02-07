using NUnit.Framework;
using System;

namespace WinningProbability.Tests
{
    public class ProbabilityTests
    {

        #region CountFactorial Tests
        [TestCase(1, ExpectedResult = 1)]
        [TestCase(2, ExpectedResult = 2)]
        [TestCase(3, ExpectedResult = 6)]
        [TestCase(4, ExpectedResult = 24)]
        [TestCase(5, ExpectedResult = 120)]
        public int CountFactorialTest(int number)
        {
            return Probability.CountFactorial(number);
        }

        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(-1000)]
        public void CountFactorialNegativeTest(int number)
        {
            Assert.Throws<ArgumentException>(() => Probability.CountFactorial(number));
        }
        #endregion

        #region CountCombinations Tests
        [TestCase(1,1, ExpectedResult = 1)]
        [TestCase(0,5, ExpectedResult = 1)]
        [TestCase(2,5, ExpectedResult = 10)]
        [TestCase(5,10, ExpectedResult = 252)]
        [TestCase(3,11, ExpectedResult = 165)]
        public int CountCombinationsTest(int k, int n)
        {
            return Probability.CountCombinations(k, n);
        }

        [TestCase(-5,10)]
        [TestCase(10,9)]
        [TestCase(-5,-3)]
        public void CountCombinationsNegativeTest(int k, int n)
        {
            Assert.Throws<ArgumentException>(() => Probability.CountCombinations(k, n));
        }
        #endregion

        #region CountBernoulliTrial Tests
        [TestCase(0.2d, 2, 10, 0.302d)]
        [TestCase(0.5d, 5, 20, 0.0147d)]
        [TestCase(0.6d, 9, 10, 0.0403d)]
        [TestCase(0d, 6, 12, 0d)]
        [TestCase(1d, 6, 12, 0d)]
        [TestCase(1d, 12, 12, 1d)]
        public void CountBernoulliTrialTest(double p, int k, int n, double expected)
        {
            double actual= Probability.CountBernoulliTrial(p, k, n);

            Assert.AreEqual(expected, actual, 0.001d);
        }

        [TestCase(0.1d,-5, 10)]
        [TestCase(0.1d, 10, 9)]
        [TestCase(0.1d, -5, -3)]
        [TestCase(-0.1d, 1, 5)]
        [TestCase(1.1d, 1, 5)]
        public void CountBernoulliTrialNegativeTest(double p, int k, int n)
        {
            Assert.Throws<ArgumentException>(() => Probability.CountBernoulliTrial(p, k, n));
        }
        #endregion
    }
}