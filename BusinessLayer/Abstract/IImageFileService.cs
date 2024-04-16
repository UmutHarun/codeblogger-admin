using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetImageFiles();

        void AddImageFile(ImageFile imageFile);

        ImageFile GetImageFileByID(int id);

        void RemoveImageFile(ImageFile imageFile);

        void EditImageFile(ImageFile imageFile);
    }
}
