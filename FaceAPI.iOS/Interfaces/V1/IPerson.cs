using System.Collections.Generic;
using System.Threading.Tasks;
using FaceAPI.Models;
using UIKit;

namespace FaceAPI.iOS.Interfaces.V1
{
	/// <summary>
	/// Web reference:
	/// https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395245
	/// </summary>

	public interface IPerson
	{
		Task AddPersonFace(PersonModel person, PersonGroupModel group, FaceImageModel face, UIImage photo, string userData = null);

		Task<PersonModel> CreatePerson(string personName, PersonGroupModel group, string userData = null);

		Task DeletePerson(PersonModel person, PersonGroupModel group);

		void DeletePersonFace();

		void GetPerson();

		Task<List<FaceImageModel>> GetPersonFaces(PersonModel person, PersonGroupModel group);

		Task<List<PersonModel>> ListPersonsInPersonGroup(PersonGroupModel group);

		Task UpdatePerson(PersonModel person, PersonGroupModel group, string personName, string userData = null);

		void UpdatePersonFace();
	}
}
