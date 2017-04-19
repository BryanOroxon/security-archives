using System;
using System.Collections.Generic;
using System.Reactive;
using Akavache;
using Archives.Controls;
using Archives.Models;
using Archives.ViewControllers;
using Foundation;
using UIKit;

namespace Archives.Sources
{
	public class SecurityFeaturesTableSource : UITableViewSource
	{
		private List<SecurityFeature> _features;
		private UIViewController _owner;
		private UITableView _tableView;

		public SecurityFeaturesTableSource(List<SecurityFeature> features, UITableView tableView, UIViewController owner)
		{
			_features = features;
			_tableView = tableView;
			_owner = owner;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(CustomSwitchCell.CellIdentifier) as CustomSwitchCell;

			if (cell == null)
			{
				cell = new CustomSwitchCell();
				cell.Switch.ValueChanged += Switch_ValueChanged;
			}

			var value = _features[indexPath.Row];
			cell.Switch.Tag = indexPath.Row;
			cell.Switch.SetState(value.Selected, true);
			cell.Switch.Enabled = value.Enabled;
			cell.TextLabel.Text = value.Name;

			return cell;
		}

		void Switch_ValueChanged(object sender, EventArgs e)
		{
			var uiswitch = sender as UISwitch;
			var datacell = _features[(int)uiswitch.Tag];
			datacell.Selected = (!datacell.Selected);

			if ((int)uiswitch.Tag == 0)
			{
				//delete passcode from secure internal storage
				IObservable<Unit> result_codedata = BlobCache.Secure.Invalidate("Passcode");

				if (datacell.Selected)
				{
					//set feature passcode
					_features[1].Enabled = true;

					//update features
					UpdateFeatures();

					//update flag
					SecurityViewController.IsCommingFromSetPasscode = true;

					//go and set a new passcode
					UIViewController uiviewcontroller = _owner.Storyboard.InstantiateViewController("SetPasscodeViewController");
					_owner.NavigationController.PushViewController(uiviewcontroller, true);
				}
				else
				{
					//set feature touch id
					_features[1].Selected = false;
					_features[1].Enabled = false;

					//update features
					UpdateFeatures();
				}
			}
			else
				UpdateFeatures(); //update features

			//refresh data
			_tableView.ReloadData();
		}

		void UpdateFeatures()
		{
			//save passcode feature
			IObservable<Unit> result_passcode = BlobCache.UserAccount.InsertObject("IsPasscodeEnabled", _features[0].Selected);

			//save touch id feature
			IObservable<Unit> result_touchid = BlobCache.UserAccount.InsertObject("IsTouchIDEnabled", _features[1].Selected);
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return _features.Count;
		}

	}
}
