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
	class PopularViewModel : ListViewModel
	{
		public PopularViewModel(MovieController movieController)
		{
			this._movieController = movieController;

			GetMovies();
		}

		public async Task GetMovies()
		{
			// Activate loading Icon
			Loading = true;
			// Search movies by title
			Movies = await _movieController.GetPopular();
			// Deactivate loading icon
			Loading = false;
			await GetCast(Movies);
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
