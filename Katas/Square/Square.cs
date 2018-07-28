using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Square
{
	public class Square
	{
		public static bool IsPerfectSquare(int number)
		{
			if (number < 0)
				return false;

			var squareRoot = Math.Sqrt(number);
			return Math.Ceiling(squareRoot) == squareRoot;
		}
	}
}
