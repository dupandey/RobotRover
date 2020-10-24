using System;

namespace RobotRover
{
	class Program
	{
		static void Main(string[] args)
		{
			var maxSize = new MoverPosition(40,30); 
		
			while (true)
			{
				var startPosition = new MoverPosition(10, 10, Directions.N);
				Console.Write("Enter Command: ");
				string command = Console.ReadLine();
				startPosition.Move(maxSize, command);
				Console.WriteLine($"{startPosition.X} {startPosition.Y} {startPosition.Direction.ToString()}");

			}

		}
	}
}
