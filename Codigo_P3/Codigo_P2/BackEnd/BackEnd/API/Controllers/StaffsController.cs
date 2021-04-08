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
    public class StaffsController : ControllerBase
    {
        private readonly SolutionDbContext _context;

        //Declaracion del automapper para poder caster los objetos 
        private readonly IMapper _mapper;

        public StaffsController(SolutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
            [HttpGet]
        public async Task<ActionResult<IEnumerable<DataModels.Staffs>>> GetStaffs()
        {
            var aux = new BS.Staffs(_context).GetAll();

            var mapaux = _mapper.Map<IEnumerable<data.Staffs>, IEnumerable<datamodels.Staffs>>(aux).ToList();
            return mapaux;
        }
    }
}
