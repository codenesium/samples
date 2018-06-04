using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
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
    <Hash>2db6774dff2a933a25686ef2ecada95e</Hash>
</Codenesium>*/