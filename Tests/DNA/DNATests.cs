using Katas.DNA;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class DNATests
	{
		[Test]
		public void should_replace_T_and_A_with_complementary_values()
		{
			Assert.AreEqual("TAAT", DNA.GetComplementaryDNA("ATTA"));
		}

		[Test]
		public void should_replace_C_and_G_with_complementary_values()
		{
			Assert.AreEqual("CGGC", DNA.GetComplementaryDNA("GCCG"));
		}

		[Test]
		public void should_keep_any_other_characters_such_as_U()
		{
			Assert.AreEqual("GTUAC", DNA.GetComplementaryDNA("CAUTG"));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase("GTUA", "CAUT")]
		[TestCase("TGCAGT", "ACGTCA")]
		public void should_return_the_complementary_DNA_for_given_DNA(string input, string expectedDNA)
		{
			Assert.AreEqual(expectedDNA, DNA.GetComplementaryDNA(input));
		}
	}
}
