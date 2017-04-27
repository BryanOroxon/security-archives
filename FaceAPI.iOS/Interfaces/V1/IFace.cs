using System.Collections.Generic;
using System.Threading.Tasks;
using FaceAPI.iOS.Models;
using UIKit;

namespace FaceAPI.iOS.Interfaces.V1
{
	/// <summary>
	/// Web reference:
	/// https://westus.dev.cognitive.microsoft.com/docs/services/563879b61984550e40cbbe8d/operations/563879b61984550f30395245
	/// </summary>

	public interface IFace
	{
		Task<List<FaceImageModel>> Detect(UIImage photo);

		void FindSimilar();

		void Group();

		void Identity();

		void Verify();
	}
}