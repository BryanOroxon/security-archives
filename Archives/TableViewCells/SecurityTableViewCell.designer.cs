// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Archives.TableViewCells
{
	[Register ("SecurityTableViewCell")]
	partial class SecurityTableViewCell
	{
		[Outlet]
		UIKit.UISwitch switchViewCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (switchViewCell != null) {
				switchViewCell.Dispose ();
				switchViewCell = null;
			}
		}
	}
}
