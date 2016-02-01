using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public sealed class Gears
	{
		[DataMember(Name = "headgear")]
		public EachGear Head { get; private set; }

		[DataMember(Name = "clothing")]
		public EachGear Clothes { get; private set; }

		[DataMember(Name = "shoes")]
		public EachGear Shoes { get; private set; }
	}

	[DataContract]
	public sealed class EachGear : KeyName
	{
		[DataMember(Name = "gear")]
		public Gear Gear { get; private set; }

		[DataMember(Name = "primary_ability")]
		public KeyName PrimaryAbility { get; private set; }

		[DataMember(Name = "secondary_abilities")]
		public KeyName[] SecondaryAbilities { get; private set; }
	}

	[DataContract]
	public sealed class Gear : KeyName
	{
		[DataMember(Name = "brand")]
		public Brand Brand { get; private set; }

		[DataMember(Name = "primary_ability")]
		public KeyName PrimaryAbility { get; private set; }
	}

	[DataContract]
	public sealed class Brand : KeyName
	{
		[DataMember(Name = "strength")]
		public KeyName Strength { get; private set; }
		
		[DataMember(Name = "weakness")]
		public KeyName Weakness { get; private set; }
	}
}