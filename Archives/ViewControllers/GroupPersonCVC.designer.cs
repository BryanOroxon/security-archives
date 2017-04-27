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
	[Register ("GroupPersonCVC")]
	partial class GroupPersonCVC
	{
		[Outlet]
		UIKit.UIImageView imageView { get; set; }

		[Outlet]
		UIKit.UILabel label { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (imageView != null) {
				imageView.Dispose ();
				imageView = null;
			}

			if (label != null) {
				label.Dispose ();
				label = null;
			}
		}
	}
}
