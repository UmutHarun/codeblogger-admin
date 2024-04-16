using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void AddContent(Content content)
        {
            throw new NotImplementedException();
        }

        public void EditContent(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetContentByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetContents()
        {
            throw new NotImplementedException();
        }

        public void RemoveContent(Content content)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListById(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetContentsByWriter(int id)
        {
            return _contentDal.GetList().Where(x => x.Writer.WriterId == id).ToList();
        }
    }
}
