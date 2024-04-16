using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class HeadingRepository : IHeadingDal
    {
        private readonly Context _context;

        DbSet<Heading> _headings;
        public HeadingRepository(Context context)
        {
            _context = context;
        }

        public void Delete(Heading item)
        {
            throw new NotImplementedException();
        }

        public Heading Get(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Heading> GetList()
        {
            return _context.Headings.Include(x => x.Category).ToList(); 
        }

        public void Insert(Heading item)
        {
            throw new NotImplementedException();
        }

        public List<Heading> List(Expression<Func<Heading, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Heading item)
        {
            throw new NotImplementedException();
        }
    }
}
