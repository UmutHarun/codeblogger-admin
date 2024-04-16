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
    public class CategoryRepository : ICategoryDal
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        DbSet<Category> _categories;

        public void Delete(Category item)
        {
            _categories.Remove(item);
            _context.SaveChanges();
        }

        public List<Category> GetList()
        {
            return _categories.ToList();
        }

        public void Insert(Category item)
        {
            _categories.Add(item);
            _context.SaveChanges();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category item)
        {
            _categories.Update(item);
            _context.SaveChanges();
        }

        public Category Get(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
