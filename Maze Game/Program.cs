using System;

namespace Maze_Game 
{
    class Program
    {
        static void Main()
        {
            char[,] maze =
            {
                {'#','#','#','#','#','#','#','#','#','#','#'},
                {'#','P',' ',' ','#',' ',' ',' ',' ',' ','#'},
                {'#',' ','#',' ','#',' ','#','#','#',' ','#'},
                {'#',' ','#',' ',' ',' ',' ',' ','#',' ','#'},
                {'#',' ','#','#','#','#','#',' ','#',' ','#'},
                {'#',' ',' ',' ',' ',' ','#',' ',' ',' ','#'},
                {'#','#','#','#','#',' ','#','#','#',' ','#'},
                {'#',' ',' ',' ',' ',' ',' ',' ','#',' ','#'},
                {'#',' ','#','#','#','#','#',' ','#','E','#'},
                {'#','#','#','#','#','#','#','#','#','#','#'}
            };

            int playerX = 1;
            int playerY = 1;

            int moves = 0;
            bool gameOver = false;

            Console.CursorVisible = false;

            while (!gameOver)
            {
                Console.Clear();

                // Display maze
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        Console.Write(maze[i, j]);
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
                Console.WriteLine("Moves: " + moves);
                Console.WriteLine("Use arrow keys to move.");

                // Read player input
                ConsoleKey key = Console.ReadKey(true).Key;

                int newX = playerX;
                int newY = playerY;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        newX--;
                        break;

                    case ConsoleKey.DownArrow:
                        newX++;
                        break;

                    case ConsoleKey.LeftArrow:
                        newY--;
                        break;

                    case ConsoleKey.RightArrow:
                        newY++;
                        break;
                }

                // Check boundaries
                if (newX < 0 || newX >= maze.GetLength(0) ||
                    newY < 0 || newY >= maze.GetLength(1))
                {
                    continue;
                }

                // Check wall
                if (maze[newX, newY] == '#')
                {
                    continue;
                }

                // Check destination
                if (maze[newX, newY] == 'E')
                {
                    moves++;
                    gameOver = true;
                    continue;
                }

                // Move player
                maze[playerX, playerY] = ' ';
                playerX = newX;
                playerY = newY;
                maze[playerX, playerY] = 'P';

                moves++;
            }

            Console.Clear();

            Console.WriteLine("Congratulations!");
            Console.WriteLine("You completed the maze!");
            Console.WriteLine("Total moves: " + moves);

            Console.CursorVisible = true;
        }
    }
}