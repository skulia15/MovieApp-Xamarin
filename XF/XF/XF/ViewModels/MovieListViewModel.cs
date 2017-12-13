﻿using MovieSearch;
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
	public class MovieListViewModel : INotifyPropertyChanged
	{
		private INavigation _navigation;
		private List<Movie> _movieList;
		private Movie _selectedMovie;
		MovieController _movieController;

		public MovieListViewModel(INavigation navigation, List<Movie> movies, MovieController movieController)
		{
			this._movieController = movieController;
			this._navigation = navigation;
			_movieList = movies;
		}

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

					this._navigation.PushAsync(new MoviePage(this._selectedMovie, _movieController), true);
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
