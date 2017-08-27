using System;
using VidAppDAL.Repositories;

namespace VidAppDAL
{
    public class DALFacade
    {
        public IVidRepo VidRepo
        {
            get { return new VidRepoEFMemory(new Context.InMemoryContext()); }
        }
    }
}
