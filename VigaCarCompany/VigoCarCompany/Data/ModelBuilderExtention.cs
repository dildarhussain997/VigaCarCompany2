using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigoCarCompany.Models;

namespace VigoCarCompany.Data
{
	// this is an extention class, it extent the functionality of an existing class
	// see how extension classes and method works 
	public static class ModelBuilderExtention
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Make>().HasData(
					new Make { Id = 1, Name = "Make1", },
					new Make { Id = 2, Name = "Make2", },
					new Make { Id = 3, Name = "Make3", }
				);


			modelBuilder.Entity<Model>().HasData(
					new Model { Id = 1, Name = "Model1 Make1", MakeId = 1 },
					new Model { Id = 2, Name = "Model2 Make1", MakeId = 1 },
					new Model { Id = 3, Name = "Model3 Make1", MakeId = 1 },
					new Model { Id = 4, Name = "Model4 Make2", MakeId = 2 },
					new Model { Id = 5, Name = "Model5 Make2", MakeId = 2 },
					new Model { Id = 6, Name = "Model6 Make2", MakeId = 2 },
					new Model { Id = 7, Name = "Model7 Make3", MakeId = 3 },
					new Model { Id = 8, Name = "Model8 Make3", MakeId = 3 },
					new Model { Id = 9, Name = "Model9 Make3", MakeId = 3 }

				);
		}
	}
}
