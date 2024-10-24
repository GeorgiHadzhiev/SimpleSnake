namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.Core.Interfaces;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
