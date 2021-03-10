using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Solution.DAL.EF;
using AutoMapper;
using datamodels = Solution.API.DataModels;

namespace Solution.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public GroupsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Groups>>> GetGroups()
        {
            // Declaramos una variable para traer la informacion
            var aux = new Solution.BS.Groups(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Groups>, IEnumerable<datamodels.Groups>>(aux).ToList();
            return mapaux;

        }

        // GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Groups>> GetGroups(int id)
        {
            var groups = new Solution.BS.Groups(_context).GetOneById(id);

            if (groups == null)
            {
                return NotFound();
            }
            var mapaux = _mapper.Map<data.Groups, datamodels.Groups >(groups);
            return mapaux;
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroups(int id, datamodels.Groups groups)
        {
            if (id != groups.GroupId)
            {
                return BadRequest();
            }          

            try
            {
                var mapaux = _mapper.Map<datamodels.Groups, data.Groups>(groups);
                new Solution.BS.Groups(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!GroupsExists(id))
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

        // POST: api/Groups
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Groups>> PostGroups(datamodels.Groups groups)
        {
            var mapaux = _mapper.Map<datamodels.Groups, data.Groups>(groups);
            new Solution.BS.Groups(_context).Insert(mapaux);

            return CreatedAtAction("GetGroups", new { id = groups.GroupId }, groups);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Groups>> DeleteGroups(int id)
        {
            var groups = new Solution.BS.Groups(_context).GetOneById(id);
            if (groups == null)
            {
                return NotFound();
            }

            new Solution.BS.Groups(_context).Delete(groups);
            var mapaux = _mapper.Map<data.Groups, datamodels.Groups>(groups);

            return mapaux;
        }

        private bool GroupsExists(int id)
        {
            return (new Solution.BS.Groups(_context).GetOneById(id) != null);
        }
    }
}
