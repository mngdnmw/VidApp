using System.Collections.Generic;
using VidAppDAL.Entities;

namespace VidAppDAL
{
    public interface IVidRepo
    {
		//C
		Video Create(Video vid);
		//R
		List<Video> GetAll();
		Video Get(int id);
		//D
		Video Delete(int id);
    }
}
