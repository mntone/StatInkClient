using System.Runtime.Serialization;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public sealed class DateTime
	{
		[DataMember(Name = "iso8601")]
		public System.DateTime Value { get; private set; }
	}
}