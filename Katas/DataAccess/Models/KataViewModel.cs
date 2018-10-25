using System;

namespace Katas.DataAccess.Models
{
	public class KataViewModel
	{
		public int KataId { get; set; }

		public string Name { get; set; }

		public string Instructions { get; set; }

		public int NumberOfSubmissions { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ModifyDate { get; set; }

		public string CreateBy { get; set; }

		public string ModifyBy { get; set; }
	}
}