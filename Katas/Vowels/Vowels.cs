using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Katas.Vowels
{
	public class Vowels
	{
		public static int Count(string phrase)
		{
			return Regex.Matches(phrase, "[aeiou]").Count;
		}
	}
}
