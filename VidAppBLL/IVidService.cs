using System;
using System.Collections.Generic;
using VidAppBE;

namespace VidAppBLL
{
    public interface IVidService
    {
        //C
        Video Create(Video vid);
        //R
        List<Video> GetAll();
        Video Get(int id);
        //U
        Video Update(Video vid);
        //D
        Video Delete(int id);
    }
}
