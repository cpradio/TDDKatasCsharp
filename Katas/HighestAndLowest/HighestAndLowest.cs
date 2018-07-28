using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.HighestAndLowest
{
	public class HighestAndLowest
	{
		public static string FindHighestAndLowestNumbers(string numbers)
		{
			var highest = Int32.MinValue;
			var lowest = Int32.MaxValue;

			foreach (var number in numbers.Split(' '))
			{
				var convertedNumber = Int32.Parse(number);
				if (convertedNumber > highest)
					highest = convertedNumber;

				if (convertedNumber < lowest)
					lowest = convertedNumber;
			}

			return $"{highest} {lowest}";
		}
	}
}
