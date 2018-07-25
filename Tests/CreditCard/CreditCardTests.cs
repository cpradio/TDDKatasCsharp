using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class CreditCardTests
	{
		[Test]
		public void should_describe_a_test()
		{
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		//[TestCase("1234567812345678", "############5678")]
		//[TestCase("1234 5678 1234 7586", "############7586")]
		//public void should_return_masked_credit_card_number(string creditCardNumber, string expectedMask)
		//{
		//	Assert.AreEqual(expectedMask, CreditCard.Mask(creditCardNumber));
		//}

		//[TestCase("1a345678123b5678")]
		//[TestCase("1234 5a78 1234 7586")]
		//[TestCase("12345678")]
		//[TestCase("1234 5678")]
		//public void should_throw_argument_exception(string creditCardNumber)
		//{
		//	Assert.Throws<ArgumentException>(() => CreditCard.Mask(creditCardNumber));
		//}
	}
}
