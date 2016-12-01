using System;
using System.Collections.Generic;
using System.Text;

namespace IgniteApp.Models
{
    public class Feed
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhoto { get; set; }
        public DateTime Timestamp { get; set; }
        public string TimestampDisplay
        {
            get
            {
                TimeSpan timePassed = DateTime.Now.Subtract(Timestamp);
                if (timePassed.TotalMinutes<1)
                {
                    return "刚刚";
                }
                else
                {
                    return $"{timePassed.TotalMinutes.ToString("f0")}分钟之前";
                }
            }
        }
        public string Content { get; set; }
        public string Picture { get; set; }
    }
}
