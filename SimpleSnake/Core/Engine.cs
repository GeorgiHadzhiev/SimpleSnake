using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;
using System.Threading;


namespace SimpleSnake.Core
{
    internal class Engine : IEngine
    {
        private Direction direction;
        private Point[] pointsOfDirection;
        private Snake snake;
        private Wall wall;
        private double sleepTime;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            pointsOfDirection = new Point[4];
            sleepTime = 100;
        }

        public void Run()
        {

            CreateDirection();

            while (true) 
            {

                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);

                if (!isMoving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;
                Thread.Sleep((int)sleepTime);

            }
            
        }
        private void CreateDirection()
        {
            pointsOfDirection[0] = new Point(1, 0);
            pointsOfDirection[1] = new Point(-1, 0);
            pointsOfDirection[2] = new Point(0, 1);
            pointsOfDirection[3] = new Point(0, -1);
        }
        private void GetNextDirection()
        {

            ConsoleKeyInfo userInput = Console.ReadKey();

            if(userInput.Key == ConsoleKey.LeftArrow)
            {
                if(direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;

        }
        private void AskUserForRestart()
        {

            int leftX = wall.LeftX + 1;
            int topY = 5;
            Console.SetCursorPosition(leftX, topY);
            Console.Write("  Would you like to restart? y/n  ");

            int leftXOffSet = leftX + 19;
            int topYOffSet = topY + 5;

            Console.SetCursorPosition(leftXOffSet, topYOffSet);
            Console.Write("Player: ");
            Console.CursorVisible = true;

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else if (input == "n")
            {
                StopGame();
            }
            else
            {
                Console.SetCursorPosition(leftXOffSet, topYOffSet + 1);
                Console.Write("Invalid command. Try again.");
                AskUserForRestart();
            }
        }

        private static void StopGame()
        {
            Console.SetCursorPosition(20, 10);
            Console.Write("Game Over!");
            Console.WriteLine("\n");
            Environment.Exit(0);
        }
    }
}
