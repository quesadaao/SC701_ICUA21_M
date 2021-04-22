using DAL.EF;
using DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = DO.Objects;


namespace BS
{
    public class Categories : ICRUD<data.Categories>
    {
        private SolutionDbContext context;
        public Categories(SolutionDbContext _context)
        {
            context = _context;
        }
        public void Delete(data.Categories t)
        {
            new DAL.Categories(context).Delete(t);
        }

        public IEnumerable<data.Categories> GetAll()
        {
            return new DAL.Categories(context).GetAll();
        }

        public data.Categories GetOneById(int id)
        {
            return new DAL.Categories(context).GetOneById(id);
        }

        public void Insert(data.Categories t)
        {
            new DAL.Categories(context).Insert(t);
        }

        public void Update(data.Categories t)
        {
            new DAL.Categories(context).Update(t);
        }
    }
}
