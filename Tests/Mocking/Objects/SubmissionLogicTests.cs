
using Katas.Mocking.DataAccess.Entities;
using Katas.Mocking.Objects.Logic;
using Katas.Mocking.Objects.Wrapper;
using Moq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class SubmissionLogicTests
	{
		private SubmissionLogic _submissionLogic;
		private Mock<ISubmissionWrapper> _mockSubmissionWrapper;

		private void SetupWrapper(bool isValid)
		{
			_mockSubmissionWrapper = new Mock<ISubmissionWrapper>();
			_mockSubmissionWrapper.Setup(p => p.Submit()).Verifiable();
			_mockSubmissionWrapper.Setup(p => p.IsValid()).Returns(isValid);

			_submissionLogic = new SubmissionLogic(new Submission())
			{
				SubmissionWrapper = _mockSubmissionWrapper.Object
			};
		}

		[Test]
		public void validate_submission_is_saved_when_valid()
		{
			var submission = new Submission();
			SetupWrapper(true);
			var result = _submissionLogic.ValidateAndSubmit(submission);

			Assert.IsTrue(result);
			_mockSubmissionWrapper.Verify(a => a.Submit(), Times.Once);
		}

		[Test]
		public void validate_submission_is_not_saved_when_invalid()
		{
			var submission = new Submission();
			SetupWrapper(false);
			var result = _submissionLogic.ValidateAndSubmit(submission);

			Assert.IsFalse(result);
			_mockSubmissionWrapper.Verify(a => a.Submit(), Times.Never);
		}
	}
}
