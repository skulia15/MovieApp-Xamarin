using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MovieSearch.Services;
using MovieSearch;
using XF.Controllers;
using XF.ViewModels;

namespace XF.Pages
{
	public partial class TitleSearchPage : ContentPage
	{
		MovieController _movieController;
		MovieListViewModel viewModel;
		
		public TitleSearchPage(MovieController movieController, MovieListViewModel viewModel)
		{
			this.viewModel = viewModel;
			this._movieController = movieController;
			this.viewModel.SetNavigation(Navigation);
			this.BindingContext = viewModel;
			InitializeComponent();
		}
	}
}
