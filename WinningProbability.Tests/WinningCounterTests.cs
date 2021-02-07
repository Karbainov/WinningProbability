using NUnit.Framework;
using System;
using System.Collections;

namespace WinningProbability.Tests
{
    public class WinningCounterTests
    {
        double accuracy = 0.01d;

        [TestCase(1.1d, 10, 1)]
        [TestCase(-0.1d, 10, 1)]
        [TestCase(1d, 0, 1)]
        [TestCase(1d, -10, 1)]
        [TestCase(1d, 10, 15)]
        [TestCase(1d, 5, -11)]
        public void ConstructorNegativeTest(double oneGameWinningProbability, int minimalGamesNumber, int pointsDelta)
        {
            Assert.Throws<ArgumentException>(() => new WinningCounter(oneGameWinningProbability, minimalGamesNumber, pointsDelta));
        }

        [TestCaseSource(typeof(CountWinInMinimalGamesNumberProbabilitySourse))]
        public void CountWinInMinimalGamesNumberProbabilityTest(WinningCounter winningCounter, double expected)
        {
            double actual = winningCounter.CountWinInMinimalGamesNumberProbability();

            Assert.AreEqual(expected, actual, accuracy);
        }

        [TestCaseSource(typeof(CountGamesOutOfMinimalNumperProbabilitySourse))]
        public void CountGamesOutOfMinimalNumperProbabilityTest(WinningCounter winningCounter, double expected)
        {
            double actual = winningCounter.CountGamesOutOfMinimalNumperProbability();

            Assert.AreEqual(expected, actual, accuracy);
        }

        [TestCaseSource(typeof(CountWinOutMinimalGamesNumberProbabilitySourse))]
        public void CountWinOutMinimalGamesNumberProbabilityTest(WinningCounter winningCounter, double expected)
        {
            double actual = winningCounter.CountWinOutMinimalGamesNumberProbability();

            Assert.AreEqual(expected, actual, accuracy);
        }

        [TestCaseSource(typeof(SolveSourse))]
        public void SolveTest(WinningCounter winningCounter, double expected)
        {
            double actual = winningCounter.Solve();

            Assert.AreEqual(expected, actual, accuracy);
        }

    }

    public class CountWinInMinimalGamesNumberProbabilitySourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new WinningCounter(0.5, 11, 1), 0.5d };
            yield return new object[] { new WinningCounter(0.5, 8, 2), 0.36d };
            yield return new object[] { new WinningCounter(0.5, 8, 3), 0.14d };
            yield return new object[] { new WinningCounter(0.4, 5, 1), 0.31d };
            yield return new object[] { new WinningCounter(0.6, 5, 1), 0.68d };
        }
    }

    public class CountGamesOutOfMinimalNumperProbabilitySourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new WinningCounter(0.5, 11, 1), 0.0d };
            yield return new object[] { new WinningCounter(0.5, 8, 2), 0.27d };
            yield return new object[] { new WinningCounter(0.5, 8, 3), 0.71d };
            yield return new object[] { new WinningCounter(0.4, 5, 1), 0.0d };
            yield return new object[] { new WinningCounter(0.6, 5, 1), 0.0d };
        }
    }

    public class CountWinOutMinimalGamesNumberProbabilitySourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new WinningCounter(0.5, 11, 1), 0.0d };
            yield return new object[] { new WinningCounter(0.5, 8, 2), 0.16d };
            yield return new object[] { new WinningCounter(0.5, 8, 3), 0.49d };
            yield return new object[] { new WinningCounter(0.4, 5, 1), 0.06d };
            yield return new object[] { new WinningCounter(0.6, 5, 1), 0.57d };
        }
    }

    public class SolveSourse : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new object[] { new WinningCounter(0.5, 11, 1), 0.50d };
            yield return new object[] { new WinningCounter(0.5, 8, 2), 0.40d };
            yield return new object[] { new WinningCounter(0.5, 8, 3), 0.49d };
            yield return new object[] { new WinningCounter(0.4, 5, 1), 0.31d };
            yield return new object[] { new WinningCounter(0.6, 5, 1), 0.68d };
        }
    }
}
