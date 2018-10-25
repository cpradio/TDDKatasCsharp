using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Katas.Mocking.DataAccess.Contexts;
using Katas.Mocking.DataAccess.Controllers;
using Katas.Mocking.DataAccess.Entities;
using Katas.Mocking.DataAccess.Entitites;
using Katas.Mocking.DataAccess.Models;
using Moq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class SubmissionsControllerTests
	{
		private SubmissionsController _submissionsController;
		private void Setup(List<Submission> dataToLoad = null)
		{
			if (dataToLoad == null)
				dataToLoad = new List<Submission>
				{
					new Submission
					{
						SubmissionId = 1,
						KataId = 1,
						Username = "username1",
						TestsPassed = 2,
						TestsFailed = 1,
						ModifyDate = DateTime.Today,
						CreateDate = DateTime.Today
					}
				};
			var submissionData = dataToLoad.AsQueryable();

			var mockSubmission = new Mock<DbSet<Submission>>();
			mockSubmission.As<IQueryable<Submission>>().Setup(m => m.ElementType).Returns(submissionData.ElementType);
			mockSubmission.As<IQueryable<Submission>>().Setup(m => m.Expression).Returns(submissionData.Expression);
			mockSubmission.As<IQueryable<Submission>>().Setup(m => m.Provider).Returns(submissionData.Provider);
			mockSubmission.Setup(a => a.Find(It.IsAny<object[]>())).Returns<object[]>(id => submissionData.FirstOrDefault(b => b.SubmissionId == (int)id[0]));

			var kataData = new List<Kata>
			{
				new Kata
				{
					KataId = 1,
					Name = "LeapYear",
					Instructions = "Determine if the given year, is a leap year."
				}
			}.AsQueryable();

			var mockKata = new Mock<DbSet<Kata>>();
			mockKata.As<IQueryable<Kata>>().Setup(m => m.ElementType).Returns(kataData.ElementType);
			mockKata.As<IQueryable<Kata>>().Setup(m => m.Expression).Returns(kataData.Expression);
			mockKata.As<IQueryable<Kata>>().Setup(m => m.Provider).Returns(kataData.Provider);
			mockKata.Setup(a => a.Find(It.IsAny<object[]>())).Returns<object[]>(id => kataData.FirstOrDefault(b => b.KataId == (int)id[0]));

			var mockDb = new Mock<IDatabaseContext>();
			mockDb.Setup(m => m.Submissions).Returns(mockSubmission.Object);
			mockDb.Setup(m => m.Katas).Returns(mockKata.Object);

			_submissionsController = new SubmissionsController();
			_submissionsController.Context = mockDb.Object;
		}

		private static List<Submission> SetupSubmissionsForSpecificPage()
		{
			var loadSubmissions = new List<Submission>();
			for (int submission = 1; submission <= 55; submission++)
			{
				loadSubmissions.Add(
					new Submission
					{
						SubmissionId = submission,
						KataId = 1,
						Username = $"username{submission}",
						TestsPassed = 3,
						TestsFailed = 2,
						ModifyDate = DateTime.Today,
						CreateDate = DateTime.Today
					}
				);
			}

			return loadSubmissions;
		}

		[Test]
		public void request_index_with_missing_kata_id()
		{
			Setup();
			var result = _submissionsController.Index(null, null);

			Assert.IsTrue(result is HttpStatusCodeResult);
			Assert.AreEqual((int)HttpStatusCode.BadRequest, ((HttpStatusCodeResult)result).StatusCode);
		}

		[Test]
		public void can_get_results_for_kata_id()
		{
			Setup();
			var result = _submissionsController.Index(1, null) as ViewResult;

			Assert.IsTrue(result.Model is SubmissionsViewModel);
			Assert.AreEqual(1, ((SubmissionsViewModel)result.Model).KataId);
			Assert.AreEqual(1, ((SubmissionsViewModel)result.Model).CurrentPageNumber);
			Assert.AreEqual(1, ((SubmissionsViewModel)result.Model).Submissions.Count());
		}

		[Test]
		public void should_return_submissions_sorted_by_submission_id()
		{
			var unsortedSubmissions = new List<Submission>
			{
				new Submission
				{
					SubmissionId = 5,
					KataId = 1,
					Username = "username2",
					TestsPassed = 3,
					TestsFailed = 2
				},
				new Submission
				{
					SubmissionId = 4,
					KataId = 1,
					Username = "username1",
					TestsPassed = 2,
					TestsFailed = 3
				}
			};

			Setup(unsortedSubmissions);
			var result = _submissionsController.Index(1, null) as ViewResult;

			Assert.IsTrue(result.Model is SubmissionsViewModel);
			Assert.AreEqual(2, ((SubmissionsViewModel)result.Model).Submissions.Count());
			Assert.AreEqual(4, ((SubmissionsViewModel)result.Model).Submissions.First().SubmissionId);
			Assert.AreEqual(5, ((SubmissionsViewModel)result.Model).Submissions.Last().SubmissionId);
		}

		[Test]
		public void can_get_results_for_specific_page()
		{
			var loadSubmissions = SetupSubmissionsForSpecificPage();

			Setup(loadSubmissions);
			var result = _submissionsController.Index(1, 2) as ViewResult;

			Assert.IsTrue(result.Model is SubmissionsViewModel);
			Assert.AreEqual(2, ((SubmissionsViewModel)result.Model).CurrentPageNumber);
			Assert.AreEqual(14, ((SubmissionsViewModel)result.Model).Submissions.Count());
		}
	}
}
