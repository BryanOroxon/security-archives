// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace Archives
{
	[Register ("PreviewViewController")]
	partial class PreviewViewController
	{
		[Outlet]
		UIKit.UIButton Cancel { get; set; }

		[Outlet]
		UIKit.UIButton Choose { get; set; }

		[Outlet]
		UIKit.UIImageView PreviewImage { get; set; }

		[Action ("CancelTouchUpInside:")]
		partial void CancelTouchUpInside (Foundation.NSObject sender);

		[Action ("ChooseTouchUpInside:")]
		partial void ChooseTouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (PreviewImage != null) {
				PreviewImage.Dispose ();
				PreviewImage = null;
			}

			if (Cancel != null) {
				Cancel.Dispose ();
				Cancel = null;
			}

			if (Choose != null) {
				Choose.Dispose ();
				Choose = null;
			}
		}
	}
}
