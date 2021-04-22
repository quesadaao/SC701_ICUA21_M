using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using data = DO.Objects;
using AutoMapper;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public CategoriesController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Categories>>> GetCategories()
        {
            return new BS.Categories(_context).GetAll().ToList();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Categories>> GetCategories(int id)
        {

            var categories = new BS.Categories(_context).GetOneById(id);

            if (categories == null)
            {
                return NotFound();
            }

            return categories;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategories(int id, data.Categories categories)
        {
            if (id != categories.CategoryId)
            {
                return BadRequest();
            }

            try
            {

                new BS.Categories(_context).Update(categories);
            }
            catch (Exception ee)
            {
                if (!CategoriesExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Categories>> PostCategories(data.Categories categories)
        {

            new BS.Categories(_context).Insert(categories);

            return CreatedAtAction("GetCategories", new { id = categories.CategoryId }, categories);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Categories>> DeleteCategories(int id)
        {

            var categories = new BS.Categories(_context).GetOneById(id);
            if (categories == null)
            {
                return NotFound();
            }

            new BS.Categories(_context).Delete(categories);

            return categories;

        }

        private bool CategoriesExists(int id)
        {
            return (new BS.Categories(_context).GetOneById(id) != null);
        }
    }
}
