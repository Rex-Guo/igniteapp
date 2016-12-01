using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreshMvvm;
using IgniteApp.PageModels;
using System.Threading.Tasks;
using IgniteApp.Services;
using Moq;

namespace UnitTest
{
    [TestClass]
    public class DetailPageModelTests
    {
        [TestMethod]
        public async Task TestDetailsViewModel()
        {
            IFeedService mockFeedService = new MockFeedService();
            var mockCoreMethods = new Mock<IPageModelCoreMethods>();
            DetailsPageModel pageModel = new DetailsPageModel(mockFeedService);
            pageModel.CoreMethods = mockCoreMethods.Object;

            pageModel.NewMessage = "new message";
            pageModel.SendCommand.Execute(null);
            Assert.IsTrue(pageModel.NewMessage == null);

            var feeds = await mockFeedService.GetFeeds();
            Assert.IsTrue(feeds.Count == 1);
        }
    }
}
