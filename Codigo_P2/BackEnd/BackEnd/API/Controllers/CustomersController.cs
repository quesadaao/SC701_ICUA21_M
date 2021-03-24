using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using AutoMapper;
//using datamodels = DAL.API.DataModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        public CustomersController(SolutionDbContext context)
        {
            _context = context;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Customers>>> GetCustomers()
        {
            return new BS.Customers(_context).GetAll().ToList();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Customers>> GetCustomers(int id)
        {
            var customers = new BS.Customers(_context).GetOneById(id);

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomers(int id, data.Customers customers)
        {
            if (id != customers.CustomerId)
            {
                return BadRequest();
            }

            try
            {
                new BS.Customers(_context).Update(customers);
            }
            catch (Exception ee)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.Customers>> PostCustomers(data.Customers customers)
        {
            new BS.Customers(_context).Insert(customers);

            return CreatedAtAction("GetCustomers", new { id = customers.CustomerId }, customers);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Customers>> DeleteCustomers(int id)
        {
            var customers = new BS.Customers(_context).GetOneById(id);
            if (customers == null)
            {
                return NotFound();
            }

            new BS.Customers(_context).Delete(customers);

            return customers;
        }

        private bool CustomersExists(int id)
        {
            return (new BS.Customers(_context).GetOneById(id) != null);
        }
    }
}
