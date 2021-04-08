using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;


namespace Solution.BS
{
    public class Foci : ICRUD<data.Foci>
    {
        private SolutionDbContext _repo = null;

        public Foci(SolutionDbContext solutionDbContext) 
        {
            _repo = solutionDbContext;
        }

        public void Delete(data.Foci t)
        {
            new DAL.Foci(_repo).Delete(t);
        }

        public IEnumerable<data.Foci> GetAll()
        {
            return new DAL.Foci(_repo).GetAll();
        }

        public data.Foci GetOneById(int id)
        {
            return new DAL.Foci(_repo).GetOneById(id);
        }

        public void Insert(data.Foci t)
        {
            new DAL.Foci(_repo).Insert(t);
        }

        public void Update(data.Foci t)
        {
            new DAL.Foci(_repo).Update(t);
        }

        public async Task<IEnumerable<data.Foci>> GetAllWithAsync()
        {
            return await new DAL.Foci(_repo).GetAllWithAsync();
        }

        public async Task<data.Foci> GetOneByIdWithAsync(int id)
        {
            return await new DAL.Foci(_repo).GetOneByIdWithAsync(id);
        }
    }
}
