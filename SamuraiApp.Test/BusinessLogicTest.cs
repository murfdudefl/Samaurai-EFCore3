using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using ConsoleApp;
using System;
using System.Collections.Generic;
using System.Text;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System.Linq;

namespace SamuraiApp.Test
{
	[TestClass]
	public class BusinessLogicTest
	{
		[TestMethod]
		public void AddMultipleSamuraisCheckCount()
		{
			var builder = new DbContextOptionsBuilder();
			builder.UseInMemoryDatabase("AddMultipleSamuraisCheckCount");
			using(var context = new SamuraiContext(builder.Options))
			{
				var busLogic = new BusinessDataLogic(context);
				string[] names = { "Bob", "Pete", "John" };
				var count = busLogic.AddSamurais(names);
				Assert.AreEqual(names.Length, count);
			}
		}
		[TestMethod]
		public void CreateSamuraiCheck()
		{
			var builder = new DbContextOptionsBuilder();
			builder.UseInMemoryDatabase("CreateSamuraiCheck");
			using(var context = new SamuraiContext(builder.Options))
			{
				var busLogic = new BusinessDataLogic(context);
				var sam = new Samurai()
				{
					Name = "Ugly"
				};
				var count = busLogic.CreateSamurai(sam);
			}
			using(var chkContext = new SamuraiContext(builder.Options))
			{
				//var sam = chkContext.Samurais.FirstOrDefault(s => s.Id == 1);
				var sam = chkContext.Samurais.Find(1);
				Assert.AreEqual(sam.Name, "Ugly");
				Assert.AreEqual(chkContext.Samurais.Count(), 1);
			}
		}
	}
}
