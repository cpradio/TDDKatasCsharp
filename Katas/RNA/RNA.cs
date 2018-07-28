using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.RNA
{
	public class RNA
	{
		public static string ConvertFromDNA(string dna)
		{
			return dna.Replace("T", "U");
		}
	}
}
