using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Katas.Mocking.DataAccess.Contexts;
using Katas.Mocking.DataAccess.Entities;
using Katas.Mocking.DataAccess.Models;

namespace Katas.Mocking.DataAccess.Controllers
{
	public class SubmissionsController : Controller
	{
		private IDatabaseContext _db = null;
		private SubmissionsViewModel _submissionsViewModel = new SubmissionsViewModel();
		private const int RECORDS_PER_PAGE = 14;

		public IDatabaseContext Context
		{
			get
			{
				if (_db == null)
					_db = new DatabaseContext();
				return _db;
			}
			set { _db = value; }
		}

		// GET: Batches
		public ActionResult Index(int? kataId, int? pageNumber)
		{
			if (kataId == null)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			var submissions = Context.Submissions.Where(a => a.KataId == kataId.Value);

			var activeRecordCount = submissions.Count();
			var selectedPageNumber = (pageNumber.HasValue) ? pageNumber.Value : 1;
			var skipRecords = (selectedPageNumber - 1) * RECORDS_PER_PAGE;

			_submissionsViewModel.Submissions = GetViewModel(submissions.OrderBy(s => s.SubmissionId)
				.Skip(skipRecords).Take(RECORDS_PER_PAGE).ToList());

			_submissionsViewModel.KataId = kataId.Value;
			_submissionsViewModel.PageSize = RECORDS_PER_PAGE;
			_submissionsViewModel.CurrentPageNumber = selectedPageNumber;
			_submissionsViewModel.EndPageNumber = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(activeRecordCount) / Convert.ToDouble(RECORDS_PER_PAGE))));
			return View(_submissionsViewModel);
		}

		internal IEnumerable<SubmissionViewModel> GetViewModel(IEnumerable<Submission> submissions)
		{
			var submissionViewModelList = new List<SubmissionViewModel>();

			foreach (var submission in submissions)
			{
				var submissionViewModel = new SubmissionViewModel
				{
					KataId = submission.KataId,
					SubmissionId = submission.SubmissionId,
					Username = submission.Username,
					TestsPassed = submission.TestsPassed,
					TestsFailed = submission.TestsFailed,
					CreateBy = submission.CreateBy,
					CreateDate = submission.CreateDate,
					ModifyBy = submission.ModifyBy,
					ModifyDate = submission.ModifyDate
				};
				submissionViewModelList.Add(submissionViewModel);
			}
			return submissionViewModelList;
		}
	}
}
