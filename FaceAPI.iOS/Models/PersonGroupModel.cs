using System.Collections.Generic;

namespace FaceAPI.Models
{
	public class PersonGroupModel : FaceModel
	{
		public List<PersonModel> People { get; set; } = new List<PersonModel>();
	}
}
