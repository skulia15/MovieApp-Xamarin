
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

namespace XF.ViewModels
{
    public class MovieViewModel : INotifyPropertyChanged
	{
		private INavigation _navigation;
		private Movie _movie;
		MovieController _movieController;

		public MovieViewModel(INavigation navigation, Movie movie, MovieController movieController)
		{
			this._navigation = navigation;
			this._movieController = movieController;
			_movie = movie;
		}

		public Movie Movie
		{
			get { return this._movie; }
			set
			{
				this._movie = value;
				OnPropertyChanged();
			}
		}

		public int? Runtime
		{
			get { return this._movie.Runtime; }
			set
			{
				this._movie.Runtime = value;
				OnPropertyChanged();
			}
		}

		public string Tagline
		{
			get { return this._movie.Tagline; }
			set
			{
				this._movie.Tagline = value;
				OnPropertyChanged();
			}
		}

		public async Task GetAdditionalInfo()
		{
			var movieInfo = await _movieController.GetMovieByIdAsync(_movie.Id);
			Runtime = movieInfo.Runtime;
			Tagline = movieInfo.Tagline;
		} 

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
