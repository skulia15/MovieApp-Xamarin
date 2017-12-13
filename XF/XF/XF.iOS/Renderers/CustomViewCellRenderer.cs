using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using XF.iOS.Renderers;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))]
namespace XF.iOS.Renderers
{
	public class CustomViewCellRenderer : ViewCellRenderer
	{
		public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var cell = base.GetCell(item, reusableCell, tv);
			cell.SelectionStyle = UITableViewCellSelectionStyle.None;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;

			return cell;
		}
	}
}