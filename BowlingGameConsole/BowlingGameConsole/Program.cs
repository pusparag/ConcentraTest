using System;

namespace BowlingGameConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var bowling = new Game();
                bowling.Roll(1);
                bowling.Roll(4);
                bowling.Roll(4);
                bowling.Roll(5);
                bowling.Roll(6);
                bowling.Roll(4);
                bowling.Roll(5);
                bowling.Roll(5);
                bowling.Roll(10);
                bowling.Roll(0);
                bowling.Roll(1);
                bowling.Roll(7);
                bowling.Roll(3);
                bowling.Roll(6);
                bowling.Roll(4);
                bowling.Roll(10);
                bowling.Roll(2);
                bowling.Roll(8);
                bowling.Roll(6);
                bowling.PrintScoreBoard();

                Console.WriteLine($"Total Score:  {bowling.Score()}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}
