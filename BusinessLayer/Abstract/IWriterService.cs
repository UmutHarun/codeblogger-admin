using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriters();

        void AddWriter(Writer writer);

        Writer GetWriterByID(int id);

        void RemoveWriter(Writer writer);

        void EditWriter(Writer writer);
    }
}
