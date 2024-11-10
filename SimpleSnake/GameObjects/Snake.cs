using SimpleSnake.GameObjects.Foods;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private readonly Wall wall;
        private readonly Queue<Point> snakeElements;
        private readonly List<Food> foods;
        private int nextLeftX;
        private int nextTopY;

        public Snake()
        {
            
            

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

            return true;

        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {

            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;

        }
    }
}
