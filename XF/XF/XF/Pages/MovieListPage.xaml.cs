using MovieSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		ListViewModel viewModel;

		public MovieListPage(List<Movie> movies, MovieController movieController, ListViewModel viewModel)
		{
			this._movieController = movieController;
			this._movies = movies;
			this.viewModel = viewModel;// new MovieListViewModel(this.Navigation, movies, _movieController);
			this.BindingContext = viewModel;
			this.InitializeComponent();
		}

		protected async override void OnAppearing()
		{
			base.OnAppearing();
			await viewModel.GetCast(_movies);
		}

		//if(Device.RuntimePlatform == Device.UWP){
		//	// Running on windows
		//}

	}
}