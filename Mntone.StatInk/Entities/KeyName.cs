using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mntone.StatInk.Entities
{
	[DataContract]
	public class KeyName
	{
		[DataMember(Name = "key", IsRequired = true)]
		public string Key { get; private set; }

		// Comment out if you use name resources.
		//[DataMember(Name = "name", IsRequired = true)]
		//public Dictionary<string, string> Name { get; private set; }
	}
}