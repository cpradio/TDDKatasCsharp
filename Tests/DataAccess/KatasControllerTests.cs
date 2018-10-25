using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Katas.DataAccess;
using Katas.DataAccess.Controllers;
using Katas.DataAccess.Entities;
using Katas.DataAccess.Entitites;
using Katas.DataAccess.Models;
using Moq;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class DbContextTests
	{
		private KatasController _katasController;
		private void SetupKatasController(List<Kata> dataToLoad = null)
		{
			if (dataToLoad == null)
				dataToLoad = new List<Kata>
				{
					new Kata
					{
						KataId = 1,
						Name = "LeapYear",
						Instructions = "Determine if the given year, is a leap year.",
						Submissions = new List<Submission>()
					}
				};
			var kataData = dataToLoad.AsQueryable();

			var mockKata = new Mock<DbSet<Kata>>();
			mockKata.As<IQueryable<Kata>>().Setup(m => m.ElementType).Returns(kataData.ElementType);
			mockKata.As<IQueryable<Kata>>().Setup(m => m.Expression).Returns(kataData.Expression);
			mockKata.As<IQueryable<Kata>>().Setup(m => m.Provider).Returns(kataData.Provider);
			mockKata.Setup(a => a.Find(It.IsAny<object[]>())).Returns<object[]>(id => kataData.FirstOrDefault(b => b.KataId == (int)id[0]));
			
			var mockDb = new Mock<IDatabaseContext>();
			mockDb.Setup(m => m.Katas).Returns(mockKata.Object);

			_katasController = new KatasController();
			_katasController.Context = mockDb.Object;
		}
		private static List<Kata> SetupMultipleKatas()
		{
			var loadKatas = new List<Kata>();
			for (int kata = 1; kata <= 18; kata++)
			{
				loadKatas.Add(
					new Kata
					{
						KataId = kata,
						Name = $"Kata{kata}",
						CreateDate = DateTime.Today,
						ModifyDate = DateTime.Today,
						Submissions = new List<Submission>()
					}
				);
			}

			return loadKatas;
		}

		[Test]
		public void request_index_with_missing_kata_id()
		{
			SetupKatasController();
			var result = _katasController.Index(null, null) as ViewResult;

			Assert.IsTrue(result.Model is KatasViewModel);
			Assert.AreEqual(1, ((KatasViewModel)result.Model).CurrentPageNumber);
			Assert.AreEqual(1, ((KatasViewModel)result.Model).KataViewModelList.Count());
		}

		[Test]
		public void can_get_results_for_a_specific_batchid()
		{
			var loadKatas = SetupMultipleKatas();
			SetupKatasController(loadKatas);
			var result = _katasController.Index(1, null) as ViewResult;

			Assert.IsTrue(result.Model is KatasViewModel);
			Assert.AreEqual(1, ((KatasViewModel)result.Model).CurrentPageNumber);
			Assert.AreEqual(1, ((KatasViewModel)result.Model).EndPageNumber);
			Assert.AreEqual(1, ((KatasViewModel)result.Model).KataViewModelList.Count());
		}

		[Test]
		public void can_get_results_for_specific_page()
		{
			var loadKatas = SetupMultipleKatas();
			SetupKatasController(loadKatas);
			var result = _katasController.Index(null, 2) as ViewResult;

			Assert.IsTrue(result.Model is KatasViewModel);
			Assert.AreEqual(2, ((KatasViewModel)result.Model).CurrentPageNumber);
			Assert.AreEqual(4, ((KatasViewModel)result.Model).KataViewModelList.Count());
		}

		[TestCase(2)]
		[TestCase(99)]
		public void should_return_2_when_page_number_provided_equals_the_max_pages_or_higher(int pageNumber)
		{
			var loadKatas = SetupMultipleKatas();
			SetupKatasController(loadKatas);
			var result = _katasController.Index(null, 2) as ViewResult;

			Assert.IsTrue(result.Model is KatasViewModel);
			Assert.AreEqual(2, ((KatasViewModel)result.Model).CurrentPageNumber);
		}
	}
}
