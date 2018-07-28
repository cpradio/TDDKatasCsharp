using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Year
{
	public class Year
	{
		public static int GetCentury(int year)
		{
			int century = year / 100;

			if (year % 100 != 0)
				century += 1;

			return century;
		}
	}
}
