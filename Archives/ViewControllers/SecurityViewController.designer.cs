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
	[Register ("SecurityViewController")]
	partial class SecurityViewController
	{
		[Outlet]
		UIKit.UITextField[] digitTextFields { get; set; }

		[Outlet]
		UIKit.UISwitch IsPasscodeEnabled { get; set; }

		[Outlet]
		UIKit.UISwitch IsTouchIDEnabled { get; set; }

		[Action ("IsPasscodeEnabledValueChanged:")]
		partial void IsPasscodeEnabledValueChanged (Foundation.NSObject sender);

		[Action ("IsTouchIDEnabledValueChanged:")]
		partial void IsTouchIDEnabledValueChanged (Foundation.NSObject sender);

		[Action ("savedButtonClicked:")]
		partial void savedButtonClicked (Foundation.NSObject sender);

		[Action ("textFieldEditingChanged:")]
		partial void textFieldEditingChanged (UIKit.UITextField sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (IsPasscodeEnabled != null) {
				IsPasscodeEnabled.Dispose ();
				IsPasscodeEnabled = null;
			}

			if (IsTouchIDEnabled != null) {
				IsTouchIDEnabled.Dispose ();
				IsTouchIDEnabled = null;
			}
		}
	}
}
