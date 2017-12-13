using MovieSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF.Controllers;
using XF.Pages;

namespace XF.ViewModels
{
	public class MovieListViewModel : ListViewModel
	{

		public MovieListViewModel(INavigation navigation, List<Movie> movies, MovieController movieController)
		{
			this._movieController = movieController;
			this._navigation = navigation;
			_movies = movies;
		}
	}
}
