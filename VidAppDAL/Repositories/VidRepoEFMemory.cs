using System.Collections.Generic;
using System.Linq;
using VidAppDAL.Context;
using VidAppDAL.Entities;

namespace VidAppDAL.Repositories
{
    public class VidRepoEFMemory: IVidRepo
    {
        //Using _ is the same as using this keyword
        InMemoryContext _context;

        public VidRepoEFMemory(InMemoryContext context)
        {
            _context = context;
        }

        public Video Create(Video vid)
        {
            //Adds the vid to the Videos table
            _context.Videos.Add(vid);
            return vid;
        }

        public Video Delete(int id)
        {
            var vid = Get(id);
            _context.Videos.Remove(vid);
            return vid;
        }

        public Video Get(int Id)
        {
            return _context.Videos.FirstOrDefault(x => x.Id == Id);
        }

        public List<Video> GetAll()
        {
            return _context.Videos.ToList();
        }
    }
}
