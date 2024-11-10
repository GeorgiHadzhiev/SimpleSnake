# SimpleSnake

A simple Snake game running in the Windows terminal.
Done with .NET 6 to see if I can.

Everything is drawn in the terminal leveraging .NET's System.Console.dll
The level is drawn outside of the main thread loop and once the main loop starts, the game logic
is proccessed with a .Sleep() suspense on the main thread to control the speed of the snake. 
Normally this would be done using game ticks but there's no need for something this primative.

Includes a ready made SimpleSnake.exe so no need to compile. 