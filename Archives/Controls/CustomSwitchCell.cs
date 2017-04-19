using System;
using UIKit;

namespace Archives.Controls
{
	public class CustomSwitchCell : UITableViewCell
	{
		public readonly UISwitch Switch = new UISwitch();

		public static string CellIdentifier
		{
			get { return "Cell"; }
		}

		public CustomSwitchCell() : base(UITableViewCellStyle.Default, CellIdentifier)
		{
			AccessoryView = Switch;
		}
	}
}
