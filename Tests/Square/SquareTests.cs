using Katas.Square;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class SquareTests
	{
		[Test]
		public void should_return_false_if_number_is_less_than_0()
		{
			Assert.IsFalse(Square.IsPerfectSquare(-1));
		}

		[Test]
		public void should_return_false_if_number_is_not_a_square()
		{
			Assert.IsFalse(Square.IsPerfectSquare(13));
		}

		[Test]
		public void should_return_true_if_number_is_a_square()
		{
			Assert.IsTrue(Square.IsPerfectSquare(25));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase(-25, false)]
		[TestCase(625, true)]
		[TestCase(0, true)]
		public void should_return_whether_a_given_number_is_a_perfect_square(int number, bool expectedResult)
		{
			Assert.AreEqual(expectedResult, Square.IsPerfectSquare(number));
		}
	}
}
