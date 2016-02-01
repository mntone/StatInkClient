using System.Runtime.Serialization;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public sealed class Statistics
	{
		[DataMember(Name = "entire")]
		public EntireStatistics Entire { get; private set; }

		[DataMember(Name = "nawabari")]
		public RegularStatistics Regular { get; private set; }

		[DataMember(Name = "gachi")]
		public RankedStatistics Ranked { get; private set; }
	}

	public abstract class StatisticsBase
	{
		[DataMember(Name = "battle_count")]
		public ulong BattleCount { get; private set; }

		[DataMember(Name = "wp")]
		public float WinningPercentage { get; private set; }

		[DataMember(Name = "kill")]
		public ulong KillCount { get; private set; }

		[DataMember(Name = "death")]
		public ulong DeathCount { get; private set; }
	}

	[DataContract]
	public sealed class EntireStatistics : StatisticsBase
	{
		[DataMember(Name = "wp_24h")]
		public float WinningPercentageInADay { get; private set; }

		[DataMember(Name = "kd_available_battle")]
		public ulong KdCountAvailableBattleCount { get; private set; }
	}

	[DataContract]
	public sealed class RegularStatistics : StatisticsBase
	{ }

	[DataContract]
	public sealed class RankedStatistics : StatisticsBase
	{ }
}
