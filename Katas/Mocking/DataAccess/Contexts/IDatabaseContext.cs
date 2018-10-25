using System;
using Katas.Mocking.DataAccess.Entitites;
using System.Data.Entity;
using Katas.Mocking.DataAccess.Entities;

namespace Katas.Mocking.DataAccess.Contexts
{
	public interface IDatabaseContext : IDisposable
    {
        DbSet<Kata> Katas { get; set; }
        DbSet<Submission> Submissions { get; set; }

        int SaveChanges();

		//To support NUnit testing use indirection on Entry object	
	    void SetEntry(object currentEntry, object newEntry);
    }
}