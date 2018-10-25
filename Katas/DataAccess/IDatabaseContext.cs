using System;
using Katas.DataAccess.Entitites;
using System.Data.Entity;
using System.Diagnostics;
using Katas.DataAccess.Entities;

namespace Katas.DataAccess
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