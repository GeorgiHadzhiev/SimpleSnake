using SimpleSnake.Core.Interfaces;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using System;


namespace SimpleSnake.Core
{
    internal class Engine : IEngine
    {
        private Direction direction;
        private Point[] pointsOfDirection;
        private Snake snake;
        private Wall wall;

        public Engine()
        {
            pointsOfDirection = new Point[4];
        }

        public void Run()
        {

            bool isMoving = snake.IsMoving(pointsOfDirection[(int)direction]);
            
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
            int topY = 3;

            Console.SetCursorPosition(leftX, topY);
            Console.Write("Would you like to continue? y/n");

            string input = Console.ReadLine();
            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {

                StopGame();

            }
        }

        private void StopGame()
        {
            
        }
    }
}
