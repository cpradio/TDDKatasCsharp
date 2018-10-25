using Katas.DataAccess.Entitites;
using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Katas.DataAccess.Entities;

namespace Katas.DataAccess
{
	public class DatabaseContext : DbContext, IDatabaseContext
	{
		public DbSet<Submission> Submissions { get; set; }
		public DbSet<Kata> Katas { get; set; }

		public DatabaseContext() : base("name=DB:Database")
		{
		}

		//Level of indirection to accommodate mocking Entry via interface
		//https://stackoverflow.com/questions/5035323/mocking-or-faking-dbentityentry-or-creating-a-new-dbentityentry
		public void SetEntry(object currentEntry, object newEntry)
		{
			Entry(currentEntry).CurrentValues.SetValues(newEntry);
		}
	}
}
