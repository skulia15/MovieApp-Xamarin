using MovieSearch;
using MovieSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Controllers;
using XF.ViewModels;

namespace XF.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		MovieViewModel viewModel;
		MovieController _movieController;
		public MoviePage (Movie movie, MovieController movieController)
		{
			this._movieController = movieController;
			viewModel = new MovieViewModel(this.Navigation, movie, _movieController);
			this.BindingContext = viewModel;
			InitializeComponent ();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await viewModel.GetAdditionalInfo();
			this.stats.Text = viewModel.Runtime + " min | " + viewModel.Movie.Genres;
		}
		
	}
}