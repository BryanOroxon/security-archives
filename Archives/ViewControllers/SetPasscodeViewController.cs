// This file has been autogenerated from a class added in the UI designer.

using System;
using Foundation;
using UIKit;
using System.Linq;
using Akavache;
using System.Reactive;

namespace Archives.ViewControllers
{
	public partial class SetPasscodeViewController : UIViewController
	{
		private int validation_round = 1;
		private string opasscode = string.Empty;
		private string rpasscode = string.Empty;

		public SetPasscodeViewController(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Title = "Passcode";
			this.passcode.Text = "Set Passcode";
			digits[0].BecomeFirstResponder();
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
				if (validation_round < 2)
				{

					this.passcode.Text = "Repeat Passcode";
					validation_round++;

					//prevent next iteration if some textfield is empty
					foreach (UITextField t in digits)
					{
						if (t.Text == string.Empty)
							return;
					}

					//backup first passcode and clear fields
					foreach (UITextField t in digits)
					{
						opasscode += t.Text;
						t.Text = string.Empty;
					}

					//set responder in the first digit 
					nextDigit = digits.FirstOrDefault();
					nextDigit.BecomeFirstResponder();
				}
				else
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
						//save passcode in secure internal storage
						IObservable<Unit> result_codedata = BlobCache.Secure.InsertObject("Passcode", rpasscode);

						//return to security features
						this.NavigationController.PopViewController(true);
					}

				}
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
