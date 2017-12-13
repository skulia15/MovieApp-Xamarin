using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace XF.Pages
{
	public partial class App : Application
	{
		public App()
		{

			// The root page of your application
			var titleSearchPage = new TitleSearchPage();
			var titleNavigationPage = new NavigationPage(titleSearchPage)
			{
				Title = "Search"
			};

			var topRatedPage = new TopRatedPage();
			var topRatedNavigationPage = new NavigationPage(topRatedPage)
			{
				Title = "Top Rated"
			};

			var tabbedPage = new TabbedPage();
			tabbedPage.Children.Add(titleNavigationPage);
			tabbedPage.Children.Add(topRatedNavigationPage);

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
