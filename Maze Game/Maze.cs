using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Maze_Game
{
    internal class Maze
    {
        private int _Width;
        private int _Height;
        private Player _Player;
        private IMazeObject[,] _MazeObjectArray;
        public Maze(int width, int height)
        {
            _Height = height;
            _Width = width;
            _MazeObjectArray = new IMazeObject[width, height];
            _Player = new Player()
            {
                X = 0,
                Y = 1
            };
        }

        public void DrawMaze()
        {
            Console.Clear();

            for (int y = 0; y < _Height; y++)
            {
                for (int x = 0; x < _Width; x++)
                {
                    // Outer Walls
                    if (x == 0 || y == 0 || x == _Width - 1 || y == _Height - 1)
                    {
                        _MazeObjectArray[x, y] = new Wall();
                        Console.Write(_MazeObjectArray[x, y].Icon);
                    }
                    else if(x == _Player.X && y == _Player.Y)
                    {
                        Console.Write(_Player.Icon);
                    }
                    else // Empty Spaces
                    {
                        _MazeObjectArray[x, y] = new EmptySpace();
                        Console.Write(_MazeObjectArray[x, y].Icon);
                    }
                }
                Console.WriteLine();
            }
        }
        public void DrawMaze2()
        {
            Console.Clear();
            int[,] maze = {{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 0, 0, 1, 0, 0, 0, 0, 1, 1, 1 },
            { 1, 0, 1, 0, 1, 1, 0, 0, 0, 1 },
            { 1, 0, 0, 0, 1, 1, 1, 1, 0, 1 },
            { 1, 1, 1, 0, 0, 0, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 0, 1, 0, 0 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 } };

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    // Outer Walls
                    if (maze[y,x] == 1)
                    {
                        _MazeObjectArray[x, y] = new Wall();
                        Console.Write(_MazeObjectArray[x, y].Icon);
                    }
                    else if (x == _Player.X && y == _Player.Y)
                    {
                        Console.Write(_Player.Icon);
                    }
                    else // Empty Spaces
                    {
                        _MazeObjectArray[x, y] = new EmptySpace();
                        Console.Write(_MazeObjectArray[x, y].Icon);
                    }
                }
                Console.WriteLine();
            }
        }
        public void MovePlayer()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();
            ConsoleKey key = userInput.Key;
            switch (key) { 
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, +1);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1, 0);
                    break;
            }
        }
        public void UpdatePlayer( int dx, int dy)
        {
            int newX = _Player.X + dx;
            int newY = _Player.Y + dy;

            if (_Player.X == 9 && _Player.Y == 7)
            {
                Console.WriteLine("Very Good :), You Are Win");
                Console.WriteLine("You Want to Play Again Y or N");
                string userInput = Console.ReadLine().Trim().ToUpper();
                if(userInput == "Y")
                {
                    _Player.X = 0;
                    _Player.Y = 1;
                    DrawMaze2();
                }
                else
                {
                    Environment.Exit(0);
                }

            }
            else if (newX < _Width && newX >= 0 && newY < _Height && newY >=0 && _MazeObjectArray[newX,newY].IsSolid == false)
            {
                _Player.X = newX;
                _Player.Y = newY;
                DrawMaze2();
            } if (_Player.X == 9 && _Player.Y == 7)
            {
                Console.WriteLine("Very Good :), You Are Win");
               

            }
        }
    }
}
