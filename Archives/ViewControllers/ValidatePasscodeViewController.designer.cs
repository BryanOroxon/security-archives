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
	[Register ("ValidatePasscodeViewController")]
	partial class ValidatePasscodeViewController
	{
		[Outlet]
		UIKit.UITextField[] digits { get; set; }

		[Action ("cancelTouchUpInside:")]
		partial void cancelTouchUpInside (Foundation.NSObject sender);

		[Action ("digitEditingChanged:")]
		partial void digitEditingChanged (UIKit.UITextField sender);

		[Action ("digitEditingDidBegin:")]
		partial void digitEditingDidBegin (UIKit.UITextField sender);

		[Action ("validateTouchUpInside:")]
		partial void validateTouchUpInside (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
