using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ServiceModel.Security;

namespace Katas.Mocking.DataAccess.Entities
{
	[Table("Submissions")]
	[Serializable]
	public class Submission
	{
		[Display(Name = "Submission ID")]
		public int SubmissionId { get; set; }


		[Display(Name = "Kata ID")]
		public int KataId { get; set; }

		[Display(Name = "Username")]
		[StringLength(25)]
		public string Username { get; set; }

		[Display(Name = "Number of Tests Passed")]
		public int TestsPassed { get; set; }

		[Display(Name = "Number of Tests Failed")]
		public int TestsFailed { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ModifyDate { get; set; }

		public string CreateBy { get; set; }

		public string ModifyBy { get; set; }
	}
}
