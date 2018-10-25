using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Katas.DataAccess.Models
{
	public class KatasViewModel
	{
		public int CurrentPageNumber { get; set; }
		public int EndPageNumber { get; set; }
		public IEnumerable<KataViewModel> KataViewModelList { get; set; }
		public int PageSize { get; set; }
	}
}