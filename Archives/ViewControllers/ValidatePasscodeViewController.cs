// This file has been autogenerated from a class added in the UI designer.

using System;
using Foundation;
using UIKit;
using System.Linq;
using Akavache;
using System.Reactive;
using System.Threading.Tasks;
using LocalAuthentication;

namespace Archives.ViewControllers
{
	public partial class ValidatePasscodeViewController : UIViewController
	{
		public string TargetViewController = string.Empty;
		public UINavigationController Navigation = null;

		public ValidatePasscodeViewController(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			digits[0].BecomeFirstResponder();

			Task.Run(async () =>
			{
				var isTouchIDEnabled = await BlobCache.UserAccount.TryGetObject<bool>("IsTouchIDEnabled");

				if (isTouchIDEnabled)
					LaunchTouchID();
			});

		}

		void LaunchTouchID()
		{
			var context = new LAContext();
			NSError AuthError;
			var reason = new NSString("Validate activity");

			if (context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, out AuthError))
			{
				var replyHandler = new LAContextReplyHandler((success, error) =>
				{
					this.InvokeOnMainThread(() =>
					{
						if (success)
						{
							UIViewController uiviewcontroller = Storyboard.InstantiateViewController(TargetViewController);
							Navigation.PushViewController(uiviewcontroller, true);
							DismissViewController(false, null);
						}
					});

				});
				context.EvaluatePolicy(LAPolicy.DeviceOwnerAuthenticationWithBiometrics, reason, replyHandler);
			}
		}

		partial void cancelTouchUpInside(NSObject sender)
		{
			DismissViewController(false, null);
		}

		partial void digitEditingChanged(UITextField sender)
		{
			var nextDigit = digits.FirstOrDefault(tf => tf.Tag == sender.Tag + 1);

			if (nextDigit != null)
			{
				nextDigit.BecomeFirstResponder();
			}
			else
			{
				Task.Run(async () =>
				{
					string opasscode = await BlobCache.Secure.TryGetSecureObject<string>("Passcode");
					string rpasscode = string.Empty;

					BeginInvokeOnMainThread(() =>
					{
						//backup second passcode and clear fields
						foreach (UITextField t in digits)
						{
							rpasscode += t.Text;
							t.Text = string.Empty;
						}

						//validate passcodes
						if (opasscode != rpasscode)
						{
							nextDigit = digits.FirstOrDefault();
							nextDigit.BecomeFirstResponder();
							rpasscode = string.Empty;
						}
						else
						{
                            DismissViewController(false, null);
							UIViewController uiviewcontroller = Storyboard.InstantiateViewController(TargetViewController);
							Navigation.PushViewController(uiviewcontroller, true);
						}
					});
				});
			}
		}

		partial void digitEditingDidBegin(UITextField sender)
		{
			sender.Text = string.Empty;
		}

		[Export("textField:shouldChangeCharactersInRange:replacementString:")]
		public bool ShouldChangeCharacters(UITextField textField, NSRange range, string replacementString)
		{
			var newLength = textField.Text.Length + replacementString.Length - range.Length;
			return newLength <= 1;
		}

	}
}
