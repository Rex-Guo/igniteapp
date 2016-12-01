using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using IgniteApp.Models;
using IgniteApp.PageModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IgniteApp.Pages
{
	public class ListPage : ContentPage
	{
		public ListPage ()
		{
            Title = "Ignite 2016 北京";

            ListView feedList = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    return new FeedCell();
                }),
                HasUnevenRows = true,
                IsPullToRefreshEnabled = true,
                SeparatorVisibility = SeparatorVisibility.None,
                BackgroundColor = Color.FromHex("#E2E2E2")
            };

            feedList.SetBinding<ListPageModel>(ListView.ItemsSourceProperty, vm => vm.Feeds);
            feedList.SetBinding<ListPageModel>(ListView.RefreshCommandProperty, vm => vm.RefreshCommand);
            feedList.SetBinding<ListPageModel>(ListView.IsRefreshingProperty, vm => vm.IsLoading);

            Content = feedList;

            ToolbarItem toolbarAdd = new ToolbarItem
            {
                Text = "发布",
            };
            toolbarAdd.SetBinding<ListPageModel>(ToolbarItem.CommandProperty, vm => vm.NewCommand);
            ToolbarItems.Add(toolbarAdd);
		}
        public class FeedCell : ViewCell
        {
            CachedImage photo;
            Label name;
            Label time;
            Image picture;
            Label content;
            public FeedCell()
            {
                Frame cell = new Frame
                {
                    Margin = new Thickness(0,0,0,2),
                    OutlineColor = Color.Gray,
                    HasShadow = false,
                    Padding = 0
                };

                Grid cellLayout = new Grid
                {
                    Padding = 10,
                    BackgroundColor = Color.White,
                    RowDefinitions = new RowDefinitionCollection
                    {
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto }
                    }
                };

                photo = new CachedImage { HeightRequest = 50, VerticalOptions = LayoutOptions.Start };
                photo.Transformations.Add(new CircleTransformation());
                photo.SetBinding<Feed>(CachedImage.SourceProperty, m => m.AuthorPhoto);
                name = new Label { FontSize = Device.GetNamedSize(NamedSize.Small,typeof(Label))};
                name.SetBinding<Feed>(Label.TextProperty, m => m.AuthorName);
                time = new Label { FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)), TextColor = Color.Gray };
                time.SetBinding<Feed>(Label.TextProperty, m => m.TimestampDisplay);

                Grid authorLayout = new Grid
                {
                    ColumnDefinitions = new ColumnDefinitionCollection
                    {
                        new ColumnDefinition {  Width = GridLength.Auto},
                        new ColumnDefinition { Width = GridLength.Star }
                    }
                };
                authorLayout.Children.Add(photo, 0, 0);
                authorLayout.Children.Add(new StackLayout
                {
                    Children =
                                {
                                    name, time
                                }
                }, 1, 0);
                cellLayout.Children.Add(authorLayout, 0, 0);
                
                content = new Label { FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
                content.SetBinding<Feed>(Label.TextProperty, m => m.Content);
                picture = new Image {Aspect = Aspect.AspectFill} ;
                picture.SetBinding<Feed>(Image.SourceProperty, m => m.Picture);
                StackLayout contentLayout = new StackLayout
                {
                    Children = { content, picture }
                };
                cellLayout.Children.Add(contentLayout, 0, 1);

                cell.Content = cellLayout;
                View = cell;
            }

            //protected override void OnTapped()
            //{
            //    base.OnTapped();

            //    System.Diagnostics.Debug.WriteLine($"photo: {photo.Width}, {photo.Height}");
            //    System.Diagnostics.Debug.WriteLine($"name: {name.Width}, {name.Height}, {name.FontSize}");
            //    System.Diagnostics.Debug.WriteLine($"time: {time.Width}, {time.Height} , {time.FontSize}");
            //    System.Diagnostics.Debug.WriteLine($"picture: {picture.Width}, {picture.Height}");
            //    System.Diagnostics.Debug.WriteLine($"content: {content.Width}, {content.Height}, {content.FontSize}");
            //}
        }
	}
}
