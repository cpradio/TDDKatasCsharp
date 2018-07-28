using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Age
{
	public class Age
	{
		public static string GetGroup(int age)
		{
			if (age <= 0)
				throw new ArgumentException();

			if (age >= 56)
				return "Senior";
			if (age >= 26)
				return "Adult";
			if (age >= 19)
				return "College Bound";
			if (age >= 13)
				return "Teenager";
			if (age == 12)
				return "Preteen";
			if (age >= 5)
				return "Child";
			if (age >= 3)
				return "Toddler";
			return "Infant";
		}
	}
}
