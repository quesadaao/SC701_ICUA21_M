using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.EF;
using DAL.Repository;
using DAL.DO.Interfaces;
using data = DAL.DO.Objects;

namespace DAL
{
    public class Staffs : ICRUD<data.Staffs>
    {
        private Repository<data.Staffs> _repo = null;
        public Staffs(SolutionDbContext solutionDbContext)
        {
            _repo = new Repository<data.Staffs>(solutionDbContext);
        }

        public void Delete(data.Staffs t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Staffs> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Staffs GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Staffs t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Staffs t)
        {
            _repo.Update(t);
            _repo.Commit();
        }
    }
}
