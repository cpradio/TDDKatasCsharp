using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.EvenOrOdd
{
	public class EvenOrOdd
	{
		public static string IsEvenOrOdd(int number)
		{
			if (Math.Abs(number % 2) == 1)
				return "Odd";

			return "Even";
		}
	}
}
