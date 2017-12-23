using MovieSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Controllers;

namespace XF.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CastMemberPage : ContentPage
	{
		CastMemberViewModel viewModel;
		public CastMemberPage (CastMember castMember, MovieController movieController)
		{
			viewModel = new CastMemberViewModel(this.Navigation, castMember, movieController);
			this.BindingContext = viewModel;
			InitializeComponent ();
		}

	}
}