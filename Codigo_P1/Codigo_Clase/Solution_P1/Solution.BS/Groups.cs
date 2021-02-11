using Solution.DAL.EF;
using Solution.DO.Interfases;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Groups : ICRUD<data.Groups>
    {
        private SolutionDbContext context;
        public Groups(SolutionDbContext _context) 
        {
            context = _context;
        }
        public void Delete(data.Groups t)
        {
            new DAL.Groups(context).Delete(t);
        }

        public IEnumerable<data.Groups> GetAll()
        {
            return new DAL.Groups(context).GetAll();
        }

        public data.Groups GetOneById(int id)
        {
            return new DAL.Groups(context).GetOneById(id);
        }

        public void Insert(data.Groups t)
        {
            new DAL.Groups(context).Insert(t);
        }

        public void Update(data.Groups t)
        {
            new DAL.Groups(context).Update(t);
        }
    }
}
