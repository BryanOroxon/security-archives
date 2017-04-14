using System;
using Foundation;
using LocalAuthentication;
using Security;
using UIKit;

namespace Archives
{
	public partial class AccessViewController : UIViewController
	{		

		public AccessViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void BtnGetAccess_TouchUpInside(UIButton sender)
		{
			SecStatusCode code = AppDelegate.ValidateKeychain();
			System.Console.WriteLine(string.Format("Code: {0}", code));
			if (code == SecStatusCode.Success)
			{
				InvokeOnMainThread(() =>
					{
						UIViewController tabs = Storyboard.InstantiateViewController("TabBarViewController");
						PresentViewController(tabs, true, null);
					});
			}
		}
	}
}

