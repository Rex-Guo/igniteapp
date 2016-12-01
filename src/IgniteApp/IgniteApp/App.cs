using FreshMvvm;
using IgniteApp.Models;
using IgniteApp.PageModels;
using IgniteApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace IgniteApp
{
	public class App : Application
	{
		public App ()
		{
            FreshIOC.Container.Register<IFeedService, FeedService>();
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<FeedDto,Feed>());

            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<ListPageModel>())
            {
                BarBackgroundColor = Color.FromHex("#1976D2"),
                BarTextColor = Color.White
            };
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
