using DAL.EF;
using DAL.Repository;
using DAL.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Stores : ICRUD<data.Stores>
    {
        private Repository<data.Stores> _repo = null;
        public Stores(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Stores>(solutionDbContext);
        }
        public void Delete(data.Stores t)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<data.Stores> GetAll()
        {
            return _repo.GetAll();
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
