using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Katas.CreditCard
{
	public class CreditCard
	{
		public static string Mask(string creditCardNumber)
		{
			var creditCardWithoutSpaces = creditCardNumber.Replace(" ", string.Empty);
			if (!Regex.IsMatch(creditCardWithoutSpaces, "^[0-9]{16}$"))
				throw new ArgumentException();

			return creditCardWithoutSpaces.Substring(12, 4).PadLeft(16, '#');
		}
	}
}
