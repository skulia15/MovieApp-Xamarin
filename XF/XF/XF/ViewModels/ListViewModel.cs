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
	public abstract class ListViewModel : INotifyPropertyChanged
	{
		protected INavigation _navigation;
		protected MovieController _movieController;
		protected List<Movie> _movies;
		protected Movie _selectedMovie;
		protected bool loading;
		protected bool _isRefreshing = false;

		internal void SetNavigation(INavigation navigation)
		{
			this._navigation = navigation;
		}

		public async Task GetCast(List<Movie> movies)
		{
			foreach (Movie movie in movies)
			{
				try
				{
					movie.ListCast = await _movieController.GetCastByIdAsync(movie.Id);
					movie.Cast = movie.CastToString();
				}
				catch (Exception e)
				{
					movie.ListCast = null;
				}
				this.Movies = movies;
			}
		}

		public List<Movie> Movies
		{
			get { return this._movies; }
			set
			{
				this._movies = value;
				OnPropertyChanged();
			}
		}

		public Movie SelectedMovie
		{
			get => this._selectedMovie;
			set
			{
				if (value != null)
				{
					this._selectedMovie = value;
					this.OnPropertyChanged();
					this._navigation.PushAsync(new MoviePage(this._selectedMovie, _movieController), true);
					this._selectedMovie = null;
					this.OnPropertyChanged();
				}
			}
		}

		public ICommand RefreshCommand
		{
			get
			{
				return new Command(async () =>
				{
					IsRefreshing = true;

					GetMoviesAsync();
					await GetCast(Movies);

					IsRefreshing = false;
				});
			}
		}

		internal abstract Task GetMoviesAsync();

		public bool IsRefreshing
		{
			get { return _isRefreshing; }
			set
			{
				_isRefreshing = value;
				OnPropertyChanged(nameof(IsRefreshing));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
