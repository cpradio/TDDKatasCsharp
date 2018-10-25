using Katas.Mocking.DataAccess.Entities;
using Katas.Mocking.Objects.Extensions;

namespace Katas.Mocking.Objects.Wrapper
{
	public class SubmissionWrapper : ISubmissionWrapper
	{
		protected Submission Submission;

		public SubmissionWrapper(Submission submission)
		{
			Submission = submission;
		}

		public bool IsValid()
		{
			return Submission.IsValid();
		}

		public void Submit()
		{
			Submission.Submit();
		}
	}
}
