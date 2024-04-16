using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadings();

        List<Heading> GetHeadingsByCategory(Category cat);

        Heading GetHeadingById (int id);

		void RemoveHeading(Heading head);

		void EditHeading(Heading head);

		void AddHeading(Heading head);
	}
}
