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
    public class WriterRepository : IWriterDal
    {
        private readonly Context _context;
        public WriterRepository(Context context)
        {
            _context = context;
        }

        DbSet<Writer> _writers { get; set; }

        public void Delete(Writer item)
        {
            _writers.Remove(item);
            _context.SaveChanges();
        }

        public Writer Get(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetList()
        {
            return _writers.ToList();
        }

        public void Insert(Writer item)
        {
            _writers.Add(item);
            _context.SaveChanges();
        }

        public List<Writer> List(Expression<Func<Writer, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Writer item)
        {
           _writers.Update(item);
           _context.SaveChanges();
        }
    }
}
