using System;

namespace Katas.Mocking.DataAccess.Models
{
	public class SubmissionViewModel
	{
		public int SubmissionId { get; set; }

		public int KataId { get; set; }

		public string Username { get; set; }

		public int TestsPassed { get; set; }

		public int TestsFailed { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ModifyDate { get; set; }

		public string CreateBy { get; set; }

		public string ModifyBy { get; set; }
	}
}