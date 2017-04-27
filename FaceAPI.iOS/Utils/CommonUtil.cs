using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FaceAPI.iOS.Utils
{
	public static class CommonUtil
	{
		public static Exception ToException(this NSError error)
		{
			if (error != null)
			{
				return new Exception(error.Description);
			}

			return null;
		}

		public static UIImage Crop(this UIImage image, CGRect rect)
		{
			rect = new CGRect(rect.X * image.CurrentScale,
							   rect.Y * image.CurrentScale,
							   rect.Width * image.CurrentScale,
							   rect.Height * image.CurrentScale);

			using (CGImage cr = image.CGImage.WithImageInRect(rect))
			{
				var cropped = UIImage.FromImage(cr, image.CurrentScale, image.Orientation);

				return cropped;
			}
		}
	}
}
