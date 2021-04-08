using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL.Repository
{
    public interface IRepositoryFoci: IRepository<data.Foci>
    {
        Task<IEnumerable<data.Foci>> GetAllWithAsAsync();

        Task<data.Foci> GetByOneWithAsAsync(int id);
    }
}
