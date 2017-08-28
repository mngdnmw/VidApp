using System;
namespace VidAppBLL.BusinessObjects
{
    public class VideoBO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Director { get; set; }

        public int Duration { get; set; }

        public string DurationInString
        {
            get
            {
                TimeSpan span = TimeSpan.FromMinutes(Duration);
                return span.ToString(@"hh\:mm\:ss");
            }
        }
    }
}
