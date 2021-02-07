using System;

namespace WinningProbability
{
    class Program
    {
        static void Main(string[] args)
        {
            //Пользователь вводит вероятность получения первым (из двух) игроком одного очка, минимальное колличество партий и необходимую для победы разницу в очках
            //Определить веротность первого игрока

            Console.Write("One game winning probability - ");
            double oneGameWinningProbability = Convert.ToDouble(Console.ReadLine());

            Console.Write("Minimal games number - ");
            int minimalGamesNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Points delta - ");
            int pointsDelta = Convert.ToInt32(Console.ReadLine());

            WinningCounter winningCounter = new WinningCounter(oneGameWinningProbability, minimalGamesNumber, pointsDelta);

            Console.WriteLine($"Winning probability = {winningCounter.Solve()}");
        }
    }
}
