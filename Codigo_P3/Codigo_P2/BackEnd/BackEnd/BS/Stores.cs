using DAL.EF;
using DAL.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace BS
{
    public class Stores : ICRUD<data.Stores>
    {
        private SolutionDbContext context;
        public Stores(SolutionDbContext _context)
        {
            context = _context;
        }

        public void Delete(data.Stores t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<data.Stores> GetAll()
        {
            return new DAL.Stores(context).GetAll();
        }

        public data.Stores GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Stores t)
        {
            throw new NotImplementedException();
        }

        public void Update(data.Stores t)
        {
            throw new NotImplementedException();
        }
    }
}
