using MovieSearch;
using MovieSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MoviePage : ContentPage
	{
		MovieViewModel viewModel;
		public MoviePage (Movie movie)
		{
			viewModel = new MovieViewModel(this.Navigation, movie);
			this.BindingContext = viewModel;
			InitializeComponent ();
			this.titleAndYear.Text = movie.Title + " (" + movie.Year + ")";
			this.stats.Text = movie.GetStringedGenres();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			await viewModel.GetAdditionalInfo();
			this.stats.Text = viewModel.Runtime + " min | " + viewModel.Movie.GetStringedGenres();
		}
	}
}