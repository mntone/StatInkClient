using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public sealed class Battle
	{
		[DataMember(Name = "id", IsRequired = true)]
		public ulong Id { get; private set; }

		[DataMember(Name = "url")]
		public Uri BattlePageUrl { get; private set; }

		[DataMember(Name = "lobby")]
		public KeyName Lobby { get; private set; }

		[DataMember(Name = "rule")]
		public Rule Rule { get; private set; }

		[DataMember(Name = "map")]
		public Map Map { get; private set; }

		[DataMember(Name = "weapon")]
		public Weapon Weapon { get; private set; }

		[DataMember(Name = "rank")]
		public KeyName Rank { get; private set; }

		[DataMember(Name = "rank_exp")]
		public ushort? RankExperience { get; private set; }

		[DataMember(Name = "rank_after")]
		public KeyName RankAfter { get; private set; }

		[DataMember(Name = "rank_exp_after")]
		public ushort? RankExperienceAfter { get; private set; }

		[DataMember(Name = "level")]
		public ushort? Level { get; private set; }

		[DataMember(Name = "level_after")]
		public ushort? LevelAfter { get; private set; }

		[DataMember(Name = "cash")]
		public uint? Cash { get; private set; }

		[DataMember(Name = "cash_after")]
		public uint? CashAfter { get; private set; }

		[DataMember(Name = "result")]
		public string Result { get; private set; }

		[DataMember(Name = "rank_in_team")]
		public ushort? RankInTeam { get; private set; }

		[DataMember(Name = "kill")]
		public ushort? KillCount { get; private set; }

		[DataMember(Name = "death")]
		public ushort? DeathCount { get; private set; }

		[DataMember(Name = "kill_ratio")]
		public float? KillRatio { get; private set; }

		[DataMember(Name = "death_reasons")]
		public DeathReason[] DeathReasons { get; private set; }

		[DataMember(Name = "gender")]
		public Gender Gender { get; private set; }

		[DataMember(Name = "fest_title")]
		public KeyName SplatfestPosition { get; private set; }

		[DataMember(Name = "fest_exp")]
		public ushort? SplatfestExperience { get; private set; }

		[DataMember(Name = "fest_title_after")]
		public KeyName SplatfestPositionAfter { get; private set; }

		[DataMember(Name = "fest_exp_after")]
		public ushort? SplatfestExperienceAfter { get; private set; }

		[DataMember(Name = "my_team_final_point")]
		public ushort? OurTeamFinalPoint { get; private set; }

		[DataMember(Name = "his_team_final_point")]
		public ushort? TheirTeamFinalPoint { get; private set; }

		[DataMember(Name = "my_team_final_percent")]
		public float? OurTeamFinalPercent { get; private set; }

		[DataMember(Name = "his_team_final_percent")]
		public float? YourTeamFinalPercent { get; private set; }

		[DataMember(Name = "knock_out")]
		public bool? Knockout { get; private set; }

		[DataMember(Name = "my_team_count")]
		public ushort? OurTeamCount { get; private set; }

		[DataMember(Name = "his_team_count")]
		public ushort? YourTeamCount { get; private set; }

		[DataMember(Name = "my_team_color")]
		public Color OurTeamColor { get; private set; }

		[DataMember(Name = "his_team_color")]
		public Color YourTeamColor { get; private set; }

		[DataMember(Name = "image_judge")]
		public Uri JudgeImageUrl { get; private set; }

		[DataMember(Name = "image_result")]
		public Uri ResultImageUrl { get; private set; }

		[DataMember(Name = "gears")]
		public Gears Gears { get; private set; }

		[DataMember(Name = "period")]
		public uint Period { get; private set; }

		[DataMember(Name = "players")]
		public BattlePlayer[] Players { get; private set; }

		[DataMember(Name = "events")]
		public Dictionary<string, object>[] Events { get; private set; }

		[DataMember(Name = "agent")]
		public Agent Agent { get; private set; }

		[DataMember(Name = "automated")]
		public bool IsAutomated { get; private set; }

		[DataMember(Name = "environment")]
		public string Environment { get; private set; }

		[DataMember(Name = "start_at")]
		public DateTime StartedAt { get; private set; }

		[DataMember(Name = "end_at")]
		public DateTime EndedAt { get; private set; }

		[DataMember(Name = "register_at")]
		public DateTime RegistereredAt { get; private set; }
	}

	[DataContract]
	public sealed class Rule : KeyName
	{
		[DataMember(Name = "mode")]
		public KeyName Mode { get; private set; }
	}

	[DataContract]
	public sealed class Map : KeyName
	{
		[DataMember(Name = "area")]
		public ushort? Area { get; private set; }

		[DataMember(Name = "release_at")]
		public DateTime ReleasedAt { get; private set; }
	}

	[DataContract]
	public sealed class Weapon : KeyName
	{
		[DataMember(Name = "type")]
		public KeyName Type { get; private set; }

		[DataMember(Name = "sub")]
		public KeyName Sub { get; private set; }

		[DataMember(Name = "special")]
		public KeyName Special { get; private set; }
	}

	[DataContract]
	public sealed class DeathReason
	{
		[DataMember(Name = "reason")]
		public Reason Reason { get; private set; }

		[DataMember(Name = "count")]
		public ushort Count { get; private set; }
	}

	[DataContract]
	public sealed class Reason : KeyName
	{
		[DataMember(Name = "type")]
		public KeyName Type { get; private set; }
	}

	[DataContract]
	public sealed class Gender : KeyName
	{
		[DataMember(Name = "iso5218")]
		public ushort Iso5218 { get; private set; }
	}

	[DataContract]
	public sealed class BattlePlayer
	{
		[DataMember(Name = "team")]
		public string Team { get; private set; }

		[DataMember(Name = "is_me")]
		public bool IsMe { get; private set; }

		[DataMember(Name = "weapon")]
		public Weapon Weapon { get; private set; }

		[DataMember(Name = "rank")]
		public KeyName Rank { get; private set; }

		[DataMember(Name = "level")]
		public ushort? Level { get; private set; }

		[DataMember(Name = "rank_in_team")]
		public ushort? RankInTeam { get; private set; }

		[DataMember(Name = "kill")]
		public ushort? KillCount { get; private set; }

		[DataMember(Name = "death")]
		public ushort? DeathCount { get; private set; }

		[DataMember(Name = "point")]
		public ushort? Points { get; private set; }
	}

	[DataContract]
	public sealed class Agent
	{
		[DataMember(Name = "name")]
		public string Name { get; private set; }

		[DataMember(Name = "version")]
		public string Version { get; private set; }

		[DataMember(Name = "custom")]
		public string Custom { get; private set; }
	}
}