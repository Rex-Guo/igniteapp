using IgniteApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IgniteApp.Models;

namespace UnitTest
{
    class MockFeedService : IFeedService
    {
        private List<FeedDto> _feeds;

        public MockFeedService()
        {
            _feeds = new List<FeedDto>();
        }
        public FeedDto GetFeedById(int id)
        {
            return _feeds?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<FeedDto>> GetFeeds()
        {
            return _feeds;
        }

        public FeedDto SendFeed(FeedDto feed)
        {
            feed.Id = _feeds.Count + 1;
            _feeds.Insert(0, feed);
            return feed;
        }
    }
}
