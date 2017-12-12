using MovieSearch;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF
{
	public class MovieListViewModel : INotifyPropertyChanged
	{
		private INavigation _navigation;
		private List<Movie> _movieList;
		private Movie _selectedMovie;

		public MovieListViewModel(INavigation navigation, List<Movie> movies)
		{
			this._navigation = navigation;
			_movieList = movies;
		}

		//private async void GetCast()
		//{
		//	_cast = await movieController.GetCastByIdAsync(_movie.Id);
		//}

		public List<Movie> Movies
		{
			get { return this._movieList; }
			set {
				this._movieList = value;
				OnPropertyChanged();
			}
		}

		public Movie SelectedMovie {
			get => this._selectedMovie;
			set {
				if (value != null)
				{
					this._selectedMovie = value;
					this.OnPropertyChanged(); 

					this._navigation.PushAsync(new MoviePage(this._selectedMovie), true);
					this._selectedMovie = null;
					this.OnPropertyChanged();
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		
	}
}
