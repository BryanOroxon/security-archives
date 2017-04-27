using System.Drawing;

namespace FaceAPI.iOS.Models
{
	public class FaceImageModel : FaceModel
	{
		public string PhotoPath { get; set; }

		//public byte [] PhotoData { get; set; }

		public RectangleF FaceRectangle { get; set; }
	}
}
