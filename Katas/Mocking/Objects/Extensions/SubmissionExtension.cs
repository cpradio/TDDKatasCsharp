using System;
using Katas.Mocking.DataAccess.Entities;

namespace Katas.Mocking.Objects.Extensions
{
	public static class SubmissionExtension
	{
		public static bool IsValid(this Submission submission)
		{
			return !String.IsNullOrWhiteSpace(submission.Username);
		}

		public static void Submit(this Submission submission)
		{
			throw new NotImplementedException();
		}
	}
}
