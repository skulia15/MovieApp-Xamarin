
using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using XF.Controllers;
using XF.ViewModels;

namespace XF.Pages
{
	public partial class App : Application
	{
		public App()
		{
			MovieController movieController = new MovieController();

			// The root page of your application

			var titleSearchPage = new TitleSearchPage(movieController, new TitleSearchViewModel(movieController));
			var titleNavigationPage = new NavigationPage(titleSearchPage)
			{
				Title = "Search"
			};

			var topRatedPage = new TopRatedPage(movieController, new TopRatedViewModel(movieController));
			var topRatedNavigationPage = new NavigationPage(topRatedPage)
			{
				Title = "Top Rated"
			};

			var popularPage = new TopRatedPage(movieController, new PopularViewModel(movieController));
			var PopularNavigationPage = new NavigationPage(popularPage)
			{
				Title = "Popular"
			};

			var tabbedPage = new TabbedPageInitializer();
			tabbedPage.Children.Add(titleNavigationPage);
			tabbedPage.Children.Add(topRatedNavigationPage);
			tabbedPage.Children.Add(PopularNavigationPage);

			this.MainPage = tabbedPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts

		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
