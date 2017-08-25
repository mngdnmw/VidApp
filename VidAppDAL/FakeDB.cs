using System;
using System.Collections.Generic;
using VidAppBE;

namespace VidAppDAL
{
    public class FakeDB
    {
        #region FakeDB
        //Need to be captialised because they are static

        public static List<Video> VideosList = new List<Video>();
        public static int Id = 1;
        #endregion
    }
}
