using Katas.FizzBuzz;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class FizzBuzzTests
	{
		[Test]
		public void should_return_fizz_for_3()
		{
			Assert.AreEqual("Fizz", FizzBuzz.IsFizzOrBuzz(3));
		}

		[Test]
		public void should_return_buzz_for_5()
		{
			Assert.AreEqual("Buzz", FizzBuzz.IsFizzOrBuzz(5));
		}

		[Test]
		public void should_return_fizzbuzz_for_15()
		{
			Assert.AreEqual("FizzBuzz", FizzBuzz.IsFizzOrBuzz(15));
		}

		[Test]
		public void should_return_number_when_not_divisible_by_3_or_5()
		{
			Assert.AreEqual("8", FizzBuzz.IsFizzOrBuzz(8));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase(45, "FizzBuzz")]
		[TestCase(48, "Fizz")]
		[TestCase(55, "Buzz")]
		[TestCase(47, "47")]
		public void should_return_the_appropriate_fizz_or_buzz_for_a_given_number(int number, string expectedResult)
		{
			Assert.AreEqual(expectedResult, FizzBuzz.IsFizzOrBuzz(number));
		}
	}
}
