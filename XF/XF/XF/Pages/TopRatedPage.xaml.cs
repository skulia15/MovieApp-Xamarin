using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Controllers;
using XF.ViewModels;

namespace XF.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TopRatedPage : ContentPage
	{
		public ListViewModel viewModel;
		MovieController _movieController;
		public TopRatedPage(MovieController movieController, ListViewModel viewModel)
		{
			this.viewModel = viewModel;
			this._movieController = movieController;
			this.viewModel.SetNavigation(Navigation);
			this.BindingContext = viewModel;
			InitializeComponent();
		}

		protected override async void OnAppearing()
		{
			base.OnAppearing();
			//await viewModel.GetCast(viewModel.Movies);
		}
	}
}