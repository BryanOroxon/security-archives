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
	[Register ("ValidatePasscodeViewController")]
	partial class ValidatePasscodeViewController
	{
		[Outlet]
		UIKit.UIButton Cancel { get; set; }

		[Outlet]
		UIKit.UITextField FirstDigit { get; set; }

		[Outlet]
		UIKit.UITextField FourthDigit { get; set; }

		[Outlet]
		UIKit.UITextField SecondDigit { get; set; }

		[Outlet]
		UIKit.UITextField ThirdDigit { get; set; }

		[Outlet]
		UIKit.UIButton Validate { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (FirstDigit != null) {
				FirstDigit.Dispose ();
				FirstDigit = null;
			}

			if (SecondDigit != null) {
				SecondDigit.Dispose ();
				SecondDigit = null;
			}

			if (ThirdDigit != null) {
				ThirdDigit.Dispose ();
				ThirdDigit = null;
			}

			if (FourthDigit != null) {
				FourthDigit.Dispose ();
				FourthDigit = null;
			}

			if (Cancel != null) {
				Cancel.Dispose ();
				Cancel = null;
			}

			if (Validate != null) {
				Validate.Dispose ();
				Validate = null;
			}
		}
	}
}