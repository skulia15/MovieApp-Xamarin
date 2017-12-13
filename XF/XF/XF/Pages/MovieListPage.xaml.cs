using MovieSearch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Controllers;
using XF.ViewModels;

namespace XF.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieListPage : ContentPage
	{
		MovieController _movieController;
		List<Movie> _movies;
		MovieListViewModel viewModel;

		public MovieListPage(List<Movie> movies, MovieController movieController)
		{
			this._movieController = movieController;
			this._movies = movies;
			viewModel = new MovieListViewModel(this.Navigation, movies, _movieController);
			this.BindingContext = viewModel;
			this.InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await getCast(_movies);
		}

		//if(Device.RuntimePlatform == Device.UWP){
		//	// Running on windows
		//}

		private async Task getCast(List<Movie> movies)
		{
			foreach (Movie movie in movies)
			{
				try
				{
					movie.ListCast = await _movieController.GetCastByIdAsync(movie.Id);
					movie.Cast = movie.CastToString();
				}
				catch(Exception e)
				{
					movie.ListCast = null;
				}
				viewModel.Movies = movies;
			}
			
		}
	}
}