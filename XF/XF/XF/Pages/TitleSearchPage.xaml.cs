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

		private MovieController _movieController;
		public TitleSearchPage(MovieController movieController)
		{
			this._movieController = movieController;
			this.BindingContext = new TitleSearchViewModel(Navigation, _movieController);
			InitializeComponent();
		}
	}
}
