using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigoCarCompany.Models;
using VigoCarCompany.ViewModels;

namespace VigoCarCompany.MappingProfiles
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Make, MakeVM>().ReverseMap();
			CreateMap<Model, ModelVM>().ReverseMap();

		}
	}
}
