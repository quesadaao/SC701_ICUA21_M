using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using data = DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.EF;
using AutoMapper;
using datamodels = API.DataModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public StoresController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/Stores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Stores>>> GetStores()
        {
            var aux = new BS.Stores(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Stores>, IEnumerable<datamodels.Stores>>(aux).ToList();
            return mapaux;
        }
    }
}
