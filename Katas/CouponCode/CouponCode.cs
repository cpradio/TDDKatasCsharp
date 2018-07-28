using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Katas.CouponCode
{
	public class CouponCode
	{
		private static readonly string[] _months =
		{
			"JAN", "FEB", "MAR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"
		};

		public static bool IsValid(string couponCode)
		{
			couponCode = couponCode.Trim();
			if (couponCode.Length != 10)
				return false;

			var currentYear = DateTime.Today.Year.ToString();
			return couponCode.StartsWith(currentYear)
				&& _months.Contains(couponCode.Substring(4, 3).ToUpper())
				&& couponCode.Substring(7, 1) == "-"
				&& Regex.IsMatch(couponCode, "[0-9]{2}$");
		}
	}
}
