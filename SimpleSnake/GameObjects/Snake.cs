using SimpleSnake.GameObjects.Foods;
using System.Collections.Generic;

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

                snakeElements.Enqueue(new Point(2, topY));

            }

        }
        private void GetFoods()
        {
            foods[0] = new FoodHash(wall);
            foods[1] = new FoodDollar(wall);
            foods[2] = new FoodAsterisk(wall);
        }
        private bool IsMoving()
        {



        }
        private void GetNextPoint(Point direction, Point snakeHead)
        {

            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;

        }
    }
}
