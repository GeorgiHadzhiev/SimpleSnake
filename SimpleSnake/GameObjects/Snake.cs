using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char SnakeSymbol = '\u25cf';
        private const char EmptySpace = ' ';

        private readonly Wall wall;
        private readonly Queue<Point> snakeElements;
        private readonly List<Food> foods;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        private int RandomFoodNumber => 
            new Random().Next(0, foods.Count);

        public Snake(Wall wall)
        {
            
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new List<Food>();
            foodIndex = RandomFoodNumber;
            GetFoods();
            CreateSnake();

        }


        private void CreateSnake()
        {

            for(int topY = 1; topY <= 6; topY++)
            {
                Point snakeBody = new Point(2, topY);
                snakeElements.Enqueue(snakeBody);
            }

        }
        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }
        private bool IsMoving(Point direction)
        {

            Point currentSnakeHead = snakeElements.Last();
            GetNextPoint(direction,currentSnakeHead);

            bool IsPointOfSnake = snakeElements
                .Any(se => se.LeftX == nextLeftX && se.TopY == nextTopY);


            if (IsPointOfSnake) return false;

            Point newSnakeHead = new Point(nextLeftX,nextTopY);

            if(wall.IsPointOfWall(newSnakeHead)) return false;

            snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(SnakeSymbol);

            if (foods[foodIndex].IsFoodPoint(newSnakeHead))
            {
                Eat(direction,currentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(EmptySpace);

            return true;

        }
        private void Eat(Point direction, Point currentSnakeHead)
        {

            int lenght = foods[foodIndex].FoodPoints;

            for(int i = 0; i < lenght; i++)
            {
                Point evenNewerSnakeBody = new Point(nextLeftX,nextTopY);
                snakeElements.Enqueue(evenNewerSnakeBody);
                GetNextPoint(direction, currentSnakeHead);
            }

            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);

        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {

            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;

        }
    }
}
