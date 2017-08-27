using System;
using Microsoft.EntityFrameworkCore;
using VidAppBE;

namespace VidAppDAL.Context
{
    public class InMemoryContext: DbContext
    {
        static DbContextOptions<InMemoryContext> options = new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;

        //base() allows us to call the super class
        //Options that we want in memory
        public InMemoryContext():base(options)
        {
        }

        public DbSet<Video> Videos { get; set; }
    }
}
