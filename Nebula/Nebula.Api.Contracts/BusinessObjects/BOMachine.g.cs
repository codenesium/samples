using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
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
    <Hash>489c4ea65ed3b244559568fb12d8cab4</Hash>
</Codenesium>*/