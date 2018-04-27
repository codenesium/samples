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
			this.Description = description.ToString();
			this.Id = id.ToInt();
			this.JwtKey = jwtKey.ToString();
			this.LastIpAddress = lastIpAddress.ToString();
			this.MachineGuid = machineGuid.ToGuid();
			this.Name = name.ToString();
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
    <Hash>88e5bdfbc2d4872482c9e90e520220a7</Hash>
</Codenesium>*/