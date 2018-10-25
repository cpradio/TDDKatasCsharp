using System.Collections.Generic;

namespace Katas.Mocking.DataAccess.Models
{
	public class KatasViewModel
	{
		public int CurrentPageNumber { get; set; }
		public int EndPageNumber { get; set; }
		public IEnumerable<KataViewModel> KataViewModelList { get; set; }
		public int PageSize { get; set; }
	}
}