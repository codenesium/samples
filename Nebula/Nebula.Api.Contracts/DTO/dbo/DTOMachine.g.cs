using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOMachine: AbstractDTO
	{
		public DTOMachine() : base()
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

		public string Description { get; set; }
		public int Id { get; set; }
		public string JwtKey { get; set; }
		public string LastIpAddress { get; set; }
		public Guid MachineGuid { get; set; }
		public string Name { get; set; }
	}
}

/*<Codenesium>
    <Hash>4ad0e4401ce5761fb2373ae362d63e1e</Hash>
</Codenesium>*/