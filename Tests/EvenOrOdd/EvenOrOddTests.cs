using Katas.EvenOrOdd;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class EvenOrOddTests
	{
		[Test]
		public void should_return_odd_for_3()
		{
			Assert.AreEqual("Odd", EvenOrOdd.IsEvenOrOdd(3));
		}

		[Test]
		public void should_return_even_for_4()
		{
			Assert.AreEqual("Even", EvenOrOdd.IsEvenOrOdd(4));
		}

		[Test]
		public void should_return_odd_for_negative_5()
		{
			Assert.AreEqual("Odd", EvenOrOdd.IsEvenOrOdd(-5));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase(47, "Odd")]
		[TestCase(150, "Even")]
		[TestCase(-2, "Even")]
		[TestCase(-5, "Odd")]
		public void should_return_whether_a_given_number_is_even_or_odd(int number, string expectedResult)
		{
			Assert.AreEqual(expectedResult, EvenOrOdd.IsEvenOrOdd(number));
		}
	}
}
