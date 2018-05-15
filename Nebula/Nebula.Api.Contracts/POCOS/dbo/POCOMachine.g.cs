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
			string description,
			int id,
			string jwtKey,
			string lastIpAddress,
			Guid machineGuid,
			string name)
		{
			this.Description = description;
			this.Id = id.ToInt();
			this.JwtKey = jwtKey;
			this.LastIpAddress = lastIpAddress;
			this.MachineGuid = machineGuid.ToGuid();
			this.Name = name;
		}

		public string Description { get; set; }
		public int Id { get; set; }
		public string JwtKey { get; set; }
		public string LastIpAddress { get; set; }
		public Guid MachineGuid { get; set; }
		public string Name { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
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
		public bool ShouldSerializeMachineGuidValue { get; set; } = true;

		public bool ShouldSerializeMachineGuid()
		{
			return this.ShouldSerializeMachineGuidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeJwtKeyValue = false;
			this.ShouldSerializeLastIpAddressValue = false;
			this.ShouldSerializeMachineGuidValue = false;
			this.ShouldSerializeNameValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>d3f0ca44503b1a9ece04d381f699f5a7</Hash>
</Codenesium>*/