using System.Collections.Generic;

namespace FaceAPI.iOS.Models
{
	public class PersonModel : FaceModel
	{
		public List<string> FaceIds { get; set; } = new List<string>();

		public List<FaceImageModel> Faces { get; set; } = new List<FaceImageModel>();
	}
}
