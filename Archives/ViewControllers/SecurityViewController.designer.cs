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
		UIKit.UITextField FirstDigit { get; set; }

		[Outlet]
		UIKit.UITextField FirstDigitRepeat { get; set; }

		[Outlet]
		UIKit.UITextField FourthDigit { get; set; }

		[Outlet]
		UIKit.UITextField FourthDigitRepeat { get; set; }

		[Outlet]
		UIKit.UISwitch IsPasscodeEnabled { get; set; }

		[Outlet]
		UIKit.UISwitch IsTouchIDEnabled { get; set; }

		[Outlet]
		UIKit.UITextField SecondDigit { get; set; }

		[Outlet]
		UIKit.UITextField SecondDigitRepeat { get; set; }

		[Outlet]
		UIKit.UITextField ThirdDigit { get; set; }

		[Outlet]
		UIKit.UITextField ThirdDigitRepeat { get; set; }

		[Action ("IsPasscodeEnabledValueChanged:")]
		partial void IsPasscodeEnabledValueChanged (Foundation.NSObject sender);

		[Action ("IsTouchIDEnabledValueChanged:")]
		partial void IsTouchIDEnabledValueChanged (Foundation.NSObject sender);
		
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

			if (FirstDigit != null) {
				FirstDigit.Dispose ();
				FirstDigit = null;
			}

			if (FirstDigitRepeat != null) {
				FirstDigitRepeat.Dispose ();
				FirstDigitRepeat = null;
			}

			if (FourthDigit != null) {
				FourthDigit.Dispose ();
				FourthDigit = null;
			}

			if (FourthDigitRepeat != null) {
				FourthDigitRepeat.Dispose ();
				FourthDigitRepeat = null;
			}

			if (SecondDigit != null) {
				SecondDigit.Dispose ();
				SecondDigit = null;
			}

			if (SecondDigitRepeat != null) {
				SecondDigitRepeat.Dispose ();
				SecondDigitRepeat = null;
			}

			if (ThirdDigit != null) {
				ThirdDigit.Dispose ();
				ThirdDigit = null;
			}

			if (ThirdDigitRepeat != null) {
				ThirdDigitRepeat.Dispose ();
				ThirdDigitRepeat = null;
			}
		}
	}
}
