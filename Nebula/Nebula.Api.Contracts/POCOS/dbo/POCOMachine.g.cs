using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOMachine
	{
		public POCOMachine()
		{}

		public POCOMachine(
			int id,
			string name,
			Guid machineGuid,
			string jwtKey,
			string lastIpAddress,
			string description)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.MachineGuid = machineGuid.ToGuid();
			this.JwtKey = jwtKey.ToString();
			this.LastIpAddress = lastIpAddress.ToString();
			this.Description = description.ToString();
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public Guid MachineGuid { get; set; }
		public string JwtKey { get; set; }
		public string LastIpAddress { get; set; }
		public string Description { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMachineGuidValue { get; set; } = true;

		public bool ShouldSerializeMachineGuid()
		{
			return this.ShouldSerializeMachineGuidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeJwtKeyValue { get; set; } = true;

		public bool ShouldSerializeJwtKey()
		{
			return this.ShouldSerializeJwtKeyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLastIpAddressValue { get; set; } = true;

		public bool ShouldSerializeLastIpAddress()
		{
			return this.ShouldSerializeLastIpAddressValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeMachineGuidValue = false;
			this.ShouldSerializeJwtKeyValue = false;
			this.ShouldSerializeLastIpAddressValue = false;
			this.ShouldSerializeDescriptionValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d09bc608ccabbd4052346f1fc211554f</Hash>
</Codenesium>*/