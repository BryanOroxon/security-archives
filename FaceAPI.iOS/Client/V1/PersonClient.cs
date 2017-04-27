using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Cognitive.Face.iOS;
using FaceAPI.iOS.Interfaces.V1;
using FaceAPI.iOS.Models;
using FaceAPI.iOS.Extensions;
using FaceAPI.iOS.Utils;
using System;
using UIKit;

namespace FaceAPI.iOS.Client.V1
{
	public class PersonClient : IPerson
	{
		private MPOFaceServiceClient _client;
		private MPOFaceServiceClient Client => _client ?? (_client = new MPOFaceServiceClient(ConfigClient.SuscriptionKey));
		private static PersonClient _shared;
		public static PersonClient Shared => _shared ?? (_shared = new PersonClient());

		public PersonClient()
		{
			if (string.IsNullOrEmpty(ConfigClient.SuscriptionKey))
			   throw new Exception("Missing suscription key at ConfigClient.SuscriptionKey");
		}

		public Task AddPersonFace(PersonModel person, PersonGroupModel group, FaceImageModel face, UIImage photo, string userData = null)
		{
			try
			{
				var tcs = new TaskCompletionSource<bool>();
				var faceRect = face.FaceRectangle.ToMPOFaceRect();

				using (var jpgData = photo.AsJPEG(.8f))
				{
					Client.AddPersonFaceWithPersonGroupId(group.Id, person.Id, jpgData, userData, faceRect, (result, error) =>
				   {
					   tcs.FailTaskIfErrored(error.ToException());
					   tcs.FailTaskByCondition(string.IsNullOrEmpty(result.PersistedFaceId), "AddPersistedFaceResult returned invalid face Id");

					   face.Id = result.PersistedFaceId;

					   person.Faces.Add(face);

					   tcs.SetResult(true);
				   }).Resume();
				}

				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public Task<PersonModel> CreatePerson(string personName, PersonGroupModel group, string userData = null)
		{
			try
			{
				var tcs = new TaskCompletionSource<PersonModel>();

				Client.CreatePersonWithPersonGroupId(group.Id, personName, userData, (result, error) =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());
								   tcs.FailTaskByCondition(string.IsNullOrEmpty(result.PersonId), "CreatePersonResult returned invalid person Id");

								   var person = new PersonModel
								   {
									   Name = personName,
									   Id = result.PersonId,
									   UserData = userData
								   };

								   group.People.Add(person);

								   tcs.SetResult(person);
							   }).Resume();

				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public Task DeletePerson(PersonModel person, PersonGroupModel group)
		{
			try
			{
				var tcs = new TaskCompletionSource<bool>();

				Client.DeletePersonWithPersonGroupId(group.Id, person.Id, error =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());

								   if (group.People.Contains(person))
								   {
									   group.People.Remove(person);
								   }

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

		public void DeletePersonFace()
		{
			throw new NotImplementedException();
		}

		public void GetPerson()
		{
			throw new NotImplementedException();
		}

		public Task<List<FaceImageModel>> GetPersonFaces(PersonModel person, PersonGroupModel group)
		{
			try
			{
				person.Faces.Clear();

				if (person.FaceIds != null)
				{
					var tcs = new TaskCompletionSource<List<FaceImageModel>>();

					foreach (var faceId in person.FaceIds)
					{
						Client.GetPersonFaceWithPersonGroupId(group.Id, person.Id, faceId, (mpoFace, error) =>
					   {
						   tcs.FailTaskIfErrored(error.ToException());

						   var face = mpoFace.ToFace();

						   person.Faces.Add(face);

						   if (person.Faces.Count == person.FaceIds.Count)
						   {
							   tcs.SetResult(person.Faces);
						   }
					   }).Resume();
					}

					return tcs.Task;
				}

				return Task.FromResult(default(List<FaceImageModel>));
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public Task<List<PersonModel>> ListPersonsInPersonGroup(PersonGroupModel group)
		{
			try
			{
				var tcs = new TaskCompletionSource<List<PersonModel>>();

				Client.ListPersonsWithPersonGroupId(group.Id, (groupPeople, error) =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());

								   var people = new List<PersonModel>(
									   groupPeople.Select(p => p.ToPerson())
								   );

								   group.People.AddRange(people);

								   tcs.SetResult(people);
							   }).Resume();

				return tcs.Task;
			}
			catch (Exception ex)
			{
				Log.Error(ex.Message);
				throw;
			}
		}

		public Task UpdatePerson(PersonModel person, PersonGroupModel group, string personName, string userData = null)
		{
			try
			{
				var tcs = new TaskCompletionSource<bool>();

				Client.UpdatePersonWithPersonGroupId(group.Id, person.Id, personName, userData, error =>
							   {
								   tcs.FailTaskIfErrored(error.ToException());

								   person.Name = personName;
								   person.UserData = userData;

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

		public void UpdatePersonFace()
		{
			throw new NotImplementedException();
		}
	}
}
