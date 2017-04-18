using System;
using Security;

namespace Archives
{
public static class Extensions
{
	public static string GetDescription(this SecStatusCode code)
	{
		string description = string.Empty;
		switch (code)
		{
			case SecStatusCode.Success:
				description = "Sucess!";
				break;
			case SecStatusCode.DuplicateItem:
				description = "Item already exists!";
				break;
			case SecStatusCode.ItemNotFound:
				description = "Item not found!";
				break;
			case SecStatusCode.AuthFailed:
				description = "Authentication failed!";
				break;
			default:
				description = code.ToString();
				break;
		}

		return description;
	}	}
}