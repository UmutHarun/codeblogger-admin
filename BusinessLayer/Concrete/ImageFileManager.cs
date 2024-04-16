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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _iImageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _iImageFileDal = imageFileDal;
        }

        public void AddImageFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void EditImageFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public ImageFile GetImageFileByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetImageFiles()
        {
            return _iImageFileDal.GetList();
        }

        public void RemoveImageFile(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
