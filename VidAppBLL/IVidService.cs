using System;
using System.Collections.Generic;
using VidAppBE;

namespace VidAppBLL
{
    public interface IVidService
    {

        //C
        Video Creat(Video vid);
        //R
        List<Video> GetAll();
        Video get(int id);
        //U
        Video Update(Video vid);
        //D
        bool Delete(int id);
    }
}
