using System.Runtime.Serialization;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public sealed class Color
	{
		[DataMember(Name = "hue")]
		public ushort Hue { get; private set; }

		[DataMember(Name = "rgb")]
		public string Rgb { get; private set; }
	}
}