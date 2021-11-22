using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VigoCarCompany.Models
{
	// models contains informations about car models available 

	[Table("Models")]
	public class Model
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		//navigation or relationships properties
		[ForeignKey("Make")]
		public int MakeId { get; set; }
		public virtual Make Make { get; set; }



	}
}
