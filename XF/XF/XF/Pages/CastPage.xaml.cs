using MovieSearch;
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
	public partial class CastPage : ContentPage
	{
		private Movie _movie;
		MovieViewModel viewModel;
		public CastPage(MovieController movieController, Movie movie)
		{
			this._movie = movie;
			viewModel = new MovieViewModel(this.Navigation, movie, movieController);
			this.BindingContext = viewModel;
			InitializeComponent();
		}
	}
}