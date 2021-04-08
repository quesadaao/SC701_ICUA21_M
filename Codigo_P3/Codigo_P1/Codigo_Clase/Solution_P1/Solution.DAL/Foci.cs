using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfases;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Foci : ICRUD<data.Foci>
    {
        //Definicion de la variable que va implementar el repositorio extendido a utilizar
        //ya que necesitamos agregar el include en los metodos del repository
        private RepositoryFoci _repo = null;

        public Foci(SolutionDbContext solutionDbContext) 
        {
            _repo = new RepositoryFoci(solutionDbContext);
        }

        public void Delete(data.Foci t)
        {
            _repo.Delete(t);
            _repo.Commit();
        }

        public IEnumerable<data.Foci> GetAll()
        {
            return _repo.GetAll();
        }

        public data.Foci GetOneById(int id)
        {
            return _repo.GetOneById(id);
        }

        public void Insert(data.Foci t)
        {
            _repo.Insert(t);
            _repo.Commit();
        }

        public void Update(data.Foci t)
        {
            _repo.Update(t);
            _repo.Commit();
        }

        public async Task<IEnumerable<data.Foci>> GetAllWithAsync() 
        {
            return await _repo.GetAllWithAsAsync();
        }

        public async Task<data.Foci> GetOneByIdWithAsync(int id)
        {
            return await _repo.GetByOneWithAsAsync(id);
        }
    }
}
