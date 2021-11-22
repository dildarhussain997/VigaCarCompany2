using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VigoCarCompany.ViewModels
{
	public class ModelVM
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }


		public int MakeId { get; set; }
	}
}
