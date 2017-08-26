using System;
using System.Collections.Generic;
using VidAppBE;

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
