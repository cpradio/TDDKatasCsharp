using Katas.HighestAndLowest;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class HighestAndLowestTests
	{
		[Test]
		public void should_return_5_for_highest_and_lowest()
		{
			Assert.AreEqual("5 5", HighestAndLowest.FindHighestAndLowestNumbers("5"));
		}

		[Test]
		public void should_return_5_as_highest_number()
		{
			Assert.IsTrue(HighestAndLowest.FindHighestAndLowestNumbers("2 5 3").StartsWith("5"));
		}

		[Test]
		public void should_return_2_as_lowest_number()
		{
			Assert.IsTrue(HighestAndLowest.FindHighestAndLowestNumbers("2 5 3").EndsWith("2"));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase("45", "45 45")]
		[TestCase("5 4 7 9 -1 10", "10 -1")]
		public void should_return_the_highest_and_lowest_numbers_found_in_input(string input, string expectedResult)
		{
			Assert.AreEqual(expectedResult, HighestAndLowest.FindHighestAndLowestNumbers(input));
		}
	}
}
