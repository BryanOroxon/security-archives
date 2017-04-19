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
	[Register ("SetPasscodeViewController")]
	partial class SetPasscodeViewController
	{
		[Outlet]
		UIKit.UITextField[] digits { get; set; }

		[Action ("digitEditingChanged:")]
		partial void digitEditingChanged (Foundation.NSObject sender);

		[Action ("next:")]
		partial void next (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
