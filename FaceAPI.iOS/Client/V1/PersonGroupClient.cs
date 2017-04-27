using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Cognitive.Face.iOS;
using FaceAPI.iOS.Interfaces.V1;
using FaceAPI.Models;
using FaceAPI.Extensions;
using FaceAPI.iOS.Utils;

namespace FaceAPI.iOS.Client.V1
{
	public class PersonGroupClient : IPersonGroup
	{
		private MPOFaceServiceClient _client;
		private MPOFaceServiceClient Client => _client ?? (_client = new MPOFaceServiceClient(ConfigClient.SuscriptionKey));
		public List<PersonGroupModel> Groups { get; private set; } = new List<PersonGroupModel>();
		private static PersonGroupClient _shared;
		public static PersonGroupClient Shared => _shared ?? (_shared = new PersonGroupClient());

		public PersonGroupClient()
		{
			if (string.IsNullOrEmpty(ConfigClient.SuscriptionKey))
				throw new Exception("Missing suscription key at ConfigClient.SuscriptionKey");
		}

		public Task<PersonGroupModel> CreatePersonGroup(string groupName, string userData = null)
		{
			try
			{
				var tcs = new TaskCompletionSource<PersonGroupModel>();

				var personGroupId = Guid.NewGuid().ToString();

				Client.CreatePersonGroupWithId(personGroupId, groupName, userData, error =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());

								   var group = new PersonGroupModel
								   {
									   Name = groupName,
									   Id = personGroupId,
									   UserData = userData
								   };

								   Groups.Add(group);

								   tcs.SetResult(group);
							   }).Resume();

				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public Task DeletePersonGroup(string personGroupId)
		{
			try
			{
				var tcs = new TaskCompletionSource<bool>();

				Client.DeletePersonGroupWithPersonGroupId(personGroupId, error =>
											   {
												   tcs.FailTaskIfErrored(error.ToException());
												   tcs.SetResult(true);
											   }).Resume();
				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public void GetPersonGroup()
		{
			throw new NotImplementedException();
		}

		public Task<List<PersonGroupModel>> GetPersonGroups(bool forceRefresh = false)
		{
			try
			{
				if (Groups.Count == 0 || forceRefresh)
				{
					var tcs = new TaskCompletionSource<List<PersonGroupModel>>();

					Client.ListPersonGroupsWithCompletion((groups, error) =>
									   {
										   tcs.FailTaskIfErrored(error.ToException());

										   Groups = new List<PersonGroupModel>(
											   groups.Select(g => g.ToPersonGroup())
										   );

										   tcs.SetResult(Groups);
									   }).Resume();

					return tcs.Task;
				}

				return Task.FromResult(Groups);
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public void GetPersonGroupTrainingStatus()
		{
			throw new NotImplementedException();
		}

		public void ListPersonGroups()
		{
			throw new NotImplementedException();
		}

		public Task TrainPersonGroup(PersonGroupModel personGroup)
		{
			try
			{
				var tcs = new TaskCompletionSource<bool>();

				Client.TrainPersonGroupWithPersonGroupId(personGroup.Id, error =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());

								   tcs.SetResult(true);

							   }).Resume();

				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public Task UpdatePersonGroup(PersonGroupModel personGroup, string groupName, string userData = null)
		{
			try
			{
				var tcs = new TaskCompletionSource<bool>();

				Client.UpdatePersonGroupWithPersonGroupId(personGroup.Id, groupName, userData, error =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());

								   personGroup.Name = groupName;
								   personGroup.UserData = userData;

								   tcs.SetResult(true);
							   }).Resume();

				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}
	}
}