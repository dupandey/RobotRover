using System;
using System.Collections.Generic;
using System.Text;

namespace RobotRover
{
	public class MoverPosition:IMoverPosition
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Directions Direction { get; set; } 
		public MoverPosition(int x, int y)
		{
			this.X = x;
			this.Y = y;
			
		}
		public MoverPosition(int x, int y, Directions direction)
		{
			this.X = x;
			this.Y = y;
			this.Direction = direction;
		}

		private void Rotate90Left()
		{
			switch (this.Direction)
			{
				case Directions.N:
					this.Direction = Directions.W;
					break;
				case Directions.S:
					this.Direction = Directions.E;
					break;
				case Directions.E:
					this.Direction = Directions.N;
					break;
				case Directions.W:
					this.Direction = Directions.S;
					break;
				default:
					break;
			}
		}

		private void Rotate90Right()
		{
			switch (this.Direction)
			{
				case Directions.N:
					this.Direction = Directions.E;
					break;
				case Directions.S:
					this.Direction = Directions.W;
					break;
				case Directions.E:
					this.Direction = Directions.S;
					break;
				case Directions.W:
					this.Direction = Directions.N;
					break;
				default:
					break;
			}
		}

		private void MoveInSameDirection(int step)
		{
			switch (this.Direction)
			{
				case Directions.N:
					this.Y += step;
					break;
				case Directions.S:
					this.Y -= step;
					break;
				case Directions.E:
					this.X += step;
					break;
				case Directions.W:
					this.X -= step;
					break;
				default:
					break;
			}
		}
	

	string b = string.Empty;
	
	public void Move(MoverPosition mp, string command)
		{
			for (int i = 0; i < command.Length; i++)
			{
				if (Char.IsDigit(command[i]))
					b += command[i];
				else
				{
					if (b.Length > 0)
					{
						SetDirectionAndPosition(b);
						SetDirectionAndPosition(command[i].ToString());
						b = string.Empty;
					}
					else
					{
						SetDirectionAndPosition(command[i].ToString());



					}
				}
			}


			if (this.X < 0 || this.X > mp.X || this.Y < 0 || this.Y > mp.Y)
				{
					throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({mp.X } , {mp.Y })");
				}
			
		}
		
	private void SetDirectionAndPosition(string command)
		{
			switch (command)
			{
				
				case "L":
					this.Rotate90Left();
					break;
				case "R":
					this.Rotate90Right();
					break;
				default:
					if (int.TryParse(command, out int n))
						MoveInSameDirection(Convert.ToInt32(command));
					else
						Console.WriteLine("wrong command");
					break;
			}
		}
	}
	}

