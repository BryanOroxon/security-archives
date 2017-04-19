using System;
namespace Archives.Models
{
	public class SecurityFeature
	{
		public SecurityFeature(string name, bool selected, bool enabled)
		{
			Name = name;
			Selected = selected;
			Enabled = enabled;
		}

		public string Name { get; set; }
		public bool Selected { get; set; }
		public bool Enabled { get; set; }
	}
}
