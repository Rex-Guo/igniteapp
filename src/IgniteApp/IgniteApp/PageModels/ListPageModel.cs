using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using IgniteApp.Models;
using IgniteApp.Services;
using Xamarin.Forms;
using System.Threading.Tasks;
using PropertyChanged;

namespace IgniteApp.PageModels
{
    [ImplementPropertyChanged]
    public class ListPageModel: FreshMvvm.FreshBasePageModel
    {
        public ObservableCollection<Feed> Feeds { get; private set; }
        public Command RefreshCommand { get; private set; }
        public Command NewCommand { get; private set; }
        public bool IsLoading { get; private set; }

        private IFeedService _feedService;
        public ListPageModel(IFeedService feedService)
        {
            _feedService = feedService;
            Feeds = new ObservableCollection<Feed>();
            RefreshCommand = new Command(async ()=> { await LoadFeedsAsync(); });
            NewCommand = new Command(GoToDetailsPage);
        }
        public async Task LoadFeedsAsync()
        {
            IsLoading = true;

            Feeds.Clear();
            var results = await _feedService.GetFeeds();
            foreach(var feedDto in results)
            {
                Feed feed = AutoMapper.Mapper.Map<Feed>(feedDto);
                Feeds.Add(feed);
            }

            IsLoading = false;
        }
        private void GoToDetailsPage()
        {
            CoreMethods.PushPageModel<DetailsPageModel>();
        }
        protected override async void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);

            if (Feeds.Count == 0)
            {
                await LoadFeedsAsync();
            }
        }
    }
}
