using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Diagnostics;

namespace SamuraiApp.Test
{
	[TestClass]
	public class InMemoryTest
	{
		[TestMethod]
		public void CanInsertSamurai()
		{
			var builder = new DbContextOptionsBuilder();
			builder.UseInMemoryDatabase("CanInsertSamurai");	// name denotes instance - can be shared arcoss test methods

			using(var context = new SamuraiContext(builder.Options))
			{
				//context.Database.EnsureDeleted();
				//context.Database.EnsureCreated();

				var sam = new Samurai();
				context.Add(sam);
				//context.SaveChanges();

				//Assert.AreNotEqual(0, sam.Id);
				Assert.AreEqual(EntityState.Added, context.Entry(sam).State);
			}

		}
	}
}
