using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using SamuraiApp.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SamuraiApp.Business
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

		public async Task<List<Samurai>> GetAllSamurais()
		{
			return await _context.Samurais.ToListAsync();
		}

		public async Task<Samurai> GetSamurai(int id)
		{
			return await _context.Samurais.FindAsync(id);
		}

		public async Task<int> AddSamurais(string[] names)
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
			return await _context.SaveChangesAsync();
		}

		public async Task CreateSamurai(Samurai sam)
		{
			_context.Add(sam);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateSamurai(Samurai sam)
		{
			_context.Entry(sam).State = EntityState.Modified;
			await _context.SaveChangesAsync();
		}

		public async Task DeleteSamurai(int id)
		{
			var samurai = await _context.Samurais.FindAsync(id);
			if(samurai == null)
			{
				return NotFound();
			}

			_context.Samurais.Remove(samurai);
			await _context.SaveChangesAsync();
		}
	}
}
