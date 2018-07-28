using System;
using Katas.Age;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class AgeTests
	{
		[TestCase(0)]
		[TestCase(-1)]
		public void should_throw_exception_for_input_less_than_1(int age)
		{
			Assert.Throws<ArgumentException>(() => Age.GetGroup(age));
		}

		[TestCase(56)]
		[TestCase(57)]
		public void should_return_senior_when_age_is_56_or_greater(int age)
		{
			Assert.AreEqual("Senior", Age.GetGroup(age));
		}

		[TestCase(26)]
		[TestCase(55)]
		public void should_return_adult_when_age_is_between_26_and_55(int age)
		{
			Assert.AreEqual("Adult", Age.GetGroup(age));
		}

		[TestCase(19)]
		[TestCase(25)]
		public void should_return_college_bound_when_age_is_between_19_and_25(int age)
		{
			Assert.AreEqual("College Bound", Age.GetGroup(age));
		}

		[TestCase(13)]
		[TestCase(18)]
		public void should_return_teenager_when_age_is_between_13_and_18(int age)
		{
			Assert.AreEqual("Teenager", Age.GetGroup(age));
		}

		[Test]
		public void should_return_preteen_when_age_is_12()
		{
			Assert.AreEqual("Preteen", Age.GetGroup(12));
		}

		[TestCase(5)]
		[TestCase(11)]
		public void should_return_child_when_age_is_between_5_and_11(int age)
		{
			Assert.AreEqual("Child", Age.GetGroup(age));
		}

		[TestCase(3)]
		[TestCase(4)]
		public void should_return_toddler_when_age_is_between_3_and_4(int age)
		{
			Assert.AreEqual("Toddler", Age.GetGroup(age));
		}

		[TestCase(1)]
		[TestCase(2)]
		public void should_return_infant_when_age_is_between_1_and_2(int age)
		{
			Assert.AreEqual("Infant", Age.GetGroup(age));
		}

		/*
		 *  AFTER WRITING ALL OF YOUR TESTS AND CODE, RUN THE FOLLOWING ADDITIONAL TESTS
		 */
		[TestCase(1, "Infant")]
		[TestCase(3, "Toddler")]
		[TestCase(8, "Child")]
		[TestCase(12, "Preteen")]
		[TestCase(15, "Teenager")]
		[TestCase(19, "College Bound")]
		[TestCase(34, "Adult")]
		[TestCase(99, "Senior")]
		public void should_assign_the_correct_group_based_on_age(int age, string expectedGroup)
		{
			Assert.AreEqual(expectedGroup, Age.GetGroup(age));
		}

		[TestCase(0)]
		[TestCase(-5)]
		public void should_throw_an_exception(int age)
		{
			Assert.Throws<ArgumentException>(() => Age.GetGroup(age));
		}
	}
}
