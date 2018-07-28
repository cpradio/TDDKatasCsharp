using Katas.Year;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class YearTests
	{
		[Test]
		public void should_return_the_16th_century_for_1600()
		{
			Assert.AreEqual(16, Year.GetCentury(1600));
		}

		[Test]
		public void should_return_the_17th_century_for_1601()
		{
			Assert.AreEqual(17, Year.GetCentury(1601));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase(0, 0)]
		[TestCase(1, 1)]
		[TestCase(100, 1)]
		[TestCase(2105, 22)]
		public void should_assign_the_correct_century_for_the_given_year(int year, int expectedCentury)
		{
			Assert.AreEqual(expectedCentury, Year.GetCentury(year));
		}
	}
}
