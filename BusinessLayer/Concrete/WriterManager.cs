﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {

        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerdal)
        {
            _writerdal = writerdal;
        }

        public void AddWriter(Writer writer)
        {
            _writerdal.Insert(writer);
        }

        public void EditWriter(Writer writer)
        {
            _writerdal.Update(writer);
        }

        public Writer GetWriterByID(int id)
        {
            return _writerdal.Get(x => x.WriterId == id);
        }

		public List<Writer> GetWriters()
        {
            return _writerdal.GetList();
        }

        public void RemoveWriter(Writer writer)
        {
            _writerdal.Delete(writer);
        }
    }
}
