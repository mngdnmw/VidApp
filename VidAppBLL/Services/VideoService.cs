using System;
using System.Linq;
using System.Collections.Generic;
using VidAppBLL.BusinessObjects;
using VidAppDAL;
using VidAppDAL.Entities;

namespace VidAppBLL.Services
{
    public class VideoService : IVidService
    {
        DALFacade DALFac;

        public VideoService(DALFacade DALFac)
        {

            this.DALFac = DALFac;
        }

        public VideoBO Create(VideoBO vid)
        {
            //Will automatically call the dispose function at the end
            using (var uow = DALFac.UOW)
            {
                var newVid = uow.VidRepo.Create(Convert(vid));
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Delete(int Id)
        {
            using (var uow = DALFac.UOW)
            {
                var newVid = uow.VidRepo.Delete(Id);
                uow.Complete();
                return Convert(newVid);
            }
        }

        public VideoBO Get(int Id)
        {
            using (var uow = DALFac.UOW)
            {
                return Convert(uow.VidRepo.Get(Id));

            }
        }

        public List<VideoBO> GetAll()
        {
            using (var uow = DALFac.UOW)
            {
                //Grabs each video in the vidRepo and converts each of them and returns a list
				//return uow.VidRepo.GetAll().Select(v => Convert(v)).ToList();
                return uow.VidRepo.GetAll().Select(Convert).ToList();

			}
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = DALFac.UOW)
            {
                var vidFromDB = uow.VidRepo.Get(vid.Id);
                if (vidFromDB == null)
                {
                    throw new InvalidOperationException("Video not found");
                }

                vidFromDB.Name = vid.Name;
                vidFromDB.Director = vid.Director;
                vidFromDB.Duration = vid.Duration;
                uow.Complete();
                return Convert(vidFromDB);
            }

        }

        private Video Convert(VideoBO vid)
        {
            return new Video()
            {
                Id = vid.Id,
                Name = vid.Name,
                Director = vid.Director,
				Duration = vid.Duration
            };

        }


		private VideoBO Convert(Video vid)
		{
			return new VideoBO()
			{
				Id = vid.Id,
				Name = vid.Name,
				Director = vid.Director,
                Duration = vid.Duration
                              
			};

		}
    }
}


