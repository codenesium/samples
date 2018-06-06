using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
	public partial class BOMachine: AbstractBusinessObject
	{
		public BOMachine() : base()
		{}

		public void SetProperties(int id,
		                          string description,
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

		public string Description { get; private set; }
		public int Id { get; private set; }
		public string JwtKey { get; private set; }
		public string LastIpAddress { get; private set; }
		public Guid MachineGuid { get; private set; }
		public string Name { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d29bbc6aa0b24ab5f3b5cd5c3415c202</Hash>
</Codenesium>*/