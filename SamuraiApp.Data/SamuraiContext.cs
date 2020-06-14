using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;

namespace SamuraiApp.Data
{
	public class SamuraiContext : DbContext
	{
		public DbSet<Samurai> Samurais { get; set; }
		public DbSet<Quote> Quotes { get; set; }
		public DbSet<Clan> Clans { get; set; }
		public DbSet<Battle> Battles { get; set; }

		public SamuraiContext()
		{

		}

		public SamuraiContext(DbContextOptions options): base(options)
		{
			// disable tracking since it will not be utilized in the Asp.net API application
			//ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
		}

		public static readonly ILoggerFactory ConsoleLoggerFactory =
			LoggerFactory.Create(builder =>
		{
			builder
			.AddFilter((category, level) =>
			category == DbLoggerCategory.Database.Command.Name &&
			level == LogLevel.Information)
			.AddConsole();      // will log operations to console - required Microsoft.Extensions.Logging.Console
		});

		// method only required for console app
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if(!optionsBuilder.IsConfigured)
			{
				optionsBuilder
					.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppTestData");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SamuraiBattle>().HasKey(k => new { k.SamuraiId, k.BattleId });
			modelBuilder.Entity<Horse>().ToTable("Horses");
		}
	}
}
