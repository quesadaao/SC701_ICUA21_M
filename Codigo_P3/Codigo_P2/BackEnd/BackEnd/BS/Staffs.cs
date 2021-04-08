using DAL.EF;
using DAL.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace BS
{
    public class Staffs : ICRUD<data.Staffs>
    {
        private SolutionDbContext context;
        public Staffs(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Staffs t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<data.Staffs> GetAll()
        {
            return new DAL.Staffs(context).GetAll();
        }

        public data.Staffs GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Staffs t)
        {
            throw new NotImplementedException();
        }

        public void Update(data.Staffs t)
        {
            throw new NotImplementedException();
        }
    }
}
