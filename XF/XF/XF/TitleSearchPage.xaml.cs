using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieSearch.Services;
using MovieSearch;

namespace XF
{
	public partial class TitleSearchPage : ContentPage
	{
		private List<Movie> _movies;

		MovieController movieController = new MovieController();
		public TitleSearchPage()
		{
			InitializeComponent();
		}

		// On search for title
		private async Task SearchButton_Clicked(object sender, EventArgs e)
		{
			if(this.titleEntry.Text != null && this.titleEntry.Text != "")
			{
				// Activate loading Icon
				this.loading.IsRunning = true;
				// Search movies by title
				this._movies = await movieController.GetMoviesByTitleAsync(titleEntry.Text);
				// Deactivate loading icon
				this.loading.IsRunning = false;
				await this.Navigation.PushAsync(new MovieListPage(this._movies));
			}
		}
	}
}
