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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutdal;
        public AboutManager(IAboutDal aboutdal) 
        {
            _aboutdal = aboutdal;
        }
        public void AddAbout(About about)
        {
            _aboutdal.Insert(about);
        }

        public void EditAbout(About about)
        {
            _aboutdal.Update(about);
        }

        public About GetAboutByID(int id)
        {
            return _aboutdal.Get(x => x.AboutId == id);
        }

        public List<About> GetAbouts()
        {
            return _aboutdal.GetList();
        }

        public void RemoveAbout(About about)
        {
            _aboutdal.Delete(about);
        }
    }
}
