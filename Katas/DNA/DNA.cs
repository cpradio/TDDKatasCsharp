using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.DNA
{
	public class DNA
	{
		public static string GetComplementaryDNA(string dna)
		{
			var complementaryDNA = "";
			foreach (var t in dna)
			{
				if (t == 'T')
					complementaryDNA += "A";
				else if (t == 'A')
					complementaryDNA += "T";
				else if (t == 'C')
					complementaryDNA += "G";
				else if (t == 'G')
					complementaryDNA += "C";
				else
					complementaryDNA += t;
			}

			return complementaryDNA;
		}
	}
}
