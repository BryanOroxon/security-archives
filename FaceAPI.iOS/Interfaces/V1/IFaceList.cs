namespace FaceAPI.iOS.Interfaces.V1
{
	/// <summary>
	/// Web reference:
	/// https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395245
	/// </summary>

	public interface IFaceList
	{
		void AddFaceToFaceList();

		void CreateFaceList();

		void DeleteFaceFromFaceList();

		void DeleteFaceList();

		void GetFaceList();

		void ListFaceLists();

		void UpdateFaceList();
	}
}
