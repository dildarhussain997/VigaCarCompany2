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
	public class MakeController : ControllerBase
	{
		#region Properties
		// properties
		private readonly VigoDbContext context;
        private readonly IMapper mapper;
		#endregion

		#region Constuctor
		// constructor
		public MakeController(VigoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
		#endregion

		#region API Functions

		#region Get All Objects
		// GET: api/Make
		[HttpGet]
        public async Task<ActionResult<IEnumerable<MakeVM>>> GetMakes()
        {
            var make = (IEnumerable<Make>)await context.Makes.Include(m => m.Models).ToListAsync();
            if (make != null)
            {
                //TODO: can shorten code to one line 
                var makeVM = mapper.Map<IEnumerable<Make>, IEnumerable<MakeVM>>(make);
                return Ok(makeVM);
            }
            return NoContent();
        }
		#endregion

		#region Get Single Object
		// GET: api/Make/5
		[HttpGet("{id}")]
        public async Task<ActionResult<MakeVM>> GetMake(int id)
        {
            //todo: check id for null 
            var make = await context.Makes.Include(m => m.Models).FirstOrDefaultAsync(m => m.Id == id);
            if (make == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<MakeVM>(make));

        }
		#endregion

		#region Update Object
		// PUT: api/Make/5
		[HttpPut("{id}")]
        public async Task<IActionResult> PutMake(int id, MakeVM makeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "model state is not valid");
            }

            if (id != makeVM.Id)
            {
                return BadRequest();
            }

            context.Entry(mapper.Map<Make>(makeVM)).State = EntityState.Modified;

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
                if (!MakeExists(id))
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
		// POST: api/Make
		[HttpPost]
        public async Task<ActionResult<MakeVM>> PostMake(MakeVM makeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Error", "Model state is not valid");
            }

            var rowsEffected = await context.SaveChangesAsync();
            if (rowsEffected > 0)
            {
                return CreatedAtAction("GetMake", new { id = makeVM.Id }, makeVM);
            }

            //TODO: can return error specific to problem
            return BadRequest();
        }
		#endregion

		#region Delete Object
		// DELETE: api/Make/5
		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMake(int id)
        {
            var make = await context.Makes.FindAsync(id);
            if (make == null)
            {
                return NotFound();
            }

            context.Makes.Remove(make);
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
		private bool MakeExists(int id)
        {
            return context.Makes.Any(e => e.Id == id);
        }


		#endregion

	}
}
