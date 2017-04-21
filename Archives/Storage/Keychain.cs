using Foundation;
using Security;

namespace Archives.Storage
{
	public static class Keychain
	{
		public const string AuthService = "authservice";

		static SecRecord genericRecord(string service) => new SecRecord(SecKind.GenericPassword)
		{
			Service = $"{NSBundle.MainBundle.BundleIdentifier}-{service}"
		};

		public static (string Account, string PrivateKey) GetItemFromKeychain(string service)
		{
			var record = SecKeyChain.QueryAsRecord(genericRecord(service), out SecStatusCode status);

			if (status == SecStatusCode.Success && record != null)
			{
				var account = record.Account;

				var privateKey = NSString.FromData(record.ValueData, NSStringEncoding.UTF8).ToString();

				return (account, privateKey);
			}

			return (null, null);
		}

		public static bool SaveItemToKeychain(string service, string account, string privateKey)
		{
			var record = genericRecord(service);

			record.Account = account;

			record.ValueData = NSData.FromString(privateKey, NSStringEncoding.UTF8);

			// Delete any existing items
			SecKeyChain.Remove(record);

			// Add the new keychain item
			var status = SecKeyChain.Add(record);

			var success = status == SecStatusCode.Success;

			if (!success)
			{
				System.Diagnostics.Debug.WriteLine($"Error in Keychain: {status}");
				System.Diagnostics.Debug.WriteLine($"If you are seeing error code '-34018' got to Project Options -> iOS Bundle Signing -> make sure Entitlements.plist is populated for Custom Entitlements for iPhoneSimulator configs");
			}

			return success;
		}


		public static bool RemoveItemFromKeychain(string service)
		{
			var record = genericRecord(service);

			var status = SecKeyChain.Remove(record);

			var success = status == SecStatusCode.Success;

			if (!success)
			{
				System.Diagnostics.Debug.WriteLine($"Error in Keychain: {status}");
				System.Diagnostics.Debug.WriteLine($"If you are seeing error code '-34018' got to Project Options -> iOS Bundle Signing -> make sure Entitlements.plist is populated for Custom Entitlements for iPhoneSimulator configs");
			}

			return success;
		}
	}
}