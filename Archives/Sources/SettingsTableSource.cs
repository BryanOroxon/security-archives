using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Archives.Entities;
using Foundation;
using UIKit;

namespace Archives.Sources
{
	public partial class SettingsTableSource : UITableViewSource
	{
		private List<Setting> _settings;
		private UIViewController _owner;

		public delegate Task ViewControllerHandler(object sender, Setting e);
		public event ViewControllerHandler ViewControllerEvent;

		public SettingsTableSource(List<Setting> settings, UIViewController owner)
		{
			_settings = settings;
			_owner = owner;
		}
			
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			string cellidentifier = _settings[indexPath.Row].Identifier;
			//request a recycled cell to save memory.
			UITableViewCell cell = tableView.DequeueReusableCell(cellidentifier);
			//if there are no cells to reuse, create a new one.
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Default, cellidentifier);
			cell.TextLabel.Text = _settings[indexPath.Row].Name;
			cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _settings.Count;
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            ViewControllerEvent(this, _settings[indexPath.Row]);
		}
	}
}
