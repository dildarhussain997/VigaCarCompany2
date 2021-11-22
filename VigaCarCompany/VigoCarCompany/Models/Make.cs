using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VigoCarCompany.Models
{
	// Make provide information about features of car models, i-e what features does a car have
	[Table("Makes")]
	public class Make
	{
		public Make()
		{
			// constructor initializes Models, so whenever new object of Make is created it contains initialized empty list of Models so that it does not thorw null reference exception
			Models = new Collection<Model>();
		}

		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		//navigation or relationships properties 

		// one to many (one make can belong to many models)
		public virtual ICollection<Model> Models { get; set; }


	}
}
