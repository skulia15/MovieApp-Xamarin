using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Controllers;

namespace XF.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopRatedPage : ContentPage
	{
		List<Movie> _movies;
		MovieController _movieController;
		public TopRatedPage(MovieController movieController)
		{
			this._movieController = movieController;
			InitializeComponent();
			
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			//// Activate loading Icon
			//this.loading.IsRunning = true;
			//// Search movies by title
			//this._movies = await _movieController.GetTopRated();
			//// Deactivate loading icon
			//this.loading.IsRunning = false;
			//await this.Navigation.PushAsync(new MovieListPage(this._movies, _movieController));
		}
	}

}