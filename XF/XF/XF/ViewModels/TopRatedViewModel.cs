﻿using MovieSearch;
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
		private bool _isRefreshing = false;
		public TopRatedViewModel(MovieController movieController)
		{
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

		public ICommand RefreshCommand
		{
			get
			{
				return new Command(async () =>
				{
					IsRefreshing = true;

					await GetMovies();
					await GetCast(Movies);

					IsRefreshing = false;
				});
			}
		}

		public new bool IsRefreshing
		{
			get { return _isRefreshing; }
			set
			{
				_isRefreshing = value;
				OnPropertyChanged(nameof(IsRefreshing));
			}
		}
	}
}
