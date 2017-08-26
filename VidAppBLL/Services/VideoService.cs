using System;
using System.Collections.Generic;
using System.Linq;
using VidAppBE;
using VidAppDAL;

namespace VidAppBLL.Services
{
    public class VideoService : IVidService
    {
        IVidRepo repo;

        public VideoService(IVidRepo repo){

            this.repo = repo;
        }
       
        public Video Create(Video vid)
        {
            return repo.Create(vid);
        }

        public Video Delete(int Id)
        {
            return repo.Delete(Id);
        }

        public Video Get(int Id)
        {
            return repo.Get(Id);
        }

        public List<Video> GetAll()
        {
            return repo.GetAll();
        }

        public Video Update(Video vid)
        {
            var vidFromDB = Get(vid.Id);
            if (vidFromDB == null)
            {
                throw new InvalidOperationException("Video not found");
            }

            vidFromDB.Name = vid.Name;
            vidFromDB.Director = vid.Director;
            vidFromDB.Genre = vid.Genre;

            return vidFromDB;

        }
    }
}
