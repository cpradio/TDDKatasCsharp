using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Katas.Mocking.DataAccess.Contexts;
using Katas.Mocking.DataAccess.Controllers;
using Katas.Mocking.DataAccess.Entities;
using Katas.Mocking.DataAccess.Entitites;
using Katas.Mocking.DataAccess.Models;
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
		private bool _calledSave = false;

		private void SetupWrapper(bool isValid)
		{
			var mockSubmissionWrapper = new Mock<ISubmissionWrapper>();
			mockSubmissionWrapper.Setup(p => p.Submit()).Callback(() => _calledSave = true);
			mockSubmissionWrapper.Setup(p => p.IsValid()).Returns(isValid);

			_submissionLogic = new SubmissionLogic(new Submission())
			{
				SubmissionWrapper = mockSubmissionWrapper.Object
			};
		}

		[Test]
		public void validate_submission_is_saved_when_valid()
		{
			_calledSave = false;

			var submission = new Submission();
			SetupWrapper(true);
			var result = _submissionLogic.ValidateAndSubmit(submission);

			Assert.IsTrue(result);
			Assert.IsTrue(_calledSave);
		}

		[Test]
		public void validate_submission_is_not_saved_when_invalid()
		{
			_calledSave = false;

			var submission = new Submission();
			SetupWrapper(false);
			var result = _submissionLogic.ValidateAndSubmit(submission);

			Assert.IsFalse(result);
			Assert.IsFalse(_calledSave);
		}
	}
}
