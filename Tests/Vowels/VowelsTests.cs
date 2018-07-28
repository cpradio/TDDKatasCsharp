using Katas.Vowels;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class VowelsTests
	{
		[Test]
		public void should_return_number_of_vowels_found_in_string()
		{
			Assert.AreEqual(5, Vowels.Count("abcdefghijklmnopqrstuvwxyz"));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase("grange", 2)]
		[TestCase("stackoverflow", 4)]
		[TestCase("aeiou are the vowels to use", 13)]
		public void should_return_the_number_of_vowels_found_in_the_string(string input, int expectedResult)
		{
			Assert.AreEqual(expectedResult, Vowels.Count(input));
		}
	}
}
