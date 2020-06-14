using Microsoft.VisualStudio.TestTools.UnitTesting;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Diagnostics;

namespace SamuraiApp.Test
{
	[TestClass]
	public class DatabaseTest
	{
		[TestMethod]
		public void CanInsertSamurai()
		{
			using(var context = new SamuraiContext())
			{
				//context.Database.EnsureDeleted();
				context.Database.EnsureCreated();

				var sam = new Samurai();
				context.Add(sam);
				Debug.WriteLine($"Before save: {sam.Id}");
				context.SaveChanges();
				Debug.WriteLine($"After save: {sam.Id}");

				Assert.AreNotEqual(0, sam.Id);
			}

		}
	}
}
