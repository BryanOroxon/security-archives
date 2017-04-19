using System;
namespace Archives.Models
{
	public class Setting
	{
		public Setting(string identifier, string name, string targetviewcontroller)
		{
			Identifier = identifier;
			Name = name;
			TargetViewController = targetviewcontroller;
		}

		public string Identifier
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string TargetViewController
		{
			get;
			set;
		}
	}
}
