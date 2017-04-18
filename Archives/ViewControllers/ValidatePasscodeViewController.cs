// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;
using Archives.Helpers;
using CoreFoundation;
using Foundation;
using LocalAuthentication;
using UIKit;

namespace Archives.ViewControllers
{
	public partial class ValidatePasscodeViewController : UIViewController
	{
		private bool _isPasscodeEnabled = false;
		private bool _isTouchIDEnabled = false;

		public string TargetViewController = string.Empty;
		public UINavigationController Navigation = null;

		public ValidatePasscodeViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			Task.Factory.StartNew(async () =>
			{
				_isPasscodeEnabled = await AkavacheHelper.TryGetObject<bool>("IsPasscodeEnabled");
				_isTouchIDEnabled = await AkavacheHelper.TryGetObject<bool>("IsTouchIDEnabled");

				DispatchQueue.MainQueue.DispatchAsync(() =>
				{
					ConfigureDigits();

					if (_isTouchIDEnabled)
						LaunchTouchID();
				});

			});
		}

		partial void CancelTouchUpInside(NSObject sender)
		{
			DismissViewController(false, null);
		}

		partial void ValidateTouchUpInside(NSObject sender)
		{
			Validate();
		}

		async void Validate()
		{
			await AkavacheHelper.TrySecureGetObject<string>("Passcode").ContinueWith((a) =>
			{
				DispatchQueue.MainQueue.DispatchAsync(() =>
				{
					string codeData = FirstDigit.Text + SecondDigit.Text + ThirdDigit.Text + FourthDigit.Text;

					if (codeData == a.Result)
					{
						UIViewController uiviewcontroller = Storyboard.InstantiateViewController(TargetViewController);
						Navigation.PushViewController(uiviewcontroller, true);
                        DismissViewController(false, null);
					}
				});
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

		void ConfigureDigits()
		{
			FirstDigit.BecomeFirstResponder();

			FirstDigit.EditingChanged += (sender, e) =>
			{
				SecondDigit.BecomeFirstResponder();
			};

			FirstDigit.ShouldChangeCharacters = (textField, range, replacementString) =>
			{
				var newLength = textField.Text.Length + replacementString.Length - range.Length;
				return newLength <= 1;
			};

			SecondDigit.EditingChanged += (sender, e) =>
			{
				ThirdDigit.BecomeFirstResponder();
			};

			SecondDigit.ShouldChangeCharacters = (textField, range, replacementString) =>
			{
				var newLength = textField.Text.Length + replacementString.Length - range.Length;
				return newLength <= 1;
			};

			ThirdDigit.EditingChanged += (sender, e) =>
			{
				FourthDigit.BecomeFirstResponder();
			};

			ThirdDigit.ShouldChangeCharacters = (textField, range, replacementString) =>
			{
				var newLength = textField.Text.Length + replacementString.Length - range.Length;
				return newLength <= 1;
			};

			FourthDigit.ShouldChangeCharacters = (textField, range, replacementString) =>
			{
				var newLength = textField.Text.Length + replacementString.Length - range.Length;
				return newLength <= 1;
			};

		}
	}
}