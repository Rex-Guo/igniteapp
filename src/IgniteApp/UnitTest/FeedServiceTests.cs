using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IgniteApp.Services;
using IgniteApp.Models;
using System.Threading.Tasks;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class FeedServiceTests
    {
        [TestMethod]
        public async Task TestFeedService()
        {
            FeedService service = new FeedService();
            string newContent = "test content";

            //test SendFeed
            var newFeed = service.SendFeed(new FeedDto { Content = newContent });
            Assert.IsTrue(newFeed.Id == 1);
            Assert.IsTrue(newFeed.Content == newContent);

            //test GetFeedById
            var feed = service.GetFeedById(1);
            Assert.IsTrue(feed != null);
            Assert.IsTrue(feed.Content == newContent);

            //test GetFeeds
            var feeds = await service.GetFeeds();
            Assert.IsTrue(feeds.Count == 1);
            Assert.IsTrue(feeds.First().Content == newContent);
        }
    }
}
