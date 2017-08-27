using System;
using VidAppDAL.Repositories;
using VidAppDAL.UOW;

namespace VidAppDAL
{
    public class DALFacade
    {
        public IVidRepo VidRepo
        {
            get { return new VidRepoEFMemory(new Context.InMemoryContext()); }
        }

        public IUnitOfWork UOW
        { get { return new UnitOfWorkMem(); }}
    }
}
