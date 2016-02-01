using System.Runtime.Serialization;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public sealed class User
	{
		[DataMember(Name = "id")]
		public ulong Id { get; private set; }

		[DataMember(Name = "name")]
		public string Name { get; private set; }

		[DataMember(Name = "screen_name")]
		public string ScreenName { get; private set; }

		[DataMember(Name = "join_at")]
		public DateTime JoinedAt { get; private set; }

		[DataMember(Name = "profile")]
		public Profile Profile { get; private set; }

		[DataMember(Name = "stat")]
		public Statistics Stat { get; private set; }
	}

	[DataContract]
	public sealed class Profile
	{
		[DataMember(Name = "nnid")]
		public string Nnid { get; private set; }

		[DataMember(Name = "twitter")]
		public string Twitter { get; private set; }

		[DataMember(Name = "ikanakama")]
		public ulong? IkaNakama { get; private set; }

		[DataMember(Name = "eneironment")]
		public string Environment { get; private set; }
	}
}