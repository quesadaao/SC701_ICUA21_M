using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL.Repository;
using DO.Interfaces;
using data = DO.Objects;


namespace DAL
{
    public class Categories : ICRUD<data.Categories>
    {
        private Repository<data.Categories> _repo = null;
        public Categories(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Categories>(solutionDbContext);
        }
        public void Delete(data.Categories t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Categories> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Categories GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Categories t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Categories t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
