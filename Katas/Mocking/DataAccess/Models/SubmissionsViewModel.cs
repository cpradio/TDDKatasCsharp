using System.Collections.Generic;

namespace Katas.Mocking.DataAccess.Models
{
	public class SubmissionsViewModel
	{
		public int CurrentPageNumber { get; set; }
		public int EndPageNumber { get; set; }
		public IEnumerable<SubmissionViewModel> Submissions { get; set; }
		public int PageSize { get; set; }
		public int KataId { get; set; }
	}
}