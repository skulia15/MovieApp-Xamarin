using MovieSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Controllers;
using XF.Pages;

namespace XF.ViewModels
{
	class TopRatedViewModel : ListViewModel
	{
		public TopRatedViewModel(/*INavigation navigation,*/ MovieController movieController)
		{
			//this._navigation = this.//= navigation;
			this._movieController = movieController;

			GetMovies();
		}

		public async Task GetMovies()
		{
			// Activate loading Icon
			Loading = true;
			// Search movies by title
			Movies = await _movieController.GetTopRated();
			// Deactivate loading icon
			Loading = false;
			//await this._navigation.PushAsync(new MovieListPage(_movies, _movieController));
		}
		

		public bool Loading
		{
			get => loading;
			set
			{
				loading = value;
				OnPropertyChanged();
			}
		}
	}
}
