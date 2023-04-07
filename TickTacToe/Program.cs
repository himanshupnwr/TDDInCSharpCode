using System.Reflection;
using System.Text;

namespace TickTacToe
{
    internal class Program
    {
        private static Game game = new();
        static void Main(string[] args)
        {
            Console.WriteLine(GetPrintableState());

            while (game.GetWinner() == Winner.GameIsUnfinished)
            {
                int index = int.Parse(Console.ReadLine());
                game.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result: {game.GetWinner()}");
            Console.ReadLine();
        }

        private static string GetPrintableState()
        {
            var sb = new StringBuilder();

            for (int i = 1; i <= 7; i += 3)
            {
                sb.AppendLine("     |     |     ")
                    .AppendLine(
                        $"  {GetPrintableChar(i)}  |  {GetPrintableChar(i + 1)}  |  {GetPrintableChar(i + 2)}  ")
                    .AppendLine("_____|_____|_____|");
            }

            return sb.ToString();
        }

        private static string GetPrintableChar(int index)
        {
            State state = game.GetState(index);
            if (state == State.Unset)
                return index.ToString();
            return state == State.Cross ? "X" : "O";
        }
    }
}