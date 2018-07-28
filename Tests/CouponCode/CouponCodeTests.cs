using System;
using Katas.CouponCode;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class CouponCodeTests
	{
		[TestCase("2018JAN-000")]
		[TestCase("2018JAN-0")]
		public void should_return_false_when_code_is_not_10_characters(string code)
		{
			Assert.IsFalse(CouponCode.IsValid(code));
		}

		[Test]
		public void should_return_false_when_code_does_not_start_with_current_year()
		{
			var priorYear = DateTime.Today.Year - 1;
			Assert.IsFalse(CouponCode.IsValid($"{priorYear}JAN-00"));
		}

		[Test]
		public void should_return_false_when_year_is_not_followed_by_month()
		{
			var currentYear = DateTime.Today.Year;
			Assert.IsFalse(CouponCode.IsValid($"{currentYear}ABC-00"));
		}

		[Test]
		public void should_return_false_when_eighth_character_is_not_a_hyphen()
		{
			var currentYear = DateTime.Today.Year;
			Assert.IsFalse(CouponCode.IsValid($"{currentYear}JAN_00"));
		}

		[TestCase("JAN-A0")]
		[TestCase("JAN-0A")]
		public void should_return_false_when_code_does_not_end_with_2_digits(string code)
		{
			var currentYear = DateTime.Today.Year;
			Assert.IsFalse(CouponCode.IsValid($"{currentYear}{code}"));
		}

		[Test]
		public void should_return_true_when_given_a_valid_coupon_code()
		{
			var currentYear = DateTime.Today.Year;
			Assert.IsTrue(CouponCode.IsValid($"{currentYear}JAN-00"));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase("2018DEC-00", true)]
		[TestCase("2018DEC-00 ", true)]
		[TestCase(" 2018DEC-00", true)]
		[TestCase("2018DEC-000", false)]
		[TestCase("2018DEC-AB", false)]
		[TestCase("2018DEM-00", false)]
		[TestCase("2017DEC-00", false)]
		[TestCase("2019DEC-00", false)]
		public void should_return_whether_a_given_coupon_code_is_valid(string code, bool expectedResult)
		{
			Assert.AreEqual(expectedResult, CouponCode.IsValid(code));
		}
	}
}
