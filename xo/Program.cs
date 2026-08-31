using System;

namespace XO
{
    internal static class Program
    {
        private const int BoardSize = 3;
        private const int CellCount = BoardSize * BoardSize;
        private static readonly char[,] Board = new char[BoardSize, BoardSize];

        private static void Main()
        {
            bool playAgain;

            do
            {
                PlayGame();
                playAgain = AskToPlayAgain();
            }
            while (playAgain);

            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        private static void InitializeBoard()
        {
            int cellNumber = 1;

            for (int row = 0; row < BoardSize; row++)
            {
                for (int column = 0; column < BoardSize; column++)
                {
                    Board[row, column] = cellNumber.ToString()[0];
                    cellNumber++;
                }
            }
        }

        private static void DisplayBoard()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int column = 0; column < BoardSize; column++)
                {
                    Console.Write(" " + Board[row, column] + " ");

                    if (column < BoardSize - 1)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (row < BoardSize - 1)
                {
                    Console.WriteLine("---|---|---");
                }
            }
        }

        private static void PlayerMove(char player)
        {
            while (true)
            {
                Console.Write("Player " + player + ", choose a cell (1-9): ");
                string input = Console.ReadLine();
                int cellNumber;

                if (!int.TryParse(input, out cellNumber) || cellNumber < 1 || cellNumber > CellCount)
                {
                    Console.WriteLine("Please enter a number between 1 and 9.");
                    continue;
                }

                int index = cellNumber - 1;
                int row = index / BoardSize;
                int column = index % BoardSize;

                if (!IsCellAvailable(row, column))
                {
                    Console.WriteLine("That cell is already occupied. Choose another one.");
                    continue;
                }

                Board[row, column] = player;
                return;
            }
        }

        private static bool IsCellAvailable(int row, int column)
        {
            return Board[row, column] != 'X' && Board[row, column] != 'O';
        }

        private static bool CheckWin(char player)
        {
            for (int index = 0; index < BoardSize; index++)
            {
                bool rowMatch = Board[index, 0] == player &&
                                Board[index, 1] == player &&
                                Board[index, 2] == player;

                bool columnMatch = Board[0, index] == player &&
                                   Board[1, index] == player &&
                                   Board[2, index] == player;

                if (rowMatch || columnMatch)
                {
                    return true;
                }
            }

            return (Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player) ||
                   (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player);
        }

        private static bool IsDraw()
        {
            for (int row = 0; row < BoardSize; row++)
            {
                for (int column = 0; column < BoardSize; column++)
                {
                    if (IsCellAvailable(row, column))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static void PlayGame()
        {
            InitializeBoard();
            char currentPlayer = 'X';

            while (true)
            {
                Console.Clear();
                DisplayBoard();
                Console.WriteLine();
                PlayerMove(currentPlayer);

                if (CheckWin(currentPlayer))
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("Player " + currentPlayer + " wins!");
                    return;
                }

                if (IsDraw())
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.WriteLine();
                    Console.WriteLine("It is a draw!");
                    return;
                }

                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        private static bool AskToPlayAgain()
        {
            while (true)
            {
                Console.Write("Play again? (y/n): ");
                string input = Console.ReadLine();

                if (string.Equals(input, "y", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(input, "yes", StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }

                if (string.Equals(input, "n", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(input, "no", StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }

                Console.WriteLine("Please enter y or n.");
            }
        }
    }
}
