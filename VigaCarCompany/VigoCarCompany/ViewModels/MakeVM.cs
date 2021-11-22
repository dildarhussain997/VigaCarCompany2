using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VigoCarCompany.ViewModels
{
	public class MakeVM
	{
		public MakeVM()
		{
			// constructor initializes Models, so whenever new object of Make is created it contains initialized empty list of Models so that it does not thorw null reference exception
			Models = new Collection<ModelVM>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public virtual ICollection<ModelVM> Models { get; set; }
	}
}
