using SimpleSnake.Core.Interfaces;
using SimpleSnake.GameObjects;


namespace SimpleSnake.Core
{
    internal class Engine : IEngine
    {

        private Point[] pointsOfDirection;

        public Engine()
        {
            pointsOfDirection = new Point[4];    
        }

        public void Run()
        {

          
          
        }
        private void CreateDirection()
        {
            pointsOfDirection[0] = new Point(1, 0);
            pointsOfDirection[1] = new Point(-1, 0);
            pointsOfDirection[2] = new Point(0, 1);
            pointsOfDirection[3] = new Point(0, -1);
        }
    }
}
