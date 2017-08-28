using System.Collections.Generic;
using System.Linq;
using VidAppDAL.Entities;

namespace VidAppDAL.Repositories
{
    class VidRepoFakeDB: IVidRepo
    {

		#region FakeDB
		//Need to be captialised because they are static
        private static List<Video> VideosList = new List<Video>();
		private static int Id = 1;
		#endregion

		public Video Create(Video vid)
		{
			Video newVid;
			VideosList.Add(newVid = new Video()
			{
				Id = Id++,
				Name = vid.Name,
				Director = vid.Director,
				
			});

			return newVid;
		}

        public Video Delete(int id)
        {
			//Put a video from the VideoList into the local variable x
			//If the id of the local variable matches the id we input, then it will save the video as vid
			//If there are multiple videos with the same id, then it will return the first one
			//Combines LINQ and lambda expression
			//Will return null if if cannot find the video with the specifed Id
			var vid = Get(Id);
			//Throws exception if cannot find the video
			var vid1 = VideosList.First(x => x.Id == Id);
			//Returns list of videos with the Id
			var vid2 = VideosList.Where(x => x.Id == Id).ToList();

			VideosList.Remove(vid);
			//Will return null or actual vid 
			return vid;
        }

        public Video Get(int id)
        {
            return VideosList.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return new List<Video>(VideosList);
        }
    }
}
