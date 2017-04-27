// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using FaceAPI.iOS.Utils;
using FaceAPI.iOS.Extensions;
using FaceAPI.iOS.Models;
using FaceAPI.iOS.Client.V1;

namespace FaceAPI.iOS.ViewControllers
{
	public partial class GroupDetailViewController : UIViewController
	{
		public PersonGroupModel Group { get; set; }
		public bool NeedsTraining { get; set; }

		GroupPersonCollectionViewController GroupPersonCVC => ChildViewControllers[0] as GroupPersonCollectionViewController;

		public GroupDetailViewController(IntPtr handle) : base(handle) { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.Title = Constants.__TITLE_GROUPDETAIL__;
			groupName.BecomeFirstResponder();
		}

		//public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		//{
		//	base.PrepareForSegue(segue, sender);

		//	if (segue.Identifier == EmbedSegueId && Group != null)
		//	{
		//		var groupPeopleCVC = segue.DestinationViewController as GroupPersonCollectionViewController;

		//		groupPeopleCVC.Group = Group;
		//	}
		//	else if (segue.Identifier == AddPersonSegueId)
		//	{
		//		//var groupPersonVC = segue.DestinationViewController as PersonDetailViewController;

		//		//groupPersonVC.Group = Group;
		//		//groupPersonVC.NeedsTraining = this.NeedsTraining;
		//	}
		//}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			if (Group != null)
			{
				groupName.Text = Group.Name;
			}
		}

		partial void saveAction(NSObject sender)
		{
			if (groupName.Text.Length == 0)
			{
				this.ShowSimpleAlert("Please input the group name");
				return;
			}

			if (Group == null)
			{
				createNewGroup().Forget();
			}
			else
			{
				updateGroup().Forget();
			}
		}

		partial void addAction(NSObject sender)
		{
			if (groupName.Text.Length == 0)
			{
				this.ShowSimpleAlert("Please input the group name");
				return;
			}

			AddPerson().Forget();
		}

		async Task AddPerson()
		{
			if (Group == null)
			{
				var createGroup = await this.ShowTwoOptionAlert("Create Group?", "Do you want to create this new group?");

				if (!createGroup)
				{
					return;
				}

				await createNewGroup();
			}

			if (Group != null)
			{
				UIViewController uiview = Storyboard.InstantiateViewController("PersonDetailViewController");
				NavigationController.PushViewController(uiview, true);
			}
		}

		async Task updateGroup()
		{
			try
			{
				this.ShowHUD("Saving Group");
				await PersonGroupClient.Shared.UpdatePersonGroup(Group, groupName.Text, string.Empty);
				this.ShowSimpleHUD("Group saved");
				//await trainGroup();
			}
			catch (Exception)
			{
				this.ShowSimpleAlert("Failed to update group.");
			}
		}

		//        - (void) longPressAction: (UIGestureRecognizer*) gestureRecognizer
		//		{
		//    if (gestureRecognizer.state == UIGestureRecognizerStateBegan) {
		//        _selectedPersonIndex = gestureRecognizer.view.tag;
		//        UIActionSheet* confirm_sheet = [[UIActionSheet alloc]

		//										 initWithTitle:@"Do you want to remove all of this person's faces?"
		//                                         delegate:self
		//										 cancelButtonTitle:@"Cancel"

		//										 destructiveButtonTitle:nil
		//										 otherButtonTitles:@"Yes", nil];
		//        confirm_sheet.tag = 0;
		//        [confirm_sheet showInView:self.view];
		//    }
		//}

		async Task createNewGroup()
		{
			try
			{
				this.ShowHUD("Creating group");
				Group = await PersonGroupClient.Shared.CreatePersonGroup(groupName.Text, string.Empty);
				GroupPersonCVC.Group = Group;
				this.ShowSimpleHUD("Group created");
				GroupPersonCVC.CollectionView.ReloadData();
			}
			catch (Exception)
			{
				this.ShowSimpleAlert("Failed to create group.");
			}
		}

		async Task trainGroup()
		{
			try
			{
				this.ShowHUD("Training group");
				await PersonGroupClient.Shared.TrainPersonGroup(Group);
				this.ShowSimpleHUD("This group is trained.");

				//if (_shouldExit)
				//{
				//    this.NavigationController.PopViewController (true);
				//}
			}
			catch (Exception)
			{
				this.ShowSimpleHUD("Failed in training group.");
			}
		}
	}
}