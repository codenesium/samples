using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Services
{
	public partial class BOMachineRefTeam: AbstractBusinessObject
	{
		public BOMachineRefTeam() : base()
		{}

		public void SetProperties(int id,
		                          int machineId,
		                          int teamId)
		{
			this.Id = id.ToInt();
			this.MachineId = machineId.ToInt();
			this.TeamId = teamId.ToInt();
		}

		public int Id { get; private set; }
		public int MachineId { get; private set; }
		public int TeamId { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a34aa7249dd613b87c152123a6662f94</Hash>
</Codenesium>*/