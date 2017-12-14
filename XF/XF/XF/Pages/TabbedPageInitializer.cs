using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TabbedPageInitializer : TabbedPage
	{
		protected override void OnAppearing()
		{
			base.OnAppearing();
			// Get movies for top rated
			((CustomListPage)((NavigationPage)Children[1]).RootPage).viewModel.GetMoviesAsync();
			// Get movies for popular
			((CustomListPage)((NavigationPage)Children[2]).RootPage).viewModel.GetMoviesAsync();
		}
	}
}