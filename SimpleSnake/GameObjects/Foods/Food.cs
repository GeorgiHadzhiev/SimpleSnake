using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food: Point
    {
        private char foodSymbol;
        private Random random;
        private Wall wall;

        protected Food(Wall wall,char foodSymbol,int points) 
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            FoodPoints = points;
            random = new Random();
        }

        public Food(int leftX, int topY) : base(leftX, topY)
        {
        }

        public int FoodPoints { get; private set; }
        public void SetRandomPosition(Queue<Point> snakeElement)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnake = snakeElement.Any(se=>IsFoodPoint(se));

            while (isPointOfSnake)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnake = snakeElement.Any(se=>IsFoodPoint(se));
            }

            Console.BackgroundColor = ConsoleColor.Red;
            Draw(foodSymbol);
            Console.BackgroundColor = ConsoleColor.White;

        }
        public bool IsFoodPoint(Point snakeHead) 
            => snakeHead.LeftX == LeftX && snakeHead.TopY == TopY;

    }
}
