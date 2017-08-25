using System;
using System.Collections.Generic;
using System.Linq;
using VidAppBE;
using VidAppDAL;

namespace VidAppBLL.Services
{
    public class VideoService : IVidService
    {
        public Video Create(Video vid)
        {
            Video newVid;
            FakeDB.VideosList.Add(newVid=new Video()
            {
                Id = FakeDB.Id,
                Name = vid.Name,
                Director = vid.Director,
                Genre = vid.Genre
			});

            return newVid;
        }

        public Video Delete(int Id)
        {
            //Put a video from the VideoList into the local variable x
            //If the id of the local variable matches the id we input, then it will save the video as vid
            //If there are multiple videos with the same id, then it will return the first one
            //Combines LINQ and lambda expression
            //Will return null if if cannot find the video with the specifed Id
            var vid = Get(Id);
            //Throws exception if cannot find the video
            var vid1 = FakeDB.VideosList.First(x => x.Id == Id);
			//Returns list of videos with the Id
            var vid2 = FakeDB.VideosList.Where(x => x.Id == Id).ToList();

            FakeDB.VideosList.Remove(vid);
            //Will return null or actual vid 
			return vid;
        }

        public Video Get(int Id)
        {
           return FakeDB.VideosList.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(FakeDB.VideosList);
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
