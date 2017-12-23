using MovieSearch;
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
	public abstract class CastListViewModel : INotifyPropertyChanged
	{
		protected INavigation _navigation;
		protected MovieController _movieController;
		protected List<string> _cast;
		protected bool loading;
		protected bool _isRefreshing = false;

		internal void SetNavigation(INavigation navigation)
		{
			this._navigation = navigation;
		}

		public List<string> ListCast
		{
			get { return this._cast; }
			set
			{
				this._cast = value;
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
