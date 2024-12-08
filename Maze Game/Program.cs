namespace Maze_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Maze Game");
            Console.WriteLine("Use Keyboard arrows to move the player");
            Maze maze = new Maze(10, 10);
            while (true)
            {
               // maze.DrawMaze();

                maze.DrawMaze2();
                maze.MovePlayer();
            }
        }


    }
}
