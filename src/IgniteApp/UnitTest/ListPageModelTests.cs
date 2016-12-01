using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IgniteApp.PageModels;
using FreshMvvm;
using System.Threading.Tasks;
using IgniteApp.Services;
using IgniteApp.Models;

namespace UnitTest
{
    [TestClass]
    public class ListPageModelTests
    {
        [TestMethod]
        public void TestListPageModel()
        {
            IFeedService mockFeedService = new MockFeedService();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<FeedDto, Feed>());

            mockFeedService.SendFeed(new FeedDto { Content = "test" });

            ListPageModel pageModel = new ListPageModel(mockFeedService);
            pageModel.RefreshCommand.Execute(null);
            Assert.IsTrue(pageModel.Feeds.Count == 1);
        }
    }
}
