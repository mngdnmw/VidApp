using System;
namespace VidAppDAL
{
    public interface IUnitOfWork: IDisposable
    {
        IVidRepo VidRepo { get; }
        int Complete();

    }
}
