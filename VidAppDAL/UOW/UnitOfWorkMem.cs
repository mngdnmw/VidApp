using System;
using VidAppDAL.Context;
using VidAppDAL.Repositories;

namespace VidAppDAL.UOW
{
    public class UnitOfWorkMem : IUnitOfWork
    {
        public IVidRepo VidRepo { get; internal set; }
        private InMemoryContext context;

        public UnitOfWorkMem()
        {
            context = new InMemoryContext();
            VidRepo = new VidRepoEFMemory(context);
        }

        public int Complete()
        {
            //The number of objects written to the underlying database
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
