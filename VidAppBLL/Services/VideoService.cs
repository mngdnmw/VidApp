using System;
using System.Collections.Generic;
using System.Linq;
using VidAppBE;
using VidAppDAL;

namespace VidAppBLL.Services
{
    public class VideoService : IVidService
    {
        DALFacade DALFac;

        public VideoService(DALFacade DALFac){

            this.DALFac = DALFac;
        }
       
        public Video Create(Video vid)
        {
            //Will automatically call the dispose function at the end
            using (var uow = DALFac.UOW){
                var newVid = uow.VidRepo.Create(vid);
                uow.Complete();
                return newVid;
            }
        }

        public Video Delete(int Id)
        {
			using (var uow = DALFac.UOW)
			{
                var newVid = uow.VidRepo.Delete(Id);
				uow.Complete();
				return newVid;
			}
        }

        public Video Get(int Id)
        {
			using (var uow = DALFac.UOW)
			{
                return uow.VidRepo.Get(Id);
				
			}
        }

        public List<Video> GetAll()
        {
			using (var uow = DALFac.UOW)
			{
				return uow.VidRepo.GetAll();

			}
        }

        public Video Update(Video vid)
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
				vidFromDB.Genre = vid.Genre;
                uow.Complete();
				return vidFromDB;
            }

           

        }
    }
}
