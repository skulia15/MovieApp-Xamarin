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
	class TitleSearchViewModel : ListViewModel
	{
		public ICommand TitleSearchCommand { protected set; get; }
		public string searchTitle;
		private bool loading;
		private bool noResult = false;
		private bool someResult = false;


		public TitleSearchViewModel(MovieController movieController)
		{
			_movieController = movieController;
			TitleSearchCommand = new Command(async () =>
			{
				if (this.searchTitle != null && this.SearchTitle != "")
				{
					// Activate loading Icon
					Loading = true;
					// Search movies by title
					NoResult = false;
					await GetMoviesAsync();

					if (this.Movies.Count != 0)
					{
						SomeResult = true;
						NoResult = false;
					}
					else
					{
						SomeResult = false;
						NoResult = true;
					}
					// Deactivate loading icon
					Loading = false;
					GetCast(Movies);
				}
			});
		}

		public bool SomeResult
		{
			get => someResult;
			set
			{
				someResult = value;
				OnPropertyChanged();
			}
		}

		public bool NoResult
		{
			get => noResult;
			set
			{
				noResult = value;
				OnPropertyChanged();
			}
		}

		public string SearchTitle
		{
			get => searchTitle;
			set
			{
				if (value != null)
				{
					searchTitle = value;
					OnPropertyChanged();
				}
			}
		}

		public bool Loading {
			get => loading;
			set
			{
				loading = value;
				OnPropertyChanged();
			}
		}

		internal override async Task GetMoviesAsync()
		{
			// Activate loading Icon
			Loading = true;
			// Search movies by title
			Movies = await _movieController.GetMoviesByTitleAsync(searchTitle);
			// Deactivate loading icon
			Loading = false;
		}
	}
}