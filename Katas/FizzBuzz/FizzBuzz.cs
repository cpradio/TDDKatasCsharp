using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.FizzBuzz
{
	public class FizzBuzz
	{
		public static string IsFizzOrBuzz(int number)
		{
			var output = "";
			if (number % 3 == 0)
				output += "Fizz";

			if (number % 5 == 0)
				output += "Buzz";

			if (output.Length == 0)
				output = number.ToString();

			return output;
		}
	}
}
