using SimpleSnake.Core.Interfaces;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Foods;
using System.Collections.Generic;


namespace SimpleSnake.Core
{
    internal class Engine : IEngine
    {
        public void Run()
        {

            Wall wall = new Wall(60, 20);

            FoodDollar food = new FoodDollar(wall);
            food.SetRandomPosition(new Queue<Point>());
            

            while(true)
            {


            }
          
        }
    }
}
