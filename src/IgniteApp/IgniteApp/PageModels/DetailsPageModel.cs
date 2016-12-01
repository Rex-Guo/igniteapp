using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using IgniteApp.Services;

namespace IgniteApp.PageModels
{
    [ImplementPropertyChanged]
    public class DetailsPageModel:FreshMvvm.FreshBasePageModel
    {
        public string NewMessage { get; set; }
        public Command SendCommand { get; set; }

        private IFeedService _feedService;
        public DetailsPageModel(IFeedService feedService)
        {
            _feedService = feedService;

            SendCommand = new Command(Send);
        }
        public void Send()
        {
            if (NewMessage != null)
            {
                _feedService.SendFeed(new FeedDto
                {
                    Content = NewMessage,
                    AuthorName = "Xamarin",
                    AuthorPhoto = "steve.png"
                });

                NewMessage = null;

                CoreMethods.PopPageModel();
            }
        }
    }
}
