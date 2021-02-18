using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;
using Microsoft.EntityFrameworkCore;

namespace Solution.DAL.Repository
{
    // Clase que es una extension de repository 
    // Implementa la interfase IRepositoryFoci
    // Esta interfase se encarga de implementar metodos que se necesitan para devolver la informacion asociada a la tabla de FK(include)
    public class RepositoryFoci : Repository<data.Foci>, IRepositoryFoci
    {
        //Constructor correspondiente a la case 
        //Parametro Cotnext para poderlo recibir, cargar al Repository y utilizar en esta misma clase
        public RepositoryFoci(SolutionDbContext context):base(context) 
        { 
            
        }
        
        public async Task<IEnumerable<Foci>> GetAllWithAsAsync()
        {
            return await _db.Foci
                .Include(m => m.Group)
                .ToListAsync();
        }

        public async Task<Foci> GetByOneWithAsAsync(int id)
        {
            return await _db.Foci
             .Include(m => m.Group)
             .SingleOrDefaultAsync(m => m.FocusId == id);
        }

        //Metodo para obtener el context cargado del repository y asi utilizarlo en esta clase
        private SolutionDbContext _db 
        {
            get { return dbContext as SolutionDbContext; }
        }
    }
}
