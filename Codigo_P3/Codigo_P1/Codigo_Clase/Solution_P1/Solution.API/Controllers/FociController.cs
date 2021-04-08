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
    public class FociController : ControllerBase
    {
        private readonly SolutionDbContext _context;
        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public FociController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Foci
        [HttpGet]
        public async Task<ActionResult<IEnumerable<datamodels.Foci>>> GetFoci()
        {
            // Declaramos una variable para traer la informacion
            var aux = await new Solution.BS.Foci(_context).GetAllWithAsync();

            var mapaux = _mapper.Map<IEnumerable<data.Foci>, IEnumerable<datamodels.Foci>>(aux).ToList();
            return mapaux;
            //return await new Solution.BS.Foci(_context).GetAllWithAsync();

        }

        // GET: api/Foci/5
        [HttpGet("{id}")]
        public async Task<ActionResult<datamodels.Foci>> GetFoci(int id)
        {
            var foci = await new Solution.BS.Foci(_context).GetOneByIdWithAsync(id);
            var mapaux = _mapper.Map<data.Foci, datamodels.Foci>(foci);

            if (mapaux == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Foci/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFoci(int id, datamodels.Foci foci)
        {
            if (id != foci.FocusId)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = _mapper.Map<datamodels.Foci, data.Foci >(foci);

                new Solution.BS.Foci(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!FociExists(id))
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

        // POST: api/Foci
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<datamodels.Foci>> PostFoci(datamodels.Foci foci)
        {
            var mapaux = _mapper.Map<datamodels.Foci, data.Foci>(foci);

            new Solution.BS.Foci(_context).Insert(mapaux);

            return CreatedAtAction("GetFoci", new { id = foci.FocusId }, foci);
        }

        // DELETE: api/Foci/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<datamodels.Foci>> DeleteFoci(int id)
        {
            var foci = new Solution.BS.Foci(_context).GetOneById(id);
            if (foci == null)
            {
                return NotFound();
            }

            new Solution.BS.Foci(_context).Delete(foci);
            var mapaux = _mapper.Map<data.Foci, datamodels.Foci>(foci);


            return mapaux;
        }

        private bool FociExists(int id)
        {
            return (new Solution.BS.Foci(_context).GetOneById(id) != null);
        }
    }
}
