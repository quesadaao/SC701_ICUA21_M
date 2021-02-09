using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Groups : ICRUD<data.Groups>
    {
        private Repository<data.Groups> _repo = null;
        public Groups(SolutionDbContext solutionDbContext) 
        {
            _repo = new Repository<data.Groups>(solutionDbContext);
        }
        public void Delete(data.Groups t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Groups> Getll()
        {
            return _repo.GetAll();
        }

        public data.Groups GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Groups t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Groups t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
