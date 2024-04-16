using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;

        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

		public void AddHeading(Heading head)
		{
			_headingdal.Insert(head);
		}

		public void EditHeading(Heading head)
		{
			_headingdal.Update(head);
		}

        public Heading GetHeadingById(int id)
        {
            return _headingdal.Get(x => x.HeadingId == id);
        }

        public List<Heading> GetHeadings()
        {
            return _headingdal.GetList();
        }

        public List<Heading> GetHeadingsByCategory(Category cat)
        {
            CategoryManager cm = new CategoryManager(new EfCategoryDal());
            var softCat = cm.GetCategories().Where(x => x.CategoryName == cat.CategoryName).FirstOrDefault();
            var value = _headingdal.GetList().Where(x => x.CategoryId == softCat.CategoryId).ToList();
            return value;
        }

		public void RemoveHeading(Heading head)
		{
			throw new NotImplementedException();
		}
	}
}
