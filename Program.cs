using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe;

namespace _2oct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PrintBoard();
            while (true)
            {
                Console.WriteLine("Enter row and column (0-2) to make a move:"); int row = int.Parse(Console.ReadLine());
                int col = int.Parse(Console.ReadLine());
                game.MakeMove(row, col); game.PrintBoard();
            }
        }
    }
}
namespace TicTacToe
{
    public enum Player { User, Computer }
    public class Game
    {
        private Player _currentPlayer;
        private char[,] _board;
        public Game()
        {
            _board = new char[3, 3];
            InitializeBoard(); _currentPlayer = RandomPlayer();
        }
        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board[i, j] = ' ';
                }
            }
        }
        private Player RandomPlayer()
        {
            return new Random().Next(2) == 0 ? Player.User : Player.Computer;
        }
        public void MakeMove(int row, int col)
        {
            if (_board[row, col] != ' ')
            {
                Console.WriteLine("Invalid move, try again."); return;
            }
            char symbol = _currentPlayer == Player.User ? 'X' : 'O'; _board[row, col] = symbol;
            if (CheckWin(symbol))
            {
                Console.WriteLine($"Player {_currentPlayer} wins!");
                return;
            }
            if (CheckDraw())
            {
                Console.WriteLine("It's a draw!");
                return;
            }
            _currentPlayer = _currentPlayer == Player.User ? Player.Computer : Player.User;
        }
        private bool CheckWin(char symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == symbol && _board[i, 1] == symbol && _board[i, 2] == symbol)
                {
                    return true;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                if (_board[0, i] == symbol && _board[1, i] == symbol && _board[2, i] == symbol)
                {
                    return true;
                }
            }
            if ((_board[0, 0] == symbol && _board[1, 1] == symbol && _board[2, 2] == symbol) ||
                (_board[0, 2] == symbol && _board[1, 1] == symbol && _board[2, 0] == symbol))
            {
                return true;
            }
            return false;
        }
        private bool CheckDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_board[i, j] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public void PrintBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
namespace AzbukaMorse
{
    class Program
    {

        public static Dictionary<string, string> MorseToAbc = new Dictionary<string, string>() {
            { ".-", "A"}, { "-...", "B"},{ "-.-.", "C"},{ "-..", "D"},
            { ".", "E"}, { "..-.", "F"}, { "--.", "G"}, { "....", "H"},
            { "..", "I"}, { ".---", "J"}, { "-.-", "K"}, { ".-..", "L"},
            { "--", "M"}, { "-.", "N"}, { "---", "O"}, { ".--.", "P"},
            { "--.-", "Q"}, { ".-.", "R"}, { "...", "S"}, { "-", "T"},
            { "..-", "U"}, { "...-", "V"}, { ".--", "W"}, { "-..-", "X"},
            { "-.--", "Y"},{ "--..", "Z"},
        };
        public static Dictionary<string, string> AbsToMorse = MorseToAbc.ToDictionary(k => k.Value, v => v.Key);


        static void Main()
        {
            string hello = "helloworld";

            string morse = ToMorse(hello);
            Console.WriteLine(morse);

            Console.WriteLine(FromMorse(morse));
        }

        static string ToMorse(string input)
        {
            input = input.ToUpper();

            string[] encoded = new string[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                encoded[i] = AbsToMorse[input[i].ToString()];
            }

            return string.Join(" ", encoded);
        }

        static string FromMorse(string input)
        {
            string[] morse = input.Split();
            string[] decoded = new string[morse.Length];

            for (int i = 0; i < morse.Length; i++)
            {
                decoded[i] = MorseToAbc[morse[i]];
            }

            return string.Concat(decoded);
        }
    }
}
