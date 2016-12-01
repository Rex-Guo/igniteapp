using IgniteApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteApp.Services
{

    public class FeedDto
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorPhoto { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
    }
    public interface IFeedService
    {
        Task<List<FeedDto>> GetFeeds();
        FeedDto SendFeed(FeedDto feed);
        FeedDto GetFeedById(int id);
    }
}
