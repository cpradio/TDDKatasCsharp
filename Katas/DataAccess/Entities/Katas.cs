using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Katas.DataAccess.Entities;

namespace Katas.DataAccess.Entitites
{
	[Table("Katas")]
	public class Kata
	{
		public Kata()
		{
			if (Submissions == null)
			{
				Submissions = new Collection<Submission>();
			}
		}

		[Display(Name = "Kata ID")]
		public int KataId { get; set; }

		[Display(Name = "Name")]
		[StringLength(25)]
		public string Name { get; set; }

		[Display(Name = "Instructions")]
		public string Instructions { get; set; }

		[Display(Name = "Submissions")]
		public virtual ICollection<Submission> Submissions { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ModifyDate { get; set; }

		public string CreateBy { get; set; }

		public string ModifyBy { get; set; }
	}
}
