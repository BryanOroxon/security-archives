// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;
using Foundation;
using Photos;
using UIKit;

namespace Archives
{
	public partial class ArchivesViewController : UITableViewController
	{
		UIImagePickerController imagePicker;

		public ArchivesViewController(IntPtr handle) : base(handle)
		{
			NavigationItem.Title = "Archives";
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			NavigationItem.SetRightBarButtonItem(new UIBarButtonItem(UIBarButtonSystemItem.Add, (sender, e) =>
			{
				LaunchUIAlertController();
			}), true);
		}

		void LaunchUIAlertController()
		{
			var alert = UIAlertController.Create("Picture", "Select a picture!", UIAlertControllerStyle.ActionSheet);
			alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
			alert.AddAction(UIAlertAction.Create("Media", UIAlertActionStyle.Default, ValidatePictureAuthorization));
			PresentViewController(alert, true, null);
		}

		void ValidatePictureAuthorization(UIAlertAction obj)
		{
			PHAuthorizationStatus status = PHPhotoLibrary.AuthorizationStatus;
			UIAlertController alert = null;

			switch (status)
			{
				case PHAuthorizationStatus.Authorized:

					GetImageFromGallery();
					break;
				case PHAuthorizationStatus.Denied:
					alert = UIAlertController.Create("Oops!", "Access Denied", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Cancel, null));
					PresentViewController(alert, true, null);
					break;
				case PHAuthorizationStatus.Restricted:
					alert = UIAlertController.Create("Oops!", "Access Restricted", UIAlertControllerStyle.Alert);
					alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Cancel, null));
					PresentViewController(alert, true, null);
					break;
				case PHAuthorizationStatus.NotDetermined:
					{
						PHPhotoLibrary.RequestAuthorization((PHAuthorizationStatus objstatus) =>
						{
							switch (objstatus)
							{
								case PHAuthorizationStatus.Authorized:
									GetImageFromGallery();
									break;
								case PHAuthorizationStatus.Denied:
									alert = UIAlertController.Create("Oops!", "Access Denied", UIAlertControllerStyle.Alert);
									alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Cancel, null));

									PresentViewController(alert, true, null);
									break;
								case PHAuthorizationStatus.Restricted:
									alert = UIAlertController.Create("Oops!", "Access Restricted", UIAlertControllerStyle.Alert);
									alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Cancel, null));
									PresentViewController(alert, true, null);
									break;
								case PHAuthorizationStatus.NotDetermined:
									break;
							}
						});

						break;
					}
			}
		}

		void GetImageFromGallery()
		{
			imagePicker = new UIImagePickerController();
			imagePicker.SourceType = UIImagePickerControllerSourceType.PhotoLibrary;
			imagePicker.MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary);
			imagePicker.FinishedPickingMedia += Handle_FinishedPickingMedia;
			imagePicker.Canceled += Handle_Canceled;
			PresentModalViewController(imagePicker, true);
		}

		void Handle_Canceled(object sender, EventArgs e)
		{
			imagePicker.DismissModalViewController(true);
		}

		protected void Handle_FinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs e)
		{
			//PreviewViewController.SelectedMedia = e.Info;

			string type = e.Info[UIImagePickerController.MediaType].ToString();
			string url = string.Empty;
			NSUrl referenceURL = e.Info[new NSString("UIImagePickerControllerReferenceURL")] as NSUrl;
			if (referenceURL != null)
				url = referenceURL.ToString();
			string trace = string.Format("Type: {0} Reference URL: {1}", type, url);
			Console.WriteLine(trace);

			switch (type)
			{
				case "public.image":
					break;
				case "public.video":
					break;
			}


			imagePicker.DismissModalViewController(true);

		}
	}
}