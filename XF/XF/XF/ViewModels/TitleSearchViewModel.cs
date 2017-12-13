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
	class TitleSearchViewModel : INotifyPropertyChanged
	{
		private INavigation _navigation;
		MovieController _movieController;
		public ICommand TitleSearchCommand { protected set; get; }
		public string title;
		public bool loading;


		public TitleSearchViewModel(INavigation navigation, MovieController movieController)
		{
			this._navigation = navigation;
			this._movieController = movieController;

			TitleSearchCommand = new Command(async () =>
			{
				if (this.title != null && this.title != "")
				{
					// Activate loading Icon
					Loading = true;
					// Search movies by title
					List<Movie> movies = await movieController.GetMoviesByTitleAsync(this.title);
					// Deactivate loading icon
					Loading = false;
					await this._navigation.PushAsync(new MovieListPage(movies, movieController, new MovieListViewModel(_navigation, movies, movieController)));
				}
			});
		}

		public string Title
		{
			get => title;
			set
			{
				if (value != null)
				{
					title = value;
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

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}