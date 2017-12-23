using MovieSearch;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XF.Controllers;

namespace XF.Pages
{
	public class CastMemberViewModel : INotifyPropertyChanged
	{
		private INavigation _navigation;
		private CastMember _castMember;
		MovieController _movieController;

		public CastMemberViewModel(INavigation navigation, CastMember castMember, MovieController movieController)
		{
			this._navigation = navigation;
			this._movieController = movieController;
			_castMember = castMember;
		}

		public CastMember CastMember
		{
			get { return this._castMember; }
			set
			{
				this._castMember = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}

}