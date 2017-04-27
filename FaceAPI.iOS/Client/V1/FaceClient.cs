using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FaceAPI.iOS.Interfaces.V1;
using FaceAPI.Models;
using Foundation;
using UIKit;
using Xamarin.Cognitive.Face.iOS;
using FaceAPI.Extensions;
using FaceAPI.iOS.Utils;

namespace FaceAPI.iOS.Client.V1
{
	public class FaceClient : IFace
	{
		private MPOFaceServiceClient _client;
		private MPOFaceServiceClient Client => _client ?? (_client = new MPOFaceServiceClient(ConfigClient.SuscriptionKey));
		private static FaceClient _shared;
		public static FaceClient Shared => _shared ?? (_shared = new FaceClient());

		public FaceClient()
		{
			if (string.IsNullOrEmpty(ConfigClient.SuscriptionKey))
				throw new Exception("Missing suscription key at ConfigClient.SuscriptionKey");
		}

		public Task<List<FaceImageModel>> Detect(UIImage photo)
		{
			try
			{
				List<FaceImageModel> faces = new List<FaceImageModel>();
				var tcs = new TaskCompletionSource<List<FaceImageModel>>();

				using (var jpgData = photo.AsJPEG(.8f))
				{
					Client.DetectWithData(jpgData, true, true, new NSObject[0], (detectedFaces, error) =>
				  {
					  tcs.FailTaskIfErrored(error.ToException());

					  foreach (var detectedFace in detectedFaces)
					  {
						  var face = detectedFace.ToFace();
						  faces.Add(face);

						  using (var croppedImage = photo.Crop(face.FaceRectangle))
						  {
							  //save to disk
							  using (var data = croppedImage.AsJPEG())
							  {
								  data.Save(face.PhotoPath, true);
							  }
						  }
					  }

					  tcs.SetResult(faces);
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

		public void FindSimilar()
		{
			throw new NotImplementedException();
		}

		public void Group()
		{
			throw new NotImplementedException();
		}

		public void Identity()
		{
			throw new NotImplementedException();
		}

		public void Verify()
		{
			throw new NotImplementedException();
		}
	}
}
