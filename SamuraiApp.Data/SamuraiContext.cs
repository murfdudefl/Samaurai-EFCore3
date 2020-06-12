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

		public static readonly ILoggerFactory ConsoleLoggerFactory =
			LoggerFactory.Create(builder =>
		{
			builder
			.AddFilter((category, level) =>
			category == DbLoggerCategory.Database.Command.Name &&
			level == LogLevel.Information)
			.AddConsole();		// will log operations to console - required Microsoft.Extensions.Logging.Console
		});
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = SamuraiAppData")
				.UseLoggerFactory(ConsoleLoggerFactory);

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SamuraiBattle>().HasKey(k => new { k.SamuraiId, k.BattleId });
			modelBuilder.Entity<Horse>().ToTable("Horses");
		}
	}
}
