using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using System.Reactive.Linq;

namespace Archives.Helpers
{
	public class AkavacheHelper
	{
		public static async Task<T> TryGetObject<T>(string element)
		{
			T result = default(T);
			try
			{
				result = await BlobCache.UserAccount.GetObject<T>(element);
			}
			catch (KeyNotFoundException)
			{
				result = default(T);
			}

			return result;
		}

		public static async Task<T> TryGetSecureObject<T>(string element)
		{
			T result = default(T);
			try
			{
				result = await BlobCache.Secure.GetObject<T>(element);
			}
			catch (KeyNotFoundException)
			{
				result = default(T);
			}

			return result;
		}
	}
}
