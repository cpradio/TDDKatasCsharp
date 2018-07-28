using Katas.RNA;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class RNATests
	{
		[Test]
		public void should_return_RNA_for_given_DNA()
		{
			Assert.AreEqual("GCAU", RNA.ConvertFromDNA("GCAT"));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase("GCAT", "GCAU")]
		[TestCase("GTAT", "GUAU")]
		public void should_return_the_complementary_RNA_for_given_DNA(string DNA, string expectedRNA)
		{
			Assert.AreEqual(expectedRNA, RNA.ConvertFromDNA(DNA));
		}
	}
}
