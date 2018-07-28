using System;
using System.Text.RegularExpressions;
using Katas.CreditCard;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class CreditCardTests
	{
		[Test]
		public void should_return_credit_card_number_without_spaces()
		{
			Assert.IsFalse(CreditCard.Mask("1234 5678 9012 3456").Contains(" "));
		}

		[TestCase("1234 5678 9012 345A")]
		[TestCase("123456789012345A")]
		[TestCase("1234 5678 9012 3456 7")]
		[TestCase("12345678901234567")]
		[TestCase("1234 5678 9012 345")]
		[TestCase("123456789012345")]
		public void should_throw_an_exception_when_card_is_not_16_digits(string creditCardNumber)
		{
			Assert.Throws<ArgumentException>(() => CreditCard.Mask(creditCardNumber));
		}

		[Test]
		public void should_return_mask_version_of_credit_card_number()
		{
			Assert.AreEqual("############3456", CreditCard.Mask("1234567890123456"));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase("1234567812345678", "############5678")]
		[TestCase("1234 5678 1234 7586", "############7586")]
		public void should_return_masked_credit_card_number(string creditCardNumber, string expectedMask)
		{
			Assert.AreEqual(expectedMask, CreditCard.Mask(creditCardNumber));
		}

		[TestCase("1a345678123b5678")]
		[TestCase("1234 5a78 1234 7586")]
		[TestCase("12345678")]
		[TestCase("1234 5678")]
		public void should_throw_argument_exception(string creditCardNumber)
		{
			Assert.Throws<ArgumentException>(() => CreditCard.Mask(creditCardNumber));
		}
	}
}
