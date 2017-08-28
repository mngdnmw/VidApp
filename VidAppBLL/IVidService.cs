using System.Collections.Generic;
using VidAppBLL.BusinessObjects;

namespace VidAppBLL
{
    public interface IVidService
    {
        //C
        VideoBO Create(VideoBO vid);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int id);
        //U
        VideoBO Update(VideoBO vid);
        //D
        VideoBO Delete(int id);
    }
}
