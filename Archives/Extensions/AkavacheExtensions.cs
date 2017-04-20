using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Akavache;
using System.Reactive.Linq;
using Foundation;
using SettingsStudio;

namespace Archives
{
	public static class AkavacheExtensions
	{
		public static async Task<T> TryGetObject<T>(this IBlobCache blob, string element)
		{
			T result = default(T);
			try
			{
				result = await BlobCache.UserAccount.GetObject<T>(element);

                Settings.SetSetting("somethingNotSecure", element);

                var somethingNotSecure = Settings.StringForKey("somethingNotSecure");

			}
			catch (KeyNotFoundException)
			{
				result = default(T);
			}

			return result;
		}

		public static async Task<T> TryGetSecureObject<T>(this ISecureBlobCache blob, string element)
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
