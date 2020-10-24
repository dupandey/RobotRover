using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotRover;
using System;

namespace RobotRoverTest
{
	[TestClass]
	public class UnitTest1
	{
		[TestClass]
		public class When_Moving_Rover
		{
			[TestMethod]
			public void Valid_Command_Sequence_Movement_Is_Successful()
			{
				MoverPosition position = new MoverPosition(1, 2, Directions.N); 


				var maxPoints = new MoverPosition(5, 5);
				var moves = "L1L1L1L11";

				position.Move(maxPoints, moves);

				var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
				var expectedOutput = "1 1 N";

				Assert.AreEqual(expectedOutput, actualOutput);
			}
			[TestMethod]
			public void Valid_Command_Sequence_Movement_Is_Failed()
			{
				MoverPosition position = new MoverPosition(1, 2, Directions.N);


				var maxPoints = new MoverPosition(5, 5);
				var moves = "L1L1L1L11";

				position.Move(maxPoints, moves);

				var actualOutput = $"{position.X} {position.Y} {position.Direction.ToString()}";
				var expectedOutput = "1 2 N";

				Assert.AreNotEqual(expectedOutput, actualOutput);
			}
			[TestMethod]
			public void Valid_Command_Sequence_Movement_Is_OutOfRange()
			{
				MoverPosition position = new MoverPosition(4, 4, Directions.N);


				var maxPoints = new MoverPosition(5, 5);
				string expected = null;
				var moves = "R2R3";
				try
				{
					position.Move(maxPoints, moves);
				}
				catch (Exception ex)
				{
					expected = ex.Message;
				}

				Assert.IsNotNull(expected);
			}


			
		}
	}
	}
