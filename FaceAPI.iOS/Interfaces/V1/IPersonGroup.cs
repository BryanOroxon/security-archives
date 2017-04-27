using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FaceAPI.Models;

namespace FaceAPI.iOS.Interfaces.V1
{
	/// <summary>
	/// Web reference:
	/// https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395245
	/// </summary>

	public interface IPersonGroup
	{
		Task<PersonGroupModel> CreatePersonGroup(string groupName, string userData = null);

		Task DeletePersonGroup(string personGroupId);

		void GetPersonGroup();

		void GetPersonGroupTrainingStatus();

		void ListPersonGroups();

		Task TrainPersonGroup(PersonGroupModel personGroup);

		Task UpdatePersonGroup(PersonGroupModel personGroup, string groupName, string userData = null);

		Task<List<PersonGroupModel>> GetPersonGroups(bool forceRefresh = false);
	}
}
