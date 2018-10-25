using Katas.Mocking.DataAccess.Entities;
using Katas.Mocking.Objects.Wrapper;

namespace Katas.Mocking.Objects.Logic
{
	public class SubmissionLogic
	{
		internal Submission Submission;

		public ISubmissionWrapper SubmissionWrapper
		{
			get => _submissionWrapper ?? (_submissionWrapper = new SubmissionWrapper(Submission));
			set => _submissionWrapper = value;
		}
		private ISubmissionWrapper _submissionWrapper;

		public SubmissionLogic(Submission submission)
		{
			Submission = submission;
		}

		public bool ValidateAndSubmit(Submission submission)
		{
			if (!SubmissionWrapper.IsValid())
				return false;

			SubmissionWrapper.Submit();
			return true;
		}
	}
}
