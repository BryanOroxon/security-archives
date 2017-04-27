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
	[Register ("SetFaceRecViewController")]
	partial class SetFaceRecViewController
	{
		[Outlet]
		UIKit.UIImageView picturePreview { get; set; }

		[Action ("takePhoto:")]
		partial void takePhoto (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (picturePreview != null) {
				picturePreview.Dispose ();
				picturePreview = null;
			}
		}
	}
}
