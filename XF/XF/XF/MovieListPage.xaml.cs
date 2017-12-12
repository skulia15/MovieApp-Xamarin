using MovieSearch;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MovieListPage : ContentPage
	{
		MovieController movieController = new MovieController();
		MovieListViewModel viewModel;
		public MovieListPage(List<Movie> movies)
		{
			viewModel = new MovieListViewModel(this.Navigation, movies);
			this.BindingContext = viewModel;
			this.InitializeComponent();
			getCast(movies);
		}

		private async Task getCast(List<Movie> movies)
		{
			foreach (Movie movie in movies)
			{
				try
				{
					movie.ListCast = await movieController.GetCastByIdAsync(movie.Id);
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