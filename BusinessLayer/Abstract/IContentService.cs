using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContents();

        void AddContent(Content content);

        Content GetContentByID(int id);

        void RemoveContent(Content content);

        void EditContent(Content content);

        public List<Content> GetListById(int id);
        public List<Content> GetContentsByWriter(int id);
    }
}
