// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Archives.ViewControllers
{
	[Register ("GroupDetailViewController")]
	partial class GroupDetailViewController
	{
		[Outlet]
		UIKit.UITextField groupName { get; set; }

		[Action ("addAction:")]
		partial void addAction (Foundation.NSObject sender);

		[Action ("saveAction:")]
		partial void saveAction (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (groupName != null) {
				groupName.Dispose ();
				groupName = null;
			}
		}
	}
}
