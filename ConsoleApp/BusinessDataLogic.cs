using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using SamuraiApp.Data;

namespace ConsoleApp
{
	public class BusinessDataLogic
	{
		private SamuraiContext _context;

		public BusinessDataLogic()
		{
			_context = new SamuraiContext();
		}
		public BusinessDataLogic(SamuraiContext context)
		{
			_context = context;
		}

		public int AddSamurais(string[] names)
		{
			var sams = new List<Samurai>();
			foreach(var name in names)
			{
				sams.Add(new Samurai()
				{
					Name = name
				});
			}
			_context.AddRange(sams);
			var result = _context.SaveChanges();
			return result;
		}

		public int CreateSamurai(Samurai sam)
		{
			_context.Add(sam);
			return _context.SaveChanges();
		}
	}
}
