using System;
using System.Collections.Generic;
using System.Text;
using IgniteApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace IgniteApp.Services
{
    class FeedService : IFeedService
    {
        private List<FeedDto> _feeds;

        private readonly string[] _authors = {"比尔盖茨", "鲍尔默", "纳德拉", "Xamarin" };
        private readonly string[] _photos =  {"bill.png", "steve.png", "satya.png", "icon.png" };
        private readonly string[] _tweets =  { "大家好, 欢迎来到微软Ignite 2016大会! 今天来了这么多人，大家一定对移动开发很重视。", "哈哈, Ignite 2016 来了，知道我是谁吗?", "嗯，移动为先，云为先...", "今天来关注Xamarin的人真多!" };
        private readonly int _total = 4;
        public async Task<List<FeedDto>> GetFeeds()
        {
            if (_feeds == null)
            {
                _feeds = new List<FeedDto>();
                for (int i = 0; i < 20; i++)
                {
                    int radamIndex = i % _total;
                    string picture = null;
                    if (i == 3)
                    {
                        picture = "site.jpg";
                    }
                    _feeds.Add(new FeedDto
                    {
                        Id = i+1,
                        AuthorName = _authors[radamIndex],
                        AuthorPhoto = _photos[radamIndex],
                        Content = _tweets[radamIndex],
                        Picture = picture,
                        Timestamp = DateTime.Now.AddMinutes(-1)
                    });
                }
            }
            await Task.Delay(1500);
            return _feeds;
        }
        public FeedDto SendFeed(FeedDto feed)
        {
            if (_feeds == null)
            {
                _feeds = new List<FeedDto>();
            }
            feed.Id = _feeds.Count + 1;
            feed.Timestamp = DateTime.Now;
            _feeds.Insert(0,feed);
            return feed;
        }
        public FeedDto GetFeedById(int id)
        {
            return _feeds?.Where(x => x.Id == id).FirstOrDefault();
        }

        //public async Task<string> GetResponseString(string url)
        //{
        //    HttpClient client = new HttpClient();
        //    return await client.GetStringAsync(url);
        //}
       
        //public async Task<string> GetResponseString(string url)
        //{
        //    HttpClient client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
        //    return await client.GetStringAsync(url);
        //}
    }
}
