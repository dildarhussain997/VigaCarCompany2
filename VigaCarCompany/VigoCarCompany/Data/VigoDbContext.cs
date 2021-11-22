using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigoCarCompany.Models;

namespace VigoCarCompany.Data
{
	public class VigoDbContext : DbContext
	{
		public VigoDbContext(DbContextOptions<VigoDbContext> options) :base(options)
		{

		}

		public DbSet<Model> Models { get; set; }
		public DbSet<Make> Makes { get; set; }

		//this is a seed method for database
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// seed method is an extention method, here we write seperate seed method just to keep seeding code clean
			modelBuilder.Seed();

			base.OnModelCreating(modelBuilder);
		}


		//// you can provide connection string for database here or in Startup class
		////below function is used to provide connection string to EF core for database 
		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		////using . for local server 
		//	optionsBuilder.UseSqlServer("Server=.; Database=VegaCarDB; Integrated Security=True;");
		//	base.OnConfiguring(optionsBuilder);
		//}
	}
}
