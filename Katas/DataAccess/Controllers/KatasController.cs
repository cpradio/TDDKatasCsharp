using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Katas.DataAccess.Entitites;
using Katas.DataAccess.Models;

namespace Katas.DataAccess.Controllers
{
	public class KatasController : Controller
	{
		private IDatabaseContext _db = null;
		private KatasViewModel _katasViewModel = new KatasViewModel();
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
			var katas = (kataId.HasValue) ? Context.Katas.Where(a => a.KataId == kataId.Value) : Context.Katas;

			var activeRecordCount = katas.Count();
			var selectedPageNumber = (pageNumber.HasValue) ? pageNumber.Value : 1;
			var skipRecords = (selectedPageNumber - 1) * RECORDS_PER_PAGE;

			_katasViewModel.KataViewModelList = GetViewModel(katas
				.OrderByDescending(d => d.CreateDate).ThenByDescending(d => d.KataId)
				.Skip(skipRecords).Take(RECORDS_PER_PAGE).ToList());

			_katasViewModel.PageSize = RECORDS_PER_PAGE;
			_katasViewModel.CurrentPageNumber = selectedPageNumber;
			_katasViewModel.EndPageNumber = Convert.ToInt32(Math.Ceiling((Convert.ToDouble(activeRecordCount) / Convert.ToDouble(RECORDS_PER_PAGE))));
			return View(_katasViewModel);
		}

		internal IEnumerable<KataViewModel> GetViewModel(IEnumerable<Kata> katas)
		{
			var kataViewModelList = new List<KataViewModel>();

			foreach (var kata in katas)
			{
				var kataViewModel = new KataViewModel
				{
					KataId = kata.KataId,
					Name = kata.Name,
					Instructions = kata.Instructions,
					NumberOfSubmissions = kata.Submissions.Count(),
					CreateBy = kata.CreateBy,
					CreateDate = kata.CreateDate,
					ModifyBy = kata.ModifyBy,
					ModifyDate = kata.ModifyDate
				};
				kataViewModelList.Add(kataViewModel);
			}
			return kataViewModelList;
		}
	}
}
