using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VigoCarCompany.Data;
using VigoCarCompany.Models;
using VigoCarCompany.ViewModels;

namespace VigoCarCompany.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ModelController : ControllerBase
	{
		#region Properties
		// properties
		private readonly VigoDbContext context;
		private readonly IMapper mapper;
		#endregion

		#region Constuctor
		// constructor
		public ModelController(VigoDbContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}
		#endregion


		#region API Functions

		#region Get All Objectss
		// GET: api/Model
		[HttpGet]
		public async Task<ActionResult<IEnumerable<ModelVM>>> GetModels()
		{
			var model = await context.Models.ToListAsync();


			if (model != null)
			{
				return Ok(mapper.Map<IEnumerable<Model>, IEnumerable<ModelVM>>(model));
			}
			return NoContent();
		}
		#endregion

		#region Get Single Object
		// GET: api/Model/5
		[HttpGet("{id}")]
		public async Task<ActionResult<ModelVM>> GetModel(int id)
		{
			//todo: check id for null 

			var model = await context.Models.FindAsync(id);

			if (model == null)
			{
				return NotFound();
			}
			return Ok(mapper.Map<ModelVM>(model));
		}
		#endregion

		#region Update Object
		// PUT: api/Model/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutModel(int id, [FromBody] ModelVM modelVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("Error", "model state is not valid");
			}

			if (id != modelVM.Id)
			{
				return BadRequest();
			}

			context.Entry(mapper.Map<Model>(modelVM)).State = EntityState.Modified;

			try
			{
				var rowsEffected = await context.SaveChangesAsync();
				if (rowsEffected > 0)
				{
					//TODO:  you can return here the newly updated object too     

					return Ok();
				}
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ModelExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}
		#endregion

		#region Add New Object
		// POST: api/Model
		[HttpPost]
		public async Task<ActionResult<ModelVM>> PostModel([FromBody] ModelVM modelVM)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("Error", "Model state is not valid");
			}

			var model = mapper.Map<Model>(modelVM);
			context.Models.Add(model);
			var rowsEffected = await context.SaveChangesAsync();
			if (rowsEffected > 0)
			{
				return CreatedAtAction("GetModel", new { id = modelVM.Id }, modelVM);
			}

			//TODO: can return error specific to problem
			return BadRequest();
		}
		#endregion

		#region Delete Object
		// DELETE: api/Model/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteModel(int id)
		{
			var model = await context.Models.FindAsync(id);
			if (model == null)
			{
				return NotFound();
			}

			context.Models.Remove(model);
			var rowsEffected = await context.SaveChangesAsync();
			if (rowsEffected > 0)
			{
				return Ok();
			}
			return NoContent();
		}
		#endregion


		#endregion

		#region Private Functions 
		private bool ModelExists(int id)
		{
			return context.Models.Any(e => e.Id == id);
		}
		#endregion

	}
}
