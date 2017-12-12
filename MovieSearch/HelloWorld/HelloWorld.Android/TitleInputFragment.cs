﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android;
using Android.Views.InputMethods;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Fragment = Android.Support.V4.App.Fragment;

namespace MovieSearch.Droid
{
	[Activity (Label = "MovieHub", Theme="@style/MyTheme")]
	public class TitleInputFragment : Fragment
	{
		private List<Movie> _movies { get; set; }
		private MovieController movieController = new MovieController();
		private InputMethodManager manager;
		private View rootView;

		public TitleInputFragment()
		{
		}
		public TitleInputFragment(List<Movie> movies)
		{
			this._movies = movies;
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle bundle)
		{
			this.rootView = inflater.Inflate(Resource.Layout.TitleInput, container, false);

			// Get our button from the layout resource,
			// and attach an event to it

			var movieTitleEditText = rootView.FindViewById<EditText>(Resource.Id.movieTitleEditText);
			var searchButton = rootView.FindViewById<Button>(Resource.Id.searchButton);
			var loadingIcon = rootView.FindViewById<ProgressBar>(Resource.Id.progressBar);
			loadingIcon.Visibility = ViewStates.Invisible;

			// On search button clicked
			searchButton.Click += async (object sender, EventArgs e) =>
			{
				HideKeyboard();

				if (movieTitleEditText.Text != "" && movieTitleEditText != null)
				{
					searchButton.Enabled = false;
					loadingIcon.Visibility = ViewStates.Visible;
					var intent = new Intent(this.Context, typeof(MovieListActivity));

					try
					{
						// Search for movies by title and store them in a list of movies
						_movies = await movieController.GetMoviesByTitleAsync(movieTitleEditText.Text);
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex);
					}
					
					loadingIcon.Visibility = ViewStates.Invisible;
					searchButton.Enabled = true;
					if (_movies.Count > 0 && _movies != null)
					{
						// Convert list of movies to list of movie title strings 
						intent.PutExtra("movieList", JsonConvert.SerializeObject(_movies));
					}
					else
					{
						intent.PutExtra("movieList", JsonConvert.SerializeObject(new List<Movie>()));
					}

					// Push 
					this.StartActivity(intent);
				}
				else
				{
					Toast.MakeText(this.Context, "Please provide a title", ToastLength.Long).Show();
				}
			};
			return rootView;
		}

		public void HideKeyboard()
		{
			try
			{
				var movieTitleEditText = rootView.FindViewById<EditText>(Resource.Id.movieTitleEditText);
				// Create a manager that handles system services
				this.manager = (InputMethodManager)this.Context.GetSystemService(Context.InputMethodService);
				// Hide keyboard
				manager.HideSoftInputFromWindow(movieTitleEditText.WindowToken, 0);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}


